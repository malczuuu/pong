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
    }
}
