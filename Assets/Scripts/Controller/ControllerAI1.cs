using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControllerAI1 : MonoBehaviour
{
    //ai sight
    public bool playerIsInLOS = false;
    public float fieldofViewAngle = 160f;
    public float losRadius = 45f;

    //temp
    //public Transform player;
    public Transform tf;


    //ai sight and memory
    private bool aiMemorizesPlayer = false;
    public float memoryStartTime = 10f;
    private float increasingMemoryTime;

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

    NavMeshAgent nav;

    public float startWaitTime = 1f;
    public float distToPlayer = 5.0f;

    //strafe
    private float randomStrafeStartTime;
    private float waitStrafeTime;
    public float t_minStrafe;
    public float t_maxStrafe;

    //strafe
    public Transform strafeRight;
    public Transform strafeLeft;
    private int randomStrafeDir;

    //chase
    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;

    private float waitTime;


    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
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
        {
            if (playerIsInLOS == false && aiMemorizesPlayer == false && aiHeardPlayer == false)
            {
                Patrol();
                NoiseCheck();
                StopCoroutine(AiMemory());
            }
            else if (aiHeardPlayer == true && playerIsInLOS == false && aiMemorizesPlayer == false)
            {
                canSpin = true;
                GoToNoisePosition();

            }
            else if (playerIsInLOS == true)
            {
                aiMemorizesPlayer = true;
                FacePlayer();
                ChasePlayer();
            }
            else if (aiMemorizesPlayer == true && playerIsInLOS == false)
            {
                ChasePlayer();
                StartCoroutine(AiMemory());
            }
        }
    }

    void NoiseCheck() //noise check function 
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        if (distance <= noiseTravelDistance)
        {
            if (Input.GetKey(KeyCode.N))//tmp solutions for hearing
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
        nav.SetDestination(noisePosition);

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
    //AI memeory
    IEnumerator AiMemory()
    {
        increasingMemoryTime = 0f;

        while (increasingMemoryTime < memoryStartTime)
        {
            increasingMemoryTime += Time.deltaTime;
            aiMemorizesPlayer = true;
            yield return null;
        }

        aiHeardPlayer = false;
        aiMemorizesPlayer = false;
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
                    Debug.Log("player seen");
                    playerIsInLOS = true;

                    aiMemorizesPlayer = true;
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
        nav.SetDestination(moveSpots[randomSpot].position);

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

    void ChasePlayer() //chase the playe if in line of sight.
    {
        float distance = Vector3.Distance(PlayerMovement.playerPos, transform.position);

        if (distance <= chaseRadius && distance > distToPlayer)
        {
            nav.SetDestination(PlayerMovement.playerPos);
        }

        else if (nav.isActiveAndEnabled && distance <= distToPlayer)
        {
            randomStrafeDir = Random.Range(0, 2);
            randomStrafeStartTime = Random.Range(t_minStrafe, t_maxStrafe);

            if (waitStrafeTime <= 0)
            {

                if (randomStrafeDir == 0)
                {
                    nav.SetDestination(strafeLeft.position);
                }
                else
                if (randomStrafeDir == 1)
                {
                    nav.SetDestination(strafeRight.position);
                }
                waitStrafeTime = randomStrafeStartTime;
            }
            else
            {
                waitStrafeTime -= Time.deltaTime;
            }
        }
    }
    void FacePlayer() //makes the zombie turn towards the player
    {
        Vector3 direction = (PlayerMovement.playerPos - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
    }
    private void OnCollisionEnter(Collision collision)
    {
       //simple temp kill mechanic 
       //if (collision.gameObject == player.gameObject)
       //{
       //   Destroy(player.gameObject);
       // }
    }
}
