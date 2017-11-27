using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour, IWeapon
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
    private double chargePercent;
    private float chargeAmount;
    private bool countCharge;
    private float cdPercent;

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
        countCharge = true;
    }
    public void Fire()
    {
        if (!onCd)
        {
            double chargeTime = Time.time - chargeStart;
            chargePercent = chargeTime / timeToMaxCharge * 100;
            charge = (float)maxCharge / 100 * (float)chargePercent;

            if (charge > maxCharge)
            {
                charge = maxCharge;
            }
            if (charge < minCharge)
            {
                charge = minCharge;
            }
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
        countCharge = false;
        chargeAmount = 0;
    }

    public float GetCharge()
    {
        return chargeAmount;
    }
    public float GetCd()
    {
        return cdPercent;
    }
    public string GetName()
    {
        return gameObject.name;
    }

    // Update is called once per frame
    void FixedUpdate () {
        if(countCharge)
        {
            double chargeTime = Time.time - chargeStart;
            double chargePercent = chargeTime / timeToMaxCharge * 100;
            float charge = (float)maxCharge / 100 * (float)chargePercent;

            if (charge > maxCharge)
            {
                charge = maxCharge;
            }
            chargeAmount = charge / maxCharge * 100;
        }
        if(timeStamp <= Time.time)
        {
            onCd = false;
            cdPercent = 0;
        }
        if(onCd)
        {
            float cd = Mathf.Abs((float)timeStamp - (float)Time.time);
            cdPercent = cd / (float)cdAmount * 100;
        }
    }
}
