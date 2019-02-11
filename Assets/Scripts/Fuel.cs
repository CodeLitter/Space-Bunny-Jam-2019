using UnityEngine;

public class Fuel : MonoBehaviour
{
    public float max = 100.0f;
    private float? m_amount;
    public bool IsNew
    {
        get { return !m_amount.HasValue; }
    }
    public float Amount
    {
        set
        {
            m_amount = value;
            if (m_amount.Value < 0.0f)
            {
                gameObject.SetActive(false);
            }
        }
        get
        {
            if (!m_amount.HasValue)
            {
                m_amount = max;
            }
            return m_amount.Value;
        }
    }
}
