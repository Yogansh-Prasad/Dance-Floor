using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Controller : MonoBehaviour
{

    [SerializeField] float speed;
    private bool free = true;
    public int score = 0;
    public int scoremultiplier;
    [SerializeField]ScoreController scoreController;


    private void Start()
    {
        StartCoroutine(IncreaseScore());
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal WASD");
        float vertical = Input.GetAxisRaw("Vertical WASD");

        MoveCharacter(horizontal, vertical);
        PlayerMovementAnimation(horizontal, vertical);

    }


    private void MoveCharacter(float horizontal, float vertical)
    {
        Vector3 position = transform.position;
        position.x = position.x + horizontal * speed * Time.deltaTime;
        position.y = position.y + vertical * speed * Time.deltaTime;
        transform.position = position;



    }

    private void PlayerMovementAnimation(float horizontal, float vertical)
    {


        Vector3 scale = transform.localScale;

        if (horizontal < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (horizontal > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }

        if (vertical < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }

        else if (vertical > 0)
        {
            scale.x = Mathf.Abs(scale.x);
        }


        transform.localScale = scale;


    }

    public void LightPenalty()
    {
        speed = 0;
        
    }

    public void ResetSpeed()
    {
        speed = 8;
        
    }
    IEnumerator IncreaseScore()
    {
        while (true)
        {
            if (free)
            {
                scoreController.IncreaseScoreP2(scoremultiplier);
            }
            
            yield return new WaitForSeconds(.1f);
        }

    }
}
