using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class FuelGauge : MonoBehaviour
{
    public Transform target;
    [HideInInspector] public Slider slider;
    private Fuel[] fuels;

    private void Awake()
    {
        slider = GetComponent<Slider>();
    }

    private void Start()
    {
        fuels = target.GetComponentsInChildren<Fuel>();
    }

    private void LateUpdate()
    {
        slider.value = fuels.Select(item => item.Amount / item.max).Aggregate(Aggregate) / fuels.Length * slider.maxValue;
    }

    private float Aggregate(float accumulation, float next)
    {
        return accumulation + next;
    }
}
