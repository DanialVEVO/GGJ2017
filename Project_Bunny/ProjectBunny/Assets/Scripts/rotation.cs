using UnityEngine;
using System.Collections;

public class rotation : MonoBehaviour
{
	public float speed = 400f;
	public float openneer = 0f;
    public Transform transformx;
    private Vector3 xAxis;
    private float secondsForOneLength = 1f;
    public Bounds boundary;  //Assuming that you're assigning this value in the inspector

    public GameObject GameIntroManager;


    void Start()
    {
    }

    void Update ()
	{
		Vector3 nextRotate = Vector3.zero;


		nextRotate.y = speed * Time.deltaTime;
		nextRotate.z = speed/3 * Time.deltaTime;   

		transform.Rotate(nextRotate);

		openneer+=Time.deltaTime;


		this.gameObject.transform.position = new Vector3(this.transform.position.x, (Mathf.Sin(openneer)*0.1f)+0.85f,this.transform.position.z);
    }
}