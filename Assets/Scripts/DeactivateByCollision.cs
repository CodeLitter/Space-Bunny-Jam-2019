using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateByCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private void OnParticleCollision(GameObject other)
    {
        if (other.CompareTag("Hazard"))
        {
            gameObject.SetActive(false);
            Debug.Log("Touch the butt");
        }        
    }
 }

