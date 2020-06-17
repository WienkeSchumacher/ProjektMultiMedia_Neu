using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRain : MonoBehaviour
{
    //Referenz zur Katze um auf dessen Healthbar zuzugreifen
    public GameObject cat;
    
    public Transform SafeAreaCheck;
    public float safeRadius = 2f;
    public LayerMask playerMask;

    bool isInSafeArea;

    // Update is called once per frame
    void Update()
    {
        isInSafeArea = Physics.CheckSphere(SafeAreaCheck.position, safeRadius, playerMask);

        if(isInSafeArea)
        {
            cat.GetComponent<PlayerHealth>().enabled = false;
        }
        else if(!isInSafeArea){
            cat.GetComponent<PlayerHealth>().enabled = true;
        }
    }
}
