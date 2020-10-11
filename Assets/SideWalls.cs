using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWalls : MonoBehaviour
{
    private static readonly string BALL = "Ball";

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.name == BALL)
        {
            string wallName = GetComponent<Transform>().name;
            GameManager.Score(wallName);
            collider.gameObject.SendMessage("ResetBall");
        }
    }
}
