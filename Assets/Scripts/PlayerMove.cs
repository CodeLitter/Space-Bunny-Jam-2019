using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

    public float Speed;
    //public float LaunchSpeed;
    private Rigidbody rb;

    void Start()
    {
        //Detects and get RB from object
        rb = GetComponent<Rigidbody>();  
	}

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVerticle = Input.GetAxis("Vertical");
        
        Vector3 movement = new Vector3 (moveHorizontal, moveVerticle, 0.0f);
        rb.velocity = movement * Speed;
    }

    void Update()
    {
     //Ship should move vertically automatically, do I need this?
     //transform.Translate(0, LaunchSpeed, 0);
    }

    
}
