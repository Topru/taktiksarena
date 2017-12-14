using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GameManagement;

public class ButtonManager : MonoBehaviour {

    private MenuManager menuManager;
    public GameObject moon;
    public GameObject desert;

    private void Start()
    {
        if (GameObject.Find("MenuManager") != null)
        {
            menuManager = GameObject.Find("MenuManager").GetComponent<MenuManager>();
        }
    }

    public void NewGameBtn()
    {
        menuManager.NewGameMenu();
    }
    public void QuitBtn()
    {
        Application.Quit();
    }
    public void CreditsBtn()
    {
        menuManager.CreditsMenu();
    }
    public void BackBtn()
    {
        menuManager.MainMenu();
    }
    public void SelectMap(string mapName)
    {
        menuManager.previewImage.SetActive(true);
        menuManager.startButton.GetComponent<Button>().interactable = true;
        if (mapName == "moon")
        {
            menuManager.previewImage.GetComponent<Image>().sprite = menuManager.moonPreview;
            LevelManager.SetSelectedLevel(moon);
        }
        if (mapName == "desert")
        {
            menuManager.previewImage.GetComponent<Image>().sprite = menuManager.desertPreview;
            LevelManager.SetSelectedLevel(desert);
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("main");
    }

    public void SetTimeLimit()
    {
        menuManager.timeLimitText.GetComponent<Text>().text = menuManager.timeLimit.GetComponent<Slider>().value.ToString();
        LevelManager.SetTimeLimit(menuManager.timeLimit.GetComponent<Slider>().value);
    }

    public void SetKillLimit()
    {
        menuManager.killLimitText.GetComponent<Text>().text = menuManager.killLimit.GetComponent<Slider>().value.ToString();
        LevelManager.SetKillLimit(menuManager.killLimit.GetComponent<Slider>().value);
    }

    public void ExitBtn()
    {
        SceneManager.LoadScene("menu");
        Time.timeScale = 1f;
    }
    public void ResumeBtn()
    {
        GameObject gameManager = GameObject.Find("GameController");
        if (gameManager != null) {
            gameManager.GetComponent<GameController>().TogglePause();
        }
    }
}
