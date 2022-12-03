using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonSpawner : MonoBehaviour
{
    [SerializeField] GameObject balloon;

    // Start is called before the first frame update
    void Start()
    {
        // if(balloon == null) {
        //     balloon = GameObject.FindGameObjectWithTag("Balloon");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        // Spawn();
    }
    void Spawn() {
        if(GameObject.FindGameObjectWithTag("Balloon") == null)
            Instantiate(balloon, new Vector3((float)-2.76, -2, 0), Quaternion.identity);
    }
}
