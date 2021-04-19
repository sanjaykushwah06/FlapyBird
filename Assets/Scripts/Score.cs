using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    int score;
    int highScore;
    Text scoreText;

    //references
    public Text panelScore;
    public Text panelHighScore;
    public GameObject newImg;

    // Start is called before the first frame update
    void Start()
    {
        // Initial score
        score = 0;
        // Get access to Text component of canvas
        scoreText = GetComponent<Text>();
        // Convert integer to string and set text of Text component
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        // Get the high score stored in local memory
        highScore = PlayerPrefs.GetInt("highscore");
        panelHighScore.text = highScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Scored() {
        score++;
        scoreText.text = score.ToString();
        panelScore.text = score.ToString();
        // When achieved new high score
        if(score > highScore) {
            highScore = score;
            panelHighScore.text = highScore.ToString();
            // Store high score value in memory
            PlayerPrefs.SetInt("highscore", highScore);
            // To visible new image
            newImg.SetActive(true);
        }
    }
}
