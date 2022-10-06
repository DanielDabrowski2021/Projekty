using UnityEngine;
using System.Collections;

public class Cube_biblioteka : MonoBehaviour {

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
    void rysuj_ekwipunek_i_asortyment()
    {
        gm.aktualna_postac = 0;
        while (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].zywy == false)
        {
            if (gm.aktualna_postac == 9)
            {
                gm.aktualna_postac = 0;
            }
            else
                gm.aktualna_postac++;
        }
        for (int i = 0; i < 10; i++)
        {
            gm.asortyment_sklepu[i] = Instantiate(gm.cube_asortyment_sklepu, new Vector3(155 + i * 5, 2.0F, 200), Quaternion.identity) as GameObject;
            gm.asortyment_sklepu[i].GetComponent<Renderer>().material.color = Color.white;
            gm.asortyment_sklepu[i].transform.localScale += new Vector3(3, 0, 3);
            gm.asortyment_sklepu[i].tag = "asortyment_sklepu";
        }
        for (int i = 0; i < 10; i++)
        {
            gm.asortyment_sklepu[i + 10] = Instantiate(gm.cube_asortyment_sklepu, new Vector3(155 + i * 5, 2.0F, 195), Quaternion.identity) as GameObject;
            gm.asortyment_sklepu[i + 10].GetComponent<Renderer>().material.color = Color.white;
            gm.asortyment_sklepu[i + 10].transform.localScale += new Vector3(3, 0, 3);
            gm.asortyment_sklepu[i + 10].tag = "asortyment_sklepu";
        }
        /* głowa*/
        for (int i = 0; i < 4; i++)
        {
            gm.ekwipunek_postaci_box[i] = Instantiate(gm.cube_ekwipunek_postaci, new Vector3(230 + i * 5, 2.0F, 195), Quaternion.identity) as GameObject;
            gm.ekwipunek_postaci_box[i].GetComponent<Renderer>().material.color = Color.white;
            gm.ekwipunek_postaci_box[i].GetComponent<Renderer>().material.mainTexture = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[i].obrazek;
            gm.ekwipunek_postaci_box[i].transform.localScale += new Vector3(3, 0, 3);
            gm.ekwipunek_postaci_box[i].tag = "ekwipunek_postaci_kieszenie";
        }
        for (int i = 0; i < 4; i++)
        {
            gm.ekwipunek_postaci_box[i + 4] = Instantiate(gm.cube_ekwipunek_postaci, new Vector3(230 + i * 5, 2.0F, 190), Quaternion.identity) as GameObject;
            gm.ekwipunek_postaci_box[i + 4].GetComponent<Renderer>().material.color = Color.white;
            gm.ekwipunek_postaci_box[i + 4].GetComponent<Renderer>().material.mainTexture = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[i + 4].obrazek;
            gm.ekwipunek_postaci_box[i + 4].transform.localScale += new Vector3(3, 0, 3);
            gm.ekwipunek_postaci_box[i + 4].tag = "ekwipunek_postaci_kieszenie";
        }
        for (int i = 0; i < 3; i++)
        {
            gm.ekwipunek_postaci_box[i + 8] = Instantiate(gm.cube_ekwipunek_postaci, new Vector3(235, 2.0F, 205 + i * 5), Quaternion.identity) as GameObject;
            gm.ekwipunek_postaci_box[i + 8].GetComponent<Renderer>().material.color = Color.white;
            gm.ekwipunek_postaci_box[i + 8].transform.localScale += new Vector3(3, 0, 3);
        }

        //gm.ekwipunek_postaci_box[10].GetComponent<Renderer>().material.mainTexture=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].obrazek;
        //gm.ekwipunek_postaci_box[9].GetComponent<Renderer>().material.mainTexture=gm.tulowTexture;
        //gm.ekwipunek_postaci_box[8].GetComponent<Renderer>().material.mainTexture=gm.nogiTexture;	


