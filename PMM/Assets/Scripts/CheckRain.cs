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

   void Start()
    {
        cat = GameObject.Find("cat");
    }

    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter()
        {
            cat.GetComponent<PlayerHealth>().enabled = false;
        }

        isInSafeArea = Physics.CheckSphere(SafeAreaCheck.position, safeRadius, playerMask);

        if(isInSafeArea)
        {
            cat.GetComponent<PlayerHealth>().enabled = false;
        }
        else if(!isInSafeArea){
            cat.GetComponent<PlayerHealth>().enabled = true;
        }

    }

    //void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(transform.position, safeRadius);
    //}

    }
