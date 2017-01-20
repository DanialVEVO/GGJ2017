using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBehaviour : MonoBehaviour {

    [SerializeField]
    float MaxSpeed = 6;

    // Use this for initialization
    void Start () {
		
	}

    void NaarVoren()
    {
        if (GetComponent<Rigidbody>().velocity.z < -MaxSpeed) ;
    }


	void FixedUpdate () {
        NaarVoren();
	}
}
