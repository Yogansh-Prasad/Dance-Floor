using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMultiplier : MonoBehaviour
{

    public BoxCollider2D gridArea;
    private float poweruptimer;
    private float poweruptimerMax;

    [SerializeField]Player1Controller player1;
    [SerializeField]Player2Controller player2;


    private void Start()
    {
        RandomizePosition();
    }

    private void Awake()
    {
        poweruptimerMax = 10.0f;
        poweruptimer = poweruptimerMax;
    }

    private void Update()
    {
        poweruptimer += Time.deltaTime;
        if (poweruptimer >= poweruptimerMax)
        {

            RandomizePosition();
            poweruptimer -= poweruptimerMax;

        }
    }

    private void RandomizePosition()
    {
        Bounds bounds = gridArea.bounds;

        float x = Random.Range(bounds.min.x, bounds.max.x);
        float y = Random.Range(bounds.min.y, bounds.max.y);

        this.transform.position = new Vector3(Mathf.Round(x), Mathf.Round(y), 0);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == ("Player1"))
        {
            RandomizePosition();
            Player1Controller player1Controller = collision.GetComponent<Player1Controller>();
            player1Controller.scoremultiplier = 2;
        }

        if (collision.tag == ("Player2"))
        {
            RandomizePosition();
            Player2Controller player2Controller = collision.GetComponent<Player2Controller>();
            player2Controller.scoremultiplier = 2;
        }

        Invoke("ResetPowerup", 3f);


    }

    private void ResetPowerup() 
    {
        player1.scoremultiplier = 1;
        player2.scoremultiplier = 1;
    }
}