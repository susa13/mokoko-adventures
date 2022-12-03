using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movementtest : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigid;
    [SerializeField] float movement;

    // Start is called before the first frame update
    void Start()
    {
        if(rigid == null)
            rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    // Good for user input
    void Update()
    {
        Input.GetAxis("Horizontal");
    }
    // called potentially multiple times per frame
    // use for physics/movement
    void FixedUpdate() {

    }
}
