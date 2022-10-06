using UnityEngine;
using System.Collections;

public class Cube_miasto : MonoBehaviour {

    private GeneratorMAPY gm;
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();
    }
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnMouseDown()
    {
        if (gm.zaznaczona_druzyna == true)
        {
            Debug.Log("Kliknięty cube");
            Debug.Log("Pozycja docelowego x=" + (int)this.transform.position.x + "\n");
            Debug.Log("Pozycja docelowego z=" + (int)this.transform.position.z + "\n");
            gm.pozycjax_kliknietego = (int)this.transform.position.x;
            gm.pozycjaz_kliknietego = (int)this.transform.position.z;
            gm.zaznaczone_pole_docelowe = true;
            return;
        }
    }
}
