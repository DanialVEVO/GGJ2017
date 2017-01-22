using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour {
    Animator anim;
    float startPoint;
    public Material[] matList;
    Renderer[] childRenderers;

    // Use this for initialization
    void Awake () {
        int seed = (int)Mathf.Floor(this.gameObject.transform.position.x * 100);
        Random.InitState(seed);
        //print(seed);
       // print(Random.value);
        anim = this.gameObject.GetComponent<Animator>();
        anim.Play("Take 001", -1, Random.value);
    }

    void Start()
    {
        childRenderers = GetComponentsInChildren<Renderer>();
        foreach (Renderer child in childRenderers)
        {
            child.material = matList[Random.Range(0,matList.Length)];
        } 
    }
	
	// Update is called once per frame
	void Update () {
    }
}
