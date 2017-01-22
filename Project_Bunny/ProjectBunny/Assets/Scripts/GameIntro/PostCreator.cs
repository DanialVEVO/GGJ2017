using UnityEngine;
using System.Collections;

public class PostCreator : MonoBehaviour {


    public string createdPost;

    public bool createNewPost = false;

    public Sprite[] avatar;

    public Sprite POTUSPortrait;

    public string[] fname =
    {
        "Harold ",
        "Rarity ",
        "Betsy ",
        "Berdy ",
        "Bennie ",
        "Anton ",
        "Michael ",
        "Danial ",
        "Jordi ",
        "Stef ",
        "Jan ",
        "Mounim ",
        "Merry ",
        "Marijn ",
        "Jeroen ",
        "Martin ",
        "Hodor ",
        "Max ",
        "July ",
        "Gerda ",
        "Ingrid ",
        "Uniqua ",
        "Ledasha ",
        "Diamond ",
        "Ruby ",
        "Saphire ",
        "Keano ",
        "Mikkel ",
        "Jane ",
        "Donald ",
        "Saphire ",
        "Peter ",
        "Trevor ",
        "Charlie ",
        "Bernie ",
        "Kevin ",
        "Carl ",
        "Jim ",
        "Stefan ",
        "Johnny ",
        "Arnold ",
        "Robbie ",
        "Maxwell ",
        "Gerald ",
        "Andy ",
        "Jack ",
        "Stefano ",
        "Will ",
        "Ann ",
        "Anna ",
        "Klaus ",
        "Bart ",
        "Werner ",
        "Charles",
        "Jason ",
        "Keith ",
        "Ryan ",
        "Mila "

    };

    public string[] twitterHandle =
    {
        "BlackSamurai",
        "DankSteven",
        "AverageArnold",
        "billyBam",
        "joeStar",
        "gregGor",
        "petePoep",
        "killerFiller",
        "pancakehead",
        "antioch",
        "joeman",
        "kiffresh",
        "moumeme",
        "warriorjan",
        "xArcky",
        "darkangel291",
        "tyler777",
        "theStorm",
        "bavariafan",
        "tylerswifter",
        "mrBondJames",
        "monstarr",
        "maanster",
        "henkdevries",
        "kamehameha",
        "gohansama",
        "diowryyyy",
        "ArnoldJames",
        "Gibson",
        "chocolateboy",
        "darkoman",
        "ilama",
        "blommenman",
        "NickLamb",
        "MichelWarrun",
        "AlexCamilleri",
        "DazzleDan",
        "Jedi_Mocro",
        "Twirlbound",
        "Lordbound",
        "PineIsFine",
        "Mvdlaar",
        "ikaros",
        "KojimaKun",
        "FalloutMan69",
        "Skyrimfan21",
        "rockNeverDies",
        "RatchetAudio",
        "punchespears",
        "Vlambe",
        "TomNopper",
        "JohnWicker",
        "JoJoJoStar",
        "gamergirl1337"
    };

    public string[] message =
    {
        "I'm out of here! Goodbye world!",
        "GREATEST COUNTRY? More like, greatest CUNTRY!",
        "Anywhere in the world is better than Jamerica!",
        "LEAVING! GOODBYE!",
        "What's WRONG? Are you all BLIND?",
        "This is all the fault of those leftist-rightist globalists.",
        "A world without war is the world I want to live in.",
        "Thanks for ruining our country, old people.",
        "Follow me on Yodl and I'll follow back! Always good tweets!",
        "I can't sleep because of the problems this country has",
        "SEE YOU NEVER",
        "EVERYTHING IS SHIT",
        "FUCK THE AMERICAN DREAM I AM OUT",
        "SEE YOU LATER DUMBASSES",
        "no i did not cry when our country went to shit i stood up",
        "fight for your rights",
        "Wow! Okay. Lost faith in all of humanity",
        "I can't sleep because of the problems this country has",
        "We need to stand together as REAL AMERICANS! Be proud!"
    };

    public string[] hashtag =
    {
        "AmericaLameAgain",
        "SyriaBestria",
        "RUINED",
        "NeverGiveUp",
        "FuckTheSystem",
        "GoodByeAmerica",
        "NOTGREAT",
        "WEW",
        "LOL",
        "ByeBye",
        "CHECKINGOUT",
        "DestinationAnywhere",
        "FuckThePOTUS",
        "OldPeopleSuck",
        "BlameTheGlobalists",
        "BURNINHELL",
        "Americant",
        "KeepOnDreaming",
        "NewLifeNoProblems"
    };



    public string[] lname =
    {
        "Abdul",
        "Pinky Pie",
        "Dildoking",
        "Assad",
        "Simpson",
        "Cunty",
        "Vaporwave",
        "Watson",
        "White",
        "Ketchum",
        "Dogson",
        "McKenzie",
        "Cupson",
        "Cuckold",
        "de Vries",
        "de Koning",
        "Banksy",
        "Neiman",
        "Botman",
        "Anderson",
        "Bloomberg",
        "Cosner",
        "Smith",
        "de Boer",
        "Smid",
        "Crystal",
        "Maluku",
        "Dutchman",
        "York",
        "Mikkelson",
        "Bertrand",
        "Sweatshop",
        "Jones",
        "Williams",
        "Taylor",
        "Johnson",
        "Walker",
        "de Jong",
        "Jansen",
        "Bakker",
        "de Wit",
        "Kok",
        "Jacobs",
        "Vos",
        "Visser",
        "Fisher",
        "Maas",
        "Post",
        "Kuiper",
        "de Leeuw"
    };

