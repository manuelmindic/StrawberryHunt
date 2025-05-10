using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LosingScreen : MonoBehaviour
{
    private GameManager gameManager = GameManager.Instance;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GameLost()
    {
        Debug.Log("Level Failed!");
        Debug.Log("Level Progress: " + gameManager.levelProgress);
        if (gameManager.levelProgress != 1) gameManager.levelProgress -= 1;
        SceneManager.LoadScene("LevelScene");
    }

}
