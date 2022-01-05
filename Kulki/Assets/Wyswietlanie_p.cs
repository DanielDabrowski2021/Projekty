using UnityEngine;
using System.Collections;

public class Wyswietlanie_p : MonoBehaviour {

	public GUIText LiczbaPunktow;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void Wyswietl(int punkty)
	{
		LiczbaPunktow.text=punkty.ToString();
		if (!LiczbaPunktow.enabled) {LiczbaPunktow.enabled=true;};
		
	}
}
