using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPointAt : MonoBehaviour {
   
    public float speed;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per fram
    public Vector3 offset; 
	void Update () {
        Camera camera = gameObject.GetComponent<Camera>();

        transform.Translate(Vector3.right * Time.deltaTime * speed);
        gameObject.transform.LookAt(GameObject.Find("Center").transform.position);
        
        //Debug.Log("Player1loc: " + player1loc);
        //Debug.Log("Player2loc: " + player2loc);

    }
}
