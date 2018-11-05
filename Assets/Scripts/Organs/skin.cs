using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skin : MonoBehaviour {

    public GameObject Score;
    private Player_score score;

    [SerializeField]
    private Transform skinplace;
    private Vector2 initialPosition;
    private float deltaX, deltaY;
    public static bool locked;

    private void Start()
    {
        initialPosition = transform.position;
        locked = false;
        Score = GameObject.FindGameObjectWithTag("Score");
        score = Score.GetComponent<Player_score>();
    }

    private void Update()
    {
        if(Input.touchCount > 0 && !locked)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                    {
                        deltaX = touchPos.x - transform.position.x;
                        deltaY = touchPos.y - transform.position.y;
                    }
                    break;

                case TouchPhase.Moved:
                    if (GetComponent<Collider2D>() == Physics2D.OverlapPoint(touchPos))
                        transform.position = new Vector2(touchPos.x - deltaX, touchPos.y - deltaY);
                    break;

                case TouchPhase.Ended:
                    if(Mathf.Abs(transform.position.x - skinplace.position.x) <= 0.5f &&
                            Mathf.Abs(transform.position.y - skinplace.position.y) <= 0.5f)
                    {
                        transform.position = new Vector2(skinplace.position.x, skinplace.position.y);
                        score.points += 1;
                        locked = true;
                        score.updateSceneIfNeeded();
                    }
                    else
                    {
                        transform.position = new Vector2(initialPosition.x, initialPosition.y);
                    }
                    break;
            }
        }
    }
}
