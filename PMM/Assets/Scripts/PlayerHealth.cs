using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100f;
    public float currentHealth;

    public HealthBar healthBar;

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
        currentHealth -= Time.deltaTime * 2;

        healthBar.SetHealth(currentHealth);
    }


    void OnTriggerEnter(Collider item)
    {
        if(item.gameObject.tag == "playerhealthBottle")
        {
            currentHealth += currentHealth + 10;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }
    }
}