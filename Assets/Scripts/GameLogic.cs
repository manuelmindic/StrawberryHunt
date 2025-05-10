using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour
{
    public int strawberriesNeededToWin;
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

    void LevelComplete()
    {
        Debug.Log("Level Complete!");
    }
}
