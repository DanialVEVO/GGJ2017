using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField]
    float ObjectStrength = 10;

    void Start()
    {
        if (!GetComponent<Collider>())
            Debug.Log(gameObject.name + " needs a collider");
    }

    public void GetObjectStrength(out float strength)
    {
        strength = ObjectStrength;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponentInParent<LevelManager>())
            gameObject.transform.parent = collision.gameObject.transform;

    }
    
    
}
