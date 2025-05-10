using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalWinningScript : MonoBehaviour
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

    public void WinningComplete()
    {
        Debug.Log("Level Complete!");
        Debug.Log("Level Progress: " + gameManager.levelProgress);
        gameManager.levelProgress = 1;
        SceneManager.LoadScene("StartScene");
    }
}
