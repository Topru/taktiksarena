using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetHealth : MonoBehaviour {

    private GameObject player;
    private Slider slider;
	// Use this for initialization
	void Start () {
        string playerTag;
        if (gameObject.transform.parent.transform.parent.tag == "Player1UI")
        {
            playerTag = "Player1";
        }
        else { 
            playerTag = "Player2";
        }
        player = GameObject.FindGameObjectWithTag(playerTag);
        slider = gameObject.GetComponent<Slider>();
	}
	
	// Update is called once per frame
	void Update () {
        int hp = player.GetComponent<DamageController>().GetHealth();
        slider.value = hp;
	}
}
