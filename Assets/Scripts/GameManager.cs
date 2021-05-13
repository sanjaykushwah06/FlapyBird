using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    public Text panelScore;

    // Game Score
    public static int gameScore;

    int drawScore;

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
        // As score is a GameObject so first we need to get script(Score) component
        // and then call the method "GetScore" of Score script to get the current score
        gameScore = score.GetComponent<Score>().GetScore();
        // Set visibility of score
        score.SetActive(false);
        // Calls method after 1 sec delay
        Invoke("ActivateGameOverCanvas", 1);
        // Set visible pause button
        pauseBtn.SetActive(false);
    }

    void ActivateGameOverCanvas() {
        // To play die sound
        AudioManager.audiomanager.Play("die");
        // Set visibility of game over canvas
        gameOverCanvas.SetActive(true);
    }

    public void OnOkBtnPressed() {
        // To play transition sound
        AudioManager.audiomanager.Play("transition");
        // SceneManager is used to load an active scene on specific index
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenuBtnPressed() {
        // To play transition sound
        AudioManager.audiomanager.Play("transition");
        // SceneManager is used to load Menu scene
        // SceneManager.LoadScene("Menu");
        // To trigger fadeIn animation
        blackFadeAnim.SetTrigger("fadeIn");
    }

    public void DrawScore()
    {
        if (drawScore <= gameScore)
        {
            panelScore.text = drawScore.ToString();
            drawScore++;
            Invoke("DrawScore", 0.05f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
