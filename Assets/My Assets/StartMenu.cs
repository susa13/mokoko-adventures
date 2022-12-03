using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StartMenu : MonoBehaviour
{
    // [SerializeField] bool paused = false;
    [SerializeField] GameObject[] pauseModeObjects;
    [SerializeField] bool inSettings = false, inLeaderboards = false;
    [SerializeField] GameObject panel, play, setting, volumeBar, leaderboardButt, leaderboard;


    // Start is called before the first frame update
    void Start()
    {
        pauseModeObjects = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        setting = GameObject.Find("Setting/Text (TMP)");
        foreach (GameObject g in pauseModeObjects) {
            g.SetActive(false);
        }
        volumeBar.GetComponent<Slider>().value = GameObject.Find("PersistentData").GetComponent<PersistentData>().GetVolume();
        leaderboard = GameObject.Find("LeaderboardPanel");
       // AudioListener.volume = volumeBar.GetComponent<Slider>().value;
        volumeBar.SetActive(false);
        Debug.Log(gameObject.GetComponent<ScoreKeeper>().GetLevel());
        if(gameObject.GetComponent<ScoreKeeper>().GetLevel() == 0)
            leaderboard.transform.GetChild(0).GetComponent<TMP_Text>().text = "High Scores:";
            PersistentData p = GameObject.Find("PersistentData").GetComponent<PersistentData>();
            foreach (int a in p.GetHighScores()) {
                leaderboard.transform.GetChild(0).GetComponent<TMP_Text>().text += "\n" + a;
            }
            leaderboard.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if(Input.GetKeyDown(KeyCode.Escape)) { 
        //     Pause();
        // }
    }
    // public void Pause() {
    //     paused = !paused;
    //     if(paused) {
    //         Time.timeScale = 0.0f;
    //         foreach (GameObject g in pauseModeObjects) {
    //             g.SetActive(true);
    //         }
    //     }
    //     else {
    //         Time.timeScale = 1.0f;
    //         foreach (GameObject g in pauseModeObjects) {
    //             g.SetActive(false);
    //         }
    //     }
    //     Debug.Log("Pause pressed");
    // }
    public void changeScene(int s) {
        SceneManager.LoadScene(s);
    }
    public void settingsButton() {
        inSettings = !inSettings;
        if(inSettings) {
            panel.SetActive(false);
            play.SetActive(false);
            volumeBar.SetActive(true);
            if(gameObject.GetComponent<ScoreKeeper>().GetLevel() == 0)
                leaderboardButt.SetActive(false);
            setting.GetComponent<TMP_Text>().text = "Go back";
        }
        else {
            panel.SetActive(true);
            play.SetActive(true);
            volumeBar.SetActive(false);
            if(gameObject.GetComponent<ScoreKeeper>().GetLevel() == 0)
                leaderboardButt.SetActive(true);
            setting.GetComponent<TMP_Text>().text = "Setting";
        }
    }
    public void leaderboardButton() {
        inLeaderboards = !inLeaderboards;
        if(inLeaderboards) {
            panel.SetActive(false);
            play.SetActive(false);
            leaderboard.SetActive(true);
            setting.gameObject.transform.parent.gameObject.SetActive(false);
            leaderboardButt.transform.GetChild(0).GetComponent<TMP_Text>().text = "Go back";
        }
        else {
            panel.SetActive(true);
            play.SetActive(true);
            leaderboard.SetActive(false);
            setting.gameObject.transform.parent.gameObject.SetActive(true);
            leaderboardButt.transform.GetChild(0).GetComponent<TMP_Text>().text = "Leaderboard";
        }
    }
}
