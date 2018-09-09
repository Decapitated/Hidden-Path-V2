using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereMove : MonoBehaviour {

    private Vector3 startPos;

    public Rigidbody rb;
    private float speed;

    public bool l_or_r; //right is true, left is false

    private Text score;
    private int scoreCount = 0;
    private int highScore;

	// Use this for initialization
	void Start () {
        startPos = new Vector3(0.0f, -7.965f, 0.0f);
        transform.position = startPos;

        rb = GetComponent<Rigidbody>();   

        speed = 3.0f;

        score = GameObject.Find("Canvas").GetComponentInChildren<Text>();
        score.text = scoreCount + "";
        Time.timeScale = 0.25f;
        highScore = PlayerPrefs.GetInt("highscore", 0);
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0.0f, -9.81f, 0.0f), ForceMode.Acceleration);
    }

    // Update is called once per frame
    void Update () {
        if(Time.timeScale < 1.0f && Time.timeScale != 0)
        {
            Time.timeScale += 0.5f * Time.deltaTime;
        }else
        {
            Time.timeScale = 1.0f;
        }
        MoveSphere();
        UpdateScore();
        Gameover();
    }

    void MoveSphere()
    {
        float currentZ = transform.position.z;
        float currentX = transform.position.x;

        if (l_or_r)
        {
            transform.position = new Vector3(currentX + speed * Time.deltaTime, transform.position.y, currentZ);
        }
        else if (!l_or_r)
        {
            transform.position = new Vector3(currentX, transform.position.y, currentZ + speed * Time.deltaTime);
        }

        if (Input.GetMouseButtonDown(0) /*&& gameStart == true*/)
        {
            l_or_r = !l_or_r;
        }
    }

    void UpdateScore()
    {
        scoreCount = (int)Mathf.Floor(transform.position.x + transform.position.z);
        score.text = scoreCount + "";
    }

    void Gameover()
    {
        if(transform.position.y < (startPos.y - 1.0f))
        {
            Time.timeScale = 0;
            if(scoreCount > highScore)
            {
                highScore = scoreCount;
                PlayerPrefs.SetInt("highscore", scoreCount);
            }
        }
    }
}