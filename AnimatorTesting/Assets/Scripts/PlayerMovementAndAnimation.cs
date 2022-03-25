using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementAndAnimation : MonoBehaviour
{
    PlayerInput playerInput;
    CharacterController controller;
    Animator animator;

    int isWalkingHash;
    int isRunningHash;

    Vector2 movementInput;
    Vector3 movement;
    Vector3 runMovement;
    bool isMovementPressed;
    bool isRunPressed;
    float rotationPerFrame = 2f;
    float runMultiplier = 5f;
   
    // from brackey
    float speed = 5f;
    float turnSmoothVelocity;
    [SerializeField] Transform cam;


    private void Awake()
    {
        playerInput = new PlayerInput();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");

        playerInput.CharacterControls.Move.started += OnMovementInput;
        playerInput.CharacterControls.Move.canceled += OnMovementInput;

        playerInput.CharacterControls.Run.started += OnRun;
        playerInput.CharacterControls.Run.canceled += OnRun;
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
        PlayerAnimation();

        if (isRunPressed)
        {
            controller.Move(runMovement * Time.deltaTime);
        }
        else
        {
            controller.Move(movement * Time.deltaTime);
        }

    }

    void OnMovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
        movement.x = movementInput.x;
        movement.z = movementInput.y;
        runMovement.x = movementInput.x * runMultiplier;
        runMovement.z = movementInput.y * runMultiplier;
        isMovementPressed = movementInput.x != 0 || movementInput.y != 0;
    }

    void OnRun(InputAction.CallbackContext context)
    {
        isRunPressed = context.ReadValueAsButton();       
    }

    void PlayerAnimation()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        if(isMovementPressed && !isWalking)
        {
            animator.SetBool(isWalkingHash, true);
        }
        else if (!isMovementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (!(isMovementPressed && isRunPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }

    void PlayerRotation()
    {
        //Vector3 positionToLookAt;
        //positionToLookAt.x = movement.x;
        //positionToLookAt.y = 0f;
        //positionToLookAt.z = movement.z;
        Vector3 direction = new Vector3(movement.x, 0f, movement.z).normalized;

        if (isMovementPressed)
        {

            

            //if (direction.magnitude >= 0.1f)
            //{
            //    float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg * cam.eulerAngles.y;
            //    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, 0.1f);
            //    transform.rotation = Quaternion.Euler(0f, angle, 0f);
            //    Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            //    controller.Move(moveDir.normalized * speed * Time.deltaTime);
            //}

            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationPerFrame * Time.deltaTime);
        }





        //Quaternion currentRotation = transform.rotation;
        //if (isMovementPressed)
        //{
        //    Quaternion targetRotation = Quaternion.LookRotation(positionToLookAt);
        //    transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, rotationPerFrame * Time.deltaTime);
        //}

    }

    private void OnEnable()
    {
        playerInput.CharacterControls.Enable();
    }
    private void OnDisable()
    {
        playerInput.CharacterControls.Disable();
    }
}