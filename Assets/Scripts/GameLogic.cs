using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int strawberriesNeededToWin;
    private GameManager gameManager = GameManager.Instance;
    private int strawberriesCollected = 0;

    void Start()
    {
        GameObject[] strawberries = GameObject.FindGameObjectsWithTag("Strawberry");
        strawberriesNeededToWin = strawberries.Length;

        Debug.Log("Strawberries needed to win: " + strawberriesNeededToWin);
    }

    public void CollectStrawberry()
    {
        strawberriesCollected++;
        Debug.Log("Strawberries collected: " + strawberriesCollected);

        if (strawberriesCollected >= strawberriesNeededToWin)
        {
            LevelComplete();
        }
    }

    public void LevelComplete()
    {
        if (gameManager.levelProgress == 3)
        {
            SceneManager.LoadScene("FinalWinningScreen");
        }
        else
        {
            Debug.Log("Level Complete!");
            SceneManager.LoadScene("WinningScreen");
        }
    }
}
