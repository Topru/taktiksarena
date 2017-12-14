using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    [Header("Menus")]
    public GameObject mainMenu;
    public GameObject credits;
    public GameObject newGame;
    [Header("NewGame")]
    public GameObject startButton;
    public GameObject previewImage;
    public Sprite moonPreview;
    public Sprite desertPreview;
    public GameObject killLimit;
    public GameObject timeLimit;
    public GameObject killLimitText;
    public GameObject timeLimitText;

    private void Start()
    {
        mainMenu.SetActive(true);
        newGame.SetActive(false);
        previewImage.SetActive(false);
        credits.SetActive(false);
    }

    public void NewGameMenu()
    {
        newGame.SetActive(true);
        mainMenu.SetActive(false);
        credits.SetActive(false);
    }

    public void MainMenu()
    {
        newGame.SetActive(false);
        mainMenu.SetActive(true);
        credits.SetActive(false);
    }
    public void CreditsMenu()
    {
        newGame.SetActive(false);
        mainMenu.SetActive(false);
        credits.SetActive(true);
    }
}
