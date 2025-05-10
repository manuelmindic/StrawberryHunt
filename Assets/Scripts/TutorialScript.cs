using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialScript : MonoBehaviour
{

    public Image[] characterImages;
    public Sprite[] char1Sprites;
    public Sprite[] char2Sprites;

    private float timer;
    private bool showAltImage = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= 0.25f)
        {
            timer = 0f;
            showAltImage = !showAltImage;

            characterImages[0].sprite = showAltImage ? char1Sprites[1] : char1Sprites[0];
            characterImages[1].sprite = showAltImage ? char2Sprites[1] : char2Sprites[0];
        }
    }


    public void StartScene()
    {
        SceneManager.LoadScene("StartScene");
    }
}
