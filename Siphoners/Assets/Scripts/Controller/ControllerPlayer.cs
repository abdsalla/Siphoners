using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    [Header("player health")]
    public int lives;
    public int health;

    [Header("Ragedoll Elements")]
    public GameObject objectToApplyRagdoll;

    //Things getting turned off when we ragdoll
    public Collider mainCollider;
    public Animator anim;
    public Rigidbody mainRigbody;

    public List<Rigidbody> partRigbody;
    public List<Collider> partColliders;
    //Start is called before the first frame update
    void Start()
    {
        //for future script dealing with health. 
        //health = GetComponent<Health>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
