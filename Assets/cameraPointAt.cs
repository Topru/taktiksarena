using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraPointAt : MonoBehaviour {
   
    public float zoomFactor;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per fram
    public Vector3 offset; 
	void Update () {
        Camera camera = gameObject.GetComponent<Camera>();

        GameObject player1 = GameObject.FindWithTag("Player1");
        GameObject player2 = GameObject.FindWithTag("Player2");

        UnityEngine.Vector3 player1loc = player1.transform.position;
        UnityEngine.Vector3 player2loc = player2.transform.position;

        float distance = Vector3.Distance(player1loc, player2loc);


        float cameraFov = 20f + distance * 1.0f;
        if(cameraFov > 70)
        {
            cameraFov = 70;
        }
        camera.fieldOfView = cameraFov;
        float cameraLookX = player1loc.x + (player2loc.x - player1loc.x) / 2;
        float cameraLookZ = player1loc.z + (player2loc.z - player1loc.z) / 2;
        float cameraLookY = player1loc.y + (player2loc.y - player1loc.y) / 2;


        camera.transform.position = Vector3.Lerp(player1loc, player2loc, 0.5f) + new Vector3(0f, 130f, 0);
        gameObject.transform.LookAt(new UnityEngine.Vector3(cameraLookX, cameraLookY, cameraLookZ)+offset);
        
        //Debug.Log("Player1loc: " + player1loc);
        //Debug.Log("Player2loc: " + player2loc);

    }
}
