using UnityEngine;
using System.Collections;

public class Cube_pole_malego_terenu : MonoBehaviour {

    // Use this for initialization
    private GeneratorMAPY gm;
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();
    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        if (gm.wybrana_postac == true) 
        {
            gm.wybrane_pole[gm.aktualna_postac] = true;
            gm.wybrane_pole_x[gm.aktualna_postac] = this.transform.position.x;
            gm.wybrane_pole_z[gm.aktualna_postac] = this.transform.position.z;
            gm.test1[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.x; //dla kazdej postaci w druzynie
            gm.test2[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.z;
            Debug.Log("Wybrane pole docelowe dla postaci " + gm.aktualna_postac + "\n");

        }

    }
}
