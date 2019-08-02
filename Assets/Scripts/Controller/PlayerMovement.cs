using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Temp
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    [Header("Move Inputs")]
    [SerializeField]
    private string horizontalInputName;
    [SerializeField]
    private string verticalInputName;
    [SerializeField]
    public float Speed;
    public float RotateSpeed;

    public CharacterController charController;


    //[Header("jumping")]
    //[SerializeField]
    //private AnimationCurve jumpFallOff;
    //[SerializeField]
    //private float jumpMultiplier;
    //[SerializeField]
    //private KeyCode jumpKey;

    //variables
    public float rotationSpeed;
    private bool isJumping;
    private bool isCrouching;
    public Vector3 rightMovement;
    public Vector3 forwardMovement;
    private bool aCover = false;
    public float maxRayDist = 3;
    public LayerMask activeLayer = 8;


    public static Vector3 playerPos;

    public void PlayerMove() //Player movement 
    {
        CharacterController controller = GetComponent<CharacterController>();
        if (transform != null)
        {
            transform.Rotate(0, Input.GetAxis("Horizontal") * RotateSpeed, 0);
            var forward = transform.TransformDirection(Vector3.forward);
            float curSpeed = Speed * Input.GetAxis("Vertical");
            controller.SimpleMove(forward * curSpeed); //simple move for char 
        }
        //JumpInput(); //calls jump functions
    }
    IEnumerator TrackPlayer()
    {
        while (true)
        {
            playerPos = gameObject.transform.position;
            yield return null;
        }
    }



    private bool FindCover()
    {
        //finds cover 
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(this.transform.position + new Vector3(0f, 3.70f, 0f), forward);
        RaycastHit hit;
        Physics.Raycast(ray, maxRayDist, activeLayer);
        Debug.DrawRay(transform.position + new Vector3(0f, 3.70f, 0f), forward, Color.red);

        if (Physics.Raycast(ray, out hit, maxRayDist))
        {
            Debug.DrawRay(hit.point, hit.point + Vector3.up * 5, Color.green);
            aCover = true;
            if (Input.GetKeyDown(KeyCode.J) && aCover == true)
            {
                Debug.Log("Available Cover");
                Vector3 normal = hit.normal;
                Vector3.OrthoNormalize(ref normal, ref rightMovement);
                charController.Move(rightMovement * Time.deltaTime);
                Vector3.OrthoNormalize(ref normal, ref forwardMovement);
                charController.Move(forwardMovement * Time.deltaTime);
            }
        }

        {
            aCover = false;
        }


        return aCover;

    }

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { SceneManager.LoadScene(0); }
        PlayerMove();
        FindCover();

    }
}



//    private void JumpInput()
//    {
//        //gets and sets input for jump.
//        if (Input.GetKeyDown(jumpKey) && !isJumping)
//        {
//            isJumping = true;
//            StartCoroutine(JumpEvent());
//        }
//    }
//    private IEnumerator JumpEvent()
//    {
//        charController.slopeLimit = 90.0f;
//        float timeInAir = 0.0f;
//        do
//        {
//            float jumpForce = jumpFallOff.Evaluate(timeInAir);
//            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
//            timeInAir += Time.deltaTime;
//            yield return null;
//        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

//        charController.slopeLimit = 45.0f;

//        isJumping = false;
        
//    }
//}
