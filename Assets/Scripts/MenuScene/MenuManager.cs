using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public Animator blackFadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        // Set game over to false as user can only open menu after game over
        GameManager.gameOver = false;
    }

    public void OnPlayBtnPressed() {
        // To play transition sound
        AudioManager.audiomanager.Play("transition");
        // SceneManager.LoadScene("Game");
        // To trigger fadeIn animation
        blackFadeAnim.SetTrigger("fadeIn");
    }

    public void OnRateBtnPressed()
    {
        #if UNITY_ANDROID
        // To open the web url
        Application.OpenURL("market://details?id=com.BroskisGames.FlappyTutorial");
        #endif
    }
}
