using UnityEngine;
using System.Collections;

public class MainMenuGUI : MonoBehaviour {

	// Use this for initialization
	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect playButton;
	public Rect loadButton;
	public Rect quitButton;
	Rect menuAreaNormalized;
	public Texture2D mainMenuTexture;
	void Start () 
	{
		menuAreaNormalized=new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y *
		                             Screen.height - (menuArea.height * 0.5f), menuArea.width,menuArea.height); 
		Debug.Log ("Start");
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		//GUI.skin = menuSkin;
		//GUI.BeginGroup (menuAreaNormalized);
		//Debug.Log ("OnGUI");
		//Application.LoadLevel (1);
		//Debug.Log (playButton.x);
		GUI.Label(new Rect (0, 0, Screen.width+200, Screen.height+50), mainMenuTexture);
		if (GUI.Button (new Rect (playButton), "Nowa gra")) 
		{
			StartCoroutine("ButtonAction", "Nowa gra");
		}
		if (GUI.Button (new Rect (quitButton), "Wyjscie")) 
		{
			StartCoroutine("ButtonAction", "quit");
		}
		/*
		if(GUI.Button(new Rect(180,75,80,20), "Maksimum")) {
			ilosc_jedzenia_do_kupienia=ilosc_dostepnego_jedzenia.ToString();
		}
		if(GUI.Button(new Rect(130,125,80,20), "Kup")) 
		{
			ilosc_dostepnego_jedzenia=ilosc_dostepnego_jedzenia-Int32.Parse(ilosc_jedzenia_do_kupienia);
		}
		if(GUI.Button(new Rect(25,170,80,20), "Wyjdz")) 
		{
			kupowanie_jedzenia_=false;
			camera_.transform.position = new Vector3(160, 40, 160);
			Destroy(tlo);
		}
		*/
		//GUI.EndGroup ();

	}
	IEnumerator ButtonAction(string levelName)
	{
		yield return new WaitForSeconds(0.35f);
		if (levelName != "quit") {
			Application.LoadLevel (1);
		} else 
		{
			Application.Quit();
			Debug.Log("Wyjscie");
		}
	}
}
