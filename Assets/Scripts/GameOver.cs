using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    public int callingScence;

    public void TryAgain()
    {  if (callingScence == SceneManager.GetActiveScene().buildIndex - 1)
            SceneManager.LoadScene(1);
        else
            SceneManager.LoadScene(1);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
