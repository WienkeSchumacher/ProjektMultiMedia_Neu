using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    //void Start()
    //{
    //    startscreen.SetActive(true);

    //}

    //public void DeactivateStartScreen()
    //{
    //    startscreen.SetActive(false);
    //}





}