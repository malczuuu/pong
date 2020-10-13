using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static int playerScore = 0;
    public static int opponentScore = 0;

    public GUISkin skin;

    public static void Score(string wallName)
    {
        if (wallName == "leftWall")
        {
            ++opponentScore;
        }
        else if (wallName == "rightWall")
        {
            ++playerScore;
        }
    }

    public void OnGUI()
    {
        GUI.skin = skin;
        GUI.Label(new Rect(Screen.width * 0.4f - 12.0f, 20.0f, 100.0f, 100.0f), "" + playerScore);
        GUI.Label(new Rect(Screen.width * 0.6f - 12.0f, 20.0f, 100.0f, 100.0f), "" + opponentScore);

        if (GUI.Button(new Rect(Screen.width / 2.0f - 121.0f / 2.0f, 23.0f, 121.0f, 53.0f), "RESET"))
        {
            playerScore = 0;
            opponentScore = 0;
            GameObject.FindGameObjectWithTag("Ball").SendMessage("ResetBall");
        }
    }
}
