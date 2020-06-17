// Script for simple Player Movement
using UnityEngine;

public class Movement : MonoBehaviour{

    // This is a reference to the Rigidbody component called "cat"
    public Rigidbody cat;

    // Variable that determines the force of movement
    public float force;

    // We marked this as "Fixed"Update because we
    // are using it to deal with physics.
    void FixedUpdate(){

        if (Input.GetKey("w")){

            // Add a force to the front
            // Time.deltaTime to handle framerates
            cat.AddForce(0, 0, -force * Time.deltaTime);
        }

        if (Input.GetKey("s")){

            // Add a force to the back
            cat.AddForce(0, 0, force * Time.deltaTime);
        }

        if (Input.GetKey("d")){ 
            // Add a force to the right
            cat.AddForce(-force * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey("a")){
            // Add a force to the left
            cat.AddForce(force * Time.deltaTime, 0, 0);
        }
    }
}
