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


    public Button LevelButton;

    public float speed = 2f;
    public float height = 8f;
    public AudioSource levelClickSound;
    public Vector3 originPos;

    void Start()
    {
        string levelCounter = "2";
        LevelSelector(levelCounter);

        originPos = transform.localPosition;
    }

    private void Update()
    {
         upAndDownLevel();    
    }

    public void LevelSelector(string levelCounter)
    {
        Debug.Log(levelCounter);
        Debug.Log(levelOneText.text);
        Debug.Log(levelCounter == levelOneText.text);


        if (levelCounter == levelOneText.text)
        {

            levelOneButton.interactable = true;
            if (levelOneButton.interactable)
            {

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
        if (LevelButton.interactable == true)
        {
            Debug.Log("audiooo");
            levelClickSound.Play();
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    public void upAndDownLevel()
    {
        if (LevelButton.interactable == true)
        {
            

            float newY = Mathf.Sin(Time.time * speed) * height;
            transform.localPosition = originPos + new Vector3(0, newY, 0);
        }
    }

    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}