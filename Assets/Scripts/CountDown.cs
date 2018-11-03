using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown : MonoBehaviour {

    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;

    private float timer;
    private bool cancount = true;
    private bool doonce = false;

    private void Start()
    {
        timer = mainTimer;
    }

    private void Update()
    {
        if(timer>=0.0f && cancount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer<=0.0f && !doonce)
        {
            cancount = false;
            doonce = true;
            uiText.text = "0.0";
            timer = 0.0f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
    }
}
