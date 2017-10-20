using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public int bulletSpeed;
    private double timeStamp = 0; //cooldown
    public double cdAmount;
    // Use this for initialization
    void Start () {
		
	}
    public void Fire()
    {
        Debug.Log("fire!");
        if (timeStamp <= Time.time)
        {
            // Create the Bullet from the Bullet Prefab
            var bullet = (GameObject)Instantiate(
                bulletPrefab,
                bulletSpawn.position,
                bulletSpawn.rotation);
            // Add velocity to the bullet
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
            timeStamp = Time.time + cdAmount;
        }
    }

    private void explode()
    {
        //var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject); // destroy the grenade
       // Destroy(expl, (float)0.5);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
