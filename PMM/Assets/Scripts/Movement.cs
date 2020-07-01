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

<<<<<<< HEAD
        if (Input.GetKey("space"))
        {
            //hier waren schon sehr viele verschiedene Versionen von Space bzw Jump. Keine hat funktioniert. Wir haben auch versucht die in dem anderen Skript(thirdperson) zu implementieren, jedoch hatte es keinen Effekt. Die Katze springt nicht egal wie viele verschiedene Versionen wir ausprobiert haben :(
            cat.AddForce(0, force * Time.deltaTime, 0);
        }
=======
        //if (Input.GetKey("space"))
        //{
        //    // Add a force to the left
        //    cat.AddForce(0, force * Time.deltaTime, 0);
        //}
>>>>>>> seda
    }
}
