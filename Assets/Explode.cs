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


        for (int i = 1; i < 3; i++)
        {
            GameObject p = GameObject.FindWithTag("Player"+i);
            if (p!=null)
            {
                if (Vector3.Distance(p.transform.position,transform.position) < 3f)
                {
                    p.GetComponent<DamageController>().ApplyDamage(100);
                }
              
            }
        }
        


      
     



        explode();

    }

    private void explode()
    {
        var expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject, 0); // destroy the grenade
 
    }
}
