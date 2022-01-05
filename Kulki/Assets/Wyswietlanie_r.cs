using UnityEngine;
using System.Collections;

public class Wyswietlanie_r : MonoBehaviour {

	public GUIText RekordP;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Wyswietl(int punkty)
	{
		RekordP.text=punkty.ToString();
		if (!RekordP.enabled) {RekordP.enabled=true;};
		
	}
}
