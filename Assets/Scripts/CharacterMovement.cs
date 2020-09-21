using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading;

public class CharacterMovement : MonoBehaviour
{
    public Rigidbody rb = new Rigidbody();

    public float forwardForce = 1f;
    public float sidewaysForce = 100f;

    public float reSpeed;
    private float preVel;

    public float initialSpeed = .001f;

    public Transform player;
    public static ScoreTracker score;
    //public CharacterMovement movement;

    public GameObject playerDestroy;
    public GameObject overUI;
    public GameObject startUI;
    public Transform scoreMove;

    public static ScoreTracker finalScoreText;

    public bool gameStart = false;
    public bool alive = true;


    // Start is called before the first frame update
    void Start()
    {
        startUI.SetActive(true);
        overUI.SetActive(false);
        rb.velocity = new Vector3(0, 0, 0);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
     
        if (!gameStart)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                Started();
            }
        }
        else if(player.position.y > -2 - (player.position.y*.015f))
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0);
            }
        }
        if (gameStart && alive)
        {
            if (player.position.y > 0)
            {
                if (rb.velocity.z >= preVel)
                {
                    preVel = rb.velocity.z;
                }
                else
                {
                    rb.AddForce(0, 0, reSpeed * Time.deltaTime);
                }

                rb.AddForce(0, 0, forwardForce * Time.deltaTime);


            }
            else if (player.position.y < -8 - (player.position.z * .015))
            {
                alive = false;
                scoreMove.position = new Vector3(scoreMove.position.x, scoreMove.position.y - .2f, scoreMove.position.z);
                overUI.SetActive(true);
                rb.velocity = new Vector3(0, 0, 0);
                rb.useGravity = false;
                
            }
            else
            {

            }
        }
        else
        {
            if (Input.GetKey(KeyCode.R))
            {
                Restart();
            }
        }

    }

    public void Started()
    {
        gameStart = true;
        startUI.SetActive(false);
        rb.velocity = new Vector3(0, 0, initialSpeed);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}