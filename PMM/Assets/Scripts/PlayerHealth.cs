﻿using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBar healthBar;


    //private bool isRespawning;
    //private Vector3 respawnPoint;
    //private Transform SpawnPoint;
    public GameObject SpawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);


        
    }

    // Update is called once per frame
    void Update()
    {
  
            TakeDamage();
        //HealPlayer();


    }

    void TakeDamage()
    {
        currentHealth -= Time.deltaTime * 4;

        healthBar.SetHealth(currentHealth);

        // calls function RestartLevel in gamemanager when healthbar is empty
        if(currentHealth < 1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    
    }



    void OnTriggerEnter(Collider item)
    {
        if(item.gameObject.tag == "playerhealthBottle")
        {
            Heal();
        }
    }


    public void Heal()
    {
        Debug.Log(currentHealth);
        currentHealth += currentHealth + 10;
        Debug.Log(currentHealth);
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }


    
}