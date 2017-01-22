using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    [SerializeField]
    float ObjectStrength = 10;
    public bool canBreak;

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

    public void OnStampeded()
    {
        if (canBreak)
        {
            //this.GetComponent<Collider>().enabled = true;
            var rigidBodies = this.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody R in rigidBodies)
            {
                R.isKinematic = false;
            }
            var colliders = this.GetComponentsInChildren<Collider>();
            foreach (Collider C in colliders)
            {
                C.enabled = true;
            }
        }
    }


}
