using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragNDrop : MonoBehaviour
{


    Vector2 startPos;

    public GameObject Score;
    private Player_score score; 
    // Use this for initialization
    void Start()
    {
        startPos = this.transform.position;
        Score = GameObject.FindGameObjectWithTag("Score");
        score = Score.GetComponent<Player_score>();
    }

    // Update is called once per frame
    void Update()
    {

        //Gets the world position of the mouse on the screen        
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Checks whether the mouse is over the sprite
        bool overSprite = this.GetComponent<SpriteRenderer>().bounds.Contains(mousePosition);

        //If it's over the sprite
        if (overSprite)
        {
            //If we've pressed down on the mouse (or touched on the iphone)
            if (Input.GetButton("Fire1"))
            {
                //Set the position to the mouse position
                this.transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                                    Camera.main.ScreenToWorldPoint(Input.mousePosition).y,
                                                      0.0f);


            }
            else
            {
                this.transform.position = startPos;
            }
        }



    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //  use else if to reduse computation power . also this method is not optimal , there is a better ans shoter way of doing things , but let's just keep it simple 

        if ((collision.gameObject.tag == "heart" && gameObject.tag == "heart") || (collision.gameObject.tag == "kidney" && gameObject.tag == "kidney"))
        {
            //  Debug.Log("Hello");
            score.points += 1;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            score.updateSceneIfNeeded();
        }

        if ((collision.gameObject.tag == "liver" && gameObject.tag == "liver") || (collision.gameObject.tag == "pancreas" && gameObject.tag == "pancreas"))
        {
            //  Debug.Log("Hello");
            score.points += 1;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            score.updateSceneIfNeeded();

        }

        if (collision.gameObject.tag == "lungs" && gameObject.tag == "lungs")
        {
            //  Debug.Log("Hello");
            score.points += 1;
            Destroy(gameObject);
            Destroy(collision.gameObject);
            score.updateSceneIfNeeded();
        }

    }


}
