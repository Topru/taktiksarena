using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : WeaponMaster
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public double timeToMaxCharge;
    public float minCharge;
    public float maxCharge;
    private double chargeStart;
    private float charge;
    private double chargePercent;
    private float chargeAmount;
    private bool countCharge;

    public override void Charge()
    {
        chargeStart = Time.time;
        countCharge = true;
    }
    public override void Fire()
    {
        shootClip.Play();
        Debug.Log(shootClip.isPlaying);
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

    public override float GetCharge()
    {
        return chargeAmount;
    }

    // Update is called once per frame
    public override void FixedUpdate () {
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
        base.FixedUpdate();
    }
}
