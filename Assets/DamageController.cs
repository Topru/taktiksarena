using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public int maxArmor;
    public int currentArmor;
    public GameObject explosion;
    public GameObject nextSpawn;
    public GameObject lastSpawn;
    private GameObject[] spawnList;
    private GameObject enemy;
    // Use this for initialization
    void Start () {
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
        var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(expl, (float)0.5);
        
        Respawn();
    }

    private void Respawn()
    {
        GameObject lastSpawn = nextSpawn;
        GameObject enemyNextSpaw = enemy.GetComponent<DamageController>().nextSpawn;
        while(nextSpawn == lastSpawn || nextSpawn == enemyNextSpaw)
        {
            int randomSpawn = Random.Range(0, spawnList.Length);
            nextSpawn = spawnList[randomSpawn];
        }
        gameObject.transform.position = nextSpawn.transform.position;
        gameObject.transform.LookAt(GameObject.Find("Center").transform);
        currentHealth = maxHealth;
        currentArmor = 0;
    }
}
