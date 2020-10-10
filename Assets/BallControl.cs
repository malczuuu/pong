using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private static readonly string PLAYER = "Player";

    public void Start()
    {
        ChooseInitialDirection();
    }

    private void ChooseInitialDirection()
    {
        float directionRanom = Random.Range(0.0f, 1.0f);
        if (directionRanom < 0.5f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-60.0f, 10.0f));
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(60.0f, 10.0f));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(PLAYER))
        {
            float ballVelocityX = GetComponent<Rigidbody2D>().velocity.x;
            float ballVelocityY = GetComponent<Rigidbody2D>().velocity.y;
            float colliderVelocityY = collision.collider.GetComponent<Rigidbody2D>().velocity.y;
            ballVelocityY = 0.5f * ballVelocityY + 0.33f * colliderVelocityY;
            GetComponent<Rigidbody2D>().velocity = new Vector2(ballVelocityX, ballVelocityY);
        }
    }
}
