using UnityEngine;
using System.Collections;

public class Cube_przedmiot_na_ziemi : MonoBehaviour
{

    // Use this for initialization
    private GeneratorMAPY gm;
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    float zwroc_numer_przedmiotu_na_ziemi(float position_x)
    {
        return (position_x - 155) / 5;
    }
    void OnMouseDown()
    {
        if (((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            int help1;
            help1 = (int)zwroc_numer_przedmiotu_na_ziemi(this.transform.position.x);
            gm.aktualny_przedmiot = gm.ekwipunek_przedmioty_na_ziemi[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.przedmiot_klikniety = true;
            Debug.Log("Przedmiot na ziemi klikniety");
            gm.pokazuje_na_przedmiot_postaci = false;
            gm.przedmiot_postaci_klikniety = false;
            gm.index_ekwipunku_postaci = -1;
            gm.index_ekwipunku_przedmiotu_na_ziemi = help1;
            return;
            //GUI.Label (new Rect (160, 25, 200, 50), gm.aktualny_budynek.asortyment_sklepu[0].cena.ToString());
            //Debug.Log("Skora");
        }
        if ((gm.przedmiot_postaci_klikniety == true) && (this.GetComponent<Renderer>().material.mainTexture == gm.emptyTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);

            gm.ekwipunek_przedmioty_na_ziemi[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
            gm.ekwipunek_przedmioty_na_ziemi[help1].numer = gm.aktualny_przedmiot.numer;
            gm.ekwipunek_przedmioty_na_ziemi[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
            gm.ekwipunek_przedmioty_na_ziemi[help1].cena = gm.aktualny_przedmiot.cena;
            gm.ekwipunek_przedmioty_na_ziemi[help1].obrazek = gm.aktualny_przedmiot.obrazek;
            this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
            gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[help1] = gm.ekwipunek_przedmioty_na_ziemi[help1];


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

    }
    void OnMouseEnter()
    {
        if (((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            int help1;
            Debug.Log("Przeszukuje cialo");

            help1 = (int)zwroc_numer_przedmiotu_na_ziemi(this.transform.position.x);
            Debug.Log("Przedmiot numer" + help1);
            gm.aktualny_przedmiot = gm.ekwipunek_przedmioty_na_ziemi[help1];
            gm.pokazuje_na_przedmiot = true;
            return;
        }
        if (((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.GetComponent<Renderer>().material.mainTexture == gm.emptyTexture))
        {
            Debug.Log("Pusty kwadrat");
            gm.pokazuje_na_przedmiot = false;
            return;
        }
    }
}
