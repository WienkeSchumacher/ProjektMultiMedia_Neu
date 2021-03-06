﻿using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour

{

    private CharacterController controller;
    public Transform cam;

    //public Rigidbody cat; // entfernt weil Mischung von RigidBody und CharacterController zu Bugs führt
    //public float force;
    public bool isOnGround;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;

    private float jumpVelocity = 0.0f;
    public float jumpHeight = 2f;

    public float gravity = 5f; //Keine echte Gravitäts-Simulation

    private Vector3 direction = Vector3.zero;

    private Animator animator;

    private void Start()
    {

        controller = gameObject.GetComponent<CharacterController>();

        animator = GetComponent<Animator>();

        if (controller.isGrounded)
        {
            Debug.Log("isGrounded");
        }
        else if (!controller.isGrounded)
        {
            Debug.Log("not Grounded");
        }

    }

    void Update()
    {

        float horizontal = Input.GetAxisRaw("Horizontal");

        float vertical = Input.GetAxisRaw("Vertical");

        float jumping = Input.GetAxisRaw("Jump");

        if (controller.isGrounded)
        {
            direction = new Vector3(horizontal, 0f, vertical);

            if (jumping > 0)
            {
                jumpVelocity = jumpHeight;
            }
        }

        else
        {
            jumpVelocity -= gravity * Time.deltaTime;
        }

        if (direction.magnitude >= 0.1f)
        {
            animator.SetBool("isWalking", true);

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            controller.Move(moveDir * speed * Time.deltaTime);

        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (jumpVelocity != 0)
        {
            animator.SetBool("isJumping", true);

            controller.Move(Vector3.up * jumpVelocity * Time.deltaTime);

            if (controller.isGrounded)
            {
                animator.SetBool("isJumping", false);

                jumpVelocity = 0.0f;
            }
        }

        //Debug.Log("Jumping: " + jumpVelocity);


    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }

}


