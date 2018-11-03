using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_score : MonoBehaviour {

    [SerializeField] private Text uiText;
    
    

    public int points = 0;
    public void updateSceneIfNeeded() // <-- ADD THIS FUNCTION TO THE "OBSERVER SCRPIT AND REMOVE IT FROM THERE CUT AND PAST IT THERE"
    {
        Debug.Log("The actual score is" + points);
        if (points == 5)
        {
            SceneManager.LoadScene(2);
        }
    }

    private void Update()
    {
        uiText.text = points.ToString();
    }
}
