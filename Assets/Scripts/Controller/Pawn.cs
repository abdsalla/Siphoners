using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    public Animator anim;
    public Transform tf;
    public static Vector3 playerPos;

    //variables 
    public float turnSpeed;
    public float speed;

    void Start()
    {
        //set variables 
        anim = GetComponent<Animator>();
        tf = GetComponent<Transform>();
    }

    void Update()
    {

    }
    public void move(Vector3 direction)
    {
        //moves character based on blend tree setting and direction.
        anim.SetFloat("Vertical", direction.z * speed);
        anim.SetFloat("Horizontal", direction.x * speed);
    }

    public void RotateTowards(Vector3 targetPoint)
    {
        //figures out where to look at 
        Vector3 vectorLook = targetPoint - tf.position;
        //rotates player(model)
        Quaternion lookRotation = Quaternion.LookRotation(vectorLook, tf.up);
        //this is so the character wont snap around to look at mouse, but is rather gradual over time.
        tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, (turnSpeed * Time.deltaTime));
    }
}
