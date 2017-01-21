using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyLane : MonoBehaviour {

    [SerializeField]
    float laneSpeed = 5f;
    

    bool lost = false;
    bool obstruction = false;
    bool start = false;

    float holdBackTime = 0.0f;

    GameObject lastTrigger = null;


    // Use this for initialization
    void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (lost)
            return;

        if (lastTrigger == other.gameObject)
            return;     

        if (!other.GetComponent<Obstacle>())
            return;
        
        other.GetComponent<Obstacle>().GetObjectStrength(out holdBackTime);

        obstruction = true;

        lastTrigger = other.gameObject;

        GetComponentInChildren<ParticleSystem>().Play();

        //other.GetComponent<Collider>().enabled = false;
       // other.GetComponent<Rigidbody>().useGravity = false;

    }

    void Setback()
    {
        if (lost)
            return;

        holdBackTime -= Time.deltaTime * 10;

        if (holdBackTime <= 0)
        {
            obstruction = false;

            GetComponentInChildren<ParticleSystem>().Stop();

            return;
        }

        transform.position -= Vector3.forward * 20 * Time.deltaTime;
    }

    void GoForward()
    {
        transform.position += Vector3.forward * laneSpeed * 0.01f;
    }

    void CatchupCheck()
    {
        if (transform.localPosition.z > 0)
        {
            BunnyLane[] AllLanes = transform.parent.GetComponentsInChildren<BunnyLane>();

            for (int i = 0; i < AllLanes.Length; i++)
                AllLanes[i].EndIt();

            Debug.Log("the End");

        }
    }

    public void EndIt()
    {
        lost = true;



        if(GetComponentInChildren<ParticleSystem>().isPlaying)
            GetComponentInChildren<ParticleSystem>().Stop();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

       

        if (!start)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                start = true;
            else
                return;
        }

        if(!lost)
            CatchupCheck();

        //if (lost)
        //    return;

        if (obstruction && !lost)
        {
            Setback();
            return;
        }

        GoForward();
	}
}
