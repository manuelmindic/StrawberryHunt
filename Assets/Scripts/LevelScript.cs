using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour
{

    public Button levelOneButton;
    public Button levelTwoButton;
    public Button levelThreeButton;
    public TMP_Text levelOneText;
    public TMP_Text levelTwoText;
    public TMP_Text levelThreeText;
    public Sprite disabledSprite;

    AudioSource levelClickSound;

    public float speed = 2f;
    public float height = 8f;

    public Vector3 originPos;
    void Start()
    {
        string levelCounter = "2";
        Debug.Log(levelOneText.text + "Hieiiier");
        LevelSelector(levelCounter);
        
    }

    public void LevelSelector(string levelCounter)
    {
        Debug.Log(levelCounter);
        Debug.Log(levelOneText.text);
        Debug.Log(levelCounter == levelOneText.text);


        if (levelCounter == levelOneText.text)
        {
            Debug.Log("hallo" + levelCounter);

            levelOneButton.interactable = true;
            if (levelOneButton.interactable)
            {
                Debug.Log("Hieiiierrrrrrr" + levelCounter);

            }
            levelTwoButton.interactable = false;
            levelTwoButton.image.sprite = disabledSprite;
            levelThreeButton.interactable = false;
            levelThreeButton.image.sprite = disabledSprite;

        }
        else if (levelCounter == levelTwoText.text)
        {
            levelTwoButton.interactable = true;
            levelThreeButton.image.sprite= disabledSprite;
            levelThreeButton.interactable = false;
            levelOneButton.image.sprite = disabledSprite;
            levelOneButton.interactable = false;
        }
        else if (levelCounter == levelThreeText.text)
        {
            levelOneButton.image.sprite = disabledSprite;
            levelOneButton.interactable = false;
            levelTwoButton.image.sprite = disabledSprite;
            levelTwoButton.interactable = false;
            levelThreeButton.interactable = true;
        }
    }

    

    public void pressNextLevel()
    {
        levelClickSound.Play();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    }