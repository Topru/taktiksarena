using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GameManagement;

public class GameController : MonoBehaviour {

    public GameObject pauseMenu;
    public GameObject winnerText;
    public GameObject winnerTextTwo;
    public GameObject resumeBtn;
    public int player1Score;
    public int player2Score;
    public int gameTime;
    public int scoreLimit;
    public float timeLeft;

    private float endTime;
    private bool ended;

    public GameObject[] weaponList;

    void Awake()
    {
        GameObject level = LevelManager.GetSelectedLevel();
        Instantiate(level);
        pauseMenu.SetActive(false);
        winnerText.SetActive(false);
        winnerTextTwo.SetActive(false);
    }

    // Use this for initialization
    void Start () {

        scoreLimit = (int)LevelManager.GetKillLimit();
        gameTime = (int)LevelManager.GetTimeLimit() * 60;
        player1Score = 0;
        player2Score = 0;
        ended = false;
        endTime = Time.time + gameTime;
        
	}
	
	// Update is called once per frame
	void Update () {
        if(ended)
        {
            return;
        }
        timeLeft = endTime - Time.time;
        if(timeLeft <= 0)
        {
            EndGame();
        }
        if(player1Score >= scoreLimit || player2Score >= scoreLimit)
        {
            EndGame();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }

    }

    void EndGame()
    {
        ended = true;
        string winner;
        if(player1Score > player2Score)
        {
            winner = "Player1";
        } else if(player1Score < player2Score)
        {
            winner = "Player2";
        } else
        {
            winner = "IT'S TIE!";
        }
        TogglePause();
        winnerText.SetActive(true);
        winnerTextTwo.SetActive(true);
        winnerTextTwo.GetComponent<Text>().text = winner;
        resumeBtn.SetActive(false);
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

    public void TogglePause()
    {
        if (!pauseMenu.active)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        } else
        {
            Time.timeScale = 1.0f;
            pauseMenu.SetActive(false);
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

    public float GetTimeLeft()
    {
        return timeLeft;
    }
    public int GetPlayer1Score()
    {
        return player1Score;
    }
    public int GetPlayer2Score()
    {
        return player2Score;
    }
}
