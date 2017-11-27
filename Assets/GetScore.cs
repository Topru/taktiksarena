using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetScore : MonoBehaviour
{
    private GameObject player;
    private Text text;
    private GameController gameController;

    // Use this for initialization
    void Start()
    {
        string playerTag;
        if (gameObject.transform.parent.tag == "Player1UI")
        {
            playerTag = "Player1";
        }
        else
        {
            playerTag = "Player2";
        }
        player = GameObject.FindGameObjectWithTag(playerTag);
        text = gameObject.GetComponent<Text>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        int score = 0;
        if (player.tag == "Player1")
        {
            score = (int)gameController.GetPlayer1Score();
        }
        else
        {
            score = (int)gameController.GetPlayer2Score();
        }
        text.text = score.ToString();
    }
}
