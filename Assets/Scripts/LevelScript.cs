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
        levelCounter = "1";

        if (levelCounter == levelOneButton.name)
        {
            levelOneButton.enabled = true;
            levelTwoButton.enabled = false;
            levelThreeButton.enabled = false;
        }
        else if (levelOneButton.name == levelTwoButton.name)
        {
            levelTwoButton.enabled = true;
            levelThreeButton.enabled = false;
            levelOneButton.enabled = false;
        }
        else if (levelThreeButton.name == levelOneButton.name)
        {
            levelOneButton.enabled = false;
            levelTwoButton.enabled = false;
            levelThreeButton.enabled = true;
        }
    }
    }