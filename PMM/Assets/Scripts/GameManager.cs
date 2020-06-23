using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int currentMilk;
    public Text milkText;

    public GameObject WinLevelUI;// to display level won message
    public GameObject LoseLevelUI;// to display game over message


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

    // restarts level when Healthbar = 0
    public void EndGame()
    {
        
        Debug.Log("Game Over! Restart.");

        LoseLevelUI.SetActive(true);

        Invoke("RestartLevel", 3);
        

    }

    public void RestartLevel()
    {
        Debug.Log("Load Scene.");
       
        //loads the currently active level
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        LoseLevelUI.SetActive(false);
    }
    
    public void WinLevel()
    {
        Debug.Log("Level Won!");
        WinLevelUI.SetActive(true);
    }
}
