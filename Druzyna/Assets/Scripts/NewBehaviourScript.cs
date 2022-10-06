using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	//public bool zaznaczone=false;
	private GeneratorMAPY gm;
	void Awake()
	{
		
		gm=GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();
	}

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		/*if (Input.GetKey (KeyCode.Mouse0)) 
		{
			if (this.GetComponent<Renderer> ().material.color==Color.red)
			{
				Debug.Log("Kliknięty");

			}

		}
		*/

	}
	void OnMouseDown()
	{
		if (this.GetComponent<Renderer> ().material.color==Color.red)
		{
			Debug.Log("Kliknięty");
			gm.zaznaczona_druzyna=true;
			gm.pozycjax_zaznaczonego=(int)this.transform.position.x;
			gm.pozycjaz_zaznaczonego=(int)this.transform.position.z;
			gm.aktualna_druzyna=this;
			Debug.Log("Pozycja x="+(int)this.transform.position.x+"\n");
			Debug.Log("Pozycja z="+(int)this.transform.position.z+"\n");

		}

	}
}
