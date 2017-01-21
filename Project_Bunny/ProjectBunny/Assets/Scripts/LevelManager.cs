using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

   //[SerializeField]
   // float levelStartZ = 100;

    [SerializeField]
    float levelEndZ = -20;

    //[SerializeField]
   // float lengthBetweenLevels = 20.0f;
    
    [SerializeField]
    float levelSpeed = 20;

    //[SerializeField]
    //GameObject[] levels;

    ArrayList movingGameObjects = new ArrayList();

    GameObject[] childrenAsBackground;

    Bounds[] childBounds;

    int currentLastBG = 0;

	float levelSpeedMultiplied;

   // bool win = false;
    
   

	// Use this for initialization
	void Start () {
        
        //LoadNewLevel();

        childrenAsBackground = new GameObject[transform.childCount];

        childBounds = new Bounds[transform.childCount];

		levelSpeedMultiplied = levelSpeed;


        for (int i = 0; i < childrenAsBackground.Length; i++)
        {
            childrenAsBackground[i] = transform.GetChild(i).gameObject;

            if (childrenAsBackground[i].transform.position.z > childrenAsBackground[currentLastBG].transform.position.z)
                currentLastBG = i;

            Bounds theseBounds = new Bounds(Vector3.zero, Vector3.zero);

            MeshFilter[] allChildren = childrenAsBackground[i].GetComponentsInChildren<MeshFilter>();

            foreach (MeshFilter mf in allChildren)
            {
               // Debug.Log(mf.sharedMesh.bounds.size);

                Vector3 pos = mf.transform.localPosition;
                Bounds child_bounds = mf.sharedMesh.bounds;
                child_bounds.center += pos;
                child_bounds.size *= mf.transform.localScale.z;
                theseBounds.Encapsulate(child_bounds);
            }

            childBounds[i] = theseBounds;

            //Debug.Log(childBounds[i].size);
        }
       
    }


    public void setLevelSpeedMultiplier(float multiplier)
	{
		levelSpeedMultiplied = levelSpeed * multiplier;
	}

    public void GetSpeedMult(out float speedMult)
    {
        speedMult = levelSpeedMultiplied / levelSpeed;
    }

    


    IEnumerator RemoveAndDestroy(GameObject thisLevel)
    {          

        yield return new WaitForEndOfFrame();
               
        
        movingGameObjects.Remove(thisLevel);
        Destroy(thisLevel);

        //LoadNewLevel();

        StopCoroutine(RemoveAndDestroy(null));
    }

   

    void BackgroundMovement()
    {
       

        for (int i=0; i < childrenAsBackground.Length; i++)
        {

            
            childrenAsBackground[i].transform.Translate(0,0, -levelSpeedMultiplied * Time.deltaTime);

            

            if (childrenAsBackground[i].transform.position.z + childBounds[i].max.z < levelEndZ)
            {

                float movAdjust = 0;

                if (i == 0)
					movAdjust = levelSpeedMultiplied * Time.deltaTime;

                childrenAsBackground[i].transform.position = new Vector3(0, 0, childrenAsBackground[currentLastBG].transform.position.z + childBounds[currentLastBG].max.z - movAdjust);

                currentLastBG = i;

                Obstacle[] obstacles = childrenAsBackground[i].GetComponentsInChildren<Obstacle>();

                for (int j = 0; j < obstacles.Length; j++)
                {
                    Destroy(obstacles[j].gameObject);
                }

            }
        }
    }


    // Update is called once per frame
    void FixedUpdate ()
    {

        //LevelMovement();

        BackgroundMovement();
      

	}
}
