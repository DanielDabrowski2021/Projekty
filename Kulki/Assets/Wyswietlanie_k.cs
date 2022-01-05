using UnityEngine;
using System.Collections;

public class Wyswietlanie_k : MonoBehaviour {

	public GUIText komunikat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Wyswietl(string message)
	{
		komunikat.text=message;
		if (!komunikat.enabled) {komunikat.enabled=true;};
		
	}
}
