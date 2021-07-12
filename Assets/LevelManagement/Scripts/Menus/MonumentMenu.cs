using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RatboyStudios.LevelManagement
{    
    public class MonumentMenu : Menu<MonumentMenu>
    {

        public void OnTopPressed()
        {
            
        }
        public void OnMiddlePressed()
        {
            
        }

        public void OnBottomPressed()
        {
            
        }

        public override void OnBackPressed()
        {
            base.OnBackPressed();
            LevelLoader.LoadMainMenuLevel();


        }


     

    
    }


}
