using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharakterScript : MonoBehaviour
{
    public Image[] characterImages;
    public Sprite[] char1Sprites;
    public Sprite[] char2Sprites;
    public Sprite[] char3Sprites;

    private float timer;
    private bool showAltImage = false;

   
    void Start()
    {
    }

    public void SelectCharacter(string value)
    {
        GameManager.Instance.selectedCharacterIndex = value;
        Debug.Log("Selected character sprite: " + value);
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.75f)
        {
            timer = 0f;
            showAltImage = !showAltImage;

            characterImages[0].sprite = showAltImage ? char1Sprites[1] : char1Sprites[0];
            characterImages[1].sprite = showAltImage ? char2Sprites[1] : char2Sprites[0];
            characterImages[2].sprite = showAltImage ? char3Sprites[1] : char3Sprites[0];
        }
    }

    public void ContinueScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}