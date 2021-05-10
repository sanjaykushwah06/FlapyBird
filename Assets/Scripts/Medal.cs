using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medal : MonoBehaviour
{
    // Sprite Image for normal medal
    public Sprite normalMedal;
    // Sprite Image for bronze medal
    public Sprite bronzeMedal;
    // Sprite Image for silver medal
    public Sprite silverMedal;
    // Sprite Image for gold medal
    public Sprite goldMedal;
    // Refrence of Image component
    Image img;

    // Start is called before the first frame update
    void Start()
    {
        // Get reference of Image component
        img = GetComponent<Image>();
        // Get current score from game manager script
        int gameScore = GameManager.gameScore;

        // Normal Medal
        if (gameScore > 0 && gameScore <= 2)
        {
            img.sprite = normalMedal;
        }
        // Bronze Medal
        else if (gameScore > 2 && gameScore <= 4)
        {
            img.sprite = bronzeMedal;
        }
        // Silver Medal
        else if (gameScore > 4 && gameScore <= 6)
        {
            img.sprite = silverMedal;
        }
        // Gold Medal
        else if (gameScore > 6)
        {
            img.sprite = goldMedal;
        }
    }

}
