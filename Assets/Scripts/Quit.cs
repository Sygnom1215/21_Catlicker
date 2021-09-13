using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    void Start()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            GameQuit();
    }

    public void GameQuit()
    {
        Application.Quit();
    }
}
