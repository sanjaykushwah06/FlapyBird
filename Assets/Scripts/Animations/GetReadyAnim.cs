using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetReadyAnim : MonoBehaviour
{
    // Refrence of Bird Script
    public Bird bird;

    void OnGetRadyAnimEnds()
    {
        // Call methof of Bird script to start game
        bird.OnGetReadyAnimFinished();
    }
}
