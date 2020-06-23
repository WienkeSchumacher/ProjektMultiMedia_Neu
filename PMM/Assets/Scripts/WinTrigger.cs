using UnityEngine;

// detects whether player has reached home/end of game
public class WinTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter()
    {
        gameManager.WinLevel();
    }
}
