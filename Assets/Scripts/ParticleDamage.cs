using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDamage : MonoBehaviour {

    public int damagePerParticle;
    private GameObject target;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnParticleCollision(GameObject collider)
    {
        if(collider.tag == "Player1" || collider.tag == "Player2")
        {
            target = collider;
            target.GetComponent<DamageController>().ApplyDamage(damagePerParticle);
        }
    }
}
