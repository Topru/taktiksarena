using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public float damagePerDistance;
    public float radius;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnParticleCollision(GameObject collision)
    {
        ApplyDamage(collision);
    }
    void ApplyDamage(GameObject collision)
    {
        GameObject p = collision.gameObject;
        if(p.tag == "Player1" || p.tag == "Player2") {
            Vector3 closestPoint = p.GetComponent<Rigidbody>().ClosestPointOnBounds(transform.position);
            float distance = Vector3.Distance(closestPoint, transform.position);
            float damage = damagePerDistance * (1.0F - Mathf.Clamp01(distance / radius));
            int intDamage = (int)damage;
            p.GetComponent<DamageController>().ApplyDamage(intDamage);
        }
    }
}
