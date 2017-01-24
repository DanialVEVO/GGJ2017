using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyLane : MonoBehaviour {

    [SerializeField]
    float laneSpeed = 5f;

    [SerializeField]
    cannon CannonScript = null;

    [SerializeField]
    GameIntro Outro = null;


    bool lost = false;
    bool obstruction = false;

    bool setup = true;
    bool gettingReady = false;
    bool start = false;


    float holdBackTime = 0.0f;

    GameObject lastTrigger = null;

    GameObject collisionObject;



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

        Camera.main.GetComponent<CameraShake>().DoShake(0.3f, 0.03f * holdBackTime);

        obstruction = true;

        lastTrigger = other.gameObject;

        GetComponentInChildren<ParticleSystem>().Play();

        GetComponent<AudioSource>().Play();

        collisionObject = other.gameObject;

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

            if (collisionObject)
            {
                collisionObject.GetComponent<Obstacle>().OnStampeded();
            }

            return;
        }

        transform.position -= Vector3.forward * 20 * Time.deltaTime;
    }

    void GoForward()
    {
        transform.position += Vector3.forward * laneSpeed * 0.01f;
    }

    public void IncreaseSpeed(float increaseAmount)
    {
        laneSpeed += increaseAmount;
    }

    void CatchupCheck()
    {
        if (transform.localPosition.z > 0)
        {
            BunnyLane[] AllLanes = transform.parent.GetComponentsInChildren<BunnyLane>();

            for (int i = 0; i < AllLanes.Length; i++)
            {
                if (AllLanes[i].CannonScript != null)
                    AllLanes[i].CannonScript.EndReached();

                AllLanes[i].EndIt();

                Camera.main.GetComponent<CameraShake>().DoShake(15.0f, 0.5f);

                if(AllLanes[i].CannonScript != null)
                    AllLanes[i].CannonScript.rotateLikeCrazy();
            }



            Debug.Log("the End");

        }
    }

    public void EndIt()
    {
        lost = true;

        laneSpeed = 20f;

        if (Outro != null)
            Outro.DeathMessage();

        if(GetComponentInChildren<ParticleSystem>().isPlaying)
            GetComponentInChildren<ParticleSystem>().Stop();
    }

    public void GetReady()
    {
        gettingReady = true;
        transform.parent.GetComponent<AudioSource>().Play();
    }

    void PrepareArmy()
    {
        transform.position += Vector3.forward * 0.2f;

        if (transform.localPosition.z >= -20)
        {
            setup = false;
            gettingReady = false;

            if (CannonScript != null)
                CannonScript.ReadyTheCannons();
        }
        
    }

	// Update is called once per frame
	void FixedUpdate () {



        if (setup)
        {
            if (gettingReady)
                PrepareArmy();

            return;
        }
       

        if (!start)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.JoystickButton0))
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

        if (lost && transform.localPosition.z > 0 && laneSpeed != 5.0f)
            laneSpeed = 5.0f;

        GoForward();
	}
}
