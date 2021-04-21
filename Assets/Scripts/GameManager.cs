using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //references
    public GameObject gameOverCanvas;
    public GameObject score;
    public GameObject getReadyImg;
    public GameObject pauseBtn;
    public Animator blackFadeAnim;

    // A static variable that can be access using class name
    public static Vector2 bottomLeft;

    //game states
    public static bool gameOver;
    public static bool gameHasStarted;
    public static bool gameIsPaused;

    // It runs before the Start method
    private void Awake() {
        // To get the bottom-left position of device
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameHasStarted = false;
        gameIsPaused = false;
    }

    public void GameHasStarted() {
        gameHasStarted = true;
        // To visible score view
        score.SetActive(true);
        // To hide get ready view
        getReadyImg.SetActive(false);
        // Set visible pause button
        pauseBtn.SetActive(true);
    }

    public void GameOver() {
        gameOver = true;
        // Set visibility of score
        score.SetActive(false);
        // Set visibility of game over canvas
        gameOverCanvas.SetActive(true);
        // Set visible pause button
        pauseBtn.SetActive(false);
    }


    public void OnOkBtnPressed() {
        // SceneManager is used to load an active scene on specific index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuBtnPressed() {
        // SceneManager is used to load Menu scene
        // SceneManager.LoadScene("Menu");
        // To trigger fadeIn animation
        blackFadeAnim.SetTrigger("fadeIn");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
