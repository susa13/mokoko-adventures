using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Balloon : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movementX;
    [SerializeField] float movementY = 0;
    [SerializeField] float speed;
    [SerializeField] bool isFacingRight = true;
    [SerializeField] bool outOfBounds = false;
    [SerializeField] int timeInFrames = 0;

    // Start is called before the first frame update
    void Start()
    {
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        // sets speed based on level taken from Game Events
        // speed = (GameObject.Find("Game Events").GetComponent<ScoreKeeper>().GetLevel() + 1) * 5; 
        int level = SceneManager.GetActiveScene().buildIndex;
        speed = (level + 1) * 5;
        // Debug.Log("levell: " + GameObject.Find("Game Events").GetComponent<ScoreKeeper>().GetLevel());
        movementX = speed;
        // randomize position
        int xMin = -8 ;
        int xMax = 8;
        int yMin = -2;
        int yMax = -2;
        Vector2 position = new Vector2(UnityEngine.Random.Range(xMin, xMax), UnityEngine.Random.Range(yMin, yMax));
        transform.position = position;
        // modify size after 1 second and every .1 second after that
        InvokeRepeating("IncreaseInSize", 1.0f, 1.0f);
    }

    // Update is called once per frame
    void Update()
    {
        timeInFrames++; 
    }
    void FixedUpdate() {
        movementY = 5*(float)Math.Sin(Math.PI * timeInFrames/240);
        rigid.velocity = new Vector2(movementX, movementY);
        if(transform.position.x > 9 || transform.position.x < -9) {
            Flip();
            if(transform.position.x > 9)
                movementX = -speed;
            else if(transform.position.x <-9)
                movementX = speed;
        }
        if(transform.localScale.x > .1731f) { // restart if it gets too big
            GameObject.Find("Game Events").GetComponent<ScoreKeeper>().Restart();
        }
        
    }
    void Flip()
    {
        transform.Rotate(0, 180, 0);
        isFacingRight = !isFacingRight;
    }
    void IncreaseInSize() {
        transform.localScale += new Vector3(.01f, .01f, 0);
    }
    public int Points() {
        return (int)((0.1831f - transform.localScale.x) * 100);
    }
}
