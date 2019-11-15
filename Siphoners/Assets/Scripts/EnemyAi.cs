using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    //ai sight
    public bool playerIsInLOS = false;
    public float fieldofViewAngle = 160f;
    public float losRadius = 45f;

    //temp
    Transform player;
    Transform tf;

    //public int health;

    //ai hearing
    Vector3 noisePosition;
    private bool aiHeardPlayer = false;
    public float noiseTravelDistance = 50f;
    public float spinspeed = 3f;
    private bool canSpin = false;
    private float isSpinningTime;
    public float spinTime = 3f;

    //waypoints
    public Transform[] moveSpots;
    private int randomSpot;

    NavMeshAgent Agent;

    public float startWaitTime = 1f;
    public float distToPlayer = 5.0f;



    //chase
    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;

    private float waitTime;

    Animator anim;
    private GameManager instance;
    private Vector3 input;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Agent.enabled = true;
        anim = GetComponentInChildren<Animator>();
        instance = GameManager.Instance;
    }

    void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);
        // Debug.Log(distance);
        {
            if (playerIsInLOS == false && aiHeardPlayer == false)
            {
                Patrol();
                NoiseCheck();
            }
            else if (aiHeardPlayer == true && playerIsInLOS == false)
            {
                canSpin = true;
                GoToNoisePosition();

            }
            else if (playerIsInLOS == true)
            {
                FacePlayer();
                ChasePlayer();
            }
            else if (playerIsInLOS == false)
            {
                ChasePlayer();
            }
        }
        input = Agent.desiredVelocity;
        input = transform.InverseTransformDirection(input);
        anim.SetFloat("Horizontal", input.x);
        anim.SetFloat("Vertical", input.z);
    }

    void NoiseCheck() //noise check function 
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        if (distance <= noiseTravelDistance)
        {
            if (distance < 10f)
            {
                noisePosition = PlayerMovement.playerPos;
                aiHeardPlayer = true;
            }
            else
            {
                aiHeardPlayer = false;
                canSpin = false;
            }
        }
    }

    void GoToNoisePosition()//AI is told to go to last spot for hearing 
    {
        Agent.SetDestination(noisePosition);

        if (Vector3.Distance(transform.position, noisePosition) <= 5f && canSpin == true)
        {
            isSpinningTime += Time.deltaTime;

            transform.Rotate(Vector3.up * spinspeed, Space.World);

            if (isSpinningTime >= spinTime)
            {
                canSpin = false;
                aiHeardPlayer = false;
                isSpinningTime = 0f;
            }
        }
    }

    void CheckLOS() //line of sight with a field of view. 
    {
        Vector3 direction = PlayerMovement.playerPos - transform.position;

        float angle = Vector3.Angle(direction, transform.forward);

        if (angle < fieldofViewAngle * 0.5f)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direction.normalized, out hit, losRadius))
            {
                if (hit.collider.tag == "Player")
                {
                    playerIsInLOS = true;

                }
                else
                {
                    playerIsInLOS = false;
                }
            }
        }
    }

    void Patrol() //Patrol state for AI goes to set waypoints. 
    {
        if (moveSpots.Length > 0)
        {
            Agent.SetDestination(moveSpots[randomSpot].position);

            if (Vector3.Distance(transform.position, moveSpots[randomSpot].position) < 2.0f)
            {
                if (waitTime <= 0)
                {
                    randomSpot = Random.Range(0, moveSpots.Length);

                    waitTime = startWaitTime;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
    }

    void ChasePlayer() //chase the playe if in line of sight.
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        if (distance <= chaseRadius && distance > distToPlayer)
        {
            Debug.Log(distance);
            if(distance < 30)
            {
                transform.LookAt(player.position);
                Agent.SetDestination(PlayerMovement.playerPos);
            }
            
        }

    }

    void FacePlayer() //makes the zombie turn towards the player
    {
        Vector3 direction = (PlayerMovement.playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
    }

    public void RotateTowards(Vector3 targetPoint)
    {
        //Find the Difference Between the Pawn and What We Want to Look At
        Vector3 vectorToLookDown = targetPoint - tf.position;
        //Get the Rotation
        Quaternion lookRotation = Quaternion.LookRotation(vectorToLookDown, tf.up);
        //Look There
        tf.rotation = Quaternion.RotateTowards(tf.rotation, lookRotation, Time.deltaTime);
    }


    private void OnCollisionEnter(Collision collision)
    {
        //simple temp kill mechanic 
        if (collision.gameObject == instance.currentPlayer)
        {
            Debug.Log("Dealt Damage");
            //Destroy(player.gameObject);
        }
    }
}
