using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    const int MENU_INDEX = 0;       //The Menu Scene Index
    const int HUB_WORLD_INDEX = 1;   //The Hub World Scene Index
    const int HUB_WORLD_2_INDEX = 2;
    const int SETTING_INDEX = 3;

    public void RunSetings()
    {
        SceneManager.LoadScene(SETTING_INDEX);
    }
    public void RunMenu()
    {
        SceneManager.LoadScene(MENU_INDEX);
    }
    public void RunHubWorld()
    {
        SceneManager.LoadScene(HUB_WORLD_INDEX);
        SceneManager.LoadSceneAsync(HUB_WORLD_2_INDEX, LoadSceneMode.Additive);
    }

    public void Quit()
    {
        Debug.Log("Saving and Quitting.");

        //Quit in build
        Application.Quit();

        //Quit in editor
#if UNITY_EDITOR
    UnityEditor.EditorApplication.isPlaying = false;
#endif

    }

}
