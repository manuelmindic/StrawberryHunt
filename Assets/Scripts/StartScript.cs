using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScript : MonoBehaviour
{
    public AudioSource levelClickSound;
    public AudioClip clickClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
