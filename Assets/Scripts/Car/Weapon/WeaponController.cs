using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject bulletPrefab;
    public GameObject explosion;
    public Transform bulletSpawn;
    public double timeToMaxCharge;
    public float minCharge;
    public float maxCharge;
    public double cdAmount;
    private double timeStamp = 0; //cooldown
    private double chargeStart;
    private float charge;
    private bool onCd;

    // Use this for initialization
    void Start () {
		
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
                bulletSpawn.rotation);
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * charge;
            timeStamp = Time.time + cdAmount;
        }
        onCd = true;
    }

    private void explode()
    {
        var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject); // destroy the grenade
        Destroy(expl, (float)0.5);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
