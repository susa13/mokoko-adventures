using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PersistentData : MonoBehaviour
{
    [SerializeField] PersistentData Instance;
    [SerializeField] static bool instanceExists = false;
    [SerializeField] int score;
    [SerializeField] float volume;
    [SerializeField] List<int> highScores = new List<int>();

    // Start is called before the first frame update
    void Awake() {
        if (Instance == null && !instanceExists)
        {
            DontDestroyOnLoad(this);
            Instance = this;
            instanceExists = true;
        }
        else
            Destroy(gameObject);
        score = 0;
        volume = 0.75f;  
        GameObject.Find("Slider").GetComponent<Slider>().value = volume;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddPoints(int points) {
        score += points;
    }
    public int GetScore() {
        return score;
    }
    public void Reset() {
        score = 0;
    }
    public void SetVolume() {
        volume = GameObject.Find("Slider").GetComponent<Slider>().value;
        AudioListener.volume = volume;
    }
    public float GetVolume() {
        return volume;
    }
    public void AddToLeaderboard() {
        highScores.Add(score);
        highScores.Sort();
        highScores.Reverse();
    }
    public List<int> GetHighScores() {
        return highScores;
    }
}
