using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //references
    public Score score;
    public GameManager gameManager;
    public Sprite birdDied;
    public ColumnSpawner columnSpawner;

    SpriteRenderer sp;
    Animator anim;
    // Rigidbody2D component used on Bird object
    Rigidbody2D rb;
    public float speed;

    // Bird angle along Y-axis as bird only moves in vertical direction
    int angle;
    int maxAngle = 20;
    int minAngle = -90;
    bool touchedGround;

    // Start is called before the first frame update
    void Start()
    {
        // Get access to Rigidbody2D of bird
        rb = GetComponent<Rigidbody2D>();
        // Get access to SpriteRenderer of bird
        sp = GetComponent<SpriteRenderer>();
        // Get access to Animator of bird
        anim = GetComponent<Animator>();

        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetMouseButtonDown(0) is use to determine mouse left click
        if(Input.GetMouseButtonDown(0) &&
            // Check If game is not over yet
            GameManager.gameOver == false&&
            // Check If game is pause or
            GameManager.gameIsPaused == false) {
                // If game is not started yet or game is in pause state then start the game
                if(GameManager.gameHasStarted == false) {
                    rb.gravityScale = 0.8f;
                    Flap();
                    //column Spawner
                    columnSpawner.InstantiateColumn();
                    gameManager.GameHasStarted();
                } else {
                    Flap(); 
                }
            
        }

        BirdRotation();
    }

    void Flap(){
        // Vector2.zero == new Vector2(0, 0)
        rb.velocity = Vector2.zero;
        // To perform jump action on bird object 
        rb.velocity = new Vector2(rb.velocity.x, speed);
    }

    void BirdRotation()
    {
        // Bird is moving in upward direction
        if (rb.velocity.y > 0) {
            rb.gravityScale = 0.8f;
            if (angle <= maxAngle) {
                // Rotates bird in upward direction
                angle = angle + 4;
            }
        // Bird is moving in downward direction
        } else if (rb.velocity.y < 0) {
            rb.gravityScale = 0.6f;

            if(rb.velocity.y < -1.3f) {
                if (angle >= minAngle) {
                    // Rotates bird in downward direction
                    angle = angle - 3;
                }
            }
        }

        // If bird didn't touch the ground
        if(touchedGround == false) {
            // Set the rotation on z-axis
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        
    }

    // It calls when an object collides with box collider component with isTrigger enable
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Column")) {
            print("We have scored");
            score.Scored();
        } else if (collision.CompareTag("Pipe")) {
            //game over
            gameManager.GameOver();
        }
    }

    // It calls when an object collides with box collider component
    private void OnCollisionEnter2D(Collision2D collision) {
        // If gameObject collides with a ground
        if (collision.gameObject.CompareTag("Ground")) {
            // If game is not over yet
            if(GameManager.gameOver == false) {
                //game over
                gameManager.GameOver();
                GameOver();
            } else {
                GameOver();
            }
        }
    }

    void GameOver() {
        touchedGround = true;
        // Stop bird animation
        anim.enabled = false;
        // Set sprite for bird die
        sp.sprite = birdDied;
        // Set the rotation on z-axis
        transform.rotation = Quaternion.Euler(0, 0, -90);
    }
}
