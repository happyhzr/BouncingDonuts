using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class donut : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float levelCompleteTimer;
    // Start is called before the first frame update
    void Start()
    {
        levelCompleteTimer = 5.0f;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.state == GameState.gamePlay)
        {
            if (transform.position.y < -10.0f)
            {
                GameState.state = GameState.gameOver;
            }
        }
        if (GameState.state == GameState.levelComplete)
        {
            rigidBody.velocity = Vector2.zero;
            levelCompleteTimer -= Time.deltaTime;
            if (levelCompleteTimer < 0.0f)
            {
                if (GameState.level == 1)
                {
                    GameState.level = 2;
                    SceneManager.LoadScene("Scenes/Level 2");
                }
                else
                {
                    GameState.state = GameState.gameOver;
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WoodPlank")
        {
            Scoring.gamescore += 10;
        }
        if (collision.gameObject.name == "Sphere")
        {
            Scoring.gamescore += 50;
        }
        if (collision.gameObject.name == "DonutBox")
        {
            Scoring.gamescore += 100;
            GameState.state = GameState.levelComplete;
        }
    }
}
