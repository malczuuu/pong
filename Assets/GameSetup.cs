using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSetup : MonoBehaviour
{
    public Camera mainCamera;

    public BoxCollider2D topWall;
    public BoxCollider2D bottomWall;
    public BoxCollider2D leftWall;
    public BoxCollider2D rightWall;

    public float playersOffset = 50.0f;

    public Transform player;
    public Transform opponent;

    // Start is called before the first frame update
    public void Start()
    {
        SetupWalls();
        SetupPlayersFixed();
    }

    // Update is called once per frame
    public void Update()
    {
    }

    private void SetupWalls()
    {
        SetupTopWall();
        SetupBottomWall();
        SetupLeftWall();
        SetupRightWall();
    }

    private void SetupTopWall()
    {
        float topWallWidth = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2.0f, 0.0f, 0.0f)).x;
        float topWallOffset = mainCamera.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f)).y + 0.5f;
        topWall.size = new Vector2(topWallWidth, 1.0f);
        topWall.offset = new Vector2(0.0f, topWallOffset);
    }

    private void SetupBottomWall()
    {
        float bottomWallWidth = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width * 2.0f, 0.0f, 0.0f)).x;
        float bottomWAllOffset = (mainCamera.ScreenToWorldPoint(new Vector3(0.0f, Screen.height, 0.0f)).y + 0.5f) * -1.0f;
        bottomWall.size = new Vector2(bottomWallWidth, 1.0f);
        bottomWall.offset = new Vector2(0.0f, bottomWAllOffset);
    }

    private void SetupLeftWall()
    {
        float leftWallHeight = mainCamera.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 2.0f, 0.0f)).y;
        float leftWallOffset = (mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x + 0.5f) * -1.0f;
        leftWall.size = new Vector2(1.0f, leftWallHeight);
        leftWall.offset = new Vector2(leftWallOffset, 0.0f);
    }

    private void SetupRightWall()
    {
        float rightWallHeight = mainCamera.ScreenToWorldPoint(new Vector3(0.0f, Screen.height * 2.0f, 0.0f)).y;
        float rightWallOffset = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x + 0.5f;
        rightWall.size = new Vector2(1.0f, rightWallHeight);
        rightWall.offset = new Vector2(rightWallOffset, 0.0f);
    }

    private void SetupPlayers()
    {
        float opponentX = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, 0.0f, 0.0f)).x - 0.5f;
        float playerX = opponentX * -1.0f;
        player.position = new Vector3(playerX, player.position.y, player.position.z);
        opponent.position = new Vector3(opponentX, opponent.position.y, opponent.position.z);
    }

    private void SetupPlayersFixed()
    {
        float opponentX = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width - playersOffset, 0.0f, 0.0f)).x;
        float playerX = mainCamera.ScreenToWorldPoint(new Vector3(playersOffset, 0.0f, 0.0f)).x;
        player.position = new Vector3(playerX, player.position.y, player.position.z);
        opponent.position = new Vector3(opponentX, opponent.position.y, opponent.position.z);
    }
}
