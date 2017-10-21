using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour {

    public int maxHealth;
    public int currentHealth;
    public int maxArmor;
    public int currentArmor;
    public GameObject explosion;

	// Use this for initialization
	void Start () {
        currentHealth = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
        if(currentHealth <= 0)
        {
            Explode();
        }
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentArmor > maxArmor)
        {
            currentArmor = maxArmor;
        }
    }

    public void ApplyDamage(int damage)
    {
        currentArmor = currentArmor - damage;
        if(currentArmor < 0)
        {
            currentHealth = currentHealth + currentArmor;
            currentArmor = 0;
        }
    }

    private void Explode()
    {
        var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject); // destroy the grenade
        Destroy(expl, (float)0.5);
    }
}
