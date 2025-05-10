using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public AudioSource levelClickSound;
    public AudioClip clickClip;

    public Image[] characterImages;
    public Sprite[] char1Sprites;
    public Sprite[] char2Sprites;
    public Sprite[] char3Sprites;
    public Sprite[] char4Sprites;

    private float timer;
    private bool showAltImage = false;
    void Start()
    {

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
            characterImages[3].sprite = showAltImage ? char4Sprites[1] : char4Sprites[0];
        }
    }

    private IEnumerator PlaySoundAndLoad(string sceneName = "")
    {
        if (levelClickSound != null && clickClip != null)
        {
            Debug.Log("Playing sound...");
            levelClickSound.PlayOneShot(clickClip);
            yield return new WaitForSeconds(clickClip.length);
        }


        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void ClickStart()
    {
        StartCoroutine(PlaySoundAndLoad());
    }

    public void CreditScene()
    {
        StartCoroutine(PlaySoundAndLoad("CreditScene"));
    }

    public void TutorialScene()
    {
        StartCoroutine(PlaySoundAndLoad("TutorialScene"));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

   
