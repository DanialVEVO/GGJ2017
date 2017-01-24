using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{

    public bool Shaking;
    private float ShakeDecay;
    private float ShakeIntensity = 1.0f;
    private float ShakeDuration;
    private Vector3 OriginalPos;
    private Quaternion OriginalRot;

    void Start()
    {
        Shaking = false;
    }

    void Update()
    {
        if (ShakeDuration > 0)
        {
            Camera.main.transform.rotation = new Quaternion(OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity) * .02f,
                                            OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity) * .02f,
                                            OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity) * .02f,
                                            OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity) * .02f);

            ShakeDuration -= ShakeDecay;
        }
        else if (Shaking)
        {
            Shaking = false;

            Camera.main.transform.rotation = OriginalRot;
        }


    }

    public void DoShake(float shakeLength = 1.0f, float newIntensity = 0.3f)
    {
        OriginalRot = Camera.main.transform.rotation;

        ShakeIntensity = newIntensity;
        ShakeDuration = shakeLength;
        ShakeDecay = 0.02f;
        Shaking = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>()==null)
        {
            DoShake();
        }
    }
}