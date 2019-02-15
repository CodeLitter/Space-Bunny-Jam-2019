using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Transform start;
    public Transform target;
    [HideInInspector] public Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
    }

    private void LateUpdate()
    {
        // distance in meters
        var distance = (target.position - start.position).y * 10.0f;
        if (distance < 0.0f)
        {
            text.text = "<0km";
        }
        else if (distance < 1000.0f)
        {
            text.text = string.Format("{0:0.00}m", distance);
        }
        else
        {
            text.text = string.Format("{0:0.00}km", distance / 1000.0f);
        }
    }
}
