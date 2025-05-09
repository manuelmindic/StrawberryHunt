using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{

    public Button levelOneButton;
    public Button levelTwoButton;
    public Button levelThreeButton;


    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LevelSelector(string levelCounter)
    {
        if (levelCounter == levelOneButton.name)
        {
            levelOneButton.enabled = true;
            levelTwoButton.enabled = false;
            levelThreeButton.enabled = false;
        }
    }
}
