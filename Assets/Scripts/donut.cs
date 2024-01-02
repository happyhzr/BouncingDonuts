using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class donut : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    float levelCompleteTimer;
    float gameOverTimer;
    AudioSource boingA;
    AudioSource boingB;
    AudioSource boingC;

    // Start is called before the first frame update
    void Start()
    {
        levelCompleteTimer = 5.0f;
        gameOverTimer = 5.0f;
        rigidBody = GetComponent<Rigidbody2D>();
        AudioSource[] audios = GetComponents<AudioSource>();
        boingA = audios[0];
        boingB = audios[1];
        boingC = audios[2];
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
                else if (GameState.level == 2)
                {
                    GameState.level = 3;
                    SceneManager.LoadScene("Scenes/Level 3");
                }
                else if (GameState.level == 3)
                {
                    GameState.level = 4;
                    SceneManager.LoadScene("Scenes/Level 4");
                }
                else if (GameState.level == 4)
                {
                    GameState.level = 5;
                    SceneManager.LoadScene("Scenes/Level 5");
                }
                else
                {
                    GameState.state = GameState.gameOver;
                }
            }
        }
        if (GameState.state == GameState.gameOver)
        {
            gameOverTimer -= Time.deltaTime;
            if (gameOverTimer < 0.0f)
            {
                GameState.state = GameState.gamePlay;
                SceneManager.LoadScene("Scenes/Title");
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "WoodPlank")
        {
            Scoring.gamescore += 10;
            boingA.Play();
        }
        if (collision.gameObject.name == "Sphere")
        {
            Scoring.gamescore += 50;
            boingB.Play();
        }
        if (collision.gameObject.name == "DonutBox")
        {
            Scoring.gamescore += 100;
            boingC.Play();
            GameState.state = GameState.levelComplete;
        }
    }
}
