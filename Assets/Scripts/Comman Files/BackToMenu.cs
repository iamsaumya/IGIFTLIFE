using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class BackToMenu : MonoBehaviour {
    int SceneIndex;

    private void Start()
    {
        SceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    public void BackGame()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(SceneIndex - 1);
    }


}