        gm.ekwipunek_postaci_box[11] = Instantiate(gm.cube_ekwipunek_postaci, new Vector3(240, 2.0F, 210), Quaternion.identity) as GameObject;
        gm.ekwipunek_postaci_box[11].GetComponent<Renderer>().material.color = Color.white;
        gm.ekwipunek_postaci_box[11].transform.localScale += new Vector3(3, 0, 3);
        gm.ekwipunek_postaci_box[12] = Instantiate(gm.cube_ekwipunek_postaci, new Vector3(230, 2.0F, 210), Quaternion.identity) as GameObject;
        gm.ekwipunek_postaci_box[12].GetComponent<Renderer>().material.color = Color.white;
        gm.ekwipunek_postaci_box[12].transform.localScale += new Vector3(3, 0, 3);
        //gm.ekwipunek_postaci_box[11].GetComponent<Renderer>().material.mainTexture=gm.prawarekaTexture;
        //gm.ekwipunek_postaci_box[12].GetComponent<Renderer>().material.mainTexture=gm.lewarekaTexture;
        gm.ekwipunek_postaci_box[10].tag = "ekwipunek_postaci_glowa";
        gm.ekwipunek_postaci_box[9].tag = "ekwipunek_postaci_tulow";
        gm.ekwipunek_postaci_box[8].tag = "ekwipunek_postaci_nogi";
        gm.ekwipunek_postaci_box[11].tag = "ekwipunek_postaci_prawa_reka";
        gm.ekwipunek_postaci_box[12].tag = "ekwipunek_postaci_lewa_reka";
        for (int i = 8; i < 13; i++)
        {
            gm.ekwipunek_postaci_box[i].GetComponent<Renderer>().material.mainTexture = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[i].obrazek;
        }

        //gm.asortyment_sklepu [0].GetComponent<Renderer> ().material.mainTexture = gm.skoraTexture;
        return;
    }
    void OnMouseDown()
    {
        if (gm.zaznaczona_druzyna == true)
        {
            gm.camera_.transform.position = new Vector3(200, 40, 200);
            gm.kupowanie_w_bibliotece = true;
            gm.tlo = Instantiate(gm.cube_tlo, new Vector3(200, 1.5F, 200), Quaternion.identity) as GameObject;
            gm.tlo.GetComponent<Renderer>().material.mainTexture = gm.bibliotekaTexture;
            gm.tlo.transform.localScale += new Vector3(100, 0, 100);
            rysuj_ekwipunek_i_asortyment();
            gm.aktualny_budynek = new budynek("Biblioteka", 10000, 1);
            Debug.Log("Wchodze do biblioteki");
            gm.aktualny_budynek.asortyment_sklepu[0] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
            gm.aktualny_budynek.asortyment_sklepu[1] = new ekwipunek(6, 4, "Zwoj: Ognista kula, 30 obrazen od ognia,koszt uzycia: 50 pkt many", 350, gm.zwojTexture);
            gm.aktualny_budynek.asortyment_sklepu[2] = new ekwipunek(7, 4, "Zwoj: Magiczny pocisk, 15 obrazen fizycznych,koszt uzycia: 25 pkt many", 175, gm.zwojTexture);
            gm.aktualny_budynek.asortyment_sklepu[3] = new ekwipunek(8, 4, "Zwoj: Blyskawica, 30 obrazen od elektrycznosci,koszt uzycia: 50 pkt many", 250, gm.zwojTexture);
            gm.asortyment_sklepu[0].GetComponent<Renderer>().material.mainTexture = gm.aktualny_budynek.asortyment_sklepu[0].obrazek;
            gm.asortyment_sklepu[1].GetComponent<Renderer>().material.mainTexture = gm.aktualny_budynek.asortyment_sklepu[1].obrazek;
            gm.asortyment_sklepu[2].GetComponent<Renderer>().material.mainTexture = gm.aktualny_budynek.asortyment_sklepu[2].obrazek;
            gm.asortyment_sklepu[3].GetComponent<Renderer>().material.mainTexture = gm.aktualny_budynek.asortyment_sklepu[3].obrazek;
            for (int i = 4; i < 20; i++)
            {
                gm.aktualny_budynek.asortyment_sklepu[i] = new ekwipunek(0, 0, "", 0, gm.emptyTexture);
                gm.asortyment_sklepu[i].GetComponent<Renderer>().material.mainTexture = gm.aktualny_budynek.asortyment_sklepu[i].obrazek;
            }
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
