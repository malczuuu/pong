using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private static readonly string PLAYER = "Player";

    public float ballSpeed = 100.0f;

    public void Start()
    {
        StartCoroutine(GoBallAfterSecond(1.0f));
    }

    private IEnumerator GoBallAfterSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        GoBall();
    }

    private void GoBall()
    {
        if (GetComponent<Rigidbody2D>().velocity != new Vector2(0.0f, 0.0f))
        {
            return;
        }
        float directionRanom = Random.Range(0.0f, 1.0f);
        if (directionRanom < 0.5f)
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(-ballSpeed, 10.0f));
        }
        else
        {
            GetComponent<Rigidbody2D>().AddForce(new Vector2(ballSpeed, 10.0f));
        }
    }

    private void ResetBall()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, 0.0f);
        GetComponent<Transform>().position = new Vector2(0.0f, 0.0f);
        StartCoroutine(GoBallAfterSecond(0.5f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag(PLAYER))
        {
            float ballVelocityX = GetComponent<Rigidbody2D>().velocity.x;
            float ballVelocityY = GetComponent<Rigidbody2D>().velocity.y;
            if (ballVelocityX != 0.0f && ballVelocityX != 0.0f)
            {
                float colliderVelocityY = collision.collider.GetComponent<Rigidbody2D>().velocity.y;
                ballVelocityY = 0.5f * ballVelocityY + 0.33f * colliderVelocityY;
                GetComponent<Rigidbody2D>().velocity = new Vector2(ballVelocityX, ballVelocityY);
            }
            GetComponent<AudioSource>().pitch = Random.Range(0.8f, 1.2f);
            GetComponent<AudioSource>().Play();
        }
    }

    private void Update()
    {
        float ballVelocityX = GetComponent<Rigidbody2D>().velocity.x;
        if (ballVelocityX != 0.0f)
        {
            if (ballVelocityX > 0.0f && ballVelocityX < 14.0f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(16.0f, GetComponent<Rigidbody2D>().velocity.y);
            }
            else if (ballVelocityX < 0.0f && ballVelocityX > -14.0f)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-16.0f, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
    }
}
