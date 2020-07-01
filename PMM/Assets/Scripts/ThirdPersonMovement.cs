using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    //public Rigidbody cat; // entfernt weil Mischung von RigidBody und CharacterController zu Bugs führt
    //public float force;
    public bool isOnGround;

    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;


    //Haben hier auch verschieden Versionen vom springen eingebaut. Dadurch das keine geklappt hat haben wir sie jedoch immer entfernt damit der Code weiterhin sauber und übersichtlich für uns bleibt.

    private void Start()
    {
        controller.Move(Vector3.down * 3 * Time.deltaTime);

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

        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;


        if (direction.magnitude >= 0.1f)
        {

            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);


            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //to add gravity
            if (!controller.isGrounded)
            {
                controller.Move(Vector3.down * 3 * Time.deltaTime);
                Debug.Log("back to ground");
            }
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
          
         
            


        }

     
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }
}


