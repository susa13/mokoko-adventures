using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{

    [SerializeField] Text scoreText;
    [SerializeField] int score = 0;
    [SerializeField] int level;

    // Start is called before the first frame update

    void Start()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if(level == 0)
            GameObject.Find("PersistentData").GetComponent<PersistentData>().Reset();
        else if(level == 4) {
            GameObject.Find("Panel/Text (TMP)").GetComponent<TMP_Text>().text += GameObject.Find("PersistentData").GetComponent<PersistentData>().GetScore();
        }
        else if(level > 0) {
            if(scoreText == null) {
                scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
            }
            scoreText.text = "Score: " + GameObject.Find("PersistentData").GetComponent<PersistentData>().GetScore();
        }
        // Debug.Log("level wow: " + GetLevel());
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AddPoints(int points) {
        GameObject.Find("PersistentData").GetComponent<PersistentData>().AddPoints(points);
        // score += points;
        // scoreText.text = "Score: " + score;
        // if(score > 10) {
        //     score = 0;
        //     SceneChange();
        // }
    }
    public void SceneChange() {
        SceneManager.LoadScene(level + 1);
    }
    public void Restart() {
        SceneManager.LoadScene(level);
    }
    public void ToIntroduction() {
        SceneManager.LoadScene(0);
    }
    public int GetLevel() {
        return level;
    }
}
