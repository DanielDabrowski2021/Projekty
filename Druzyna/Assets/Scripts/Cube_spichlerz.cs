using UnityEngine;
using System.Collections;

public class Cube_spichlerz : MonoBehaviour {

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
    void OnMouseEnter()
    {
        if (gm.wizyta_w_miescie == true) 
        {
            //GUI.Label (new Rect (230, 25, 200, 50), "Spichlerz");
            Debug.Log("Spichlerz");
            return;
        }




        //|| (this.tag == "ekwipunek_postaci_tulow") || (this.tag=="ekwipunek_postaci_prawa_reka") || (this.tag=="ekwipunek_postaci_lewa_reka") || (this.tag=="ekwipunek_postaci_nogi") || (this.tag=="ekwipunek_postaci_glowa"))
    }
    void OnMouseDown()
    {
        if (gm.zaznaczona_druzyna == true) 
        {
            gm.camera_.transform.position = new Vector3(200, 40, 200);
            gm.kupowanie_jedzenia_ = true;
            gm.tlo = Instantiate(gm.cube_tlo, new Vector3(200, 1.5F, 200), Quaternion.identity) as GameObject;
            gm.tlo.GetComponent<Renderer>().material.mainTexture = gm.spichlerzTexture;
            gm.tlo.transform.localScale += new Vector3(100, 0, 100);
            //tlo.GetComponent<Renderer> ().material.color = Color.yellow;
            /*
			Debug.Log("Kupujemy jedzenie w miescie");
			Debug.Log ("Druzyna =" + gm.aktualna_druzyna_index);
			Debug.Log ("Mamy " + gm.tablica_druzyn [gm.aktualna_druzyna_index].zywnosc + "zywnosci");
			if (gm.tablica_graczy[1].pieniadze > 100) 
			{
				gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-100;
				Debug.Log ("Kupilismy jedzenie");
				gm.tablica_druzyn [gm.aktualna_druzyna_index].zywnosc=gm.tablica_druzyn [gm.aktualna_druzyna_index].zywnosc+200;
				Debug.Log ("Mamy " + gm.tablica_druzyn [gm.aktualna_druzyna_index].zywnosc + "zywnosci");
			}
			return ;
			*/
            return;
        }
    }
}
