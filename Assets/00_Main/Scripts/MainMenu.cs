using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FinalAssignment.Main
{

    public class MainMenu : MonoBehaviour
    {
        public void LoadGame(int index)
        {
            Debug.Log(index);
            SceneManager.LoadScene(index);
        }

        public void ExitApp()
        {

#if UNITY_EDITOR

            EditorApplication.ExitPlaymode();
#else
            Debug.Log("Exit");
            Application.Quit();
#endif
        }
    }

}