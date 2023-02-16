using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightController : MonoBehaviour
{
    public float speed = 5.0f;
    public Vector2 maximumBoundary = new Vector2(1, 1);
    public Vector2 minimumBoundary = new Vector2(1, 1);
    private Rigidbody2D rb;
    float timePassed = 0f;
    
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LightMotion();
        

    }
    private void Update()
    {
        
        timePassed += Time.deltaTime;
        //Time.timeScale = 0;
        if (timePassed > 4f)
        {
            LightMotion();
        }
    }
    private void FixedUpdate()
    {
        Vector2 position = transform.position;
        if (position.x > maximumBoundary.x ||(position.y) > maximumBoundary.y || (position.x) < minimumBoundary.x || (position.y) < minimumBoundary.y)
        {
            rb.velocity = -rb.velocity;
        }
    }

    private void LightMotion() 
    {
        Vector2 randomDirection = Random.insideUnitCircle * speed;
        rb.velocity = randomDirection;
        
        timePassed = 0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            Player1Controller Player1 = collision.GetComponent<Player1Controller>();
            Player1.LightPenalty();
        }
        if (collision.tag == "Player2")
        {
            Player2Controller Player2 = collision.GetComponent<Player2Controller>();
            Player2.LightPenalty();
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player1")
        {
            Player1Controller Player1 = collision.GetComponent<Player1Controller>();
            Player1.ResetSpeed();
        }
        if (collision.tag == "Player2")
        {
            Player2Controller Player2 = collision.GetComponent<Player2Controller>();
            Player2.ResetSpeed();
        }

    }
}
