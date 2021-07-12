using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RatboyStudios.LevelManagement
{
    public class MainMenu : Menu<MainMenu>
    {

        [SerializeField]
        private float _playDelay = 0.5f;

        [SerializeField]
        private TransitionFader startTransitionPrefab;

        public void OnPlayPressed()
        {
            //me interesa abrir la escena de monumento y menu monumento
            LevelLoader.LoadLevel(1);
            MonumentMenu.Open();


        }

        public void OnSettingsPressed()
        {

            SettingsMenu.Open();
        }
        public void OnCreditsPressed()
        {



            CreditsMenu.Open();
        }

        public override void OnBackPressed()
        {

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else

            Application.Quit();
#endif
        }
    }
}