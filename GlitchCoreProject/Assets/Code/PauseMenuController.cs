using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GC.GlitchCoreProject
{
    public class PauseMenuController : MonoBehaviour
    {
        public void Resume()
        {
            GameController.instance.TogglePause();
        }

        public void Quit()
        {
            SceneChanger.LoadLevel("Menu");
        }
    }
}
