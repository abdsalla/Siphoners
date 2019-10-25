using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTP : MonoBehaviour
{
    private GameManager instance;
    private PlayerMovement movement;

    public List<KeyCode> keys;
    public List<Transform> transforms;

    void Start()
    {
        instance = GameManager.Instance;
        movement = instance.currentPlayer.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (instance.currentPlayer == null)
        {
            movement = instance.currentPlayer.GetComponent<PlayerMovement>();
        }

        if(Input.anyKey)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    movement.enabled = false;
                    instance.currentPlayer.transform.position = transforms[i].position;
                    movement.enabled = true;
                }
            }
        }
    }
}
