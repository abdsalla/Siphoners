using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestTP : MonoBehaviour
{
    public GameObject player;
    private PlayerMovement movement;
    public TestSpawn spawn;
    public List<KeyCode> keys;
    public List<Transform> transforms;

    void Start()
    {
        movement = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            player = spawn.currentPlayer;
            movement = player.GetComponent<PlayerMovement>();
        }

        if(Input.anyKey)
        {
            for (int i = 0; i < keys.Count; i++)
            {
                if (Input.GetKeyDown(keys[i]))
                {
                    movement.enabled = false;
                    player.transform.position = transforms[i].position;
                    movement.enabled = true;
                }
            }
        }
    }
}
