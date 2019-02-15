using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacher : MonoBehaviour
{
    public GameObject prefab;
    [Tag] public string targetTag;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag(targetTag))
        {
            Instantiate(prefab, other.transform);
        }
    }
}
