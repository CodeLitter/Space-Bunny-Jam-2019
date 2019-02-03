using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivateByCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter(Collision collision)

    {
        if (collision.collider.tag == "Hazard")
        {
            gameObject.SetActive(false);
            Debug.Log("Touch the butt");
        }
        
    }
 }

