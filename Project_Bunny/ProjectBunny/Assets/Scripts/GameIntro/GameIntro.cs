using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameIntro : MonoBehaviour {

	public GameObject mobilePhone;

	public Canvas canvas;

	public int maxStage;
	public int currentStage;

	public float popInSpeed;

	public AudioSource source;
	public AudioClip[] tweetNotification;

	public GameObject tweet;
	public GameObject curTweet;
	
	public List<GameObject> prevTweets;

	public GameObject Lanes;

	public int NumberOfRampageTweets = 40;

	public int maxDeathMessages = 3;
    public int deathMessageAutoDelay = 3;

    private bool displayingDeathMessage = false;

	private int deathMessagesDisplayed;
	private bool randomRampage = false;
	private bool isLerpingPhone = false;
	private bool isLerping = false;
	private bool finishedPhoneLerp = false;
	private bool finishedRampage = false;
	private bool isRampaging = false;

	private bool isFading = false;

	private Vector3 oldPhonePos;

	private float startTime;
	public float journeyLength;

	// Use this for initialization
	void Start ()
	{
		source = GetComponent<AudioSource>();
		startTime = Time.time;
		oldPhonePos = mobilePhone.transform.position;
	}

	void PopInTweet(bool isRandom = false)
	{
		//Play yodel sound
		AudioClip randomNotificationSound = tweetNotification[Random.Range(0, 4)];
		source.PlayOneShot(randomNotificationSound, 0.4f);

		//Spawn new sound
		GameObject newTweet = Instantiate(tweet);
		newTweet.transform.SetParent(canvas.transform);

		PostCreator postCreator = GetComponent<PostCreator>();

		string generatedName = postCreator.GenerateName();
		string generatedMessage = postCreator.GenerateMessage();
		Sprite generatedSprite = postCreator.GenerateAvatar();

		//Set Avatar
		Image[] avatarSprite = newTweet.GetComponentsInChildren<Image>();
		avatarSprite[1].sprite = generatedSprite;

		Text[] newText = newTweet.GetComponentsInChildren<Text>();

		//Set text
		if (currentStage < 3)
		{
			newText[0].text = "Mr. President @POTUS";
			newText[1].text = postCreator.POTUSMessage[currentStage];
			avatarSprite[1].sprite = postCreator.POTUSPortrait;
		}

		else if (currentStage == 4)
		{
			newText[0].text = "Symmerian Border Police";
			newText[1].text = "To all Dramerican citizens migrating to the jewel of the Middle-East. GO BACK TO YOUR OWN COUNTRY!";
			avatarSprite[1].sprite = postCreator.GovPortrait;

		}

		else
		{
			newText[0].text = generatedName;
			newText[1].text = generatedMessage;
		}

		if (isRandom == true)
		{
			randomRampage = true;
			int randX = Random.Range(-650, 650);
			int randY = Random.Range(-450, 450);

			newTweet.GetComponent<RectTransform>().anchoredPosition = new Vector3(randX, randY, 0);
		}

		else
		{
			newTweet.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -360, 0);
		}

		curTweet = newTweet;

		//add newest tweet to previous tweets to be moved up
		prevTweets.Add(newTweet);

		//Starts Coroutine to move stuff up
		isLerping = true;

	}

	void DeathMessage()
	{
		if (deathMessagesDisplayed <= maxDeathMessages)
		{
			//Play sound
			AudioClip randomNotificationSound = tweetNotification[Random.Range(0, 4)];
			source.PlayOneShot(randomNotificationSound, 0.4f);

			//Instantiate tweet
			GameObject newTweet = Instantiate(tweet);
			newTweet.transform.SetParent(canvas.transform);

			//Get postcreator messages
			PostCreator postCreator = GetComponent<PostCreator>();
			Text[] newText = newTweet.GetComponentsInChildren<Text>();
			Image[] avatarSprite = newTweet.GetComponentsInChildren<Image>();

			newText[0].text = "Symerian News Network";
			avatarSprite[1].sprite = postCreator.SNNPortrait;

			//Place tweet
			newTweet.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, -360, 0);

            if (displayingDeathMessage == false)
            {
                StartCoroutine(DeathMessageAuto());
            }

            if (deathMessagesDisplayed <= 0)
			{
				newText[1].text = "A Heroic Sacrifice: Patroller dies fleeing for <NUMBER OF MILES> from Dramericans.";
			}

			else
			{
				newText[1].text = postCreator.deathMessage[Random.Range(0, postCreator.deathMessage.Length)];
			}

			deathMessagesDisplayed++;

			prevTweets.Add(newTweet);
			isLerping = true;
		}

		else if (deathMessagesDisplayed >= maxDeathMessages)
		{
			//DisableEverything();
		}
	}


	// Update is called once per frame
	void Update()
	{
        /*
        if (Input.GetKeyDown(KeyCode.E))
        {
            DeathMessage();
        }
        */

		if (currentStage == (maxStage - 1))
		{
			//StartTweetSwarm()

			if (finishedRampage == false && isRampaging == false)
				StartCoroutine(TweetRampage(NumberOfRampageTweets));

			else if (finishedRampage == true)
			{
				//Handles the destruction of tweets at the end.
				float distCovered = (Time.time - startTime) * popInSpeed;
				float fracJourney = distCovered / journeyLength;

				foreach (GameObject tweet in prevTweets)
				{
					Vector3 tweetPos = tweet.transform.position;
					Vector3 targetPos = new Vector3(4, 1200, 0);

					tweet.transform.position = Vector3.Lerp(tweetPos, targetPos, fracJourney * 0.1f);

					if (tweet.transform.position.y > targetPos.y)
					{
						tweetPos = new Vector3(tweetPos.x, targetPos.y, tweetPos.z);
						tweet.SetActive(false);
					}
				}

				//Removes mobile phone
				mobilePhone.transform.position = Vector3.Lerp(mobilePhone.transform.position, oldPhonePos, fracJourney * 0.1f);

				if (mobilePhone.transform.position.y > oldPhonePos.y)
				{
					mobilePhone.transform.position = new Vector3(mobilePhone.transform.position.x, oldPhonePos.y, transform.position.z);
					AudioClip randomNotificationSound = tweetNotification[Random.Range(0, tweetNotification.Length)];
					source.PlayOneShot(randomNotificationSound, 0.4f);

					isFading = false;
					currentStage = maxStage;

					DisableEverything();
				}



				BunnyLane[] allLanes = Lanes.GetComponentsInChildren<BunnyLane>();
				for (int i = 0; i < allLanes.Length; i++)
				{
					allLanes[i].GetReady();
				}

				Debug.Log("deleting all phone related");
				currentStage = maxStage;
			}
		}

		if (currentStage < maxStage - 1)
		{
			if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.JoystickButton0))
			{
				
				if (finishedPhoneLerp == true)
				{
					//Player moves tweets
					PopInTweet();
					currentStage++;
					Debug.Log("Current Stage is " + currentStage);
				}

				else if (finishedPhoneLerp == false)
				{
					//Player moves phone
					isLerpingPhone = true;

					AudioClip vibrateClip = tweetNotification[5];
					source.PlayOneShot(vibrateClip, 1f);
				}

			}

			if (isLerping)
			{
				//Move tweets up
				StartCoroutine(MoveTweetsUp());
			}

			if (isLerpingPhone)
			{
				//Controls the mobile phone at the start of the intro

				float distCovered = (Time.time - startTime) * popInSpeed;
				float fracJourney = distCovered / journeyLength;

				Vector3 targetPos = new Vector3(1.5f, 4.5f, 91.8f);
				mobilePhone.transform.position = Vector3.Lerp(mobilePhone.transform.position, targetPos, fracJourney * 0.1f);

				if (mobilePhone.transform.position.y > targetPos.y)
				{
					mobilePhone.transform.position = new Vector3(mobilePhone.transform.position.x, targetPos.y, transform.position.z);
					mobilePhone.GetComponent<rotation>().enabled = true;
					isLerpingPhone = false;
				}

				finishedPhoneLerp = true;
			}

		}
	}

	void DisableEverything()
	{
		//Disables all Intro-specific gameObjects
		//this.gameObject.SetActive(false);
		mobilePhone.gameObject.SetActive(false);

		foreach (GameObject tweet in prevTweets)
		{
			Destroy(tweet);
		}
	}

	public IEnumerator MoveTweetsUp()
	{
		//Move up tweets
		if (randomRampage == false)
		{
			foreach (GameObject tweet in prevTweets)
			{
				float distCovered = (Time.time - startTime) * popInSpeed;
				float fracJourney = distCovered / journeyLength;
					
				tweet.transform.position = Vector3.Lerp(tweet.transform.position, (tweet.transform.position + new Vector3(0, 80, 0)), fracJourney);
				tweet.transform.localScale += new Vector3(-0.25F, -0.25F, -0.25F);
			}

			yield return null;

			isLerping = false;
		}
	}

	public IEnumerator DeathMessageAuto()
	{
        float i = 0;
        displayingDeathMessage = true;

        while (i <= maxDeathMessages)
		{
            i++;
            DeathMessage();
            Debug.LogWarning("DOING AUTO MESSAGE");

            yield return new WaitForSeconds(deathMessageAutoDelay);
		}

	}

	IEnumerator TweetRampage(int maxNumTweets)
	{
		float i = 0;

		Debug.LogWarning("STARTED RAMPAGE");
		isRampaging = true;

		while (i < maxNumTweets)
		{
			//do stuff
			i++;

			float delay = 0.6f - (i / 10f);

			if (delay < 0.05f)
			{
				delay = 0.05f;
			}

			Debug.LogWarning(i);

			bool random = true;
			PopInTweet(random);

			//yield return 0; //Wait 1 Frame
			yield return new WaitForSeconds(delay);
		}

		isRampaging = false;
		finishedRampage = true;
	}

}
