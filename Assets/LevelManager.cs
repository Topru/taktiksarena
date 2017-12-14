using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameManagement
{
    public static class LevelManager
    {

        public static GameObject selectedLevel;
        public static float timeLimit = 5;
        public static float killLimit = 5;

        public static void SetSelectedLevel(GameObject level)
        {
            selectedLevel = level;
        }
        public static void SetTimeLimit(float _timeLimit)
        {
            timeLimit = _timeLimit;
        }
        public static void SetKillLimit(float _killLimit)
        {
            killLimit = _killLimit;
        }

        public static GameObject GetSelectedLevel()
        {
            return selectedLevel;
        }
        public static float GetTimeLimit()
        {
            return timeLimit;
        }
        public static float GetKillLimit()
        {
            return killLimit;
        }

    }
}