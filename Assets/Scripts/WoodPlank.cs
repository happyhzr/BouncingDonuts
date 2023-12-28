using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodPlank : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameState.state == GameState.gamePlay)
        {
            if (Input.GetKey("up"))
            {
                transform.Translate(0, 5 * Time.deltaTime, 0);
            }
            if (Input.GetKey("down"))
            {
                transform.Translate(0, -5 * Time.deltaTime, 0);
            }
        }
    }
}
