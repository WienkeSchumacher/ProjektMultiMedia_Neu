﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiverController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Test");

        FindObjectOfType<GameManager>().EndGame();
    }
}
