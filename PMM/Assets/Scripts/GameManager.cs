using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int currentMilk;
    public Text milkText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddMilk(int milkToAdd)
    {
        currentMilk += milkToAdd;
        milkText.text = "Milk: " + currentMilk;
    }
}