    /*public string[] myPosts = new string[]
	{
		"My", "just died",
		"I hate my boss, he is such a",
		"MMM, I'm going to have", "for lunch",
		"Did anybody see my",
		"Frikking", "invading my country and stealing our",
		"I just bought a",
		"I painted my room in a", "colour",
		"This music sounds like", "music. I wished they played REAL music",
		"I tripped over a", "AGAIN! Stupid",
		"are the best",
		"I love my", "19-6-2010 never forget",
		"Wow check out this"
	};*/

    public string[] myHalfPosts = new string[]
    {
        "Wow check out this ",
        "I cannot believe ",
        "I watched a",
        "I'm walking my ",
        "Ugh, I have to make a",
        "Why stay ",
        "I need some ",
        "I hate it when ",
        "I'm rooting for my home team the ",
        "I'm the man of the ",
        "I'm dancing with my ",
        "I fell in love with a ",
        "Keano scratched his hairy back with his ",
        "I kissed a ",
        "Never again shall I lick this crazy ",
        "I just completed hugging my ",
        "Cleaning my ",
        "Ha! I won an internet argument against ",
        "My fursona is a ",
        "Just go this ",
        "Only 90's kids will remember ",
        "Like if you want to have sex with a ",
        "I just got kicked in the groin by a full-blown ",
        "Man, I wanna get shitfaced and hump ",
        "I could enjoy some ",
        "Just fucked my "
    };

    public string[] POTUSMessage = new string[]
    {
        "This is a disgrace! Fake Americans leaving the country! SHAME!",
        "Totally biased reporters are slandering my name - do not trust them!",
        "We will make our country GREAT AGAIN!",
    };



    public string[] mySecondHalfPosts = new string[]
	{
		" it's so crazy",
		" this made me unconfortable",
		" for 12 hours",
		" what a disgrace",
		" I could never be happier",
		" I'm getting too old for this",
		" I feel enligthend",
		" I guess it's accepted in some cultures...",
		" I'm never drinking again",
		" and I liked it",
		" It's just not right",
		" I wish I could get a degree in this...",
		" thorough",
		" makes me feel euphoric",
		"kin",
		" I will write a book about this",
		" I wish my life was more exciting",
		" this is why i voet trump!",
		" for every like I will do it again",
		" I wish I could die already",
		" Linkin Park sang about this"
	};

	public string[] mySubjects = new string[]
	{
		"customer",
		"drama",
		"gender",
		"bleep",
		"rain",
		"stepson",
		"television",
		"toothbrush",
		"wasp",
		"activity",
		"aluminium",
		"bottle",
		"deodorant",
		"freeze",
		"South-America",
		"toy",
		"typhoon",
		"yodler",
		"white-supremacist",
		"hockysticks",
		"hammer",
		"white women",
		"crazy boy",
		"Keano",
		"lubed jellyjar",
		"coconut oil",
		"banana",
		"bradwurst",
		"microphone",
		"dildo",
		"Meatswipe",
		"Yodlbirdz",
		"banker",
		"Jeroen's baby",
		"South-African folk singers",
		"nature",
		"spikey apples",
		"My Little Pony hentai doushinji",
		"your moms buttabplog",
		"weird hentai written by O.J. Simpson",
		"Occulus Rift",
		"goats",
		"Pokemon",
		"Pickachu",
		"Global Game Jam 2016"
	};


	void Start () {
		GenerateName();
		GenerateMessage();

	}
	
	// Update is called once per frame
	void Update () {

		if (!createNewPost)
			return;

		GenerateName();
		GenerateMessage();

		createNewPost = false;
	}

	

	public string CreatePost (){
		
		createdPost = fname[Random.Range(0, fname.Length)] + 
					  lname[Random.Range(0, lname.Length)] + 
					  myHalfPosts[Random.Range(0, myHalfPosts.Length)] + 
					  mySubjects[Random.Range(0, mySubjects.Length)] + 
					  mySecondHalfPosts[Random.Range(0, mySecondHalfPosts.Length)];

		return createdPost;
	}

	public Sprite GenerateAvatar()
	{
		Sprite generatedAvatar = avatar[Random.Range(0, avatar.Length)];

		return generatedAvatar;
	}

	public string GenerateName ()
	{

		string generatedName;
		int handleGen = Random.Range(0, 1);

		if (handleGen == 0)
			{
            //Twitter Handle = internet name
            //Re-add this for last name:  + lname[Random.Range(0, lname.Length)]
            generatedName = fname[Random.Range(0, fname.Length)] + " @" + twitterHandle[Random.Range(0, lname.Length)];
			}

		else
			{
			//Twitter Handle = Last name
			generatedName = fname[Random.Range(0, fname.Length)] + " @" + lname[Random.Range(0, lname.Length)];
			}


		return generatedName;
	}

	public string GenerateMessage ()
	{

		string generatedMessage = message[Random.Range(0, message.Length)] + " #" + hashtag[Random.Range(0, hashtag.Length)];

		return generatedMessage;
	}

}
