using UnityEngine;

public class Fuel : MonoBehaviour
{
    public float max = 100.0f;
    private float? m_amount;
    public bool IsEmpty
    {
        get
        {
            return Amount < 0.0f;
        }
    }
    public float Amount
    {
        set
        {
            m_amount = value;
            if (IsEmpty)
            {
                gameObject.SetActive(false);
            }
        }
        get
        {
            if (!m_amount.HasValue)
            {
                return max;
            }
            return m_amount.Value;
        }
    }
}
