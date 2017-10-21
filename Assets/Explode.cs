using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {
   public GameObject explosion;
	// Use this for initialization
	void Start () {
        Debug.Log("start");
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter (Collision col)
    {
        explode();
    }

    private void explode()
    {
        var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject); // destroy the grenade
        Destroy(expl, (float)0.5);
    }
}
