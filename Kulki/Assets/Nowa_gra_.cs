using UnityEngine;
using System.Collections;

public class Nowa_gra_ : MonoBehaviour {

	private Starter s;
	void Awake()
	{

		s=GameObject.FindGameObjectWithTag("GameController").GetComponent<Starter>();
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{
		s.nowa_gra_2();

	}
}
