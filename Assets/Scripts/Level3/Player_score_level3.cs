﻿using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_score_level3 : MonoBehaviour
{

    [SerializeField] private Text uiText;

    public GameObject NxtLevelinstructionUI;

    public int points = 0;
    public void updateSceneIfNeeded() // <-- ADD THIS FUNCTION TO THE "OBSERVER SCRPIT AND REMOVE IT FROM THERE CUT AND PAST IT THERE"
    {
        Debug.Log("The actual score is" + points);
        if (points == 7)
        {
            StartCoroutine(PauseForsec(8f));
        }
    }

    IEnumerator PauseForsec(float delay)
    {
        NxtLevelinstructionUI.SetActive(true);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private void Update()
    {
        uiText.text = points.ToString();
    }
}
