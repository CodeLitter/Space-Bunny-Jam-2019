using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 10.0f; //public variable will have default values if possible 
    [HideInInspector] public Rigidbody2D rigidbody2D; //Hidden public come after visible variables
    private Vector3 m_velocity; //private variables will be prefixed with m_ and will be last in the variable listing

    //Use awake to initialize local components within this gameobject
    private void Awake()
    {
        //Detects and get RB from object
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        //Apply velocity in fixedUpdate
        rigidbody2D.velocity = m_velocity * speed;
    }

    //Use update when capturing input as it is framerate dependent
    private void Update()
    {
        //Save captured input, horizontal movement is only needed
        m_velocity.x = Input.GetAxis("Horizontal");
    }


}
