using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScriptDetails : MonoBehaviour
{
    public float speed = 2f;
    public float height = 8f;
    
    public Vector3 originPos;

    public Button LevelButton;

    void Start()
    {
        originPos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        checkUnlockedLevel();
    }

   
    public void checkUnlockedLevel()
    {
        if(LevelButton.interactable == true)
        {
            float newY = Mathf.Sin(Time.time * speed) * height;
            transform.localPosition = originPos + new Vector3(0, newY, 0);
        }
    }
}
