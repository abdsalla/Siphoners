using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Temp
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;

    private CharacterController charController;

    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;

    public float rotationSpeed;
    private bool isJumping;

   

    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) { SceneManager.LoadScene(0); }
        PlayerMove();
    }

    private void PlayerMove()
    {
        float horizInput = Input.GetAxis(horizontalInputName) * movementSpeed;
        float vertInput = Input.GetAxis(verticalInputName) * movementSpeed;


        Vector3 forwardMovement = transform.forward * vertInput;
        Vector3 rightMovement = transform.right * horizInput;

        charController.SimpleMove(forwardMovement + rightMovement);

        if (Input.GetKeyDown(KeyCode.D))
        {
            // Move Right
            Vector3 vectorRotation = Vector3.up * rotationSpeed * Time.deltaTime;
            //motor.rotate(vectorRotation);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Move Left
            Vector3 vectorRotation = Vector3.up * rotationSpeed * Time.deltaTime;
            //motor.rotate(-vectorRotation);
        }

        JumpInput();
    }

    private void JumpInput()
    {
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }
    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;
        do
        {
            float jumpForce = jumpFallOff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpForce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null;
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;

        isJumping = false;
        
    }
}
