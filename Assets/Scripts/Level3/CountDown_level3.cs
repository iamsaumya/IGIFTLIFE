using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountDown_level3: MonoBehaviour
{

    [SerializeField] private Text uiText;
    [SerializeField] private float mainTimer;


    public GameObject Score;
    private Player_score_level3 score;

    public GameObject VisitIGIFTLIFE;

    private float timer;
    private bool cancount = true;
    private bool doonce = false;

    private void Start()
    {
        timer = mainTimer;
        Score = GameObject.FindGameObjectWithTag("Score");
        score = Score.GetComponent<Player_score_level3>();

        GameObject gameover = GameObject.Find("Gameover");
        GameOver GameOver_script = gameover.GetComponent<GameOver>();
        GameOver_script.callingScence = SceneManager.GetActiveScene().buildIndex;
    }

    private void Update()
    {
        if (timer >= 0.0f && cancount)
        {
            timer -= Time.deltaTime;
            uiText.text = timer.ToString("F");
        }

        else if (timer <= 0.0f && !doonce)
        {
            cancount = false;
            doonce = true;
            uiText.text = "0.0";
            timer = 0.0f;

            if (score.points <= 6)
            {
                StartCoroutine(PauseForsec(15f));
            }

        }


    }

    IEnumerator PauseForsec(float delay)
    {
        VisitIGIFTLIFE.SetActive(true);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
