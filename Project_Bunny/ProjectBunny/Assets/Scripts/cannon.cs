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

    public bool allowFire = true;

    // Use this for initialization
    void Start()
    {
        //StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            FireAway();
    }

    public virtual void FireAway()
    {
        if (allowFire)
        {
            //print("FireAway");
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