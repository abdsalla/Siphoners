using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputAnimation : MonoBehaviour
{
    //Variables
    [SerializeField, Tooltip("The max speed of the player")]
    private float speed = 4f;
    private Animator animator;

    private void Awake()
    {
        //Get Components
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        //Player Movement Input
        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        input = Vector3.ClampMagnitude(input, 1f);
        input *= speed;
        
        //Animator Movement Using Input
        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.z);
    }
}
