using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementTesting : MonoBehaviour
{
    int isWalkingHash;
    int isRunningHash;
    float angle;
    bool isMovementPressed;
    bool isRunPressed;   

    Vector3 movement;
    Vector3 runMovement;
    CharacterController controller;
    Transform cam;
    Animator animator;

    float rotationPerFrame = 10f;
    float speed = 5f;

    private void Awake()
    {
        cam = Camera.main.transform;
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovementInput();

        if (Mathf.Abs(movement.x) < 1 && Mathf.Abs(movement.z) < 1) return;

        PlayerDirection();
        PlayerRotation();
        PlayerAnimation();
        Move();

    }

    void PlayerMovementInput()
    {

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
       
        //Debug.Log(movement.x + " " + movement.z);
        

    }

    void PlayerDirection()
    {
        angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        angle += cam.eulerAngles.y;
    }

    void PlayerRotation()
    {
        Quaternion targetRotation = Quaternion.Euler(0, angle, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationPerFrame * Time.deltaTime);
    }
    void Move()
    {
        transform.position += transform.forward * speed * Time.deltaTime; 
    }

    void PlayerAnimation()
    {

        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);

        if (isMovementPressed && !isWalking)
        {           
            animator.SetBool(isWalkingHash, true);
        }
        else if (!isMovementPressed && isWalking)
        {
            animator.SetBool(isWalkingHash, false);
        }
        if ((isMovementPressed && isRunPressed) && !isRunning)
        {
            animator.SetBool(isRunningHash, true);
        }
        else if (!(isMovementPressed && isRunPressed) && isRunning)
        {
            animator.SetBool(isRunningHash, false);
        }
    }
}
