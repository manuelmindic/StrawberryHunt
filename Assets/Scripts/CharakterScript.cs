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

    public AudioSource levelClickSound;
    public AudioSource levelClickSound2;
    public AudioSource levelClickSound3;
    public AudioSource backButtonSource;
    public AudioClip clickClip;
    public AudioClip clickClip2;
    public AudioClip clickClip3;
    public AudioClip backButtonClip;

    void Start()
    {
    }

    private IEnumerator PlaySoundAndLoad(string sceneName = "", AudioSource audioSource = null, AudioClip audioClip = null)
    {
        if (audioSource != null && audioClip != null)
        {
            Debug.Log("Playing sound...");
            audioSource.PlayOneShot(audioClip); 
            yield return new WaitForSeconds(audioClip.length); 
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

    public void SelectCharacter(string value)
    {
        GameManager.Instance.selectedCharacterIndex = value;
        Debug.Log("Selected character sprite: " + value);

        if (value == "blue")
        {
            StartCoroutine(PlaySoundAndLoad("",levelClickSound, clickClip));
        }
        else if (value == "pink")
        {
            StartCoroutine(PlaySoundAndLoad("", levelClickSound2, clickClip2));
        }
        else if (value == "yellow")
        {
            StartCoroutine(PlaySoundAndLoad("", levelClickSound3, clickClip3));
        }
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

    public void BackScene()
    {
        StartCoroutine(PlaySoundAndLoad("BackScene", backButtonSource, backButtonClip));
    }
}