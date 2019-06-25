using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SceneLoadTrigger : MonoBehaviour
{
    //Variables
    public SceneLoader sceneLoader;     //The scene loader
    public enum Scenes {Settings, Menu, Hubworld, Level1};
    public Scenes scene = Scenes.Menu;
    private BoxCollider trigger;        //The trigger box


    void Start()
    {
        //Get Components
        trigger = GetComponent<BoxCollider>();
        trigger.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (scene)
        {
            case Scenes.Settings:
                sceneLoader.RunSetings();
                break;
            case Scenes.Menu:
                sceneLoader.RunMenu();
                break;
            case Scenes.Hubworld:
                sceneLoader.RunHubWorld();
                break;
            case Scenes.Level1:
                sceneLoader.RunLevel1();
                break;
        }
    }

}
