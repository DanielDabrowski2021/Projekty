using UnityEngine;
using System.Collections;

public class Cube_asortyment_sklepu : MonoBehaviour {

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

    void OnMouseEnter()
    {
        if ((gm.kupowanie_u_mysliwego == true) && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            //gm.aktualny_przedmiot=gm.aktualny_budynek.asortyment_sklepu[0];
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.aktualny_budynek.asortyment_sklepu[help1];
            gm.pokazuje_na_przedmiot = true;
            Debug.Log("Mysliwy, wskazuje na przedmiot");
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
        if ((gm.kupowanie_u_alchemika == true) && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            //gm.aktualny_przedmiot=gm.aktualny_budynek.asortyment_sklepu[0];
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.aktualny_budynek.asortyment_sklepu[help1];
            gm.pokazuje_na_przedmiot = true;
            Debug.Log("Alchemik, wskazuje na przedmiot");
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
        if ((gm.kupowanie_u_platnerza == true)  && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            //gm.aktualny_przedmiot=gm.aktualny_budynek.asortyment_sklepu[0];
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.aktualny_budynek.asortyment_sklepu[help1];
            gm.pokazuje_na_przedmiot = true;
            Debug.Log("Platnerz, wskazuje na przedmiot");
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
        if ((gm.kupowanie_w_bibliotece == true) && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            //gm.aktualny_przedmiot=gm.aktualny_budynek.asortyment_sklepu[0];
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.aktualny_budynek.asortyment_sklepu[help1];
            gm.pokazuje_na_przedmiot = true;
            Debug.Log("Biblioteka, wskazuje na przedmiot");
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
    }
    void OnMouseDown()
    {
        if ((gm.przedmiot_postaci_klikniety == true) && (this.GetComponent<Renderer>().material.mainTexture == gm.emptyTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.tablica_graczy[1].pieniadze = gm.tablica_graczy[1].pieniadze + gm.aktualny_przedmiot.cena;
            gm.aktualny_budynek.asortyment_sklepu[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
            gm.aktualny_budynek.asortyment_sklepu[help1].numer = gm.aktualny_przedmiot.numer;
            gm.aktualny_budynek.asortyment_sklepu[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
            gm.aktualny_budynek.asortyment_sklepu[help1].cena = gm.aktualny_przedmiot.cena;
            gm.aktualny_budynek.asortyment_sklepu[help1].obrazek = gm.aktualny_przedmiot.obrazek;
            this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;

            if (gm.index_ekwipunku_postaci == 10)
            {
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].rodzaj = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].numer = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].obrazek = gm.glowaTexture;
                gm.ekwipunek_postaci_box[10].GetComponent<Renderer>().material.mainTexture = gm.glowaTexture;
            }
            if (gm.index_ekwipunku_postaci == 9)
            {
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].rodzaj = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].numer = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].obrazek = gm.tulowTexture;
                gm.ekwipunek_postaci_box[9].GetComponent<Renderer>().material.mainTexture = gm.tulowTexture;
            }
            if (gm.index_ekwipunku_postaci == 8)
            {
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].rodzaj = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].numer = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].obrazek = gm.nogiTexture;
                gm.ekwipunek_postaci_box[8].GetComponent<Renderer>().material.mainTexture = gm.nogiTexture;
            }
            if ((gm.index_ekwipunku_postaci == 11) || (gm.index_ekwipunku_postaci == 12))
            {
                if (gm.index_ekwipunku_postaci == 11)
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].obrazek = gm.prawarekaTexture;
                    gm.ekwipunek_postaci_box[11].GetComponent<Renderer>().material.mainTexture = gm.prawarekaTexture;
                }
                if (gm.index_ekwipunku_postaci == 12)
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].obrazek = gm.lewarekaTexture;
                    gm.ekwipunek_postaci_box[12].GetComponent<Renderer>().material.mainTexture = gm.lewarekaTexture;
                }
            }
            if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
            {
                gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
            }
            gm.pokazuje_na_przedmiot = false;
            gm.pokazuje_na_przedmiot_postaci = false;
            gm.przedmiot_klikniety = false;
            gm.przedmiot_postaci_klikniety = false;
            gm.index_ekwipunku_postaci = -1;
            gm.index_ekwipunku_sklepu = -1;
            return;
        }
        if ((gm.kupowanie_u_mysliwego == true) && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.aktualny_budynek.asortyment_sklepu[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.przedmiot_klikniety = true;
            Debug.Log("Skora kliknieta 1");
            gm.pokazuje_na_przedmiot_postaci = false;
            gm.przedmiot_postaci_klikniety = false;
            gm.index_ekwipunku_postaci = -1;
            gm.index_ekwipunku_sklepu = help1;
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
        if ((gm.kupowanie_u_platnerza == true) && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.aktualny_budynek.asortyment_sklepu[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.przedmiot_klikniety = true;
            gm.pokazuje_na_przedmiot_postaci = false;
            gm.przedmiot_postaci_klikniety = false;
            gm.index_ekwipunku_postaci = -1;
            gm.index_ekwipunku_sklepu = help1;
            Debug.Log("Skora kliknieta 2");
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
        if ((gm.kupowanie_u_alchemika == true) && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.aktualny_budynek.asortyment_sklepu[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.przedmiot_klikniety = true;
            gm.pokazuje_na_przedmiot_postaci = false;
            gm.przedmiot_postaci_klikniety = false;
            gm.index_ekwipunku_postaci = -1;
            gm.index_ekwipunku_sklepu = help1;
            Debug.Log("Skora kliknieta 3");
            Debug.Log("Numer kliknietego ewkipunku:" + help1);
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
        if ((gm.kupowanie_w_bibliotece == true)  && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.aktualny_budynek.asortyment_sklepu[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.przedmiot_klikniety = true;
            gm.pokazuje_na_przedmiot_postaci = false;
            gm.przedmiot_postaci_klikniety = false;
            gm.index_ekwipunku_postaci = -1;
            gm.index_ekwipunku_sklepu = help1;
            Debug.Log("Skora kliknieta 4");
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
    }
}
