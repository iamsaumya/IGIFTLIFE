using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
    public GameObject Level1instructionUI;
    public void PlayGame()
    {
        StartCoroutine(PauseForsec(10f));
    }

    IEnumerator PauseForsec(float delay)
    {
        Level1instructionUI.SetActive(true);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

     
   
}
