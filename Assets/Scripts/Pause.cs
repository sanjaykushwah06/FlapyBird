using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    Image img;

    //references
    public Sprite playSprite;
    public Sprite pausedSprite;

    // Start is called before the first frame update
    private void Start()
    {
        img = GetComponent<Image>();
    }

    public void OnPauseGame() {
        if(GameManager.gameIsPaused == false) {
            // To freeze the game
            Time.timeScale = 0;
            // To set play icon(Sprite)
            img.sprite = playSprite;
            GameManager.gameIsPaused = true;
        } else {
            // To continue the game
            Time.timeScale = 1;
            // To set pause icon(Sprite)
            img.sprite = pausedSprite;
            GameManager.gameIsPaused = false;
        }
    }
}
