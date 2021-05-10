using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverAnim : MonoBehaviour
{
    public GameObject medal;

    public GameManager gameManager;

    void OnGameOverAnimEnds() {
        // Set visibility of medal canvas
        medal.SetActive(true);
        //draw the score
        gameManager.DrawScore();
    }
}
