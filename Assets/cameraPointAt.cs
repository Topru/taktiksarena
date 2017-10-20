using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPointAt : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject player1 = GameObject.FindWithTag("Player1");
        GameObject player2 = GameObject.FindWithTag("Player2");

        UnityEngine.Vector3 player1loc = player1.transform.position;
        UnityEngine.Vector3 player2loc = player2.transform.position;

        float cameraLookX = player1loc.x + (player2loc.x - player1loc.x) / 2;
        float cameraLookZ = player1loc.z + (player2loc.z - player1loc.z) / 2;
        float cameraLookY = player1loc.y + (player2loc.y - player1loc.y) / 2;

        gameObject.transform.LookAt(new UnityEngine.Vector3(cameraLookX, cameraLookY, cameraLookZ));
        
        //Debug.Log("Player1loc: " + player1loc);
        //Debug.Log("Player2loc: " + player2loc);

    }
}
