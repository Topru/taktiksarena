using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using Helpers;

public class DamageController : NetworkBehaviour {

    public int maxHealth;
    public int currentHealth;
    public int maxArmor;
    public int currentArmor;
    public GameController gameController;
    public GameObject explosion;
    public GameObject nextSpawn;
    public GameObject lastSpawn;
    private GameObject[] spawnList;
    private GameObject enemy;
    public GameObject weapon = null;
    // Use this for initialization
    void Start () {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        if (isLocalPlayer)
        {
            Debug.Log("local!");
            gameController.SetLocalPlayer(gameObject);
        }
        Debug.Log("car spawned");
        currentHealth = maxHealth;
        spawnList = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        if (gameObject.tag == "Player1")
        {
            enemy = GameObject.FindGameObjectWithTag("Player2");
        }
        if (gameObject.tag == "Player2")
        {
            enemy = GameObject.FindGameObjectWithTag("Player1");
        }
        lastSpawn = null;
        Respawn();
    }
	
	// Update is called once per frame
	void Update () {
        if(currentHealth <= 0)
        {
            Explode();
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentArmor > maxArmor)
        {
            currentArmor = maxArmor;
        }
    }

    public void ApplyDamage(int damage)
    {
        currentArmor = currentArmor - damage;
        if(currentArmor < 0)
        {
            currentHealth = currentHealth + currentArmor;
            currentArmor = 0;
        }
    }

    private void Explode()
    {
        gameController.AddScore(enemy.tag, 1);
        var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(expl, (float)0.5);
        
        Respawn();
    }

    private void Respawn()
    {
        if (isLocalPlayer)
        {
            GetWeapon();
        }
        GameObject lastSpawn = nextSpawn;
        int randomSpawn = Random.Range(0, spawnList.Length);
        nextSpawn = spawnList[randomSpawn];
        gameObject.transform.position = nextSpawn.transform.position;
        gameObject.transform.LookAt(GameObject.Find("Center").transform);
        currentHealth = maxHealth;
        currentArmor = 0;
    }
    private void GetWeapon()
    {
        Debug.Log("weapon!");

        GameObject oldWeapon = gameObject.FindChildrenWithTag("Weapon");
        GameObject weapon = oldWeapon;
        Destroy(oldWeapon);
        int index = 0;
        while (weapon == oldWeapon)
        {
            index = Random.Range(0, gameController.weaponList.Length);
            weapon = gameController.GetWeapon(index);
        }
        Debug.Log(weapon.name);
        //GameObject spawnWeapon = Instantiate(weapon, gameObject.transform);
        CmdSpawn(index, gameObject);
    }
    [Command]
    private void CmdSpawn(int index, GameObject g)
    {
        Debug.Log(g.name);
        weapon = Instantiate(gameController.GetWeapon(index), gameObject.transform);
        weapon.transform.parent = g.transform;
        if (isServer)
        {
            NetworkServer.Spawn(weapon);
        }
        else if (isClient)
        {
            NetworkServer.SpawnWithClientAuthority(weapon, base.connectionToClient);
        }
        //clone.transform.parent = gameObject.transform;
        RpcSyncSpawn(weapon.transform.localPosition, weapon.transform.transform.localRotation, weapon, g);
        weapon.GetComponent<GunController>().parentId = gameObject.GetComponent<NetworkIdentity>().netId;
    }
    [ClientRpc]
    protected void RpcSyncSpawn(Vector3 localPos, Quaternion localRot, GameObject weapon, GameObject parent)
    {
        weapon.transform.parent = parent.transform;
        weapon.transform.localPosition = localPos;
        weapon.transform.localRotation = localRot;
    }
    public override void OnStartClient()
    {
        Debug.Log("testings");
        GameObject oldWeapon = GameObject.FindGameObjectWithTag("Weapon");
        GameObject parent = ClientScene.FindLocalObject(oldWeapon.GetComponent<GunController>().parentId);
        oldWeapon.transform.parent = parent.transform;
    }
}
