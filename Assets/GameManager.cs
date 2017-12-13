using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {

    public GameObject selectedLevel;
    public float timeLimit;
    public float killLimit;

    public void SetSelectedLevel(GameObject level)
    {
        selectedLevel = level;
    }
    public void SetTimeLimit(float _timeLimit)
    {
        timeLimit = _timeLimit;
    }
    public void SetKillLimit(float _killLimit)
    {
        killLimit = _killLimit;
    }

    public GameObject GetSelectedLevel()
    {
        return selectedLevel;
    }
    public float GetTimeLimit()
    {
        return timeLimit;
    }
    public float GetKillLimit()
    {
        return killLimit;
    }

}
