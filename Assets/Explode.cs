using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
   public GameObject explosion;
    private double startTime;
	// Use this for initialization
	void Start ()
    {
        Debug.Log("start");
        startTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {

	}

    void OnCollisionEnter (Collision col)
    {
        explode();
    }

    private void explode()
    {
        var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject, 0); // destroy the grenade
    }
}
