using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] bool paused = false;
    [SerializeField] GameObject[] pauseModeObjects;
    [SerializeField] bool inSettings = false;
    [SerializeField] GameObject resume, mainMenu, setting, volumeBar;


    // Start is called before the first frame update
    void Start()
    {
        pauseModeObjects = GameObject.FindGameObjectsWithTag("ShowWhenPaused");
        setting = GameObject.Find("Setting/Text (TMP)");
        foreach (GameObject g in pauseModeObjects) {
            g.SetActive(false);
        }
        volumeBar.GetComponent<Slider>().value = GameObject.Find("PersistentData").GetComponent<PersistentData>().GetVolume();
        // AudioListener.volume = volumeBar.GetComponent<Slider>().value;
        volumeBar.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) { 
            if(inSettings)
                settingsButton();
            Pause();
        }
    }
    public void Pause() {
        paused = !paused;
        if(paused) {
            Time.timeScale = 0.0f;
            foreach (GameObject g in pauseModeObjects) {
                g.SetActive(true);
                volumeBar.SetActive(false);
            }
        }
        else {
            Time.timeScale = 1.0f;
            foreach (GameObject g in pauseModeObjects) {
                g.SetActive(false);
            }
        }
        Debug.Log("Pause pressed");
    }
    public void changeScene(int s) {
        SceneManager.LoadScene(s);
        Time.timeScale = 1.0f;
    }
    public void settingsButton() {
        inSettings = !inSettings;
        if(inSettings) {
            resume.SetActive(false);
            mainMenu.SetActive(false);
            volumeBar.SetActive(true);
            setting.GetComponent<TMP_Text>().text = "Go back";
        }
        else {
            resume.SetActive(true);
            mainMenu.SetActive(true);
            volumeBar.SetActive(false);
            setting.GetComponent<TMP_Text>().text = "Setting";
        }
    }
}
