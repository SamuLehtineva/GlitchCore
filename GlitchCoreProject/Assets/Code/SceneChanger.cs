using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GC.GlitchCoreProject
{
    public class SceneChanger: MonoBehaviour
    {
        public static void LoadLevel(string name)
		{
            SceneManager.LoadSceneAsync(name);
		}

        public static void LoadLevelAdditive(string name)
		{
            SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
		}

        public static void QuitGame()
		{
            Debug.Log("Quit");
            Application.Quit();
		}
    }
}
