using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    [SerializeField] GameObject PersistentData;
    [SerializeField] Slider slider;
    [SerializeField] Button button;
    // Start is called before the first frame update
    void Start()
    {
        PersistentData = GameObject.Find("PersistentData");
        try {
            slider = gameObject.GetComponent<Slider>();
            slider.onValueChanged.AddListener(
                delegate {UpdateBar();}
            );
        } catch(System.Exception e) {
            Debug.Log(e);
        }
        try {
            button = gameObject.GetComponent<Button>();
            button.onClick.AddListener(
                delegate {PersistentData.GetComponent<PersistentData>().AddToLeaderboard();}
            );
        } catch (System.Exception e) {
            Debug.Log(e);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateBar() {
        PersistentData.GetComponent<PersistentData>().SetVolume();
    }
}
