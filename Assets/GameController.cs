using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int player1Score;
    public int player2Score;
    public GameObject localPlayer;
    public GameObject camera;

    public GameObject[] weaponList;

	// Use this for initialization
	void Start () {
        player1Score = 0;
        player2Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLocalPlayer(GameObject player)
    {
        camera.SetActive(true);
        localPlayer = player;
    }
    public GameObject GetLocalPlayer()
    {
        return localPlayer;
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

    public GameObject GetWeapon(int index)
    {
        GameObject weapon = weaponList[index];
        return weapon;
    }
}
