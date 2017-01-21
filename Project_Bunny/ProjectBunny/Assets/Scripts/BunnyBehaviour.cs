using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyBehaviour : MonoBehaviour {

    [SerializeField]
    Vector2 MaxSpeedRange = new Vector2(2.0f, 3.0f);

    float MaxSpeed = 2;

    bool goBack = false;

    // Use this for initialization
    void Start () {
        MaxSpeed = Random.Range(MaxSpeedRange.x, MaxSpeedRange.y);
	}

    void NaarVoren()
    {
        if (GetComponent<Rigidbody>().velocity.z > -MaxSpeed)
        {
            GetComponent<Rigidbody>().AddForce(Vector3.back * 5);
        }
       // Debug.Log(GetComponent<Rigidbody>().velocity.z);
    }


	void FixedUpdate () {
        NaarVoren();
	}
}
