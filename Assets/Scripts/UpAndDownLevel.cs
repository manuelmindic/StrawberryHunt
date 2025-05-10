using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class UpAndDownLevel : MonoBehaviour
{
    public Vector3 originPos;
    public float speed = 2f;
    public float height = 8f;
    public Button[] LevelButtons;

    public AudioSource levelClickSound;

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
        Debug.Log("audiooo");
        levelClickSound.Play();
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
