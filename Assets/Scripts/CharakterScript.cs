using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharakterScript : MonoBehaviour
{

    // Update is called once per frame
    public Image[] characterImages; // Assign in Inspector
    public Sprite[] char1Sprites;   // 2 sprites for Character 1
    public Sprite[] char2Sprites;   // 2 sprites for Character 2
    public Sprite[] char3Sprites;   // 2 sprites for Character 3

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
}
