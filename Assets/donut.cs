using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class donut : MonoBehaviour
{
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.state == GameState.gameOver)
        {
            //gameObject.SetActive(false);
            rb.velocity = Vector2.zero;
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
        if (collision.gameObject.name == "donutbox")
        {
            Scoring.gamescore += 100;
            GameState.state = GameState.gameOver;
        }
    }
}
