using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneLoader : MonoBehaviour
{
    public const int MENU_INDEX = 0;       //The Menu Scene Index
    public const int HUB_WORLD_INDEX = 1;   //The Hub World Scene Index
    public const int HUB_WORLD_2_INDEX = 2;
    public const int SETTING_INDEX = 3;
    public const int LEVEL_1_1_INDEX = 4;
    public const int LEVEL_1_2_INDEX = 5;

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

    public void RunLevel1()
    {
        SceneManager.LoadScene(LEVEL_1_1_INDEX);
        SceneManager.LoadSceneAsync(LEVEL_1_2_INDEX, LoadSceneMode.Additive);
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
