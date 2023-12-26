using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public static int gamescore;
    // Start is called before the first frame update
    void Start()
    {
        gamescore = 0;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private void OnGUI()
    {
        GUI.skin.box.fontSize = 30;
        GUI.Box(new Rect(20, 20, 200, 50), "Score: " + gamescore);
        if (GameState.state == GameState.gameOver)
        {
            GUI.skin.box.fontSize = 60;
            GUI.Box(new Rect(Screen.width / 2 - 200, Screen.height / 2 - 50, 400, 100), "Game Over");
        }
    }
} 
