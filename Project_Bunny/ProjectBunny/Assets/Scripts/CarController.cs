using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

    public GameObject truckBody;
    public GameObject backLeftTire;
    public GameObject backRightTire;
    public GameObject frontLeftTire;
    public GameObject frontRightTire;

    public float maxSpeed = 4;
    public float correctionMultiplier = 2.5f;

    float truckXRot = 0;
    float truckYRot = 0;
    float truckZRot = 0;
    float tX = 0;
    float tZ = 0;
    float tRand = 0;
    float amplitudeX = 1;
    float amplitudeZ = 1;
    float toAmplitudeX = 1;
    float toAmplitudeZ = 1;
    float timeSpeedX = 5;
    float timeSpeedZ = 5;
    float indexX = 0;
    float indexZ = 0;
    float xSpeed = 0;
    float acceleration = 0.4f;
    float randomBounceTreshold = 100;
    float randomBounceTimer = 0;
    float truckYPos;
    public float boundary;
    int direction = 1;



    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SetSineX();
        SetSineZ();
        MoveCar();
        RandomBounce();
        ClampCar();
        truckBody.transform.localEulerAngles = new Vector3(truckXRot, 0, truckZRot);
    }

    void MoveCar()
    {
        //Debug.Log(Input.GetAxis("LeftX"));

        //if (Input.GetKey("a") && this.gameObject.transform.position.x < boundary)
        if ((Input.GetAxis("LeftX") == -1 || Input.GetKey("a")) && this.gameObject.transform.position.x < boundary)
        {
            if (xSpeed < maxSpeed)
            {
                if (xSpeed < 0)
                    xSpeed += Time.deltaTime * acceleration * correctionMultiplier;
                else
                    xSpeed += Time.deltaTime * acceleration;
            }
        }
        else if ((Input.GetAxis("LeftX") == 1 || Input.GetKey("d")) && this.gameObject.transform.position.x > -boundary)
        {
            if (xSpeed > -maxSpeed )
            {
                if (xSpeed > 0)
                    xSpeed -= Time.deltaTime * acceleration * correctionMultiplier;
                else
                    xSpeed -= Time.deltaTime * acceleration;
            }
        }
        else
        { 
            if (xSpeed < 0)
            {
                xSpeed += Time.deltaTime * acceleration;
                if (xSpeed >= 0)
                {
                    xSpeed = 0;
                }
            }
            else if (xSpeed > 0)
            {
                xSpeed -= Time.deltaTime * acceleration;
                if (xSpeed <= 0)
                {
                    xSpeed = 0;
                }
            }
        }
        
        Mathf.Clamp(xSpeed, -2, 2);
       
        this.gameObject.transform.Translate(Vector3.right * xSpeed, Space.World);

        truckYRot = xSpeed*100;
        this.gameObject.transform.localEulerAngles = new Vector3(0, truckYRot, 0);
    }

    void RandomBounce()
    {
        randomBounceTimer += Time.deltaTime;
        if (randomBounceTreshold == 100)
        {
            randomBounceTreshold = Random.Range(2, 4);
        }
        if (randomBounceTimer > randomBounceTreshold)
        {
            tRand += Time.deltaTime*8*direction;
            truckYPos = Mathf.Lerp(0, 0.25f, tRand);
            this.gameObject.transform.position = new Vector3(this.gameObject.transform.position.x, truckYPos, this.gameObject.transform.position.z);
            if (tRand > 1)
            {
                direction = -1;
            }
            if (tRand < 0)
            {
                tRand = 0;
                randomBounceTreshold = 100;
                randomBounceTimer = 0;
                direction = 1;
            }
        }
    }

    void ClampCar()
    {
        if (this.gameObject.transform.position.x > boundary)
        {
            xSpeed -= Time.deltaTime;
            Mathf.Clamp(xSpeed, 0, maxSpeed);
        }
        if (this.gameObject.transform.position.x < -boundary)
        {
            xSpeed += Time.deltaTime;
            Mathf.Clamp(xSpeed, -maxSpeed, 0);
        }
            
    }

    void SetSineX()
    {
        indexX += Time.deltaTime * timeSpeedX;
        tX += Time.deltaTime;
        truckXRot = Mathf.Sin(indexX) * amplitudeX;
               
        if (tX > 1)
        {
            tX = 0;
            toAmplitudeX = Random.Range(0.1f, 3);
            timeSpeedX = Random.Range(8f, 12f);
        }
        if (toAmplitudeX < amplitudeX)
        {
            amplitudeX -= Time.deltaTime;
            Mathf.Clamp(amplitudeX, toAmplitudeX, amplitudeX);
        }
        else
        {
            amplitudeX += Time.deltaTime;
            Mathf.Clamp(amplitudeX, 0, toAmplitudeX);
        }
    }

    void SetSineZ()
    {
        indexZ += Time.deltaTime * timeSpeedZ;
        tZ += Time.deltaTime;
        truckZRot = Mathf.Sin(indexZ) * amplitudeZ;


        if (tZ > 0.75f)
        {
            tZ = 0;
            toAmplitudeZ = Random.Range(0.1f, 3);
            timeSpeedZ = Random.Range(12, 16);
        }
        if (toAmplitudeZ < amplitudeZ)
        {
            amplitudeZ -= Time.deltaTime;
            Mathf.Clamp(amplitudeZ, toAmplitudeZ, amplitudeZ);
        }
        else
        {
            amplitudeZ += Time.deltaTime;
            Mathf.Clamp(amplitudeZ, 0, toAmplitudeZ);
        }
    }

    
}
