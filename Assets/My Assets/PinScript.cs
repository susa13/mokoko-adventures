using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinScript : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;
    [SerializeField] GameObject player;
    [SerializeField] GameObject scoreKeeper;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        if (rigid == null)
            rigid = GetComponent<Rigidbody2D>();
        if(player == null)
            player = GameObject.FindGameObjectWithTag("Player");
        if(!player.GetComponent<Movement>().right()) {
            movement = -speed;
        } else {
            movement = speed;
        }
        rigid.velocity = new Vector2(movement, 0);
        if(scoreKeeper == null)
            scoreKeeper = GameObject.Find("Game Events");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        if(transform.position.x > 10 || transform.position.x < -10) {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.tag == "Balloon") {
            Debug.Log("hit!");
                GameObject.Find("Sound").GetComponent<Sound>().playSound();
            int pointsToAdd = GameObject.Find("balloon").GetComponent<Balloon>().Points();
            Debug.Log("points: " + pointsToAdd);
            scoreKeeper.GetComponent<ScoreKeeper>().AddPoints(pointsToAdd);
            scoreKeeper.GetComponent<ScoreKeeper>().SceneChange();
            Destroy(gameObject);
            Destroy(collider.gameObject);
        }
    }
}
