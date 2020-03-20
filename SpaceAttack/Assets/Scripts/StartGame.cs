using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ScreenSwitching()
    {
        SceneManager.LoadScene("SpaceGame");
        PlayerControls.playerLives = 5;
        UseCoroutines.column = 0;
    }
}
