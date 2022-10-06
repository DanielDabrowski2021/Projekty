using UnityEngine;
using System.Collections;

public class Cube_ekwipunek_postaci : MonoBehaviour
{


    private GeneratorMAPY gm;
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();
    }
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void lecz(int ilosc_hp)
    {
        if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp + ilosc_hp < gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp)
        {
            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp + ilosc_hp;
        }
        else
        {
            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp;
        }
        return;
    }
    void dodaj_mane(int ilosc_many)
    {
        if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana + ilosc_many < gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_mana)
        {
            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana + ilosc_many;
        }
        else
        {
            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_mana;
        }
        return;
    }
    void dodaj_sily_temp(int ilosc_sily)
    {
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].temp_sila = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].temp_sila + ilosc_sily;
        return;
    }
    void dodaj_sile(int ilosc_sily)
    {
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].sila = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].sila + ilosc_sily;
        return;
    }
    void dodaj_zrecznosc_temp(int ilosc_zrecznosci)
    {
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].temp_zrecznosc = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].temp_zrecznosc + ilosc_zrecznosci;
        return;
    }
    void dodaj_zrecznosc(int ilosc_zrecznosci)
    {
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].zrecznosc = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].zrecznosc + ilosc_zrecznosci;
        return;
    }
    void dodaj_mane_const(int ilosc_many)
    {
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_mana+ilosc_many;
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_mana;
        return;
    }
    void dodaj_zdrowie_const(int ilosc_hp)
    {
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp + ilosc_hp;
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp;
        return;
    }
    void OnMouseDown()
    {
             /*Z ziemi do kieszeni*/
		if ((gm.przedmiot_klikniety==true) && (this.tag=="ekwipunek_postaci_kieszenie") && (gm.inwentarz_narysowany!=true) && (gm.badam_cialo != true)) 
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			Debug.Log ("numer ekwipunku="+help1);
			Debug.Log ("gm.aktualna_druzyna_index="+gm.aktualna_druzyna_index);
			Debug.Log ("gm.aktualna_postac="+gm.aktualna_postac);

			if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj==-1)
			{
				if ((gm.aktualny_przedmiot.cena<=gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety==true))
				{
					if (gm.przedmiot_postaci_klikniety!=true)
						gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;

					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj=gm.aktualny_przedmiot.rodzaj;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer=gm.aktualny_przedmiot.numer;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc=gm.aktualny_przedmiot.wlasciwosc;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena=gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek=gm.aktualny_przedmiot.obrazek;
					this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
					if (gm.index_ekwipunku_sklepu!=-1)
					{
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc="brak";
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek=gm.emptyTexture;
						gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer> ().material.mainTexture=gm.emptyTexture;
						gm.index_ekwipunku_sklepu=-1;
					}
					gm.pokazuje_na_przedmiot=false;
					Debug.Log ("kupione");
					if ((gm.aktualny_przedmiot.rodzaj==6) && (gm.przedmiot_postaci_klikniety==true) && (gm.index_ekwipunku_postaci==10))
					{
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].rodzaj=-1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].obrazek=gm.glowaTexture;
						gm.ekwipunek_postaci_box[10].GetComponent<Renderer>().material.mainTexture=gm.glowaTexture;
					}
					if ((gm.aktualny_przedmiot.rodzaj==0) && (gm.przedmiot_postaci_klikniety==true) && (gm.index_ekwipunku_postaci==9))
					{
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].rodzaj=-1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].obrazek=gm.tulowTexture;
						gm.ekwipunek_postaci_box[9].GetComponent<Renderer>().material.mainTexture=gm.tulowTexture;
					}
					if ((gm.aktualny_przedmiot.rodzaj==5) && (gm.przedmiot_postaci_klikniety==true) && (gm.index_ekwipunku_postaci==8))
					{
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].rodzaj=-1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].obrazek=gm.nogiTexture;
						gm.ekwipunek_postaci_box[8].GetComponent<Renderer>().material.mainTexture=gm.nogiTexture;
					}
					if (((gm.aktualny_przedmiot.rodzaj==2)|| (gm.aktualny_przedmiot.rodzaj==3) || (gm.aktualny_przedmiot.rodzaj==4) || (gm.aktualny_przedmiot.rodzaj >= 100) ) && (gm.przedmiot_postaci_klikniety==true) && ((gm.index_ekwipunku_postaci==11)|| (gm.index_ekwipunku_postaci==12)))
					{
						if (gm.index_ekwipunku_postaci==11)
						{
							gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj=-1;
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer = -1;
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].obrazek=gm.prawarekaTexture;
							gm.ekwipunek_postaci_box[11].GetComponent<Renderer>().material.mainTexture=gm.prawarekaTexture;
						}
						if (gm.index_ekwipunku_postaci==12)
						{
							gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj=-1;
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer = -1;
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].obrazek=gm.lewarekaTexture;
							gm.ekwipunek_postaci_box[12].GetComponent<Renderer>().material.mainTexture=gm.lewarekaTexture;
						}
					}
					if ((gm.index_ekwipunku_postaci>=0) && (gm.index_ekwipunku_postaci<8))
					{
						gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture=gm.emptyTexture;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc="brak";
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek=gm.emptyTexture;
						gm.index_ekwipunku_postaci=-1;
					}
					/*gm.ekwipunek_postaci_box[10].tag="ekwipunek_postaci_glowa";
						gm.ekwipunek_postaci_box[9].tag="ekwipunek_postaci_tulow";
						gm.ekwipunek_postaci_box[8].tag="ekwipunek_postaci_nogi";
						gm.ekwipunek_postaci_box[11].tag="ekwipunek_postaci_prawa_reka";
						gm.ekwipunek_postaci_box[12].tag="ekwipunek_postaci_lewa_reka";
					 * 
					 * 
					 * */
					//gm.pokazuje_na_przedmiot=true;
					gm.przedmiot_klikniety=false;
					gm.pokazuje_na_przedmiot_postaci=false;
					gm.przedmiot_postaci_klikniety=false;
					gm.index_ekwipunku_postaci=-1;
				}
				else
				{
					gm.texthint.text="Za malo zlota";
					//gm.texthint.
					Debug.Log ("Za malo pieniedzy");
				}

			}
			return;
		}
		if ((gm.przedmiot_klikniety==true) && (this.tag=="ekwipunek_postaci_tulow") && (gm.aktualny_przedmiot.rodzaj==0) && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true)) 
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			Debug.Log ("numer ekwipunku tulow="+help1);
			Debug.Log ("gm.aktualna_druzyna_index="+gm.aktualna_druzyna_index);
			Debug.Log ("gm.aktualna_postac="+gm.aktualna_postac);
			Debug.Log ("Kupione na tulow=");
			if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj==-1)
			{
				if ((gm.aktualny_przedmiot.cena<=gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety==true))
				{
					if (gm.przedmiot_postaci_klikniety!=true)
						gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;

					//gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj=gm.aktualny_przedmiot.rodzaj;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer=gm.aktualny_przedmiot.numer;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc=gm.aktualny_przedmiot.wlasciwosc;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena=gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek=gm.aktualny_przedmiot.obrazek;
					this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
					if (gm.index_ekwipunku_sklepu!=-1)
					{
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc="brak";
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek=gm.emptyTexture;
						gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer> ().material.mainTexture=gm.emptyTexture;
						gm.index_ekwipunku_sklepu=-1;
					}
					gm.pokazuje_na_przedmiot=false;
					Debug.Log ("kupione");
					if ((gm.przedmiot_postaci_klikniety==true) && (gm.index_ekwipunku_postaci!=-1))
					{
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc="brak";
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek=gm.emptyTexture;
						//this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
						gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture=gm.emptyTexture;
					}
					gm.przedmiot_klikniety=false;
					gm.pokazuje_na_przedmiot_postaci=false;
					gm.przedmiot_postaci_klikniety=false;
					gm.index_ekwipunku_postaci=-1;
				}
				else
				{
					gm.texthint.text="Za malo zlota";
					//gm.texthint.
					Debug.Log ("Za malo pieniedzy");
				}
				
			}
			return;
		}
		if ((gm.przedmiot_klikniety==true) && ((this.tag=="ekwipunek_postaci_prawa_reka") || (this.tag=="ekwipunek_postaci_lewa_reka")) && ( (gm.aktualny_przedmiot.rodzaj==2) || (gm.aktualny_przedmiot.rodzaj==3) || (gm.aktualny_przedmiot.rodzaj==4) || (gm.aktualny_przedmiot.rodzaj >= 100)) && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true))
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			Debug.Log ("numer ekwipunku rece="+help1);
			Debug.Log ("gm.aktualna_druzyna_index="+gm.aktualna_druzyna_index);
			Debug.Log ("gm.aktualna_postac="+gm.aktualna_postac);
			Debug.Log ("Kupione do reki=");
			if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj==-1)
			{
				if ((gm.aktualny_przedmiot.cena<=gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety==true))
				{
					if (gm.przedmiot_postaci_klikniety!=true)
						gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;

					//gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj=gm.aktualny_przedmiot.rodzaj;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer=gm.aktualny_przedmiot.numer;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc=gm.aktualny_przedmiot.wlasciwosc;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena=gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek=gm.aktualny_przedmiot.obrazek;
					this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
					if (gm.index_ekwipunku_sklepu!=-1)
					{
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc="brak";
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek=gm.emptyTexture;
						gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer> ().material.mainTexture=gm.emptyTexture;
						gm.index_ekwipunku_sklepu=-1;
					}
					gm.pokazuje_na_przedmiot=false;
					Debug.Log ("kupione");
					if ((gm.przedmiot_postaci_klikniety==true) && (gm.index_ekwipunku_postaci!=-1))
					{
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc="brak";
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena=-1;
                        if (gm.index_ekwipunku_postaci == 11)
                        {
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].obrazek=gm.prawarekaTexture;
							gm.ekwipunek_postaci_box[11].GetComponent<Renderer>().material.mainTexture=gm.prawarekaTexture;
                        }
                        else if (gm.index_ekwipunku_postaci == 12) //19.07.2020
                        {
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].obrazek = gm.lewarekaTexture;
                            gm.ekwipunek_postaci_box[12].GetComponent<Renderer>().material.mainTexture = gm.lewarekaTexture;
                        }
                        else
                        {
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                            //this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
                            gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        }
					}
					gm.przedmiot_klikniety=false;
					gm.pokazuje_na_przedmiot_postaci=false;
					gm.przedmiot_postaci_klikniety=false;
					gm.index_ekwipunku_postaci=-1;
				}
				else
				{
					gm.texthint.text="Za malo zlota";
					//gm.texthint.
					Debug.Log ("Za malo pieniedzy");
				}
				
			}
			return;
		}
		if ((gm.przedmiot_klikniety==true) && (this.tag=="ekwipunek_postaci_nogi") && (gm.aktualny_przedmiot.rodzaj==5) && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true))
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			Debug.Log ("numer ekwipunku nogi="+help1);
			Debug.Log ("gm.aktualna_druzyna_index="+gm.aktualna_druzyna_index);
			Debug.Log ("gm.aktualna_postac="+gm.aktualna_postac);
			Debug.Log ("Kupione dla nog=");
			if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj==-1)
			{
				if ((gm.aktualny_przedmiot.cena<=gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety==true))
				{
					if (gm.przedmiot_postaci_klikniety!=true)
						gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;

					//gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj=gm.aktualny_przedmiot.rodzaj;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer=gm.aktualny_przedmiot.numer;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc=gm.aktualny_przedmiot.wlasciwosc;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena=gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek=gm.aktualny_przedmiot.obrazek;
					this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
					if (gm.index_ekwipunku_sklepu!=-1)
					{
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc="brak";
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek=gm.emptyTexture;
						gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer> ().material.mainTexture=gm.emptyTexture;
						gm.index_ekwipunku_sklepu=-1;
					}
					gm.pokazuje_na_przedmiot=false;
					Debug.Log ("kupione");

					if ((gm.przedmiot_postaci_klikniety==true) && (gm.index_ekwipunku_postaci!=-1))
					{
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc="brak";
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena=-1;
						gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek=gm.emptyTexture;
						//this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
						gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture=gm.emptyTexture;
					}
					gm.przedmiot_klikniety=false;
					gm.pokazuje_na_przedmiot_postaci=false;
					gm.przedmiot_postaci_klikniety=false;
					gm.index_ekwipunku_postaci=-1;
				}
				else
				{
					gm.texthint.text="Za malo zlota";
					//gm.texthint.
					Debug.Log ("Za malo pieniedzy");
				}
				
			}
			return;
		}
		if ((gm.przedmiot_klikniety==true) && (this.tag=="ekwipunek_postaci_glowa") && (gm.aktualny_przedmiot.rodzaj==6) && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true))
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			Debug.Log ("numer ekwipunku glowa="+help1);
			Debug.Log ("gm.aktualna_druzyna_index="+gm.aktualna_druzyna_index);
			Debug.Log ("gm.aktualna_postac="+gm.aktualna_postac);
			Debug.Log ("Kupione dla glowy=");

			if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj==-1)
			{
				if ((gm.aktualny_przedmiot.cena<=gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety==true))
				{
					if (gm.przedmiot_postaci_klikniety!=true)
						gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;

					//gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj=gm.aktualny_przedmiot.rodzaj;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer=gm.aktualny_przedmiot.numer;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc=gm.aktualny_przedmiot.wlasciwosc;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena=gm.aktualny_przedmiot.cena;
					gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek=gm.aktualny_przedmiot.obrazek;
					this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
					if (gm.index_ekwipunku_sklepu!=-1)
					{
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc="brak";
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena=-1;
						gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek=gm.emptyTexture;
						gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer> ().material.mainTexture=gm.emptyTexture;
						gm.index_ekwipunku_sklepu=-1;
					}
					gm.pokazuje_na_przedmiot=false;
					Debug.Log ("kupione");
					if (gm.przedmiot_postaci_klikniety==true)
					{
						if ((gm.index_ekwipunku_postaci>=0) && (gm.index_ekwipunku_postaci<8))
						{
							gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture=gm.emptyTexture;
							gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj=-1;
							gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer=-1;
							gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc="brak";
							gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena=-1;
							gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek=gm.emptyTexture;
							gm.index_ekwipunku_postaci=-1;
						}
					}
					gm.przedmiot_klikniety=false;
					gm.pokazuje_na_przedmiot_postaci=false;
					gm.przedmiot_postaci_klikniety=false;
					gm.index_ekwipunku_postaci=-1;
				}
				else
				{
					gm.texthint.text="Za malo zlota";
					//gm.texthint.
					Debug.Log ("Za malo pieniedzy");
				}
				
			}
			return;
		}

		if ((this.tag == "ekwipunek_postaci_kieszenie") && (this.GetComponent<Renderer> ().material.mainTexture != gm.emptyTexture) ) 
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			gm.aktualny_przedmiot=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
			gm.przedmiot_klikniety=true;
			gm.przedmiot_postaci_klikniety=true;
			gm.pokazuje_na_przedmiot=true;
			gm.pokazuje_na_przedmiot_postaci=true;
			gm.index_ekwipunku_postaci=help1;
			gm.index_ekwipunku_sklepu=-1;
			Debug.Log ("Kliknalem ekipunek");
			return;
		}
		if ((this.tag == "ekwipunek_postaci_tulow") && (this.GetComponent<Renderer> ().material.mainTexture != gm.tulowTexture)) 
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			gm.aktualny_przedmiot=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
			gm.przedmiot_klikniety=true;
			gm.przedmiot_postaci_klikniety=true;
			gm.pokazuje_na_przedmiot=true;
			gm.pokazuje_na_przedmiot_postaci=true;
			gm.index_ekwipunku_postaci=help1;
			gm.index_ekwipunku_sklepu=-1;
			return;
		}
		if ((this.tag == "ekwipunek_postaci_glowa") && (this.GetComponent<Renderer> ().material.mainTexture != gm.glowaTexture)) 
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			gm.aktualny_przedmiot=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
			gm.przedmiot_klikniety=true;
			gm.przedmiot_postaci_klikniety=true;
			gm.pokazuje_na_przedmiot=true;
			gm.pokazuje_na_przedmiot_postaci=true;
			gm.index_ekwipunku_postaci=help1;
			gm.index_ekwipunku_sklepu=-1;
			return;
		}
		if ((this.tag == "ekwipunek_postaci_nogi") && (this.GetComponent<Renderer> ().material.mainTexture != gm.nogiTexture)) 
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			gm.aktualny_przedmiot=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
			gm.przedmiot_klikniety=true;
			gm.przedmiot_postaci_klikniety=true;
			gm.pokazuje_na_przedmiot=true;
			gm.pokazuje_na_przedmiot_postaci=true;
			gm.index_ekwipunku_postaci=help1;
			gm.index_ekwipunku_sklepu=-1;
			return;
		}
		if ((this.tag == "ekwipunek_postaci_prawa_reka") && (this.GetComponent<Renderer> ().material.mainTexture != gm.prawarekaTexture)) 
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			gm.aktualny_przedmiot=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
			gm.przedmiot_klikniety=true;
			gm.przedmiot_postaci_klikniety=true;
			gm.pokazuje_na_przedmiot=true;
			gm.pokazuje_na_przedmiot_postaci=true;
			gm.index_ekwipunku_postaci=help1;
			gm.index_ekwipunku_sklepu=-1;
			return;
		}
		if ((this.tag == "ekwipunek_postaci_lewa_reka") && (this.GetComponent<Renderer> ().material.mainTexture != gm.lewarekaTexture)) 
		{
			int help1;
			help1=(int)gm.zwroc_numer_ekwipunku(this.transform.position.x,this.transform.position.z);
			gm.aktualny_przedmiot=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
			gm.przedmiot_klikniety=true;
			gm.przedmiot_postaci_klikniety=true;
			gm.pokazuje_na_przedmiot=true;
			gm.pokazuje_na_przedmiot_postaci=true;
			gm.index_ekwipunku_postaci=help1;
			gm.index_ekwipunku_sklepu=-1;
			return;
		}
        if (gm.pokazuje_na_przedmiot == true)
        {
            if ((gm.aktualny_przedmiot.numer == 1) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp < gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp)
                {
                    gm.pokazuje_na_przedmiot = false;
                    gm.przedmiot_klikniety = false;
                    //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                    //index_ekwipunku_postaci
                    lecz(30);
                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
                    }
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        //index_w_tabeli
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Mikstura zdrowia uzyta");
                    return;
                }
                else
                {
                    Debug.Log("Zdrowie pelne");
                    return;
                }
            }
            if ((gm.aktualny_przedmiot.numer == 9) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp < gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp)
                {
                    gm.pokazuje_na_przedmiot = false;
                    gm.przedmiot_klikniety = false;
                    //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                    //index_ekwipunku_postaci
                    lecz(15);
                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
                    }
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        //index_w_tabeli
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Ziolo zdrowia zuzyte");
                    return;
                }
                else
                {
                    Debug.Log("Zdrowie pelne");
                    return;
                }
            }
            if ((gm.aktualny_przedmiot.numer == 2) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana < gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_mana)
                {
                    gm.pokazuje_na_przedmiot = false;
                    gm.przedmiot_klikniety = false;
                    //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                    //index_ekwipunku_postaci
                    dodaj_mane(30);
                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
                    }
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        //index_w_tabeli
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Mikstura many uzyta");
                    return;
                }
                else
                {
                    Debug.Log("Mana pelna");
                    return;
                }
            }
            if ((gm.aktualny_przedmiot.numer == 3) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                    gm.pokazuje_na_przedmiot = false;
                    gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                    dodaj_sily_temp(5);
                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
                    }
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        //index_w_tabeli
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Mikstura sily tymczasowa uzyta");
                    return;
            }
            if ((gm.aktualny_przedmiot.numer == 11) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                gm.pokazuje_na_przedmiot = false;
                gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                dodaj_sily_temp(2);
                if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                {
                    gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                    gm.index_ekwipunku_postaci = -1;
                }
                if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                {
                    gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                    //index_w_tabeli
                    gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                }
                //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //this.ma
                Debug.Log("Ziolo sily tymczasowe zuzyte");
                return;
            }
            if ((gm.aktualny_przedmiot.numer == 4) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                gm.pokazuje_na_przedmiot = false;
                gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                dodaj_sile(2);
                if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                {
                    gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                    gm.index_ekwipunku_postaci = -1;
                }
                if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                {
                    gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                    //index_w_tabeli
                    gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                }
                //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //this.ma
                Debug.Log("Mikstura sily na stale zuzyta");
                return;
            }
            if ((gm.aktualny_przedmiot.numer == 5) && (gm.aktualny_przedmiot.rodzaj == 1)  && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                gm.pokazuje_na_przedmiot = false;
                gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                dodaj_zrecznosc_temp(5);
                if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                {
                    gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                    gm.index_ekwipunku_postaci = -1;
                }
                if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                {
                    gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                    //index_w_tabeli
                    gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                }
                //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //this.ma
                Debug.Log("Mikstura zrecznosci tymczasowa uzyta");
                return;
            }
            if ((gm.aktualny_przedmiot.numer == 12) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                gm.pokazuje_na_przedmiot = false;
                gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                dodaj_zrecznosc_temp(2);
                if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                {
                    gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                    gm.index_ekwipunku_postaci = -1;
                }
                if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                {
                    gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                    //index_w_tabeli
                    gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                }
                //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //this.ma
                Debug.Log("Ziolo zrecznosci tymczasowe zuzyte");
                return;
            }
            if ((gm.aktualny_przedmiot.numer == 6) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                gm.pokazuje_na_przedmiot = false;
                gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                dodaj_zrecznosc(2);
                if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                {
                    gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                    gm.index_ekwipunku_postaci = -1;
                }
                if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                {
                    gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                    //index_w_tabeli
                    gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                }
                //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //this.ma
                Debug.Log("Mikstura zrecznosci na stale zuzyta");
                return;
            }
            if ((gm.aktualny_przedmiot.numer == 7) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                gm.pokazuje_na_przedmiot = false;
                gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                dodaj_zdrowie_const(20);
                if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                {
                    gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                    gm.index_ekwipunku_postaci = -1;
                }
                if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                {
                    gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                    //index_w_tabeli
                    gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                }
                //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //this.ma
                Debug.Log("Mikstura zdrowia na stale zuzyta");
                return;
            }
            if ((gm.aktualny_przedmiot.numer == 8) && (gm.aktualny_przedmiot.rodzaj == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_glowa"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                gm.pokazuje_na_przedmiot = false;
                gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                dodaj_mane_const(20);
                if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                {
                    gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                    gm.index_ekwipunku_postaci = -1;
                }
                if (gm.index_ekwipunku_przedmiotu_na_ziemi != -1)
                {
                    gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                    gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                    //index_w_tabeli
                    gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                }
                //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //this.ma
                Debug.Log("Mikstura many na stale zuzyta");
                return;
            }
            if ((gm.aktualny_przedmiot.numer == 1) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && (this.tag == "ekwipunek_postaci_kieszenie"))
            {
                /*&& (gm.przedmiot_klikniety == true)*/
                int help1;
                help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
                //gm.pokazuje_na_przedmiot = false;
                //  gm.przedmiot_klikniety = false;
                //gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                //gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //index_ekwipunku_postaci
                if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("zabrane");


                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
                    }
                    if ((gm.aktualny_przedmiot.rodzaj == 0) && (gm.przedmiot_postaci_klikniety == true) && (gm.index_ekwipunku_postaci == 9))
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].obrazek = gm.tulowTexture;
                        gm.ekwipunek_postaci_box[9].GetComponent<Renderer>().material.mainTexture = gm.tulowTexture;
                    }
                    /*gm.ekwipunek_postaci_box[10].tag="ekwipunek_postaci_glowa";
                        gm.ekwipunek_postaci_box[9].tag="ekwipunek_postaci_tulow";
                        gm.ekwipunek_postaci_box[8].tag="ekwipunek_postaci_nogi";
                        gm.ekwipunek_postaci_box[11].tag="ekwipunek_postaci_prawa_reka";
                        gm.ekwipunek_postaci_box[12].tag="ekwipunek_postaci_lewa_reka";
                     * 
                     * 
                     * */
                    //gm.pokazuje_na_przedmiot=true;
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;


                    // gm.aktualna_druzyna.
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi >= 0)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                        gm.pokazuje_na_przedmiot = false;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Skora kliknieta");

                    return;
                }

            }
            if ((gm.aktualny_przedmiot.rodzaj == 10) && (gm.przedmiot_klikniety == true) && ((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true)) && ((this.tag == "ekwipunek_postaci_kieszenie") || (this.tag == "ekwipunek_postaci_tulow") || (this.tag == "ekwipunek_postaci_glowa") || (this.tag == "ekwipunek_postaci_nogi") || (this.tag == "ekwipunek_postaci_prawa_reka") || (this.tag == "ekwipunek_postaci_lewa_reka")))
            {
                gm.pokazuje_na_przedmiot = false;
                gm.przedmiot_klikniety = false;
                // gm.aktualna_druzyna.
                gm.tablica_druzyn[gm.aktualna_druzyna_index].zywnosc = gm.tablica_druzyn[gm.aktualna_druzyna_index].zywnosc + 100;
                gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                //index_w_tabeli
                gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                //this.ma
                Debug.Log("Żywność kliknieta");

                return;
            }
            if ((gm.aktualny_przedmiot.rodzaj == 0) && (gm.przedmiot_klikniety == true) && (((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true))) && ((this.tag == "ekwipunek_postaci_kieszenie") || (this.tag == "ekwipunek_postaci_tulow")))
            {
                int help1;
                help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
                Debug.Log("numer ekwipunku=" + help1);
                Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
                Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);

                if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("zabrane");


                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
                    }
                    if (gm.index_ekwipunku_postaci == 9)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].obrazek = gm.tulowTexture;
                        gm.ekwipunek_postaci_box[9].GetComponent<Renderer>().material.mainTexture = gm.tulowTexture;
                    }
                    /*gm.ekwipunek_postaci_box[10].tag="ekwipunek_postaci_glowa";
                        gm.ekwipunek_postaci_box[9].tag="ekwipunek_postaci_tulow";
                        gm.ekwipunek_postaci_box[8].tag="ekwipunek_postaci_nogi";
                        gm.ekwipunek_postaci_box[11].tag="ekwipunek_postaci_prawa_reka";
                        gm.ekwipunek_postaci_box[12].tag="ekwipunek_postaci_lewa_reka";
                     * 
                     * 
                     * */
                    //gm.pokazuje_na_przedmiot=true;
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;


                    // gm.aktualna_druzyna.
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi >= 0)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                        gm.pokazuje_na_przedmiot = false;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Skora kliknieta");

                    return;
                }
            }
            if ((gm.aktualny_przedmiot.rodzaj == 6) && (gm.przedmiot_klikniety == true) && (((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true))) && ((this.tag == "ekwipunek_postaci_kieszenie") || (this.tag == "ekwipunek_postaci_glowa")))
            {
                int help1;
                help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
                Debug.Log("numer ekwipunku=" + help1);
                Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
                Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);

                if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("zabrane");


                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
                    }
                    if (gm.index_ekwipunku_postaci == 10)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].obrazek = gm.glowaTexture;
                        gm.ekwipunek_postaci_box[10].GetComponent<Renderer>().material.mainTexture = gm.glowaTexture;
                    }
                    /*gm.ekwipunek_postaci_box[10].tag="ekwipunek_postaci_glowa";
                        gm.ekwipunek_postaci_box[9].tag="ekwipunek_postaci_tulow";
                        gm.ekwipunek_postaci_box[8].tag="ekwipunek_postaci_nogi";
                        gm.ekwipunek_postaci_box[11].tag="ekwipunek_postaci_prawa_reka";
                        gm.ekwipunek_postaci_box[12].tag="ekwipunek_postaci_lewa_reka";
                     * 
                     * 
                     * */
                    //gm.pokazuje_na_przedmiot=true;
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;


                    // gm.aktualna_druzyna.
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi >= 0)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                        gm.pokazuje_na_przedmiot = false;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Skora kliknieta");

                    return;
                }
            }
            if ((gm.aktualny_przedmiot.rodzaj == 5) && (gm.przedmiot_klikniety == true) && (((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true))) && ((this.tag == "ekwipunek_postaci_kieszenie") || (this.tag == "ekwipunek_postaci_nogi")))
            {
                int help1;
                help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
                Debug.Log("numer ekwipunku=" + help1);
                Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
                Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);

                if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("zabrane");


                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
                    }
                    if (gm.index_ekwipunku_postaci == 8)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].obrazek = gm.nogiTexture;
                        gm.ekwipunek_postaci_box[8].GetComponent<Renderer>().material.mainTexture = gm.nogiTexture;
                    }
                    /*gm.ekwipunek_postaci_box[10].tag="ekwipunek_postaci_glowa";
                        gm.ekwipunek_postaci_box[9].tag="ekwipunek_postaci_tulow";
                        gm.ekwipunek_postaci_box[8].tag="ekwipunek_postaci_nogi";
                        gm.ekwipunek_postaci_box[11].tag="ekwipunek_postaci_prawa_reka";
                        gm.ekwipunek_postaci_box[12].tag="ekwipunek_postaci_lewa_reka";
                     * 
                     * 
                     * */
                    //gm.pokazuje_na_przedmiot=true;
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;


                    // gm.aktualna_druzyna.
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi >= 0)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                        gm.pokazuje_na_przedmiot = false;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Skora kliknieta");

                    return;
                }
            }
            if (((gm.aktualny_przedmiot.rodzaj == 4) || (gm.aktualny_przedmiot.rodzaj == 2) || (gm.aktualny_przedmiot.rodzaj == 3)) && (gm.przedmiot_klikniety == true) && (((gm.badam_cialo == true) || (gm.inwentarz_narysowany == true))) && ((this.tag == "ekwipunek_postaci_kieszenie") || (this.tag == "ekwipunek_postaci_lewa_reka") || (this.tag == "ekwipunek_postaci_prawa_reka")))
            {
                int help1;
                help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
                Debug.Log("numer ekwipunku=" + help1);
                Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
                Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);

                if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("zabrane");


                    if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                    {
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        gm.index_ekwipunku_postaci = -1;
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
                    /*gm.ekwipunek_postaci_box[10].tag="ekwipunek_postaci_glowa";
                        gm.ekwipunek_postaci_box[9].tag="ekwipunek_postaci_tulow";
                        gm.ekwipunek_postaci_box[8].tag="ekwipunek_postaci_nogi";
                        gm.ekwipunek_postaci_box[11].tag="ekwipunek_postaci_prawa_reka";
                        gm.ekwipunek_postaci_box[12].tag="ekwipunek_postaci_lewa_reka";
                     * 
                     * 
                     * */
                    //gm.pokazuje_na_przedmiot=true;
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;


                    // gm.aktualna_druzyna.
                    if (gm.index_ekwipunku_przedmiotu_na_ziemi >= 0)
                    {
                        gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = new ekwipunek(-1, -1, "brak", -1, gm.emptyTexture);
                        gm.przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.tablica_malego_terenu[gm.index_w_tabeli[gm.aktualna_postac]].rzeczy_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi] = gm.ekwipunek_przedmioty_na_ziemi[gm.index_ekwipunku_przedmiotu_na_ziemi];
                        gm.index_ekwipunku_przedmiotu_na_ziemi = -1;
                        gm.pokazuje_na_przedmiot = false;
                    }
                    //gm.GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    //this.ma
                    Debug.Log("Zwoj klikniety");

                    return;
                }
            }
        }
        /*Z ziemi do kieszeni*/
        if ((gm.przedmiot_klikniety == true) && (this.tag == "ekwipunek_postaci_kieszenie") && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            Debug.Log("numer ekwipunku=" + help1);
            Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
            Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);

            if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
            {
                if ((gm.aktualny_przedmiot.cena <= gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety == true))
                {
                    if (gm.przedmiot_postaci_klikniety != true)
                        gm.tablica_graczy[1].pieniadze = gm.tablica_graczy[1].pieniadze - gm.aktualny_przedmiot.cena;

                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    if (gm.index_ekwipunku_sklepu != -1)
                    {
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc = "brak";
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek = gm.emptyTexture;
                        gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.index_ekwipunku_sklepu = -1;
                    }
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("kupione");
                    if ((gm.aktualny_przedmiot.rodzaj == 6) && (gm.przedmiot_postaci_klikniety == true) && (gm.index_ekwipunku_postaci == 10))
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].obrazek = gm.glowaTexture;
                        gm.ekwipunek_postaci_box[10].GetComponent<Renderer>().material.mainTexture = gm.glowaTexture;
                    }
                    if ((gm.aktualny_przedmiot.rodzaj == 0) && (gm.przedmiot_postaci_klikniety == true) && (gm.index_ekwipunku_postaci == 9))
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[9].obrazek = gm.tulowTexture;
                        gm.ekwipunek_postaci_box[9].GetComponent<Renderer>().material.mainTexture = gm.tulowTexture;
                    }
                    if ((gm.aktualny_przedmiot.rodzaj == 5) && (gm.przedmiot_postaci_klikniety == true) && (gm.index_ekwipunku_postaci == 8))
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[8].obrazek = gm.nogiTexture;
                        gm.ekwipunek_postaci_box[8].GetComponent<Renderer>().material.mainTexture = gm.nogiTexture;
                    }
                    if (((gm.aktualny_przedmiot.rodzaj == 2) || (gm.aktualny_przedmiot.rodzaj == 3) || (gm.aktualny_przedmiot.rodzaj == 4)) && (gm.przedmiot_postaci_klikniety == true) && ((gm.index_ekwipunku_postaci == 11) || (gm.index_ekwipunku_postaci == 12)))
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
                        gm.index_ekwipunku_postaci = -1;
                    }
                    /*gm.ekwipunek_postaci_box[10].tag="ekwipunek_postaci_glowa";
						gm.ekwipunek_postaci_box[9].tag="ekwipunek_postaci_tulow";
						gm.ekwipunek_postaci_box[8].tag="ekwipunek_postaci_nogi";
						gm.ekwipunek_postaci_box[11].tag="ekwipunek_postaci_prawa_reka";
						gm.ekwipunek_postaci_box[12].tag="ekwipunek_postaci_lewa_reka";
					 * 
					 * 
					 * */
                    //gm.pokazuje_na_przedmiot=true;
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;
                }
                else
                {
                    gm.texthint.text = "Za malo zlota";
                    //gm.texthint.
                    Debug.Log("Za malo pieniedzy");
                }

            }
            return;
        }
        if ((gm.przedmiot_klikniety == true) && (this.tag == "ekwipunek_postaci_tulow") && (gm.aktualny_przedmiot.rodzaj == 0) && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            Debug.Log("numer ekwipunku tulow=" + help1);
            Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
            Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);
            Debug.Log("Kupione na tulow=");
            if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
            {
                if ((gm.aktualny_przedmiot.cena <= gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety == true))
                {
                    if (gm.przedmiot_postaci_klikniety != true)
                        gm.tablica_graczy[1].pieniadze = gm.tablica_graczy[1].pieniadze - gm.aktualny_przedmiot.cena;

                    //gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    if (gm.index_ekwipunku_sklepu != -1)
                    {
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc = "brak";
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek = gm.emptyTexture;
                        gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.index_ekwipunku_sklepu = -1;
                    }
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("kupione");
                    if ((gm.przedmiot_postaci_klikniety == true) && (gm.index_ekwipunku_postaci != -1))
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        //this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    }
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;
                }
                else
                {
                    gm.texthint.text = "Za malo zlota";
                    //gm.texthint.
                    Debug.Log("Za malo pieniedzy");
                }

            }
            return;
        }
        if ((gm.przedmiot_klikniety == true) && ((this.tag == "ekwipunek_postaci_prawa_reka") || (this.tag == "ekwipunek_postaci_lewa_reka")) && ((gm.aktualny_przedmiot.rodzaj == 2) || (gm.aktualny_przedmiot.rodzaj == 3) || (gm.aktualny_przedmiot.rodzaj == 4)) && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            Debug.Log("numer ekwipunku rece=" + help1);
            Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
            Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);
            Debug.Log("Kupione do reki=");
            if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
            {
                if ((gm.aktualny_przedmiot.cena <= gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety == true))
                {
                    if (gm.przedmiot_postaci_klikniety != true)
                        gm.tablica_graczy[1].pieniadze = gm.tablica_graczy[1].pieniadze - gm.aktualny_przedmiot.cena;

                    //gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    if (gm.index_ekwipunku_sklepu != -1)
                    {
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc = "brak";
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek = gm.emptyTexture;
                        gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.index_ekwipunku_sklepu = -1;
                    }
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("kupione");
                    if ((gm.przedmiot_postaci_klikniety == true) && (gm.index_ekwipunku_postaci != -1))
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        //this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    }
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;
                }
                else
                {
                    gm.texthint.text = "Za malo zlota";
                    //gm.texthint.
                    Debug.Log("Za malo pieniedzy");
                }

            }
            return;
        }
        if ((gm.przedmiot_klikniety == true) && (this.tag == "ekwipunek_postaci_nogi") && (gm.aktualny_przedmiot.rodzaj == 5) && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            Debug.Log("numer ekwipunku nogi=" + help1);
            Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
            Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);
            Debug.Log("Kupione dla nog=");
            if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
            {
                if ((gm.aktualny_przedmiot.cena <= gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety == true))
                {
                    if (gm.przedmiot_postaci_klikniety != true)
                        gm.tablica_graczy[1].pieniadze = gm.tablica_graczy[1].pieniadze - gm.aktualny_przedmiot.cena;

                    //gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    if (gm.index_ekwipunku_sklepu != -1)
                    {
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc = "brak";
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek = gm.emptyTexture;
                        gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.index_ekwipunku_sklepu = -1;
                    }
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("kupione");

                    if ((gm.przedmiot_postaci_klikniety == true) && (gm.index_ekwipunku_postaci != -1))
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                        //this.GetComponent<Renderer> ().material.mainTexture=gm.aktualny_przedmiot.obrazek;
                        gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                    }
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;
                }
                else
                {
                    gm.texthint.text = "Za malo zlota";
                    //gm.texthint.
                    Debug.Log("Za malo pieniedzy");
                }

            }
            return;
        }
        if ((gm.przedmiot_klikniety == true) && (this.tag == "ekwipunek_postaci_glowa") && (gm.aktualny_przedmiot.rodzaj == 6) && (gm.inwentarz_narysowany != true) && (gm.badam_cialo != true))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            Debug.Log("numer ekwipunku glowa=" + help1);
            Debug.Log("gm.aktualna_druzyna_index=" + gm.aktualna_druzyna_index);
            Debug.Log("gm.aktualna_postac=" + gm.aktualna_postac);
            Debug.Log("Kupione dla glowy=");

            if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj == -1)
            {
                if ((gm.aktualny_przedmiot.cena <= gm.tablica_graczy[1].pieniadze) || (gm.przedmiot_postaci_klikniety == true))
                {
                    if (gm.przedmiot_postaci_klikniety != true)
                        gm.tablica_graczy[1].pieniadze = gm.tablica_graczy[1].pieniadze - gm.aktualny_przedmiot.cena;

                    //gm.tablica_graczy[1].pieniadze=gm.tablica_graczy[1].pieniadze-gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].rodzaj = gm.aktualny_przedmiot.rodzaj;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].numer = gm.aktualny_przedmiot.numer;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].wlasciwosc = gm.aktualny_przedmiot.wlasciwosc;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].cena = gm.aktualny_przedmiot.cena;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1].obrazek = gm.aktualny_przedmiot.obrazek;
                    this.GetComponent<Renderer>().material.mainTexture = gm.aktualny_przedmiot.obrazek;
                    if (gm.index_ekwipunku_sklepu != -1)
                    {
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].rodzaj = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].numer = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].wlasciwosc = "brak";
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].cena = -1;
                        gm.aktualny_budynek.asortyment_sklepu[gm.index_ekwipunku_sklepu].obrazek = gm.emptyTexture;
                        gm.asortyment_sklepu[gm.index_ekwipunku_sklepu].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                        gm.index_ekwipunku_sklepu = -1;
                    }
                    gm.pokazuje_na_przedmiot = false;
                    Debug.Log("kupione");
                    if (gm.przedmiot_postaci_klikniety == true)
                    {
                        if ((gm.index_ekwipunku_postaci >= 0) && (gm.index_ekwipunku_postaci < 8))
                        {
                            gm.ekwipunek_postaci_box[gm.index_ekwipunku_postaci].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].rodzaj = -1;
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].numer = -1;
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].wlasciwosc = "brak";
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].cena = -1;
                            gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[gm.index_ekwipunku_postaci].obrazek = gm.emptyTexture;
                            gm.index_ekwipunku_postaci = -1;
                        }
                    }
                    gm.przedmiot_klikniety = false;
                    gm.pokazuje_na_przedmiot_postaci = false;
                    gm.przedmiot_postaci_klikniety = false;
                    gm.index_ekwipunku_postaci = -1;
                }
                else
                {
                    gm.texthint.text = "Za malo zlota";
                    //gm.texthint.
                    Debug.Log("Za malo pieniedzy");
                }

            }
            return;
        }

        if ((this.tag == "ekwipunek_postaci_kieszenie") && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.przedmiot_klikniety = true;
            gm.przedmiot_postaci_klikniety = true;
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            gm.index_ekwipunku_sklepu = -1;
            Debug.Log("Kliknalem ekipunek");
            return;
        }
        if ((this.tag == "ekwipunek_postaci_tulow") && (this.GetComponent<Renderer>().material.mainTexture != gm.tulowTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.przedmiot_klikniety = true;
            gm.przedmiot_postaci_klikniety = true;
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            gm.index_ekwipunku_sklepu = -1;
            return;
        }
        if ((this.tag == "ekwipunek_postaci_glowa") && (this.GetComponent<Renderer>().material.mainTexture != gm.glowaTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.przedmiot_klikniety = true;
            gm.przedmiot_postaci_klikniety = true;
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            gm.index_ekwipunku_sklepu = -1;
            return;
        }
        if ((this.tag == "ekwipunek_postaci_nogi") && (this.GetComponent<Renderer>().material.mainTexture != gm.nogiTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.przedmiot_klikniety = true;
            gm.przedmiot_postaci_klikniety = true;
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            gm.index_ekwipunku_sklepu = -1;
            return;
        }
        if ((this.tag == "ekwipunek_postaci_prawa_reka") && (this.GetComponent<Renderer>().material.mainTexture != gm.prawarekaTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.przedmiot_klikniety = true;
            gm.przedmiot_postaci_klikniety = true;
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            gm.index_ekwipunku_sklepu = -1;
            return;
        }
        if ((this.tag == "ekwipunek_postaci_lewa_reka") && (this.GetComponent<Renderer>().material.mainTexture != gm.lewarekaTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.przedmiot_klikniety = true;
            gm.przedmiot_postaci_klikniety = true;
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            gm.index_ekwipunku_sklepu = -1;
            return;
        }

    }
    void OnMouseEnter()
    {
        if ((this.tag == "ekwipunek_postaci_kieszenie") && (this.GetComponent<Renderer>().material.mainTexture != gm.emptyTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            return;
            //gm.przedmiot_klikniety=true;
        }
        if ((this.tag == "ekwipunek_postaci_tulow") && (this.GetComponent<Renderer>().material.mainTexture != gm.tulowTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            return;
        }
        if ((this.tag == "ekwipunek_postaci_glowa") && (this.GetComponent<Renderer>().material.mainTexture != gm.glowaTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            return;
        }
        if ((this.tag == "ekwipunek_postaci_nogi") && (this.GetComponent<Renderer>().material.mainTexture != gm.nogiTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            return;

        }
        if ((this.tag == "ekwipunek_postaci_prawa_reka") && (this.GetComponent<Renderer>().material.mainTexture != gm.prawarekaTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            //gm.przedmiot_klikniety=true;
            //gm.przedmiot_postaci_klikniety=true;
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            return;
        }
        if ((this.tag == "ekwipunek_postaci_lewa_reka") && (this.GetComponent<Renderer>().material.mainTexture != gm.lewarekaTexture))
        {
            int help1;
            help1 = (int)gm.zwroc_numer_ekwipunku(this.transform.position.x, this.transform.position.z);
            gm.aktualny_przedmiot = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[help1];
            //gm.przedmiot_klikniety=true;
            //gm.przedmiot_postaci_klikniety=true;
            gm.pokazuje_na_przedmiot = true;
            gm.pokazuje_na_przedmiot_postaci = true;
            gm.index_ekwipunku_postaci = help1;
            return;
        }

    }
}