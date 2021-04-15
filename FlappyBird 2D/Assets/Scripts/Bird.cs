using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // Rigidbody2D component used on Bird object
    Rigidbody2D rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        // Get access to Rigidbody2D of bird
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Input.GetMouseButtonDown(0) is use to determine mouse left click
        if(Input.GetMouseButtonDown(0)) {

            // Vector2.zero == new Vector2(0, 0)
            rb.velocity = Vector2.zero;
            // To perform jump action on bird object 
            rb.velocity = new Vector2(rb.velocity.x, speed);
        }
    }
}
