using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    Animator animator;
    CharacterController controller;
    float speed = 5f;
    float jumpSpeed = 7f;
    float ySpeed;
    float angle;
    float rotationPerFrame = 700f;
    float magnitude;

    bool isJump;
    bool isGrounded;

    Vector3 movement;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
       
        cam = Camera.main.transform;
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        movement = new Vector3(horizontal, 0, vertical);
        magnitude = Mathf.Clamp01(movement.magnitude) * speed;
        movement.Normalize();

        controller.SimpleMove(movement * magnitude);
        //movement *= magnitude * Time.deltaTime;
        //transform.Translate(movement, Space.World);

        float velocityX = Vector3.Dot(movement.normalized, transform.right);
        float velocityZ = Vector3.Dot(movement.normalized, transform.forward);
        animator.SetFloat("velocityX", velocityX, 0.1f, Time.deltaTime);
        animator.SetFloat("velocityZ", velocityZ, 0.1f, Time.deltaTime);

        PlayerDirection();
        PlayerRotation();
        PlayerJump();
        Attack();

    }

    void PlayerDirection()
    {
        angle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
        angle += cam.eulerAngles.y;
    }

    void PlayerRotation()
    {
        if (movement != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationPerFrame * Time.deltaTime);
        }
    }

    void PlayerJump()
    {
        ySpeed += Physics.gravity.y * Time.deltaTime;

        if (controller.isGrounded)
        {
            Debug.Log(controller.isGrounded);
            ySpeed = -0.5f;
            animator.SetBool("isGrounded", true);
            isGrounded = true;
            animator.SetBool("isJumping", false);
            isJump = false;
            animator.SetBool("isFalling", false);

            if (Input.GetButton("Jump"))
            {
                ySpeed = jumpSpeed;
                animator.SetBool("isJumping", true);
                isJump = true;

            }
        }
        else
        {
            animator.SetBool("isGrounded", false);
            isGrounded = false;
            animator.SetBool("isFalling", true);
            //if ((isJump && ySpeed < 0) || ySpeed < -2)
            //{

            //}
        }

        Vector3 velocity = movement * magnitude;
        velocity.y = ySpeed;
        controller.Move(velocity * Time.deltaTime);

    }

    void Attack()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            //Reset the "Crouch" trigger
            animator.ResetTrigger("isKick");
            //Send the message to the Animator to activate the trigger parameter named "Jump"
            animator.SetTrigger("isPunch");
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //Reset the "Jump" trigger
            animator.ResetTrigger("isPunch");
            //Send the message to the Animator to activate the trigger parameter named "Crouch"
            animator.SetTrigger("isKick");
        }
    }


}
