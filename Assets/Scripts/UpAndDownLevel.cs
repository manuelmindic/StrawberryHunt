using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpAndDownLevel : MonoBehaviour
{
    public Vector3 originPos;
    public float speed = 2f;
    public float height = 8f;
    public Button[] LevelButtons;

    private GameManager gameManager = GameManager.Instance;

    public AudioSource levelClickSound;
    public AudioClip clickClip;
    // Start is called before the first frame update
    void Start()
    {
        originPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        upAndDownLevel();
    }
    public void upAndDownLevel()
    {
        foreach (var level in LevelButtons)
        {
            if (level.interactable)
            {
                Debug.Log("WARRRUUMM");
                float newY = Mathf.Sin(Time.time * speed) * height;
                transform.localPosition = originPos + new Vector3(0, newY, 0);
            }
        }
    }

    public void pressNextLevel()
    {
        StartCoroutine(PlaySoundAndLoad());
    }

    private IEnumerator PlaySoundAndLoad()
    {
        if (levelClickSound != null && clickClip != null)
        {
            levelClickSound.PlayOneShot(clickClip);
            yield return new WaitForSeconds(clickClip.length);
        }

        SceneManager.LoadScene("GameSceneLevel" + gameManager.levelProgress);
    }

}
