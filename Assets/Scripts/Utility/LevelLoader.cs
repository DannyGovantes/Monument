using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using RatboyStudios.LevelManagement;

public class LevelLoader : MonoBehaviour
    {

        private static int mainMenuIndex = 0;

        public static void LoadLevel(string levelName)
        {
            if (Application.CanStreamedLevelBeLoaded(levelName))
            {
                SceneManager.LoadScene(levelName);
            }
            else
            {
                Debug.LogWarning("LEVEL LOADER load level error: invalid scene specified");
            }

        }
        public static void LoadLevel(int levelIndex)
        {
            if (levelIndex >= 0 && levelIndex < SceneManager.sceneCountInBuildSettings)
            {
                if (levelIndex == mainMenuIndex)
                {
                    MainMenu.Open();
                }
                SceneManager.LoadScene(levelIndex);
            }
            else
            {
                Debug.LogWarning("LEVEL LOADER load level erro: invalid scene specified");
            }

        }

        public static void ReloadLevel()
        {
            Scene scene = SceneManager.GetActiveScene();
            LoadLevel(scene.buildIndex);
        }
        public static void LoadNextLevel()
        {

            int nextSceneIndex = (SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings;
            //Regresa un valor si supera el mínimo, o si supera el máximo
            nextSceneIndex = Mathf.Clamp(nextSceneIndex,mainMenuIndex,nextSceneIndex);
            LoadLevel(nextSceneIndex);


        }

        public static void LoadMainMenuLevel()
        {
            LoadLevel(mainMenuIndex);
        }

    }
