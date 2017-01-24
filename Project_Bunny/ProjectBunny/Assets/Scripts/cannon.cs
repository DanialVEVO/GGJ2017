using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannon : MonoBehaviour {

    public int salvoFire;
    public int shootCost;

    public float cooldown;
    public float miniCooldown;
    public float shootPower;
    public float ammo;

    public GameObject[] projectiles;
    public Transform muzzle;
    public GameObject Title;
    public AudioSource shootSound;
    public GameObject Lanes;

    
    public int speedUpgradeAfterXSeconds = 20;
    public float lengthOfSpeedUpgrade = 0.3f;

    public bool allowFire = true;
    bool gameStarted = false;
    bool firstShot = true;
    bool movingTitleScreen = false;

    int amountOfSpeedIncreases = 1;

    float timeTraveled = 0.0f;

    bool end = false;

    SphereCollider sphere;
    Rigidbody rBody;

    
    

    // Use this for initialization
    void Start()
    {
        //sphere = GetComponent<SphereCollider>();
        rBody = GetComponentInChildren<Rigidbody>();
        sphere = GetComponentInChildren<SphereCollider>();
        GetComponentInChildren<Rigidbody>().isKinematic = true;
        //sphere.gameObject.SetActive(false);
        
        //StartCoroutine(Shoot());
    }

    public void ReadyTheCannons()
    {
        gameStarted = true;
    }

    public void EndReached()
    {
        end = true;

        Debug.Log("Distance travelled = " + timeTraveled * 100);
    }

    public void GetDistance( out float distance)
    {
        distance = timeTraveled * 100;
    }



    // Update is called once per frame
    void Update()
    {

        if (!gameStarted)
            return;

        if (end)
            return;

        timeTraveled += Time.deltaTime;

        if (timeTraveled > amountOfSpeedIncreases * speedUpgradeAfterXSeconds)
        {
            IncreaseLaneSpeed();
        }

        if (movingTitleScreen)
         MoveTitleScreen();

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
            FireAway();
        
    }

    void IncreaseLaneSpeed()
    {
        
        BunnyLane[] allLanes = Lanes.GetComponentsInChildren<BunnyLane>();

        for (int i = 0; i < allLanes.Length; i++)
            allLanes[i].IncreaseSpeed(lengthOfSpeedUpgrade);

        amountOfSpeedIncreases++;

        Debug.Log(" Speed Upgraded" );
        
    }

    void MoveTitleScreen()
    {
        Title.transform.position += Vector3.forward * Time.deltaTime * 2.0f;

        if (Title.transform.position.z > 93)
            movingTitleScreen = false;
    }

    public virtual void FireAway()
    {
        

        if (allowFire)
        {
            if (firstShot)
            {
                movingTitleScreen = true;
                firstShot = false;
            }

            shootSound.Play();
            StartCoroutine(Shoot());
        }
    }

    public virtual IEnumerator Shoot()
    {
        
        if (ammo >= 1)
        {
            allowFire = false;

            for (int i = 1; i <= salvoFire; i++)
            {
                MakeProjectile(projectiles[Random.Range(0,projectiles.Length)]);
                yield return new WaitForSeconds(miniCooldown);
                //send ammo to inventory function inventory(shootcost);
                ammo--;
            }
            yield return new WaitForSeconds(cooldown);
            allowFire = true;
        }
    }

    public void rotateLikeCrazy()
    {
        Debug.Log("It reached this");

       // sphere.gameObject.SetActive(true);
        rBody.isKinematic = false;
        rBody.AddTorque(transform.up * 10);
    }

    public virtual void MakeProjectile(GameObject explosive)
    {
        //		if (allowFire == true){
        GameObject projectileInstance;
        projectileInstance = (GameObject)Instantiate(explosive, muzzle.position, muzzle.rotation);
        projectileInstance.GetComponent<Rigidbody>().velocity = muzzle.forward * shootPower;
        //print("current projectile speed" + projectileInstance.GetComponent<Rigidbody>().velocity);
        //print("current projectile magnitude" + projectileInstance.GetComponent<Rigidbody>().velocity.magnitude);
        Ammo(shootCost);
        //		}
    }

    public void Ammo(int ammo)
    {
        //currentAmmo -= ammo;
        //Mathf.Clamp(value to clamp, 0, maxAmmo);
    }
}