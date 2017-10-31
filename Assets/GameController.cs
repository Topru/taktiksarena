﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int player1Score;
    public int player2Score;

    public GameObject[] weaponList;

	// Use this for initialization
	void Start () {
        player1Score = 0;
        player2Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddScore(string player, int score)
    {
        if(player == "Player1")
        {
            player1Score += score;
        }
        if (player == "Player2")
        {
            player2Score += score;
        }
    }

    public GameObject GetWeapon(GameObject lastWeapon)
    {
        GameObject weapon = lastWeapon;
        while(weapon == lastWeapon)
        {
            int index = Random.Range(0, weaponList.Length);
            weapon = weaponList[index];
        }
        return weapon;
    }
}
