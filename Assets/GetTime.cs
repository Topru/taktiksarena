using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTime : MonoBehaviour {

    private Text text;
    private GameController gameController;

	// Use this for initialization
	void Start () {
        text = gameObject.GetComponent<Text>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
	}
	
	// Update is called once per frame
	void Update () {
        int time = (int)gameController.GetTimeLeft();
        text.text = time.ToString();
	}
}
