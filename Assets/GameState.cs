using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static int state;
    public const int gamePlay = 1;
    public const int gameOver = 2;
    // Start is called before the first frame update
    void Start()
    {
        state = gamePlay;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
