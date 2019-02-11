using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Engine
public class Launcher : MonoBehaviour
{
    public float force = 10.0f;
    [HideInInspector] public Rigidbody2D rigidbody2D;
    private Fuel m_fuel;
    private Fuel fuel
    {
        get
        {
            m_fuel = m_fuel ?? GetComponentInChildren<Fuel>();
            if (!m_fuel.gameObject.activeSelf)
            {
                m_fuel = null;
            }
            return m_fuel;
        }
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (fuel != null && fuel.Amount > 0.0f)
        {
            rigidbody2D.velocity = rigidbody2D.transform.up * force + (Vector3)Physics2D.gravity;
            fuel.Amount -= Time.deltaTime;
        }
    }
}
