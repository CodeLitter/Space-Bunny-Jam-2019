using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    public float force = 10.0f;
    [HideInInspector] public Rigidbody2D rigidbody2D;
    private Fuel[] m_fuels;
    private Fuel m_fuel;
    private bool isDirty = true;

    public ICollection<Fuel> Fuels
    {
        get
        {
            if (isDirty)
            {
                m_fuels = GetComponentsInChildren<Fuel>();
                isDirty = false;
            }
            return m_fuels;
        }
    }

    private Fuel Current
    {
        get
        {
            m_fuel = m_fuel ?? Fuels.FirstOrDefault();
            return m_fuel;
        }
    }

    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Current != null)
        {
            if (Current.Amount > 0.0f)
            {
                rigidbody2D.AddForce(rigidbody2D.transform.up * force);
                Current.Amount -= Time.deltaTime;
            }
            else
            {
                Current.gameObject.SetActive(false);
                m_fuel = null;
            }
        }
        isDirty = isDirty || transform.hasChanged;
    }
}
