using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GunController : NetworkBehaviour, IWeapon
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public double timeToMaxCharge;
    public float minCharge;
    public float maxCharge;
    public double cdAmount;
    private double timeStamp = 0; //cooldown
    private double chargeStart;
    private float charge;
    private bool onCd;
    public int parentIdShow;
    [SyncVar(hook = "CallbackSetOwner")]
    public NetworkInstanceId parentId;

    private WeaponControl weaponControl;

    // Use this for initialization
    void Start () {
        weaponControl = gameObject.transform.parent.gameObject.GetComponent<WeaponControl>();
        weaponControl.Switched(this);
        //gameObject.transform.position = gameObject.transform.parent.Find("GunPosition").transform.position;
    }
    public void Charge()
    {
        if (timeStamp <= Time.time)
        {
            onCd = false;
        }
        chargeStart = Time.time;
    }
    public void Fire()
    {
        if (!onCd)
        {
            double chargeTime = Time.time - chargeStart;
            double chargePercent = chargeTime / timeToMaxCharge * 100;
            charge = (float)maxCharge / 100 * (float)chargePercent;

            if (charge > maxCharge)
            {
                charge = maxCharge;
            }
            if (charge < minCharge)
            {
                charge = minCharge;
            }
            Debug.Log(charge);
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation, gameObject.transform);
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * charge;
            timeStamp = Time.time + cdAmount;
        }
        onCd = true;
    }
    void CallbackSetOwner(NetworkInstanceId parentId)
    {
        Debug.Log("asddsa");
        Debug.Log(parentId);
        GameObject parent = ClientScene.FindLocalObject(parentId);
        gameObject.transform.parent = parent.transform;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
