using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {
    public float damagePerDistance;

	// Use this for initialization
	void Start () {
        ApplyDamage();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void ApplyDamage()
    {
        for (int i = 1; i < 3; i++)
        {
            GameObject p = GameObject.FindWithTag("Player" + i);
            if (p != null)
            {
                float distance = Vector3.Distance(p.transform.position, transform.position);
                if (distance < 3.5f)
                {
                    float damage = (3.5f - distance) * damagePerDistance;
                    int intDamage = (int)damage;
                    Debug.Log(intDamage);
                    p.GetComponent<DamageController>().ApplyDamage(intDamage);
                }

            }
        }
    }
}
