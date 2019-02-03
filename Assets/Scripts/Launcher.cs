using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public UnityEngine.Events.UnityEvent launchEvent;
    [HideInInspector] public Rigidbody2D rigidbody2D;

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rigidbody2D.AddForce(rigidbody2D.transform.up * 100.0f, ForceMode2D.Impulse);
            launchEvent.Invoke();
        }
    }
}
