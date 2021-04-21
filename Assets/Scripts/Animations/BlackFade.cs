using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BlackFade : MonoBehaviour
{
    void OnBlackFadeFinished() {
        // To check if currently active scene is Menu
        if(SceneManager.GetActiveScene().name == "Menu") {
            // Load Game scene
            SceneManager.LoadScene("Game");
        // To check if currently active scene is Game    
        } else if(SceneManager.GetActiveScene().name == "Game"){
            // Load Menu scene
            SceneManager.LoadScene("Menu");
        }
    }
}
