using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CameraFollow : MonoBehaviour {
    public GameObject player;
    public float cameraHeight = 20.0f;
    public GameController gameController;
    // Use this for initialization
    void Start() {
        gameController = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        player = gameController.GetLocalPlayer();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = player.transform.position;
        pos.y += cameraHeight;
        transform.position = pos;
    }
}
