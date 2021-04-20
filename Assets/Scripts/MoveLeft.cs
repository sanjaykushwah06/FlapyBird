using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    // Can edit from Inspector View
    public float speed;

    BoxCollider2D box;

    float groundWidth;
    float pipeWidth;

    // Start is called before the first frame update
    void Start()
    {
        // To check if a game object has a "Ground" Tag
        if (gameObject.CompareTag("Ground")) {
            // Get access for BoxCollider2D
            box = GetComponent<BoxCollider2D>();
            // Get size from BoxCollider2D, Here it will be 1.68
            groundWidth = box.size.x;
          // To check if a game object has a "Column" Tag   
        } else if (gameObject.CompareTag("Column")) {
            // We have a prefab which has pipe but we can not get sixe of BoxCollider2D component from prefab, 
            // so it is required to fetch game-object of pipe and then get the size of BoxCollider2D component
            // Here we are retrieving game-object with tag and then get the size of BoxCollider2D component
            pipeWidth = GameObject.FindGameObjectWithTag("Pipe").GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check If game is not over yet
        if(GameManager.gameOver == false) {
            // Move object towards left direction
            transform.position = new Vector2(
                transform.position.x - speed * Time.deltaTime,
                transform.position.y);
        }
        
        if (gameObject.CompareTag("Ground")) {
            // The ground object completely moved towards left(Removed from screen)
            if (transform.position.x <= -groundWidth) {
                // Update x-axis position to extremly right of scene to make smooth ground movement
                transform.position = new Vector2(
                    transform.position.x + 2 * groundWidth,
                    transform.position.y);
            }   
            
        } else if (gameObject.CompareTag("Column")) {
            // Here we destroy column object if off from the screen
            if(transform.position.x < GameManager.bottomLeft.x - pipeWidth)
            {
                // Destroy the object
                Destroy(gameObject);
            }
        }
    }
}
