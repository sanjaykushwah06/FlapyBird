using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnSpawner : MonoBehaviour
{
    public GameObject column;
    public float maxY;
    public float minY;
    float randY;
    // Maximum time to create new refrence of column object
    public float maxTime;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        // InstantiateColumn();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver == false &&
            GameManager.gameHasStarted == true) {
            // Increment a timer
            timer += Time.deltaTime;
            if (timer >= maxTime) {
                InstantiateColumn();
                timer = 0;
            }
        }
        
    }

    public void InstantiateColumn() {

        // Instantiate a new game object with already created object
        GameObject newColumn = Instantiate(column);
        // Get random value for Y-axis
        randY = Random.Range(minY, maxY);
        // Set position of newly created game object
        newColumn.transform.position = new Vector2(
            transform.position.x,
            randY);
    }
}
