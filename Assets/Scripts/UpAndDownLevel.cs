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
    public Button LevelButton1;
    public Button LevelButton2;
    public Button LevelButton3;

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
        if (LevelButton1.interactable == true )
        {
            Debug.Log("WARRRUUMM");
            float newY = Mathf.Sin(Time.time * speed) * height;
            transform.localPosition = originPos + new Vector3(0, newY, 0);
        } 
        
    }
    public void pressNextLevel()
    {
        if (LevelButton1.interactable == true || LevelButton2.interactable == true)
        {
            Debug.Log("audiooo");
            levelClickSound.Play();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

}
