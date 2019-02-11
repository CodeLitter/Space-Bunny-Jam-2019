using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTrigger : MonoBehaviour
{
    [Tag] public string colliderTag = "Untagged";
    public UnityEngine.Events.UnityEvent collisionEvent;

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag(colliderTag))
        {
            collisionEvent.Invoke();
        }
    }
}

