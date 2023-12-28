using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleMenu : MonoBehaviour
{
    public string GameScene;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PlayGame()
    {
        Scoring.gamescore = 0;
        GameState.level = 1;
        SceneManager.LoadScene("Scenes/Level 1");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
