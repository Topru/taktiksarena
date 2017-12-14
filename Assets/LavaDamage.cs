using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        GameObject collider = collision.gameObject;

        if (collider.tag == "Player1" || collider.tag == "Player2")
        {
            collider.GetComponent<DamageController>().ApplyDamage(999);
        }
    }
}
