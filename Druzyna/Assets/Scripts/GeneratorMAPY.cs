using UnityEngine;
using UnityEngine.UI;
//using UnityEngine;
using System.Collections;
using System;
public class ekwipunek
{
	public int numer;
	public int rodzaj;
	public string wlasciwosc;
	public int cena;
	public Texture2D obrazek;
	public ekwipunek(int numer_,int rodzaj_,string wlasciwosc_,int cena_,Texture2D obrazek_)
	{
		numer = numer_;
		rodzaj = rodzaj_;
		wlasciwosc = wlasciwosc_;
		cena = cena_;
		obrazek = obrazek_;
	}
	
}
public class gracz
{
	public Color kolor;
	public int numer;
	public string nazwa;
	public int liczba_druzyn;
	public druzyna[] tablica_druzyn=new druzyna[10];
	public int pieniadze;
	public int liczba_miast;
	public miasto[] tablica_miast=new miasto[50];
	public gracz(Color kolor_,int numer_,string nazwa_,int liczba_druzyn_,int pieniadze_,int liczba_miast_)
	{
		kolor = kolor_;
		numer = numer_;
		nazwa = nazwa_;
		liczba_druzyn = liczba_druzyn_;
		pieniadze = pieniadze_;
		liczba_miast = liczba_miast_;
	}
}
public class obiekt_pole_mapy
{
	public int kolor;
	public int positionx;
	public int positionz;
	public int number;
	public int zajete;
	public int rodzaj_terenu;
	public int rodzaj_miasta;
	public obiekt_pole_mapy(int x,int z,int number_,int zajete_,int kolor_,int rodzaj_terenu_,int rodzaj_miasta_)
	{
		positionx=x;
		positionz=z;
		number=number_;
		zajete=zajete_;
		kolor=kolor_;
		rodzaj_terenu = rodzaj_terenu_;
		rodzaj_miasta = rodzaj_miasta_;
	}
	
}
public class obiekt_pole_malego_terenu
{
	public int kolor;
	public int positionx;
	public int positionz;
	public int number;
	public int zajete;
	public int rodzaj_terenu;
	public int rodzaj_miasta;
	public ekwipunek[] rzeczy_na_ziemi=new ekwipunek[4];
	public obiekt_pole_malego_terenu(int x,int z,int number_,int zajete_,int kolor_,int rodzaj_terenu_,int rodzaj_miasta_)
	{
		positionx=x;
		positionz=z;
		number=number_;
		zajete=zajete_;
		kolor=kolor_;
		rodzaj_terenu = rodzaj_terenu_;
		rodzaj_miasta = rodzaj_miasta_;
	}


}
public class budynek
{
	public ekwipunek[] asortyment_sklepu=new ekwipunek[20];
	public string nazwa;
	public int cena_wybudowania;
	public int rodzaj;
	public budynek(string nazwa_,int cena_wybudowania_,int rodzaj_)
	{
		nazwa = nazwa_;
		cena_wybudowania = cena_wybudowania_;
		rodzaj = rodzaj_;
	}
}
public class miasto
{
	public int wielkosc; //0- wioska,1-miasteczko,2-miasto
	public int obszar_mapy;//grupy lewy gorny 0 z<50 x<50 ,z<50 x>=50 lewy dolny 1,z>=50 x<50 prawy gorny 2,z=>50 x>=50 prawy dolny 3
	public int wlasciciel; //0 -neutralny,1 - gracz,2- player one,3 -player two, 4- player three
	public int positionx;
	public int positionz;
	public int number;
	public int mury; //0 -brak,1 sa, wioska palisada, miasteczko mur kamienny,miasto mur granitowy
	public int rodzaj_terenu;
	public int liczba_ludnosci;
	public int podatki;

	public miasto(int x,int z,int number_,int wlasciciel_,int wielkosc_,int rodzaj_terenu_,int mury_,int obszar_mapy_,int liczba_ludnosci_,int podatki_)
	{
		positionx=x;
		positionz=z;
		number=number_;
		wlasciciel=wlasciciel_;
		wielkosc=wielkosc_;
		rodzaj_terenu = rodzaj_terenu_;
		obszar_mapy = obszar_mapy_;
		mury = mury_;
		liczba_ludnosci = liczba_ludnosci_;
		podatki = podatki_;
	}
}

public class postac
{
	public string imie;
	public int rasa;
	public int actual_hp;
	public int max_hp;
	public int sila;
	public int actual_mana;
	public int max_mana;
	public int exp;
	public int lvl;
    public int zrecznosc;
    public int atak;
    public int obrona;
    public ekwipunek[] tablica_ekwipunku=new ekwipunek[13];
    public bool zywy;
    public int temp_sila;
    public int temp_zrecznosc;
    public int temp_obrona;
	public postac(int rasa_,int actual_hp_,int max_hp_,int sila_, int zrecznosc_, int atak_, int obrona_,int actual_mana_,int max_mana_,string imie_,bool zywy_)
	{
		rasa = rasa_;
		actual_hp = actual_hp_;
		max_hp = max_hp_;
		sila = sila_;
        zrecznosc = zrecznosc_;
        atak = atak_;
        obrona = obrona_;
		actual_mana = actual_mana_;
		max_mana = max_mana_;
		exp = 0;
		lvl = 1;
		imie = imie_;
        zywy = zywy_;
        temp_sila = 0;
        temp_zrecznosc = 0;
        temp_obrona = 0;
    }
}
public class druzyna
{
	public string nazwa;
	public int numer_druzyny_gracza;
	public int numer_globalny;
	public int ilosc_postaci;
	public int gracz;
	public int sila;
	public int positionx;
	public int positionz;
	public int zywnosc;
	public int numer_pola;
	public postac[] tablica_postaci=new postac[10];
	public ekwipunek[] tablica_wspolnego_ekwipunku=new ekwipunek[8];
	public druzyna(int ilosc_,int gracz_,int sila_)
	{
		ilosc_postaci = ilosc_;
		gracz = gracz_;
		sila = sila_;
	}
	public int oblicz_sile()
	{
		int suma = 0;
		for (int i=0; i<ilosc_postaci; i++) 
		{
			suma=suma+tablica_postaci[i].sila;
		}
		return suma;
	}
}
public class wrog_potwor
{
    public string nazwa;
    public int rasa;
    public int actual_hp;
    public int max_hp;
    public int sila;
    public int actual_mana;
    public int max_mana;
    public int zrecznosc;
    public int atak;
    public int obrona;
    public int exp;
    public int ilosc_przeciwnikow;
    public int exp_dodany;
    public int[] sasiednie_pola = new int[8];
    public wrog_potwor(string nazwa_,int rasa_, int actual_hp_, int max_hp_, int sila_, int zrecznosc_, int atak_, int obrona_, int actual_mana_, int max_mana_,int exp_)
    {
        nazwa = nazwa_;
        rasa = rasa_;
        actual_hp = actual_hp_;
        max_hp = max_hp_;
        sila = sila_;
        zrecznosc = zrecznosc_;
        atak = atak_;
        obrona = obrona_;
        actual_mana = actual_mana_;
        max_mana = max_mana_;
        exp = exp_;
        ilosc_przeciwnikow = 0;
        exp_dodany = 0;
    }
}
public class GeneratorMAPY : MonoBehaviour {

	public GameObject cube;
    public GameObject cube_tlo;
    public GameObject cube_asortyment_sklepu;
    public GameObject cube_ekwipunek_postaci;
    public GameObject cube_przedmiot_na_ziemi;
    public GameObject cube_spichlerz;
    public GameObject cube_platnerz;
    public GameObject cube_biblioteka;
    public GameObject cube_alchemik;
    public GameObject cube_mysliwy;
    public GameObject cube_pole;
    public GameObject cube_pole_malego_terenu;
    public GameObject cube_miasto;
    public GameObject sphere_miasto;
	public GameObject cylinder_miasto;
	public GameObject capsule_druzyna;
    public GameObject cube_postac;
    public GameObject cube_wrog;
    public GameObject camera_;
    public GameObject wrog1;
    public GameObject wrog2;
    public GameObject wrog3;
    public GameObject wrog4;
    public GameObject wrog5;
    public GameObject wrog6;
    public GameObject wrog7;
    public GameObject wrog8;
    public GameObject wrog9;
    public GameObject wrog10;


    public GameObject budynek, budynek1, budynek2, budynek3, budynek4;
   // public Image Test_paska_zdrowia;
    //public GameObject aktualna_druzyna;
    public NewBehaviourScript aktualna_druzyna;
	public GameObject[] pole=new GameObject[10000];
	public GameObject[] pole_malego_terenu_=new GameObject[625];
	public GameObject[] miasto_prostokat = new GameObject[50];
	public GameObject[] druzyna_capsule= new GameObject[40];
    public GameObject[] postacie = new GameObject[10];
    private Vector3 pozycja;
	
	private int pozycjax,pozycjaz,licznik;
	public int pozycjax_zaznaczonego, pozycjaz_zaznaczonego;
	public int pozycjax_kliknietego, pozycjaz_kliknietego;
    //public int index_w_tabeli=0;//-1 dla kazdej postaci w druzynie
    public int[] index_w_tabeli = new int[10];
    public obiekt_pole_mapy[] tablica=new obiekt_pole_mapy[10000];
	public obiekt_pole_malego_terenu[] tablica_malego_terenu = new obiekt_pole_malego_terenu[625];
	public miasto[] tablica_miast=new miasto[50];
	public druzyna[] tablica_druzyn=new druzyna[40];
	public gracz[] tablica_graczy = new gracz[5];
	public Texture2D spichlerzTexture;
	public Texture2D graczeTexture;
	public Texture2D platnerzTexture;
	public Texture2D bibliotekaTexture;
	public Texture2D alchemikTexture;
	public Texture2D mysliwyTexture;
	public Texture2D glowaTexture;
	public Texture2D tulowTexture;
	public Texture2D nogiTexture;
	public Texture2D lewarekaTexture;
	public Texture2D prawarekaTexture;
	public Texture2D smiercTexture;
	public Texture2D skoraTexture;
	public Texture2D skorzanebutyTexture;
	public Texture2D miksturahpTexture;
	public Texture2D miksturamanaTexture;
    public Texture2D miksturasilatempTexture;
    public Texture2D miksturasilaTexture;
    public Texture2D miksturazrecznosctempTexture;
    public Texture2D miksturazrecznoscTexture;
    public Texture2D miksturahpconstTexture;
    public Texture2D miksturamanaconstTexture;
    public Texture2D ziolozdrowieTexture;
    public Texture2D ziolosilaTexture;
    public Texture2D ziolozrecznoscTexture;
    public Texture2D mieczTexture;
	public Texture2D tarczaTexture;
    public Texture2D lukTexture;
    public Texture2D strzalyTexture;
    public Texture2D procaTexture;
    public Texture2D pociskiTexture;
    public Texture2D katapultaTexture;
    public Texture2D kamienTexture;
    public Texture2D zwojTexture;
	public Texture2D helmTexture;
    public Texture2D zbrojaTexture;
    public Texture2D toporTexture;
    public Texture2D maczugaTexture;
    public Texture2D mlotTexture;
    public Texture2D laskaTexture;
	public Texture2D emptyTexture;
    public Texture2D wilkTexture;
    public Texture2D jelenTexture;
    public Texture2D dzikTexture;
    public Texture2D gargoylTexture;
    public Texture2D niedzwiedzTexture;
    public Texture2D skorpionTexture;
    public Texture2D warpunTexture;
    public Texture2D sarnaTexture;
    public Texture2D miesoTexture;
    public Texture2D postacgracza1Texture;
    public Texture2D korzenTexture;
    public Texture2D kwiatTexture;
    public Texture2D zlotoTexture;
    public Texture2D klejnotyTexture;
    public Texture2D rogiTexture;
    public Texture2D zebywTexture;
    public Texture2D ogonTexture;
    public Text texthint;

	private int numer,licznikkulek,wylosowanykolor;
	private Color kolorek;
	public int numeraktualny;
	public int punkty=0;
	public int rekord=0;
	public bool menu_wyboru_graczy = false;
	private int generowanie_wrogow=0;
	private int liczba_miast = 0;
	public string ilosc_jedzenia_do_kupienia = "0";
	public string imie_gracza="";
	public string imie_gracza_1="";
	public string imie_gracza_2="";
	public string imie_gracza_3="";
	public int ilosc_dostepnego_jedzenia=1000;
	public bool zaznaczona_druzyna = false;
    public bool wybrana_postac = false;
    //public bool wybrany_wrog = false;
    public bool[] wybrane_pole = new bool[10];
    public float[] wybrane_pole_x = new float[10];
    public float[] wybrane_pole_z = new float[10];
    public float[] postac_gracza_positionx = new float[10];
    public float[] postac_gracza_positionz = new float[10];
    public float[] test1 = new float[10];
    public float[] test2 = new float[10];
    // public bool x_ok = false;
    // public bool z_ok = false;
   // public float[] x_ok = new float[10];
   // public float[] z_ok = new float[10];

    public bool walka_w_trakcie = false;
    public bool pause = true;//false
   // public bool ruszaj = false;
	public bool zaznaczone_pole_docelowe=false;
	public bool kupowanie_jedzenia_ = false;
	public bool kupowanie_u_platnerza=false;
    public bool badam_cialo = false;
	public bool kupowanie_w_bibliotece = false;
	public bool kupowanie_u_alchemika=false;
	public bool kupowanie_u_mysliwego = false;
	public bool wizyta_w_miescie = false;
    public bool polowanie = false;
    public bool pokazuje_inwentarz = false;
    public bool inwentarz_narysowany = false;
    public bool smierglodowa=false;
    public bool smiercpokonani = false;
    public int zywnosc_startowa=1000;
	public int aktualna_druzyna_index = 0;
	public int aktualna_postac=0;
	public int wylosowane = 0;
	public GameObject tlo;
	public GameObject[] asortyment_sklepu=new GameObject[20];
    public GameObject[] przedmioty_na_ziemi = new GameObject[4];
	public GameObject[] ekwipunek_postaci_box = new GameObject[13];
	public budynek aktualny_budynek;
	public ekwipunek aktualny_przedmiot;
    public ekwipunek[] ekwipunek_przedmioty_na_ziemi = new ekwipunek[4];
    public bool pokazuje_na_przedmiot = false;
	public bool przedmiot_klikniety=false;
	public bool pokazuje_na_przedmiot_postaci = false;
	public bool przedmiot_postaci_klikniety=false;
	public int index_ekwipunku_postaci=-1;
	public int index_ekwipunku_sklepu=-1;
    public int index_ekwipunku_przedmiotu_na_ziemi = -1;
    public int poczatkowa_liczba_postaci_gracza = 0;
    // public float postac_gracza_positionx = 0; //dla kazdej postaci w druzynie
    //  public float postac_gracza_positionz = 0; //dla kazdej postaci w druzynie
   // public float[] postac_gracza_positionx = new float[10];
  //  public float[] postac_gracza_positionz = new float[10];
    
    public float postac_wroga_positionx = 0;
    public float postac_wroga_positionz = 0;
    //public int aktualna_druzyna_index = -1;
    /*
	private int liczba_miast_cyan=0;
	private int liczba_miast_magenta=0;
	private int liczba_miast_orange=0;
	private int liczba_druzyn_cyan=0;
	private int liczba_druzyn_magenta=0;
	private int liczba_druzyn_orange=0;
	private int liczba_druzyn_gracz = 0;
	*/
    private int licznik_wszystkich_drużyn=0;
	//private int liczba_miast_gracz=0;
	//public GUIText licznik_punktow;
	//public GUIText pole_rekord;
	//public GUIText komunikat;
	
	public int koniec_gry=0;
    public float[] test3 = new float[10];
    public float[] test4 = new float[10];
    public bool[] test5 = new bool[10]; //wybrany_wrog[i]
    public bool[] test6 = new bool[10]; //wybrany_wrog_do_ostrzelania
    public wrog_potwor wrog_nr_1;
    public wrog_potwor wrog_nr_2;
    public wrog_potwor wrog_nr_3;
    public wrog_potwor wrog_nr_4;
    public wrog_potwor wrog_nr_5;
    public wrog_potwor wrog_nr_6;
    public wrog_potwor wrog_nr_7;
    public wrog_potwor wrog_nr_8;
    public wrog_potwor wrog_nr_9;
    public wrog_potwor wrog_nr_10;

    public float zwroc_numer_ekwipunku(float position_x, float position_z)
    {
        int help2;
        help2 = (int)position_z;
        switch (help2)
        {
            case 215:
            case 205:
                return ((position_z - 205) / 5) + 8;
            case 200:
                return (position_x - 155) / 5;
            case 210:
                if (position_x == 240)
                    return 11;
                else if (position_x == 230)
                    return 12;
                else if (position_x == 235)
                    return 9;
                else
                    return -1;
            case 195:
                if (position_x < 230)
                    return ((position_x - 155) / 5) + 10;
                else
                    return (position_x - 230) / 5;
            case 190:
                return ((position_x - 230) / 5) + 4;
            default:
                return -1;
        }
    }

    public int sprawdz_ekwipunek_postaci_obrona(postac postac_gracza)
    {
        int i, obrona;
        obrona = 0;
        for (i = 8; i < 13; i++)
        {
            if (postac_gracza.tablica_ekwipunku[i] != null)
            {
                if ((postac_gracza.tablica_ekwipunku[i].numer == 0) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 0))
                {
                    obrona = obrona + 2; //skora wilka
                }
                if ((postac_gracza.tablica_ekwipunku[i].numer == 1) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 0))
                {
                    obrona = obrona + 4; //zbroja
                }
                if ((postac_gracza.tablica_ekwipunku[i].numer == 4) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 3))
                {
                    obrona = obrona + 3; //tarcza
                }
                if ((postac_gracza.tablica_ekwipunku[i].numer == 7) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 5))
                {
                    obrona = obrona + 1; //skorzane buty
                }
                if ((postac_gracza.tablica_ekwipunku[i].numer == 8) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 6))
                {
                    obrona = obrona + 2; //helm
                }
            }
        }

        return obrona;
    }
    public int sprawdz_ekwipunek_postaci_atak(postac postac_gracza)
    {
        int i,atak;
        atak = 0;
        for (i=8;i<13;i++)
        {
            if (postac_gracza.tablica_ekwipunku[i] != null)
            {
                if ((postac_gracza.tablica_ekwipunku[i].numer == 3) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 2))
                {
                    atak = atak + 3;
                    if (postac_gracza.rasa==4) //czlowiek i miecz
                    {
                        atak = atak + 1;
                    }
                }
                else if ((postac_gracza.tablica_ekwipunku[i].numer == 4) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 2))
                {
                    atak = atak + 3;
                    if (postac_gracza.rasa == 8) //ork i topor
                    {
                        atak = atak + 1;
                    }
                }
                else if ((postac_gracza.tablica_ekwipunku[i].numer == 5) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 2))
                {
                    atak = atak + 3;
                    if (postac_gracza.rasa == 0) //ogr i maczuga
                    {
                        atak = atak + 1;
                    }
                }
                else if ((postac_gracza.tablica_ekwipunku[i].numer == 6) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 2))
                {
                    atak = atak + 4;
                    if (postac_gracza.rasa == 1) //krasnolud i mlot bojowy
                    {
                        atak = atak + 1;
                    }
                }
                else if ((postac_gracza.tablica_ekwipunku[i].numer == 7) && (postac_gracza.tablica_ekwipunku[i].rodzaj == 2))
                {
                    atak = atak + 3;
                }
            }

        }

        return atak;
    }
    public int sprawdz_ekwipunek_postaci_zrecznosc(postac postac_gracza)
    {
        int i, zrecznosc;
        zrecznosc = 0;
        for (i = 8; i < 13; i++)
        {


        }

        return zrecznosc;
    }
    public int sprawdz_ekwipunek_postaci_sila(postac postac_gracza)
    {
        int i, sila;
        sila = 0;
        for (i = 8; i < 13; i++)
        {


        }

        return sila;
    }
    public int sprawdz_sile_temp(postac postac_gracza)
    {
        int sila_temp = 0;

        sila_temp = postac_gracza.temp_sila;

        return sila_temp;
    }
    public int policz_przeciwnikow_potwora(wrog_potwor potwor)
    {
        int i = 0,liczba_przeciwnikow=0;
        for (i = 0; i < 8; i++)
        {
           if  (wrog_nr_1.sasiednie_pola[i] == 1)
           {
                liczba_przeciwnikow++;
           }
        }
        potwor.ilosc_przeciwnikow = liczba_przeciwnikow;
        return liczba_przeciwnikow;
    }
    public bool walcz(postac postac_gracza, wrog_potwor potwor)
    {
        bool trafiony;
        bool koniec_walki;
        int szansa_trafienia_postac, szansa_trafienia_potwor;
        int wylosowana_liczba;
        int atak_calkowity;
        int atak_z_sily;
        int wielkosc_ran;
        int ilosc_ran;
        int obrazenia;
        int ilosc_przeciwnikow_potwora= policz_przeciwnikow_potwora(potwor);
        DateTime now = DateTime.Now;
        szansa_trafienia_postac = postac_gracza.zrecznosc + postac_gracza.temp_zrecznosc+sprawdz_ekwipunek_postaci_zrecznosc(postac_gracza) - potwor.zrecznosc/ilosc_przeciwnikow_potwora;
        if (szansa_trafienia_postac <= 10)
        {
            szansa_trafienia_postac = 10;
        }
        UnityEngine.Random.seed = (now.Second + now.Minute + now.Millisecond);
        wylosowana_liczba = UnityEngine.Random.Range(0, 100);
        if (wylosowana_liczba < szansa_trafienia_postac)
        {
            Debug.Log("postac_trafila \n");
            atak_z_sily = (postac_gracza.sila+postac_gracza.temp_sila+sprawdz_ekwipunek_postaci_sila(postac_gracza)) / 20;
            if (atak_z_sily <= 1)
            {
                atak_z_sily = 1;
            }
            atak_calkowity = atak_z_sily + postac_gracza.atak+ sprawdz_ekwipunek_postaci_atak(postac_gracza);
            wielkosc_ran = (postac_gracza.sila + postac_gracza.temp_sila + sprawdz_ekwipunek_postaci_sila(postac_gracza) - potwor.sila) / 10;
            if (wielkosc_ran <= 2)
            {
                wielkosc_ran = 2;
            }
            ilosc_ran = atak_calkowity - potwor.obrona/ilosc_przeciwnikow_potwora;
            if (ilosc_ran <= 1)
            {
                ilosc_ran = 1;
            }
            obrazenia = ilosc_ran * wielkosc_ran;
            Debug.Log("postac zadala " + obrazenia + " obrażeń \n");
            potwor.actual_hp = potwor.actual_hp - obrazenia;
            if (potwor.actual_hp <= 0)
            {
                koniec_walki = true;
                return koniec_walki;
            }
        }
        szansa_trafienia_potwor = potwor.zrecznosc/ilosc_przeciwnikow_potwora - postac_gracza.zrecznosc- postac_gracza.temp_zrecznosc-sprawdz_ekwipunek_postaci_zrecznosc(postac_gracza);
        if (szansa_trafienia_potwor <= 10)
        {
            szansa_trafienia_potwor = 10;
        }
        UnityEngine.Random.seed = (now.Second + now.Minute + now.Millisecond);
        wylosowana_liczba = UnityEngine.Random.Range(0, 100);
        if (wylosowana_liczba < szansa_trafienia_potwor)
        {
            Debug.Log("potwor trafil \n");
            atak_z_sily = (potwor.sila / 20);
            if (atak_z_sily <= 1)
            {
                atak_z_sily = 1;
            }
            atak_calkowity = atak_z_sily + potwor.atak;
            wielkosc_ran = (potwor.sila - postac_gracza.sila - postac_gracza.temp_sila - sprawdz_ekwipunek_postaci_sila(postac_gracza)) / 10;
            if (wielkosc_ran <= 2)
            {
                wielkosc_ran = 2;
            }
            ilosc_ran = atak_calkowity - postac_gracza.obrona - sprawdz_ekwipunek_postaci_obrona(postac_gracza);
            if (ilosc_ran <= 1)
            {
                ilosc_ran = 1;
            }
            obrazenia = ilosc_ran * wielkosc_ran;
            Debug.Log("potwor zadal " + obrazenia + " obrażeń \n");
            postac_gracza.actual_hp = postac_gracza.actual_hp - obrazenia;
            if (postac_gracza.actual_hp <= 0)
            {
                koniec_walki = true;
                return koniec_walki;
            }
        }
        return false;
    }
    void Start () 
	{

		if (menu_wyboru_graczy == false) 
		{
			menu_wyboru_graczy=true;
			camera_.transform.position = new Vector3(200, 40, 228);
			tlo = Instantiate (cube_tlo, new Vector3 (200, 1.5F, 200), Quaternion.identity) as GameObject;
			tlo.GetComponent<Renderer> ().material.mainTexture=graczeTexture;
			tlo.transform.localScale += new Vector3(100, 0, 100);
			/*
			 * 
			 * 
			 *
			 *gm.camera_.transform.position = new Vector3(200, 40, 200);
			gm.kupowanie_jedzenia_=true;
			gm.tlo = Instantiate (gm.cube, new Vector3 (200, 1.5F, 200), Quaternion.identity) as GameObject;
			gm.tlo.GetComponent<Renderer> ().material.mainTexture=gm.spichlerzTexture;
			gm.tlo.transform.localScale += new Vector3(100, 0, 100);
			 */
		}
	}
    bool czy_w_miescie()
    {
        int numer;
        numer = (int)(aktualna_druzyna.transform.position.x * 100 + aktualna_druzyna.transform.position.z);
        if (tablica[numer].rodzaj_miasta != -1)
        {
            //pozycjax_zaznaczonego;
            //pozycjaz_zaznaczonego;
           
            Debug.Log("Tu jest miasto");
            Debug.Log("Pozycja aktualna x=" + aktualna_druzyna.transform.position.x + "\n");
            Debug.Log("Pozycja aktualna z=" + aktualna_druzyna.transform.position.z + "\n");
            //  Debug.Log("pozycjax="+pozycjax);
            //     Debug.Log("pozycjaz="+pozycjaz);
            Debug.Log("numer=" + numer);
            return true;
        }
        else
        {
            Debug.Log("Tu nie ma miasta");
            Debug.Log("Pozycja aktualna x=" + aktualna_druzyna.transform.position.x + "\n");
            Debug.Log("Pozycja aktualna z=" + aktualna_druzyna.transform.position.z + "\n");
            Debug.Log("numer=" + numer);
            //  Debug.Log("pozycjax="+pozycjax);
            //   Debug.Log("pozycjaz="+pozycjaz);
            //   Debug.Log("numer=" + numer);
            return false;
        }
    }
    void wyczysc_teren()
    {
        int licznik = 0;
        for (int i = 0; i < 25; i++)
        {
            for (int j = 0; j < 25; j++)
            {
                tablica_malego_terenu[licznik] = new obiekt_pole_malego_terenu(i, j, licznik, 0, -1, -1, -1);
                for (int k = 0; k < 4; k++)
                {
                    tablica_malego_terenu[licznik].rzeczy_na_ziemi[k] = new ekwipunek(-1, -1, "brak", -1, emptyTexture);
                }
                licznik++;
            }
        }
    }
    // Update is called once per frame
    void Update () {
        /*
		if (koniec_gry==1)
		{
			if (Input.GetButtonUp("Jump"))
			{
				nowa_gra();
				
				
			}
		}
		*/
        if (Input.GetKeyDown("o"))
        {
           pause = !pause;
        }
        if (zaznaczona_druzyna == true) 
		{
			if (Input.GetButtonUp("Jump"))//Up
			{
				przesuwaj();
					
			}
            else if (Input.GetKeyDown("m"))
            {
                if (czy_w_miescie())
                {
                    kupowanie_jedzenia();
                }
            }
            else if (Input.GetKeyDown("p"))
            {
            	walka_w_terenie();
            }
            else if (Input.GetKeyDown("l"))
            {
                akcja_w_terenie();
            }
            //Debug.Log("Pokaz inwentarz");
            //walka_w_terenie();
            else if (Input.GetKeyDown("e"))
			{
				//Debug.Log("Kamera wraca");
               // badam_cialo = false;
              //  if (polowanie == true)
              //  {
              //      polowanie = false;
               //     Destroy(postac1);
               //     Destroy(wrog1);
             //   }
              //  else
              //  {
                    if (budynek!=null)
                    Destroy(budynek);
                    if (budynek1 != null)
                        Destroy(budynek1);
                    if (budynek2 != null)
                        Destroy(budynek2);
                    if (budynek3 != null)
                        Destroy(budynek3);
                    if (budynek4 != null)
                        Destroy(budynek4);

               // }
				powrot_kamery();
                
            }
		}
        if (polowanie == true)
        {
            if (Input.GetKeyDown("e"))
            {
                Debug.Log("Kamera wraca");
                badam_cialo = false;
                inwentarz_narysowany = false;
                pokazuje_inwentarz = false;
                if (polowanie == true)
                {
                    polowanie = false;
                    int licznik_druzyn = 30;
                    //Destroy(postac1);
                    
                    for (int i = 0; i < poczatkowa_liczba_postaci_gracza/*tablica_druzyn[aktualna_druzyna_index].ilosc_postaci*/; i++)
                    {
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i].temp_sila = 0;
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i].temp_zrecznosc = 0;
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i].temp_obrona = 0;
                        Destroy(postacie[i]);
                    }
                    Destroy(wrog1);
                }
                powrot_kamery();
                pause = true;
                wyczysc_teren();
                poczatkowa_liczba_postaci_gracza = 0;
            }
            else if (Input.GetKeyDown("i"))
            {

                    if (wybrana_postac == true)
                    {
                        /*
                        if (this.GetComponent<Renderer>().material.mainTexture == gm.smiercTexture)
                        {
                            Debug.Log("ciało");
                            gm.camera_.transform.position = new Vector3(200, 40, 200);
                            gm.badam_cialo = true;
                            gm.tlo = Instantiate(gm.cube, new Vector3(200, 1.5F, 200), Quaternion.identity) as GameObject;
                            //gm.tlo.GetComponent<Renderer>().material.mainTexture = gm.platnerzTexture;
                            gm.tlo.GetComponent<Renderer>().material.color = gm.wybierzkolor(1);
                            gm.tlo.transform.localScale += new Vector3(100, 0, 100);
                            rysuj_ekwipunek_i_przedmioty_na_ziemi();
                            gm.ekwipunek_przedmioty_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                            gm.przedmioty_na_ziemi[0].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[0].obrazek;
                            gm.ekwipunek_przedmioty_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
                            gm.przedmioty_na_ziemi[1].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[1].obrazek;
                        }
                        */
                        pokazuje_inwentarz = true;
                        Debug.Log("Pokaz inwentarz");
                    }
                    else
                    {
                        Debug.Log("Postac niewybrana");
                    }
                }

         }

        if ((smierglodowa == true) || (smiercpokonani==true))
		{
			if (Input.GetKeyDown("k"))
			{
				Destroy(tlo);
				Application.LoadLevel (0);

			}
		}
	}
	public void tworz_ekwipunek_druzyny_gracza(int numer_postaci)
	{
		int licznik_druzyn = 30;
		int i = numer_postaci;
		for (int indeksik=0;indeksik<13;indeksik++)
		{
			tablica_druzyn[licznik_druzyn].tablica_postaci[i].tablica_ekwipunku[indeksik]=new ekwipunek(-1,-1,"brak",-1,emptyTexture);
			Debug.Log("tworze ekwipunek="+indeksik);
			Debug.Log("postac="+i);
			Debug.Log("licznik_druzyn="+licznik_druzyn);
		}
		tablica_druzyn[licznik_druzyn].tablica_postaci[i].tablica_ekwipunku[8].obrazek=nogiTexture;
		tablica_druzyn[licznik_druzyn].tablica_postaci[i].tablica_ekwipunku[9].obrazek=tulowTexture;
		tablica_druzyn[licznik_druzyn].tablica_postaci[i].tablica_ekwipunku[10].obrazek=glowaTexture;
		tablica_druzyn[licznik_druzyn].tablica_postaci[i].tablica_ekwipunku[11].obrazek=prawarekaTexture;
		tablica_druzyn[licznik_druzyn].tablica_postaci[i].tablica_ekwipunku[12].obrazek=lewarekaTexture;


	}
	public void nowa_gra()
	{
		//koniec_gry=0;
		//punkty=0;
		//komunikat.SendMessage("Wyswietl","");
		//licznik_punktow.SendMessage("Wyswietl",punkty);
		licznik=0;
		licznikkulek=0;
		
		for (int i=0;i<100;i++)
		{
			for (int j=0;j<100;j++)
			{
				tablica[licznik]=new obiekt_pole_mapy(i,j,licznik,0,-1,-1,-1);
				licznik++;
			}
		}
		licznik = 0;
		for (int i=0;i<25;i++)
		{
			for (int j=0;j<25;j++)
			{
				tablica_malego_terenu[licznik]=new obiekt_pole_malego_terenu(i,j,licznik,0,-1,-1,-1);
                for (int k=0;k<4;k++)
                {
                    tablica_malego_terenu[licznik].rzeczy_na_ziemi[k] = new ekwipunek(-1, -1, "brak", -1, emptyTexture);
                }
				licznik++;
			}
		}
        for (int i=0;i<10;i++)
        {
            wybrane_pole[i] = false;
            test5[i] = false;
            test6[i] = false;
            wybrane_pole_x[i] = -1;
            wybrane_pole_z[i] = -1;
            test1[i] = -1;
            test2[i] = -1;
            test3[i] = -1;
            test4[i] = -1;
        //    z_ok[i] = -1;
         //   x_ok[i] = -1;
       //     postac_gracza_positionx[i] = -1;
       //     postac_gracza_positionz[i] = -1;
        }
		losuj();
		
	}
    public void zeruj_pola_docelowe()
    {
        for (int i = 0; i < 10; i++)
        {
            wybrane_pole[i] = false;
            wybrane_pole_x[i] = -1;
            wybrane_pole_z[i] = -1;

        }
    }
	public void nowa_gra_2()
	{
		koniec_gry=0;
		punkty=0;
		//komunikat.SendMessage("Wyswietl","");
		//licznik_punktow.SendMessage("Wyswietl",punkty);

		losuj();
		
	}
	public int walka_automatyczna(float sila_player1,float sila_player2)
	{
		float stosunek_sil;
		int wylosowana_liczba;
		DateTime now=DateTime.Now;
		
		UnityEngine.Random.seed=(now.Second+now.Minute+now.Millisecond);
		wylosowana_liczba=UnityEngine.Random.Range(0,100);
		stosunek_sil = (sila_player1 / (sila_player1+sila_player2))*100;
		Debug.Log("Sila player1:"+sila_player1);
		Debug.Log("Sila player2:"+sila_player2);
		Debug.Log("Stosunek sil:"+stosunek_sil);
		Debug.Log("Wylosowana liczba:"+wylosowana_liczba);
		if (stosunek_sil > (float)wylosowana_liczba) 
		{
			Debug.Log("Player 1 wygrywa");
			Debug.Log ("Smierc w walce");
			Application.Quit();
			return 1;
		} 
		else 
		{
			Debug.Log("Player 2 wygrywa");
			return 2;
		}

	}
	public void losuj()
	{
		//int counter=0;
		int numer2=0;
		int numer3=0;
		int numer4 = 0;
		int numer5 = 0;
		int numer6 = 0;
		int numer7 = 0;

		int numer3a = 0;

		int numer4a = 0;
		int numer5a = 0;
		int numer6a = 0;
		int numer7a = 0;

		int kolor2 = 0;
		int help = 0;
		int help2 = 0;
		int i=0;
		int j=0;
		//int help=0;

		//while (counter<3 && licznikkulek<10000)
		//{
			DateTime now=DateTime.Now;
			
			UnityEngine.Random.seed=(now.Second+now.Minute+now.Millisecond);
			numer=UnityEngine.Random.Range(0,2);
			wylosowane = numer;
			if (numer == 0) 
			{ //pustynia na północy
				numer2 = UnityEngine.Random.Range (10, 30);
				Debug.Log("Żółte="+numer2);
				for (i=0; i<numer2/*numer2*/; i++) 
				{
					licznikkulek=i;
				for (j=0; j<100 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = 4;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
					    //	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (4);
					}

				}
				Debug.Log("Ostatni="+numer);
				numer3 = UnityEngine.Random.Range (10, 30);
				numer4 = UnityEngine.Random.Range(10,40);

				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor2 dlugosc="+numer3);
				Debug.Log("Kolor2 szerokosc="+numer4);
				Debug.Log("kolor2="+kolor2);
				for (i=0; i<numer3/*numer2*/; i++) 
				{
					licznikkulek=i+numer2;
					for (j=0; j<numer4 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
			//	Debug.Log("numer-1 po drugim obszarze="+(numer-1));
			//	Debug.Log("x po drugim obszarze="+tablica [numer-1].positionx);
			//	Debug.Log("z po drugim obszarze="+tablica [numer-1].positionz);
				Debug.Log("numer po drugim a obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
			//	Debug.Log("numer+1 po drugim obszarze="+(numer+1));
			//	Debug.Log("x po drugim obszarze="+tablica [numer+1].positionx);
			//	Debug.Log("z po drugim obszarze="+tablica [numer+1].positionz);
			//	Debug.Log("numer+100 po drugim obszarze="+(numer+100));
			//	Debug.Log("x po drugim obszarze="+tablica [numer+100].positionx);
			//	Debug.Log("z po drugim obszarze="+tablica [numer+100].positionz);		
				numer5 = UnityEngine.Random.Range(10,40);
				
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3);
				Debug.Log("Kolor3 szerokosc="+numer5);
				Debug.Log("kolor3="+kolor2);
				help = numer-numer3+100+1;
				Debug.Log("help po drugim a obszarze="+(help));
				Debug.Log("x po drugim obszarze="+tablica [help].positionx);
				Debug.Log("z po drugim obszarze="+tablica [help].positionz);
				for (i=0; i<numer3/*numer2*/; i++) 
				{
					licznikkulek=i+help;
					for (j=0; j<numer5 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
				numer6 = UnityEngine.Random.Range(10,40);
				Debug.Log("numer po drugim b obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3);
				Debug.Log("Kolor3 szerokosc="+numer6);
				if (numer4+numer5+numer6>100)
					numer6=100-numer4-numer5;
				Debug.Log("kolor3="+kolor2);
				help = numer-numer3+100+1;
				Debug.Log("help po drugim b obszarze="+(help));
				Debug.Log("x po drugim obszarze="+tablica [help].positionx);
				Debug.Log("z po drugim obszarze="+tablica [help].positionz);
				for (i=0; i<numer3/*numer2*/; i++) 
				{
					licznikkulek=i+help;
					for (j=0; j<numer6 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
			numer7 = 100-numer6-numer5-numer4;
			Debug.Log("numer po drugim c obszarze="+numer);
			Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
			Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
			if (tablica [numer].positionx!=99)
			{
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3);
				Debug.Log("Kolor3 szerokosc="+numer7);
				//if (numer4+numer5+numer6>100)
				//	numer6=100-numer4-numer5;
				Debug.Log("kolor3="+kolor2);
				help = numer-numer3+100+1;
				Debug.Log("help po drugim c obszarze="+(help));
				Debug.Log("x po drugim obszarze="+tablica [help].positionx);
				Debug.Log("z po drugim obszarze="+tablica [help].positionz);
				for (i=0; i<numer3/*numer2*/; i++) 
				{
					licznikkulek=i+help;
					for (j=0; j<numer7 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
				Debug.Log("numer po drugim d obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
			}
		  //---------------------------------------trzeci pas
			numer3a = UnityEngine.Random.Range (10, 50);
			numer4a = UnityEngine.Random.Range(10,40);
			
			kolor2= UnityEngine.Random.Range(0,6);
			Debug.Log("Kolor2 dlugosc="+numer3a);
			Debug.Log("Kolor2 szerokosc="+numer4a);
			Debug.Log("kolor2="+kolor2);
			for (i=0; i<numer3a/*numer2*/; i++) 
			{
				licznikkulek=i+numer2+numer3;
				for (j=0; j<numer4a ;j++) 
				{
					numer = licznikkulek;
					if (numer>9999)
					{
					//	Debug.Log ("numer poza zasiegiem="+numer);
					//	Debug.Log ("i="+i);
					//	Debug.Log ("j="+j);
						continue;
					}
					//Debug.Log ("numer="+numer);
					pozycjax = tablica [numer].positionx;
					pozycjaz = tablica [numer].positionz;
					//Debug.Log ("pozycjax="+pozycjax);
					//Debug.Log ("pozycjaz="+pozycjaz);
					tablica [numer].zajete = 1;
					tablica [numer].kolor = kolor2;
					//if(numer==numer2)
					//{
					//	licznikkulek=licznikkulek+(100-numer2);
					//}
					//	else
					licznikkulek=licznikkulek+100;
					//Debug.Log("licznikkulek="+licznikkulek);
					pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
					pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
				}
				
			}
		//	Debug.Log("numer-1 po drugim obszarze="+(numer-1));
		//	Debug.Log("x po drugim obszarze="+tablica [numer-1].positionx);
		//	Debug.Log("z po drugim obszarze="+tablica [numer-1].positionz);
			Debug.Log("numer po trzecim a obszarze="+numer);
			Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
			Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
			//Debug.Log("numer+1 po drugim obszarze="+(numer+1));
		//	Debug.Log("x po drugim obszarze="+tablica [numer+1].positionx);
		//	Debug.Log("z po drugim obszarze="+tablica [numer+1].positionz);
		//	Debug.Log("numer+100 po drugim obszarze="+(numer+100));
		//	Debug.Log("x po drugim obszarze="+tablica [numer+100].positionx);
		//	Debug.Log("z po drugim obszarze="+tablica [numer+100].positionz);		
			numer5a = UnityEngine.Random.Range(10,40);
			
			kolor2= UnityEngine.Random.Range(0,6);
			Debug.Log("Kolor3 dlugosc="+numer3a);
			Debug.Log("Kolor3 szerokosc="+numer5a);
			Debug.Log("kolor3="+kolor2);
			//help = numer-numer3+100+1;
			help = numer-numer3a+100+1;
			Debug.Log("help po trzecim a obszarze="+(help));
			Debug.Log("x po drugim obszarze="+tablica [help].positionx);
			Debug.Log("z po drugim obszarze="+tablica [help].positionz);
			for (i=0; i<numer3a/*numer2*/; i++) 
			{
				licznikkulek=i+help;
				for (j=0; j<numer5a ;j++) 
				{
					numer = licznikkulek;
					if (numer>9999)
					{
					//	Debug.Log ("numer poza zasiegiem="+numer);
					//	Debug.Log ("i="+i);
					//	Debug.Log ("j="+j);
						continue;
					}
					//Debug.Log ("numer="+numer);
					pozycjax = tablica [numer].positionx;
					pozycjaz = tablica [numer].positionz;
					//Debug.Log ("pozycjax="+pozycjax);
					//Debug.Log ("pozycjaz="+pozycjaz);
					tablica [numer].zajete = 1;
					tablica [numer].kolor = kolor2;
					//if(numer==numer2)
					//{
					//	licznikkulek=licznikkulek+(100-numer2);
					//}
					//	else
					licznikkulek=licznikkulek+100;
					//Debug.Log("licznikkulek="+licznikkulek);
					pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
					pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
				}
				
			}
			numer6a = UnityEngine.Random.Range(10,40);
			
			kolor2= UnityEngine.Random.Range(0,6);
			Debug.Log("numer po trzecim b obszarze="+numer);
			Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
			Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
			Debug.Log("Kolor3 dlugosc="+numer3a);
			Debug.Log("Kolor3 szerokosc="+numer6a);
			while(numer4a+numer5a+numer6a>100)
			{
				//numer6a=100-numer4a-numer5a;
				//numer6a=100-numer4a-numer5a;
				numer6a = UnityEngine.Random.Range(10,40);
				Debug.Log("Kolor3 szerokosc="+numer6a);
			}
			Debug.Log("kolor3="+kolor2);
			help = numer-numer3a+100+1;
			Debug.Log("help po trzecim b obszarze="+(help));
			Debug.Log("x po drugim obszarze="+tablica [help].positionx);
			Debug.Log("z po drugim obszarze="+tablica [help].positionz);
			for (i=0; i<numer3a/*numer2*/; i++) 
			{
				licznikkulek=i+help;
				for (j=0; j<numer6a ;j++) 
				{
					numer = licznikkulek;
					//Debug.Log ("numer="+numer);
					if (numer>9999)
					{
					//	Debug.Log ("numer poza zasiegiem="+numer);
					//	Debug.Log ("i="+i);
					//	Debug.Log ("j="+j);
						continue;
					}
					pozycjax = tablica [numer].positionx;
					pozycjaz = tablica [numer].positionz;
					//Debug.Log ("pozycjax="+pozycjax);
					//Debug.Log ("pozycjaz="+pozycjaz);
					tablica [numer].zajete = 1;
					tablica [numer].kolor = kolor2;
					//if(numer==numer2)
					//{
					//	licznikkulek=licznikkulek+(100-numer2);
					//}
					//	else
					licznikkulek=licznikkulek+100;
					//Debug.Log("licznikkulek="+licznikkulek);
					pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
					pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
				}
				
			}
			numer7a = 100-numer6a-numer5a-numer4a;
			
			kolor2= UnityEngine.Random.Range(0,6);
			Debug.Log("numer po trzecim c obszarze="+numer);
			Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
			Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
			Debug.Log("Kolor3 dlugosc="+numer3a);
			Debug.Log("Kolor3 szerokosc="+numer6a);
			Debug.Log("kolor3="+kolor2);
			help = numer-numer3a+100+1;
			Debug.Log("help po trzecim c obszarze="+(help));
            if (help>9999)
            {
                losuj();
            }
			Debug.Log("x po drugim obszarze="+tablica [help].positionx); //Do poprawy za duzy indeks
			Debug.Log("z po drugim obszarze="+tablica [help].positionz);
			for (i=0; i<numer3a/*numer2*/; i++) 
			{
				licznikkulek=i+help;
				for (j=0; j<numer7a ;j++) 
				{
					numer = licznikkulek;
					if (numer>9999)
					{
					//	Debug.Log ("numer poza zasiegiem="+numer);
					//	Debug.Log ("i="+i);
					//	Debug.Log ("j="+j);
						continue;
					}
					//Debug.Log ("numer="+numer);
					pozycjax = tablica [numer].positionx;
					pozycjaz = tablica [numer].positionz;
					//Debug.Log ("pozycjax="+pozycjax);
					//Debug.Log ("pozycjaz="+pozycjaz);
					tablica [numer].zajete = 1;
					tablica [numer].kolor = kolor2;
					//if(numer==numer2)
					//{
					//	licznikkulek=licznikkulek+(100-numer2);
					//}
					//	else
					licznikkulek=licznikkulek+100;
					//Debug.Log("licznikkulek="+licznikkulek);
					pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
					pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
				}
				
			}
				Debug.Log("numer po trzecim D obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				help = 100-numer2-numer3-numer3a;
				help2 = numer2 + numer3 + numer3a;
				Debug.Log("Żółte="+help);
				for (i=0; i<help/*numer2*/; i++) 
				{
					licznikkulek=i+help2;
					for (j=0; j<100 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = 7;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (7);
					}
					
				}
				Debug.Log("Ostatni 0="+numer);
				Debug.Log("Wylosowane:"+wylosowane);
				generuj_miasta();
				generuj_wrogie_miasta();
				return;
			} 
			else //lodowiec na polnocy
			{
				numer2 = UnityEngine.Random.Range (10, 30);
				for (i=0; i<numer2; i++) {
					licznikkulek=i;
					for (j=0; j<100; j++) {
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						tablica [numer].zajete = 1;
						tablica [numer].kolor = 7;
						licznikkulek=licznikkulek+100;
						//licznikkulek++;
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (7);
					}
					
				}
				Debug.Log("Ostatni="+numer);
				numer3 = UnityEngine.Random.Range (10, 30);
				numer4 = UnityEngine.Random.Range(10,40);
				
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor2 dlugosc="+numer3);
				Debug.Log("Kolor2 szerokosc="+numer4);
				Debug.Log("kolor2="+kolor2);
				for (i=0; i<numer3/*numer2*/; i++) 
				{
					licznikkulek=i+numer2;
					for (j=0; j<numer4 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
		
				Debug.Log("numer po drugim  a obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				
				numer5 = UnityEngine.Random.Range(10,40);
				
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3);
				Debug.Log("Kolor3 szerokosc="+numer5);
				if (numer4+numer5>100)
				numer5=100-numer4;
				Debug.Log("kolor3="+kolor2);
				help = numer-numer3+100+1;
				Debug.Log("help po drugim a obszarze="+(help));
				Debug.Log("x po drugim obszarze="+tablica [help].positionx);
				Debug.Log("z po drugim obszarze="+tablica [help].positionz);
				for (i=0; i<numer3/*numer2*/; i++) 
				{
					licznikkulek=i+help;
					for (j=0; j<numer5 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
				numer6 = UnityEngine.Random.Range(10,40);
				Debug.Log("numer po drugim  b obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszaze="+tablica [numer].positionz);
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3);
				Debug.Log("Kolor3 szerokosc="+numer6);
				if (numer4+numer5+numer6>100)
				numer6=100-numer4-numer5;
				Debug.Log("kolor3="+kolor2);
				help = numer-numer3+100+1;
				Debug.Log("help po drugim b obszarze="+(help));
				Debug.Log("x po drugim obszarze="+tablica [help].positionx);
				Debug.Log("z po drugim obszarze="+tablica [help].positionz);
				for (i=0; i<numer3/*numer2*/; i++) 
				{
					licznikkulek=i+help;
					for (j=0; j<numer6 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
				numer7 = 100-numer6-numer5-numer4;
				Debug.Log("numer po drugim  c obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3);
				Debug.Log("Kolor3 szerokosc="+numer6);
				Debug.Log("kolor3="+kolor2);
				if (tablica [numer].positionx!=99)
				{
					help = numer-numer3+100+1;
					Debug.Log("help po drugim c obszarze="+(help));
					Debug.Log("x po drugim obszarze="+tablica [help].positionx);
					Debug.Log("z po drugim obszarze="+tablica [help].positionz);
					for (i=0; i<numer3/*numer2*/; i++) 
					{
						licznikkulek=i+help;
						for (j=0; j<numer7 ;j++) 
						{
							numer = licznikkulek;
							if (numer>9999)
							{
							//	Debug.Log ("numer poza zasiegiem="+numer);
							//	Debug.Log ("i="+i);
							//	Debug.Log ("j="+j);
								continue;
							}
							//Debug.Log ("numer="+numer);
							pozycjax = tablica [numer].positionx;
							pozycjaz = tablica [numer].positionz;
							//Debug.Log ("pozycjax="+pozycjax);
							//Debug.Log ("pozycjaz="+pozycjaz);
							tablica [numer].zajete = 1;
							tablica [numer].kolor = kolor2;
							//if(numer==numer2)
							//{
							//	licznikkulek=licznikkulek+(100-numer2);
							//}
							//	else
							licznikkulek=licznikkulek+100;
							//Debug.Log("licznikkulek="+licznikkulek);
							pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
							pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
						}
						
					}
					Debug.Log("numer po drugim  d obszarze="+numer);
					Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
					Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				}
				//---------------------------------------trzeci pas
				numer3a = UnityEngine.Random.Range (10, 50);
				numer4a = UnityEngine.Random.Range(10,40);
				
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor2 dlugosc="+numer3a);
				Debug.Log("Kolor2 szerokosc="+numer4a);
				Debug.Log("kolor2="+kolor2);
				for (i=0; i<numer3a/*numer2*/; i++) 
				{
					licznikkulek=i+numer2+numer3;
					for (j=0; j<numer4a ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
				Debug.Log("numer po trzecim a obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				
				numer5a = UnityEngine.Random.Range(10,40);
				
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3a);
				Debug.Log("Kolor3 szerokosc="+numer5a);
				Debug.Log("kolor3="+kolor2);
				//help = numer-numer3+100+1;
				help = numer-numer3a+100+1;
				Debug.Log("help po trzecim a obszarze="+(help));
				Debug.Log("x po drugim obszarze="+tablica [help].positionx);
				Debug.Log("z po drugim obszarze="+tablica [help].positionz);
				for (i=0; i<numer3a/*numer2*/; i++) 
				{
					licznikkulek=i+help;
					for (j=0; j<numer5a ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
				numer6a = UnityEngine.Random.Range(10,40);
				Debug.Log("numer po trzecim b obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3a);
				Debug.Log("Kolor3 szerokosc="+numer6a);
				if (numer4a+numer5a+numer6a>100)
					numer6a=100-numer4a-numer5a;
				Debug.Log("kolor3="+kolor2);
				help = numer-numer3a+100+1;
				Debug.Log("help po trzecim b obszarze="+(help));
				Debug.Log("x po drugim obszarze="+tablica [help].positionx);
				Debug.Log("z po drugim obszarze="+tablica [help].positionz);
				for (i=0; i<numer3a/*numer2*/; i++) 
				{
					licznikkulek=i+help;
					for (j=0; j<numer6a ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
				}
				numer7a = 100-numer6a-numer5a-numer4a;
				Debug.Log("numer po trzecim c obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				kolor2= UnityEngine.Random.Range(0,6);
				Debug.Log("Kolor3 dlugosc="+numer3a);
				Debug.Log("Kolor3 szerokosc="+numer6a);
				Debug.Log("kolor3="+kolor2);
				help = numer-numer3a+100+1;
				Debug.Log("help po trzecim c obszarze="+(help));
                if (help > 9999)
                {
                    losuj();
                }
                Debug.Log("x po drugim obszarze="+tablica [help].positionx);//do poprawy indeks wychodzi
				Debug.Log("z po drugim obszarze="+tablica [help].positionz);
				for (i=0; i<numer3a/*numer2*/; i++) 
				{
					licznikkulek=i+help;
					for (j=0; j<numer7a ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = kolor2;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (kolor2);
					}
					
					}
				Debug.Log("numer po trzecim d obszarze="+numer);
				Debug.Log("x po drugim obszarze="+tablica [numer].positionx);
				Debug.Log("z po drugim obszarze="+tablica [numer].positionz);
				help = 100-numer2-numer3-numer3a;
				help2 = numer2 + numer3 + numer3a;
				Debug.Log("Żółte="+help);
				for (i=0; i<help/*numer2*/; i++) 
				{
					licznikkulek=i+help2;
					for (j=0; j<100 ;j++) 
					{
						numer = licznikkulek;
						if (numer>9999)
						{
						//	Debug.Log ("numer poza zasiegiem="+numer);
						//	Debug.Log ("i="+i);
						//	Debug.Log ("j="+j);
							continue;
						}
						//Debug.Log ("numer="+numer);
						pozycjax = tablica [numer].positionx;
						pozycjaz = tablica [numer].positionz;
						//Debug.Log ("pozycjax="+pozycjax);
						//Debug.Log ("pozycjaz="+pozycjaz);
						tablica [numer].zajete = 1;
						tablica [numer].kolor = 4;
						//if(numer==numer2)
						//{
						//	licznikkulek=licznikkulek+(100-numer2);
						//}
						//	else
						licznikkulek=licznikkulek+100;
						//Debug.Log("licznikkulek="+licznikkulek);
						pole [numer] = Instantiate (cube_pole, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
						pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (4);
					}
				
			}
				Debug.Log("Ostatni="+numer);
				generuj_miasta();
				generuj_wrogie_miasta();
				return;
			}
			/*
			numer=UnityEngine.Random.Range (0,10000);

			while ((tablica[numer].zajete!=0) && (licznikkulek<10000))
			{
				
				numer=UnityEngine.Random.Range(0,10000);
				
			}
			*/
			/*
			if (tablica[numer].zajete==0)
			{
				
				wylosowanykolor=UnityEngine.Random.Range(0,7);
				
				pozycjax=tablica[numer].positionx;
				pozycjaz=tablica[numer].positionz;
				tablica[numer].zajete=1;
				tablica[numer].kolor=wylosowanykolor;
				licznikkulek++;
				
				pole[numer]=Instantiate (cube, new Vector3(pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
				pole[numer].GetComponent<Renderer>().material.color = wybierzkolor (wylosowanykolor);
				

			}
			
		}
		if (licznikkulek>=10000)
		{
			if (punkty>rekord)
			{
				rekord=punkty;	
			}
			//pole_rekord.SendMessage("Wyswietl",rekord);
			koniec_gry=1;
			//komunikat.SendMessage("Wyswietl","Koniec gry.Wcisnij spacje");
		}
		*/
	}
	public int zwroc_obszar (int pozycja_x,int pozycja_y)
	{
		//grupy lewy gorny 0 z<50 x<50 ,z<50 x>=50 lewy dolny 1,z>=50 x<50 prawy gorny 2,z=>50 x>=50 prawy dolny 3
		if (pozycja_x < 50) 
		{
			if (pozycja_y < 50) 
			{
				return 0;
			} 
			else 
			{
				return 2;
			}
		}
		else 
		{
			if (pozycja_y < 50) 
			{
				return 1;
			} 
			else 
			{
				return 3;
			}

		}
	}
	public void generuj_miasta()
	{
		liczba_miast=UnityEngine.Random.Range (30, 50);

		/* 0
		  lewy gorny -gracz
		  ld - player one
		  pg - player two
		  pd -player three;
		  1
		  lewy gorny -player one
		  ld - player gracz
		  pg - player two
		  pd -player three;
		  2
		  lewy gorny -player one
		  ld - player two
		  pg - player gracz
		  pd -player three;
          3
		  lewy gorny -player one
		  ld - player two
		  pg - player three
		  pd -player gracz;
		 */
		int licznik = 0;
		int licznik2 = 0;
		int miasta_zbudowane = 0;
		int obszar = 0;
		int numer_na_mapie;
		int pozycja_x_, pozycja_z_;
		int teren;
		int juz_zajete = 0;
		for (int j=0;j<50;j++)
		{
			tablica_miast[j]=new miasto(-1,-1,-1,-1,-1,-1,-1,-1,-1,-1);
		}
		//public miasto(int x,int z,int number_,int wlasciciel_,int wielkosc_,int rodzaj_terenu_,int mury_,int obszar_mapy_)
		Debug.Log("Generuje miasta");
		Debug.Log("Liczba miast:"+liczba_miast);
		for (licznik=0;licznik<liczba_miast;licznik++)
		{
			numer_na_mapie=UnityEngine.Random.Range (0, 10000);
			teren=tablica[numer_na_mapie].kolor;
			if (teren==3) //woda
			{
				licznik--;
				continue;
			}
			for (licznik2=0;licznik2<miasta_zbudowane;licznik2++)
			{
				if (numer_na_mapie==tablica_miast[licznik2].number)
				{
					juz_zajete++;
					break;
				}
			}
			if (juz_zajete>0)
			{
				licznik--;
				juz_zajete=0;
				continue;
			}
			juz_zajete=0;
		//	if (numer_na_mapie==tablica_miast[licznik].number)
			pozycja_x_=tablica[numer_na_mapie].positionx;
			pozycja_z_=tablica[numer_na_mapie].positionz;
			obszar=zwroc_obszar(pozycja_x_,pozycja_z_);
			tablica_miast[licznik].obszar_mapy=obszar;
			tablica_miast[licznik].positionx=pozycja_x_;
			tablica_miast[licznik].positionz=pozycja_z_;
			tablica_miast[licznik].number=numer_na_mapie;
			tablica_miast[licznik].rodzaj_terenu=teren;
			tablica_miast[licznik].wielkosc=UnityEngine.Random.Range (0, 2);
            tablica[numer_na_mapie].rodzaj_miasta = tablica_miast[licznik].wielkosc;
            //pole [numer] = Instantiate (cube, new Vector3 (pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
            //pole [numer].GetComponent<Renderer> ().material.color = wybierzkolor (4);
            switch (tablica_miast[licznik].wielkosc)
			{
			case 0:
				miasto_prostokat[licznik]=Instantiate (cube_miasto, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
				tablica_miast[licznik].liczba_ludnosci=UnityEngine.Random.Range (2000, 4000);
				break;
			case 1:
				miasto_prostokat[licznik]=Instantiate (sphere_miasto, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
				tablica_miast[licznik].liczba_ludnosci=UnityEngine.Random.Range (800, 1700);
				break;
			case 2:
				miasto_prostokat[licznik]=Instantiate (cylinder_miasto, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
				tablica_miast[licznik].liczba_ludnosci=UnityEngine.Random.Range (200, 500);
				break;
			default:
				licznik--;
				continue;
				//break;
			}
			//miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;

			miasto_prostokat[licznik].GetComponent<Renderer> ().material.color = wybierzkolor (8);
			miasta_zbudowane++;
		}

		return;
	}
	public void generuj_wrogie_miasta()
	{

		int ilosc = 0;
		int numer_miasta = 0;
		int licznik = 0;
		int licznik_druzyn = 0;
		int numer_pola;
		int obszar = 0;
		int pozycja_x_d;
		int pozycja_z_d;
		int teren = 0;
		for (int j=0;j<40;j++)
		{
			tablica_druzyn[j]=new druzyna(-1,-1,-1);
		}
		generowanie_wrogow = UnityEngine.Random.Range (0, 3); //0 do zmiany UnityEngine.Random.Range (0, 3);
		if (generowanie_wrogow == 0) /*PIERWSZY UKLAD*/
		{
			//tablica[licznik]=new obiekt_pole_mapy(i,j,licznik,0,-1,-1,-1);
			/*
			public Color kolor;
			public int numer;
			public string nazwa;
			public int liczba_druzyn;
			public druzyna[] tablica_druzyn=new druzyna[10];
			public int pieniadze;
			public int liczba_miast;
			public miasto[] tablica_miast=new miasto[50];
			*/
			tablica_graczy[2] = new gracz(Color.cyan,2,imie_gracza_1,0,3000,0);

			ilosc=UnityEngine.Random.Range (2, 4);

			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);

				if (tablica_miast[numer_miasta].obszar_mapy==0)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[2].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[2].kolor;
					tablica_graczy[2].liczba_miast++;
					//liczba_miast_cyan++;
					licznik++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==0) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[2].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80),3,3,k,k,"Postac "+i,true);
						Debug.Log("Gracz cyan postac:"+i);
						Debug.Log("Rasa:"+tablica_druzyn[licznik_druzyn].tablica_postaci[i].rasa);
						Debug.Log("Actual hp:"+tablica_druzyn[licznik_druzyn].tablica_postaci[i].actual_hp);
						Debug.Log("Max hp:"+tablica_druzyn[licznik_druzyn].tablica_postaci[i].max_hp);
						Debug.Log("Actual mana:"+tablica_druzyn[licznik_druzyn].tablica_postaci[i].actual_mana);
						Debug.Log("Max mana:"+tablica_druzyn[licznik_druzyn].tablica_postaci[i].max_mana);
						Debug.Log("Sila:"+tablica_druzyn[licznik_druzyn].tablica_postaci[i].sila);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[2].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz cyan");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[2].liczba_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}

			//-------------------------------------------------------
			tablica_graczy[3] = new gracz(Color.magenta,3,imie_gracza_2,0,3000,0);
			ilosc=UnityEngine.Random.Range (2, 4);
			licznik=0;
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==1)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[3].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[3].kolor;
					licznik++;
					tablica_graczy[3].liczba_miast++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=10;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==1) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[3].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3,k,k,"Postac "+i,true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[3].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz magenta");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[3].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
			//--------------------------------------------
			ilosc=UnityEngine.Random.Range (2, 4);
			licznik=0;
			tablica_graczy[4] = new gracz(new Color(0.94F, 0.57F, 0.06F),4,imie_gracza_3,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==2)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[4].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[4].kolor;
					licznik++;
					tablica_graczy[4].liczba_miast++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=20;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==2) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[4].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i,true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[4].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz orange");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[4].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
			//---------------------gracz
			licznik_druzyn=30;
			ilosc=1;
			licznik=0;
			tablica_graczy[1] = new gracz(Color.red,1,imie_gracza,0,1000,0);
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==3) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[1].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=5;
					tablica_druzyn[licznik_druzyn].zywnosc=1000;
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i] = new postac(-1, -1, -1, -1, -1, -1, -1, -1, -1, "", false);
                        kopiuj_postac(tablica_druzyn[licznik_druzyn].tablica_postaci[i], tworz_postac(i));
                        //new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i,true);
                        tworz_ekwipunek_druzyny_gracza(i);
					}
                    for (int i = tablica_druzyn[licznik_druzyn].ilosc_postaci; i < 10; i++)
                    {
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i] = new postac(-1, -1, -1, -1, -1, -1, -1, -1, -1, "", false);
                        tworz_ekwipunek_druzyny_gracza(i);
                    }
                    druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[1].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz1");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					licznik++;
					tablica_graczy[1].liczba_druzyn++;
					licznik_wszystkich_drużyn++;

				}
				else
					continue;
			}
		}
		else if (generowanie_wrogow == 1)
		{
			ilosc=UnityEngine.Random.Range (2, 4);
			tablica_graczy[2] = new gracz(Color.cyan,2,imie_gracza_1,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==1)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[2].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[2].kolor;
					tablica_graczy[2].liczba_miast++;
					licznik++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=0;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==1) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[2].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i,true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[2].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz cyan");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[2].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
			//-----------------------------------------------
			ilosc=UnityEngine.Random.Range (2, 4);
			licznik=0;
			tablica_graczy[3] = new gracz(Color.magenta,3,imie_gracza_2,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==2)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[3].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[3].kolor;
					licznik++;
					tablica_graczy[3].liczba_miast++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=10;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==2) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[3].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i,true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[3].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz magenta");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[3].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}

			//------------------------------------------------------------
			ilosc=UnityEngine.Random.Range (2, 4);
			licznik=0;
			tablica_graczy[4] = new gracz(new Color(0.94F, 0.57F, 0.06F),4,imie_gracza_3,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==3)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[4].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[4].kolor;
					licznik++;
					tablica_graczy[4].liczba_miast++;;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=20;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==3) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[4].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i, true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[4].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz orange");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[4].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
			//-----------------------------------
			licznik_druzyn=30;
			ilosc=1;
			licznik=0;
			tablica_graczy[1] = new gracz(Color.red,1,imie_gracza,0,1000,0);
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==0) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[1].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=5;
					tablica_druzyn[licznik_druzyn].zywnosc=1000;
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i] = new postac(-1, -1, -1, -1, -1, -1, -1, -1, -1, "", false);
                        kopiuj_postac(tablica_druzyn[licznik_druzyn].tablica_postaci[i], tworz_postac(i));
                        //tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i, true);
                        tworz_ekwipunek_druzyny_gracza(i);
					}
                    for (int i = tablica_druzyn[licznik_druzyn].ilosc_postaci; i < 10; i++)
                    {
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i] = new postac(-1, -1, -1, -1, -1, -1, -1, -1, -1, "", false);
                        tworz_ekwipunek_druzyny_gracza(i);
                    }
                    druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[1].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz1");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					licznik++;
					tablica_graczy[1].liczba_druzyn++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
		}
		else if (generowanie_wrogow == 2)
		{
			ilosc=UnityEngine.Random.Range (2, 4);
			tablica_graczy[2] = new gracz(Color.cyan,2,imie_gracza_1,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==2)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[2].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[2].kolor;
					tablica_graczy[2].liczba_miast++;
					licznik++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==2) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[2].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i, true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[2].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz cyan");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[2].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}

			//---------------------------------------
			ilosc=UnityEngine.Random.Range (2, 4);
			licznik=0;
			tablica_graczy[3] = new gracz(Color.magenta,3,imie_gracza_2,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==3)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[3].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[3].kolor;
					licznik++;
					tablica_graczy[3].liczba_miast++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=10;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==3) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[3].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i, true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[3].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz magenta");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[3].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
			//--------------------------------------------
			ilosc=UnityEngine.Random.Range (2, 4);
			licznik=0;
			tablica_graczy[4] = new gracz(new Color(0.94F, 0.57F, 0.06F),4,imie_gracza_3,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==0)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[4].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = new Color(0.94F, 0.57F, 0.06F);
					licznik++;
					tablica_graczy[4].liczba_miast++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=20;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==0) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[4].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i,true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[4].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz orange");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[4].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
			//--------------------
			licznik_druzyn=30;
			ilosc=1;
			licznik=0;
			tablica_graczy[1] = new gracz(Color.red,1,imie_gracza,0,1000,0);
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==1) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[1].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=5;
					tablica_druzyn[licznik_druzyn].zywnosc=1000;
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i] = new postac(-1, -1, -1, -1, -1, -1, -1, -1, -1, "", false);
                        kopiuj_postac(tablica_druzyn[licznik_druzyn].tablica_postaci[i], tworz_postac(i));
                        //tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i,true);
                        tworz_ekwipunek_druzyny_gracza(i);
					}
                    for (int i = tablica_druzyn[licznik_druzyn].ilosc_postaci; i < 10; i++)
                    {
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i] = new postac(-1, -1, -1, -1, -1, -1, -1, -1, -1, "", false);
                        tworz_ekwipunek_druzyny_gracza(i);
                    }
                    druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[1].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz1");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					licznik++;
					tablica_graczy[1].liczba_druzyn++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
		}
		else if (generowanie_wrogow == 3)
		{
			ilosc=UnityEngine.Random.Range (2, 4);
			tablica_graczy[2] = new gracz(Color.cyan,2,imie_gracza_1,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==3)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[2].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[2].kolor;
					tablica_graczy[2].liczba_miast++;
					licznik++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==3) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[2].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i,true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[2].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz cyan");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[2].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
			//-------------------------------------
			ilosc=UnityEngine.Random.Range (2, 4);
			licznik=0;
			tablica_graczy[3] = new gracz(Color.magenta,3,imie_gracza_2,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==0)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[3].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[3].kolor;
					licznik++;
					tablica_graczy[3].liczba_miast++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=10;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==0) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[3].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i, true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[3].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz magenta");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[3].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}


			//---------------------------
			ilosc=UnityEngine.Random.Range (2, 4);
			licznik=0;
			tablica_graczy[4] = new gracz(new Color(0.94F, 0.57F, 0.06F),4,imie_gracza_3,0,3000,0);
			while(licznik!=ilosc)
			{
				numer_miasta=UnityEngine.Random.Range (0, liczba_miast-1);
				if (tablica_miast[numer_miasta].obszar_mapy==1)
				{
					tablica_miast[numer_miasta].wlasciciel=tablica_graczy[4].numer;
					miasto_prostokat[numer_miasta].GetComponent<Renderer> ().material.color = tablica_graczy[4].kolor;
					licznik++;
					tablica_graczy[4].liczba_miast++;
				}
				else
					continue;
			}
			licznik=0;
			ilosc=UnityEngine.Random.Range (1, 3);
			licznik_druzyn=20;
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==1) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[4].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=UnityEngine.Random.Range (5,7);
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
						tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i, true);
					}
					druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[4].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz orange");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d);
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					tablica_graczy[4].liczba_druzyn++;
					licznik_druzyn++;
					licznik++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}
			//---------------------------
			licznik=0;
			ilosc=1;
			licznik_druzyn=30;
			tablica_graczy[1] = new gracz(Color.red,1,imie_gracza,0,1000,0);
			while(licznik!=ilosc)
			{
				numer_pola=UnityEngine.Random.Range (0, 9999);
				pozycja_x_d=tablica[numer_pola].positionx;
				pozycja_z_d=tablica[numer_pola].positionz;
				obszar=zwroc_obszar(pozycja_x_d,pozycja_z_d);
				teren=tablica[numer_pola].kolor;
				if ((obszar==2) && (teren!=3))
				{
					tablica_druzyn[licznik_druzyn].gracz=tablica_graczy[1].numer;
					tablica_druzyn[licznik_druzyn].ilosc_postaci=5;
					tablica_druzyn[licznik_druzyn].zywnosc=1000;
					for (int i=0;i<tablica_druzyn[licznik_druzyn].ilosc_postaci;i++)
					{
						int j=UnityEngine.Random.Range(70,100);
						int k=UnityEngine.Random.Range(20,80);
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i] = new postac(-1, -1, -1, -1, -1, -1, -1, -1, -1, "", false);
                        kopiuj_postac(tablica_druzyn[licznik_druzyn].tablica_postaci[i], tworz_postac(i));
                        //tablica_druzyn[licznik_druzyn].tablica_postaci[i]=new postac(UnityEngine.Random.Range(0,6),j,j,UnityEngine.Random.Range(20,80), UnityEngine.Random.Range(20, 80), 3, 3, k,k,"Postac "+i, true);
                        tworz_ekwipunek_druzyny_gracza(i);

					}
                    for (int i = tablica_druzyn[licznik_druzyn].ilosc_postaci; i < 10; i++)
                    {
                        tablica_druzyn[licznik_druzyn].tablica_postaci[i] = new postac(-1, -1, -1, -1, -1, -1, -1, -1, -1, "", false);
                        tworz_ekwipunek_druzyny_gracza(i);
                    }
                    druzyna_capsule[licznik_druzyn]=Instantiate (capsule_druzyna, new Vector3 (pozycja_x_d, 3.5F, pozycja_z_d), Quaternion.identity) as GameObject;
					druzyna_capsule[licznik_druzyn].GetComponent<Renderer> ().material.color = tablica_graczy[1].kolor;
					tablica_druzyn[licznik_druzyn].positionx=pozycja_x_d;
					tablica_druzyn[licznik_druzyn].positionz=pozycja_z_d;
					tablica_druzyn[licznik_druzyn].numer_pola=numer_pola;
					Debug.Log("Gracz1");
					Debug.Log("Jestem na pozycji x:"+pozycja_x_d); 
					Debug.Log("Jestem na pozycji z:"+pozycja_z_d);
					Debug.Log("Jestem na polu:"+numer_pola);
					licznik++;
					tablica_graczy[1].liczba_druzyn++;
					licznik_wszystkich_drużyn++;
				}
				else
					continue;
			}

		}
		return;
	}
	
	
	public Color wybierzkolor(int kolor)
	{
		Color kolorek1;
		switch(kolor)
		{
		case 0: 
			kolorek1=Color.green;   //łąka	
            tablica[numer].rodzaj_terenu = 0;
            break;
		case 1:
			kolorek1=new Color(0.36F,0.24F,0.12F); //brazowy //brązowy ,bagna
            tablica[numer].rodzaj_terenu = 1;
            break;
		case 2:
			kolorek1=new Color(0.18F, 0.52F, 0.34F); //lasy ciemny zielony
            tablica[numer].rodzaj_terenu = 2;
            break;
		case 3: 
			kolorek1=Color.blue;    //woda
            tablica[numer].rodzaj_terenu = 3;
            break;
		case 4:
			kolorek1=Color.yellow;  //pustynia
            tablica[numer].rodzaj_terenu = 4;
            break;
		case 5:
		//	kolorek1=new Color(0.18F, 0.52F, 0.34F);
		//	break;
			//kolorek1=Color.cyan;	
			kolorek1=new Color(0.18F, 0.52F, 0.34F); //lasy ciemny zielony
            tablica[numer].rodzaj_terenu = 2;
            break;
		case 6:
			kolorek1=Color.grey;    //gory
            tablica[numer].rodzaj_terenu = 5;
            break;
		case 7:
			kolorek1=Color.white;  //lodowiec
            tablica[numer].rodzaj_terenu = 6;
            break;
		case 8:
			kolorek1=Color.black; //miasto
			break;	
		default:
			//kolorek1=new Color(0, 1, 1);
			//if (Color.TryParseHexString)
		//	kolorek1=new Color(0.18F, 0.52F, 0.34F);
		//	kolorek1=new Color(0.36F,0.24F,0.12F); brazowy


			kolorek1=new Color(255.0F, 0.3F, 0.4F, 1F);
			break;
		}
		return kolorek1;
	}
	public void przesuwaj()
	{
		int i,aktualna_druzyna_numer_pola,help;
		Debug.Log ("Pozycja aktualna x=" + aktualna_druzyna.transform.position.x + "\n");
		Debug.Log ("Pozycja aktualna z=" + aktualna_druzyna.transform.position.z + "\n");
		aktualna_druzyna_numer_pola = (int)(aktualna_druzyna.transform.position.x * 100 + aktualna_druzyna.transform.position.z);
		if (aktualna_druzyna_index == 0) 
		{
			for (i=30; i<40; i++) {
				if (tablica_druzyn [i].numer_pola == aktualna_druzyna_numer_pola) {
					aktualna_druzyna_index = i;
					Debug.Log ("Druzyna znaleziona");
					Debug.Log ("Druzyna =" + aktualna_druzyna_index);
					break;
				}
			
			}
		}

		if (zaznaczone_pole_docelowe == true) 
		{
			Debug.Log ("Druzyna wybrana.Cel zaznaczony");
			if (aktualna_druzyna.transform.position.x < pozycjax_kliknietego) {
				//aktualna_druzyna.transform.position.x=aktualna_druzyna.transform.position.x+1;
				aktualna_druzyna.transform.position = new Vector3 (aktualna_druzyna.transform.position.x + 1, 3.5F, aktualna_druzyna.transform.position.z);
			} else if (aktualna_druzyna.transform.position.x > pozycjax_kliknietego) {
				//aktualna_druzyna.transform.position.x=aktualna_druzyna.transform.position.x-1;
				aktualna_druzyna.transform.position = new Vector3 (aktualna_druzyna.transform.position.x - 1, 3.5F, aktualna_druzyna.transform.position.z);
			}
			if (aktualna_druzyna.transform.position.z < pozycjaz_kliknietego) {
				//aktualna_druzyna.transform.position.z=aktualna_druzyna.transform.position.z+1;
				aktualna_druzyna.transform.position = new Vector3 (aktualna_druzyna.transform.position.x, 3.5F, aktualna_druzyna.transform.position.z + 1);
			} else if (aktualna_druzyna.transform.position.z > pozycjaz_kliknietego) {
				//aktualna_druzyna.transform.position.z=aktualna_druzyna.transform.position.z-1;
				aktualna_druzyna.transform.position = new Vector3 (aktualna_druzyna.transform.position.x, 3.5F, aktualna_druzyna.transform.position.z - 1);
			}
			aktualna_druzyna_numer_pola = (int)(aktualna_druzyna.transform.position.x * 100 + aktualna_druzyna.transform.position.z);
			for (i=0; i<30; i++) {
				if (tablica_druzyn [i].numer_pola == aktualna_druzyna_numer_pola) {
					Debug.Log ("tablica_druzyn[i].numer_pola" + tablica_druzyn [i].numer_pola);
					Debug.Log ("aktualna_druzyna_numer_pola" + aktualna_druzyna_numer_pola);
					Debug.Log ("aktualna_druzyna_index" + aktualna_druzyna_index);
					Debug.Log ("wroga druzyna" + i);

					help = walka_automatyczna (tablica_druzyn [i].oblicz_sile (), tablica_druzyn [aktualna_druzyna_index].oblicz_sile ());
				}

			}

			tablica_druzyn [aktualna_druzyna_index].zywnosc = tablica_druzyn [aktualna_druzyna_index].zywnosc - (tablica_druzyn [aktualna_druzyna_index].ilosc_postaci * 10);
			Debug.Log ("Druzyna =" + aktualna_druzyna_index);
			Debug.Log ("Mamy " + tablica_druzyn [aktualna_druzyna_index].zywnosc + "zywnosci");
			if (tablica_druzyn [aktualna_druzyna_index].zywnosc <= 0) 
			{
				Debug.Log ("Smierc glodowa");
				koniecgry(0);
				//Application.Quit();
			}
		} 
		else 
		{
			aktualna_druzyna_numer_pola = (int)(aktualna_druzyna.transform.position.x * 100 + aktualna_druzyna.transform.position.z);
			for (i=30; i<40; i++) {
				if (tablica_druzyn [i].numer_pola == aktualna_druzyna_numer_pola) {
					aktualna_druzyna_index = i;
					Debug.Log ("Druzyna znaleziona");
					Debug.Log ("Druzyna =" + aktualna_druzyna_index);
					break;
				}
				
			}


		}

	}
	public void generuj_teren(int rodzaj)
	{
		int i,j,licznik_pol;
		licznik_pol = 0;
		for (i=0; i<25; i++) 
		{
			for (j=0; j<25 ;j++) 
			{
				pozycjax = tablica_malego_terenu[licznik_pol].positionx;
				pozycjaz = tablica_malego_terenu[licznik_pol].positionz;
				tablica_malego_terenu[licznik_pol].zajete = 1;
				tablica_malego_terenu[licznik_pol].kolor = 0;
				pole_malego_terenu_[licznik_pol] = Instantiate (cube_pole_malego_terenu, new Vector3 (pozycjax+150, 1.5F, pozycjaz+150), Quaternion.identity) as GameObject;
				pole_malego_terenu_[licznik_pol].GetComponent<Renderer> ().material.color = wybierzkolor (0);
				licznik_pol++;
			}
			
		}
		Debug.Log ("Wygenerowane");
		//camera_.transform.Translate(100,100,0);
		camera_.transform.position = new Vector3(160, 40, 160);
		//camera_.transform.
		budynek=Instantiate (cube_spichlerz, new Vector3 (165, 2.5F, 165), Quaternion.identity) as GameObject;;
		//miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
		budynek.GetComponent<Renderer> ().material.color = wybierzkolor (1);
		budynek.tag = "Spichlerz";
		budynek1=Instantiate (cube_platnerz, new Vector3 (168, 2.5F, 168), Quaternion.identity) as GameObject;;
		//miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
		budynek1.GetComponent<Renderer> ().material.color = Color.black;
		budynek1.tag = "Platnerz";
		budynek2=Instantiate (cube_biblioteka, new Vector3 (170, 2.5F, 170), Quaternion.identity) as GameObject;;
		//miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
		budynek2.GetComponent<Renderer> ().material.color = Color.blue;
		budynek2.tag = "Biblioteka";
		budynek3=Instantiate (cube_alchemik, new Vector3 (162, 2.5F, 162), Quaternion.identity) as GameObject;;
		//miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
		budynek3.GetComponent<Renderer> ().material.color = Color.cyan;
		budynek3.tag = "Alchemik";
		budynek4=Instantiate (cube_mysliwy, new Vector3 (159, 2.5F, 159), Quaternion.identity) as GameObject;;
		//miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
		budynek4.GetComponent<Renderer> ().material.color = Color.magenta;
		budynek4.tag = "Mysliwy";
		wizyta_w_miescie = true;
		return;
	}
	public void kupowanie_jedzenia()
	{
		Debug.Log ("Kupujemy jedzenie");
		generuj_teren(0);
		return;
	}
    public void walka_w_terenie()
    {
        int i, j, licznik_pol;
        
        licznik_pol = 0;
        for (i = 0; i < 25; i++)
        {
            for (j = 0; j < 25; j++)
            {
                pozycjax = tablica_malego_terenu[licznik_pol].positionx;
                pozycjaz = tablica_malego_terenu[licznik_pol].positionz;
                tablica_malego_terenu[licznik_pol].zajete = 1;
                tablica_malego_terenu[licznik_pol].kolor = 0;
                pole_malego_terenu_[licznik_pol] = Instantiate(cube_pole_malego_terenu, new Vector3(pozycjax + 150, 1.5F, pozycjaz + 150), Quaternion.identity) as GameObject;
                pole_malego_terenu_[licznik_pol].GetComponent<Renderer>().material.color = wybierzkolor(0);
                pole_malego_terenu_[licznik_pol].tag = "pole_malego_terenu";
                licznik_pol++;
            }

        }
        for (i=0;i<10;i++)
        {
            index_w_tabeli[i] = 0;
            test1[i] = 0;
            test2[i] = 0;
            test5[i] = false;
            test6[i] = false;
            //z_ok[i] = 0;
            //x_ok[i] = 0;
        }
        Debug.Log("Wygenerowane");
        //camera_.transform.Translate(100,100,0);
        camera_.transform.position = new Vector3(160, 40, 160);
        //camera_.transform.
        for (i=0;i< tablica_druzyn[aktualna_druzyna_index].ilosc_postaci;i++)
        {
            postacie[i]= Instantiate(cube_postac, new Vector3(174-2*i, 2.5F, 174-2*i), Quaternion.identity) as GameObject;
            postacie[i].GetComponent<Renderer>().material.mainTexture = postacgracza1Texture;
            postacie[i].tag="Postac_gracza";
           // postacie[i].AddComponent<Cube_postac>();
            postacie[i].GetComponent<Cube_postac>().moj_numer = i;
           // postacie[i].GetComponent<cube_postac>().
            //postacie[i].GetScript dostac sie do moj number albo component?
            index_w_tabeli[i]= ((int)(174-2*i - 150) * 25) + (int)(174 - 2 * i - 150);
            tablica_malego_terenu[index_w_tabeli[i]].zajete = 2;//postac gracza
            test1[i] = 174 - 2 * i;
            test2[i] = 174 - 2 * i;
        }
       // postac1 = Instantiate(cube, new Vector3(174, 2.5F, 174), Quaternion.identity) as GameObject; ;
        //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
        //postac1.GetComponent<Renderer>().material.color = wybierzkolor(3);
       // postac1.GetComponent<Renderer>().material.mainTexture=postacgracza1Texture;
        //postac1.tag = "Postac_gracza";
        //index_w_tabeli = ((int)(174 - 150) * 25) + (int)(174 - 150);
        zeruj_pola_docelowe();
        //wygenerowac dla kazdej postaci w druzynie
        wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
        //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
        //wrog1.GetComponent<Renderer>().material.color = Color.red;
        wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
        wrog1.tag = "Postac_wrog";
        wrog_nr_1 = new wrog_potwor("Wilk",0,60,60,2,2,2,2,0,0,200);
        for (i = 0; i < 8; i++)
        {
            wrog_nr_1.sasiednie_pola[i] = 0;
        }
        tablica_malego_terenu[((159 - 150) * 25) + (159 -  150)].zajete = 3;//wrog
        polowanie = true;
        poczatkowa_liczba_postaci_gracza = tablica_druzyn[aktualna_druzyna_index].ilosc_postaci;
        return;

    }
    public void akcja_w_terenie()
    {
        int i, j, licznik_pol,kolor,numer;
        int wylosowana_liczba;

        licznik_pol = 0;
        numer = (int)(aktualna_druzyna.transform.position.x * 100 + aktualna_druzyna.transform.position.z);
        kolor = tablica[numer].kolor;
        for (i = 0; i < 25; i++)
        {
            for (j = 0; j < 25; j++)
            {
                pozycjax = tablica_malego_terenu[licznik_pol].positionx;
                pozycjaz = tablica_malego_terenu[licznik_pol].positionz;
                tablica_malego_terenu[licznik_pol].zajete = 1;
                tablica_malego_terenu[licznik_pol].kolor = kolor;//0;
                pole_malego_terenu_[licznik_pol] = Instantiate(cube_pole_malego_terenu, new Vector3(pozycjax + 150, 1.5F, pozycjaz + 150), Quaternion.identity) as GameObject;
                pole_malego_terenu_[licznik_pol].GetComponent<Renderer>().material.color = wybierzkolor(kolor);
                pole_malego_terenu_[licznik_pol].tag = "pole_malego_terenu";
                licznik_pol++;
            }

        }
        for (i = 0; i < 10; i++)
        {
            index_w_tabeli[i] = 0;
            test1[i] = 0;
            test2[i] = 0;
            test5[i] = false;
            test6[i] = false;
            //z_ok[i] = 0;
            //x_ok[i] = 0;
        }
        Debug.Log("Wygenerowane");
        //camera_.transform.Translate(100,100,0);
        camera_.transform.position = new Vector3(160, 40, 160);
        //camera_.transform.
        for (i = 0; i < tablica_druzyn[aktualna_druzyna_index].ilosc_postaci; i++)
        {
            postacie[i] = Instantiate(cube_postac, new Vector3(174 - 2 * i, 2.5F, 174 - 2 * i), Quaternion.identity) as GameObject;
            postacie[i].GetComponent<Renderer>().material.mainTexture = postacgracza1Texture;
            postacie[i].tag = "Postac_gracza";
            // postacie[i].AddComponent<Cube_postac>();
            postacie[i].GetComponent<Cube_postac>().moj_numer = i;
            // postacie[i].GetComponent<cube_postac>().
            //postacie[i].GetScript dostac sie do moj number albo component?
            index_w_tabeli[i] = ((int)(174 - 2 * i - 150) * 25) + (int)(174 - 2 * i - 150);
            tablica_malego_terenu[index_w_tabeli[i]].zajete = 2;//postac gracza
            test1[i] = 174 - 2 * i;
            test2[i] = 174 - 2 * i;
        }
        // postac1 = Instantiate(cube, new Vector3(174, 2.5F, 174), Quaternion.identity) as GameObject; ;
        //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
        //postac1.GetComponent<Renderer>().material.color = wybierzkolor(3);
        // postac1.GetComponent<Renderer>().material.mainTexture=postacgracza1Texture;
        //postac1.tag = "Postac_gracza";
        //index_w_tabeli = ((int)(174 - 150) * 25) + (int)(174 - 150);
        zeruj_pola_docelowe();
        polowanie = true;
        poczatkowa_liczba_postaci_gracza = tablica_druzyn[aktualna_druzyna_index].ilosc_postaci;
        if (kolor == 0) /*laka*/
        {
            DateTime now = DateTime.Now;
            UnityEngine.Random.seed = (now.Second + now.Minute + now.Millisecond);
            wylosowana_liczba = UnityEngine.Random.Range(0, 100);
            Debug.Log("wylosowana_liczba=" + wylosowana_liczba);
            Debug.Log("Laka");

            if (wylosowana_liczba <= 15)
            {
                if (wylosowana_liczba >= 12)
                {
                    //spotkanie saren
                    Debug.Log("Sarny");
                    //spotkanie wilkow
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(4, 7);
                    switch (wylosowana_liczba)
                    {
                        case 4: //cztery sarny
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            break;
                        case 5: //5 saren
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            break;
                        case 6: //6 saren
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            break;
                        case 7: //siedem saren
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
                else if (wylosowana_liczba >= 8)
                {
                    //spotkanie jeleni
                    Debug.Log("Jelenie");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 2);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden jelen
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = jelenTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Jelen", 0, 50, 50, 1, 2, 1, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa jelenie
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = jelenTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Jelen", 0, 50, 50, 1, 2, 1, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = jelenTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Jelen", 0, 50, 50, 1, 2, 1, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
                else if (wylosowana_liczba >= 4)
                {
                    //spotkanie wilkow
                    Debug.Log("Wilki");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 7);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden wilk
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                        case 3: //trzy wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            break;
                        case 4: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            break;
                        case 5: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            break;
                        case 6: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            break;
                        case 7: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
                else
                {
                    //spotkanie dzikow
                    Debug.Log("Dziki");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 7);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden wilk
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                        case 3: //trzy wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            break;
                        case 4: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            break;
                        case 5: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            break;
                        case 6: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            break;
                        case 7: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            break;
                    }
                }


                //spotkanie zwierzyny


                if (wylosowana_liczba <= 10)
                {
                    //drogie ziola
                    Debug.Log("Drogie ziolo");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 3);
                    if (wylosowana_liczba == 1)
                    {
                        //jedno ziolo
                        Debug.Log("jedno ziolo");
                        DateTime now2 = DateTime.Now;
                        UnityEngine.Random.seed = (now2.Second + now2.Minute + now2.Millisecond);
                        wylosowana_liczba = UnityEngine.Random.Range(1, 3);
                        if (wylosowana_liczba == 1)
                        {
                            Debug.Log("ziolo zdrowia");
                            tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(9, 1, "Zioło zdrowia, +15 punktow zdrowia", 25, ziolozdrowieTexture);
                        }
                        else if (wylosowana_liczba == 2)
                        {
                            Debug.Log("ziolo sily");
                            tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(11, 1, "Zioło siły tymczasowe, +2 siły", 125, ziolosilaTexture);
                        }
                        else
                        {
                            Debug.Log("ziolo zrecznosci");
                            tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(12, 1, "Zioło zrecznosci tymczasowe, +2 zrecznosc", 125, ziolozrecznoscTexture);
                        }

                    }
                }
            }
            else //test
            {
                /*
                wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                wrog1.tag = "Postac_wrog";
                wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_1.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                wrog2.tag = "Postac_wrog";
                wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_2.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog3.GetComponent<Renderer>().material.mainTexture = jelenTexture;
                wrog3.tag = "Postac_wrog";
                wrog_nr_3 = new wrog_potwor("Jelen", 0, 50, 50, 1, 2, 1, 2, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_3.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog

                wrog4 = Instantiate(cube_wrog, new Vector3(161, 2.5F, 161), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                wrog4.tag = "Postac_wrog";
                wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_4.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((161 - 150) * 25) + (161 - 150)].zajete = 3;//wrog
                */
                wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                wrog1.tag = "Postac_wrog";
                wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_1.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                wrog2.tag = "Postac_wrog";
                wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_2.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                wrog3.tag = "Postac_wrog";
                wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_2.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                wrog4.tag = "Postac_wrog";
                wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_4.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                wrog5 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog5.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                wrog5.tag = "Postac_wrog";
                wrog_nr_5 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_5.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                wrog6 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog6.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                wrog6.tag = "Postac_wrog";
                wrog_nr_6 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_6.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                wrog7 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog7.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                wrog7.tag = "Postac_wrog";
                wrog_nr_7 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_7.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog

                tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(9, 1, "Zioło zdrowia, +15 punktow zdrowia", 25, ziolozdrowieTexture);
                tablica_malego_terenu[1].rzeczy_na_ziemi[0] = new ekwipunek(11, 1, "Zioło siły tymczasowe, +2 siły", 125, ziolosilaTexture);
                tablica_malego_terenu[2].rzeczy_na_ziemi[0] = new ekwipunek(12, 1, "Zioło zrecznosci tymczasowe, +2 zrecznosc", 125, ziolozrecznoscTexture);
            }
        }
        else if ((kolor == 2) || (kolor == 5))
        {
            DateTime now = DateTime.Now;
            UnityEngine.Random.seed = (now.Second + now.Minute + now.Millisecond);
            wylosowana_liczba = UnityEngine.Random.Range(0, 100);
            Debug.Log("wylosowana_liczba=" + wylosowana_liczba);
            Debug.Log("Las");

            if (wylosowana_liczba <= 20)
            {
                if (wylosowana_liczba >= 12)
                {
                    //spotkanie saren
                    Debug.Log("Sarny");
                    //spotkanie wilkow
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(4, 7);
                    switch (wylosowana_liczba)
                    {
                        case 4: //cztery sarny
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            break;
                        case 5: //5 saren
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            break;
                        case 6: //6 saren
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            break;
                        case 7: //siedem saren
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(156, 2.5F, 156), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = sarnaTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Sarna", 0, 30, 30, 0, 3, 0, 1, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
                else if (wylosowana_liczba >= 10)
                {
                    Debug.Log("Jelenie");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 2);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden jelen
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = jelenTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Jelen", 0, 50, 50, 1, 2, 1, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa jelenie
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = jelenTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Jelen", 0, 50, 50, 1, 2, 1, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = jelenTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Jelen", 0, 50, 50, 1, 2, 1, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                    }

                }
                else if (wylosowana_liczba >= 8)
                {
                    //spotkanie wilkow
                    Debug.Log("Wilki");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 7);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden wilk
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                        case 3: //trzy wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            break;
                        case 4: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            break;
                        case 5: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            break;
                        case 6: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            break;
                        case 7: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = wilkTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Wilk", 0, 60, 60, 2, 2, 2, 2, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
                else if (wylosowana_liczba >= 6)
                {
                    //spotkanie gargoyli
                    Debug.Log("Gargoyle");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 2);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden jelen
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = gargoylTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Gargoyl", 0, 800, 800, 6, 2, 6, 6, 0, 0, 1000);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa jelenie
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = gargoylTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Gargoyl", 0, 800, 800, 6, 2, 6, 6, 0, 0, 1000);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = gargoylTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Gargoyl", 0, 800, 800, 6, 2, 6, 6, 0, 0, 1000);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
                else if (wylosowana_liczba >= 4)
                {
                    //spotkanie dzikow
                    Debug.Log("Dziki");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 7);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden wilk
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                        case 3: //trzy wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            break;
                        case 4: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            break;
                        case 5: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            break;
                        case 6: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            break;
                        case 7: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = dzikTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Dzik", 0, 80, 80, 3, 1, 3, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
                else if (wylosowana_liczba >= 2)
                {
                    //spotkanie niedzwiedzi
                    Debug.Log("niedzwiedzie");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 2);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden jelen
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = niedzwiedzTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Niedzwiedz", 0, 250, 250, 4, 2, 4, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa jelenie
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = niedzwiedzTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Niedzwiedz", 0, 250, 250, 4, 2, 4, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = niedzwiedzTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Niedzwiedz", 0, 250, 250, 4, 2, 4, 3, 0, 0, 200);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
            }
            else //test
            {
                //spotkanie niedzwiedzi
                Debug.Log("niedzwiedzie");
                DateTime now1 = DateTime.Now;
                UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                wylosowana_liczba = UnityEngine.Random.Range(1, 2);
                switch (wylosowana_liczba)
                {
                    case 1: //jeden jelen
                        wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                        //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                        //wrog1.GetComponent<Renderer>().material.color = Color.red;
                        wrog1.GetComponent<Renderer>().material.mainTexture = niedzwiedzTexture;
                        wrog1.tag = "Postac_wrog";
                        wrog_nr_1 = new wrog_potwor("Niedzwiedz", 0, 250, 250, 4, 2, 4, 3, 0, 0, 200);
                        for (i = 0; i < 8; i++)
                        {
                            wrog_nr_1.sasiednie_pola[i] = 0;
                        }
                        tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                        break;
                    case 2: //dwa jelenie
                        wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                        //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                        //wrog1.GetComponent<Renderer>().material.color = Color.red;
                        wrog1.GetComponent<Renderer>().material.mainTexture = niedzwiedzTexture;
                        wrog1.tag = "Postac_wrog";
                        wrog_nr_1 = new wrog_potwor("Niedzwiedz", 0, 250, 250, 4, 2, 4, 3, 0, 0, 200);
                        for (i = 0; i < 8; i++)
                        {
                            wrog_nr_1.sasiednie_pola[i] = 0;
                        }
                        tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                        wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                        //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                        //wrog1.GetComponent<Renderer>().material.color = Color.red;
                        wrog2.GetComponent<Renderer>().material.mainTexture = niedzwiedzTexture;
                        wrog2.tag = "Postac_wrog";
                        wrog_nr_2 = new wrog_potwor("Niedzwiedz", 0, 250, 250, 4, 2, 4, 3, 0, 0, 200);
                        for (i = 0; i < 8; i++)
                        {
                            wrog_nr_2.sasiednie_pola[i] = 0;
                        }
                        tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                        break;
                }
            }
            

        }
        else if (kolor == 4) // pustynia
        {
            DateTime now = DateTime.Now;
            UnityEngine.Random.seed = (now.Second + now.Minute + now.Millisecond);
            wylosowana_liczba = UnityEngine.Random.Range(0, 100);
            Debug.Log("wylosowana_liczba=" + wylosowana_liczba);
            Debug.Log("pustynia");

            if (wylosowana_liczba <= 20)
            {
                if (wylosowana_liczba >= 12)
                {
                    Debug.Log("Skorpiony");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 10);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden wilk
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                        case 3: //trzy wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            break;
                        case 4: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            break;
                        case 5: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            break;
                        case 6: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            break;
                        case 7: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            break;
                        case 8: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            wrog8 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog8.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog8.tag = "Postac_wrog";
                            wrog_nr_8 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_8.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog
                            break;
                        case 9: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            wrog8 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog8.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog8.tag = "Postac_wrog";
                            wrog_nr_8 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_8.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog
                            wrog9 = Instantiate(cube_wrog, new Vector3(152, 2.5F, 152), Quaternion.identity) as GameObject; ;
                            wrog9.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog9.tag = "Postac_wrog";
                            wrog_nr_9 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_9.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((152 - 150) * 25) + (152 - 150)].zajete = 3;//wrog
                            break;
                        case 10: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            wrog8 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject; 
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog8.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog8.tag = "Postac_wrog";
                            wrog_nr_8 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_8.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog
                            wrog9 = Instantiate(cube_wrog, new Vector3(152, 2.5F, 152), Quaternion.identity) as GameObject; ;
                            wrog9.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog9.tag = "Postac_wrog";
                            wrog_nr_9 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_9.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((152 - 150) * 25) + (152 - 150)].zajete = 3;//wrog
                            wrog10 = Instantiate(cube_wrog, new Vector3(151, 2.5F, 151), Quaternion.identity) as GameObject; ;
                            wrog10.GetComponent<Renderer>().material.mainTexture = skorpionTexture;
                            wrog10.tag = "Postac_wrog";
                            wrog_nr_10 = new wrog_potwor("Skorpion", 0, 150, 150, 3, 2, 3, 3, 0, 0, 400);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_10.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((151 - 150) * 25) + (151 - 150)].zajete = 3;//wrog
                            break;
                    }
                }
                else if (wylosowana_liczba >=6)
                {
                    Debug.Log("Warpuny");
                    DateTime now1 = DateTime.Now;
                    UnityEngine.Random.seed = (now1.Second + now1.Minute + now1.Millisecond);
                    wylosowana_liczba = UnityEngine.Random.Range(1, 10);
                    switch (wylosowana_liczba)
                    {
                        case 1: //jeden wilk
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            break;
                        case 2: //dwa wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            break;
                        case 3: //trzy wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            break;
                        case 4: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((157 - 150) * 25) + (157 - 150)].zajete = 3;//wrog
                            break;
                        case 5: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            break;
                        case 6: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            break;
                        case 7: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            break;
                        case 8: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            wrog8 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog8.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog8.tag = "Postac_wrog";
                            wrog_nr_8 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_8.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog
                            break;
                        case 9: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            wrog8 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog8.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog8.tag = "Postac_wrog";
                            wrog_nr_8 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_8.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog
                            wrog9 = Instantiate(cube_wrog, new Vector3(152, 2.5F, 152), Quaternion.identity) as GameObject; ;
                            wrog9.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog9.tag = "Postac_wrog";
                            wrog_nr_9 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_9.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((152 - 150) * 25) + (152 - 150)].zajete = 3;//wrog
                            break;
                        case 10: //cztery wilki
                            wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog1.tag = "Postac_wrog";
                            wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_1.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
                            wrog2 = Instantiate(cube_wrog, new Vector3(158, 2.5F, 158), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog2.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog2.tag = "Postac_wrog";
                            wrog_nr_2 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_2.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((158 - 150) * 25) + (158 - 150)].zajete = 3;//wrog
                            wrog3 = Instantiate(cube_wrog, new Vector3(160, 2.5F, 160), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog3.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog3.tag = "Postac_wrog";
                            wrog_nr_3 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_3.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((160 - 150) * 25) + (160 - 150)].zajete = 3;//wrog
                            wrog4 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog4.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog4.tag = "Postac_wrog";
                            wrog_nr_4 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_4.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog5 = Instantiate(cube_wrog, new Vector3(157, 2.5F, 157), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog5.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog5.tag = "Postac_wrog";
                            wrog_nr_5 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_5.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((156 - 150) * 25) + (156 - 150)].zajete = 3;//wrog
                            wrog6 = Instantiate(cube_wrog, new Vector3(155, 2.5F, 155), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog6.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog6.tag = "Postac_wrog";
                            wrog_nr_6 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_6.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((155 - 150) * 25) + (155 - 150)].zajete = 3;//wrog
                            wrog7 = Instantiate(cube_wrog, new Vector3(154, 2.5F, 154), Quaternion.identity) as GameObject; ;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog7.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog7.tag = "Postac_wrog";
                            wrog_nr_7 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_7.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((154 - 150) * 25) + (154 - 150)].zajete = 3;//wrog
                            wrog8 = Instantiate(cube_wrog, new Vector3(153, 2.5F, 153), Quaternion.identity) as GameObject;
                            //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                            //wrog1.GetComponent<Renderer>().material.color = Color.red;
                            wrog8.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog8.tag = "Postac_wrog";
                            wrog_nr_8 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_8.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((153 - 150) * 25) + (153 - 150)].zajete = 3;//wrog
                            wrog9 = Instantiate(cube_wrog, new Vector3(152, 2.5F, 152), Quaternion.identity) as GameObject; ;
                            wrog9.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog9.tag = "Postac_wrog";
                            wrog_nr_9 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_9.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((152 - 150) * 25) + (152 - 150)].zajete = 3;//wrog
                            wrog10 = Instantiate(cube_wrog, new Vector3(151, 2.5F, 151), Quaternion.identity) as GameObject; ;
                            wrog10.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                            wrog10.tag = "Postac_wrog";
                            wrog_nr_10 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                            for (i = 0; i < 8; i++)
                            {
                                wrog_nr_10.sasiednie_pola[i] = 0;
                            }
                            tablica_malego_terenu[((151 - 150) * 25) + (151 - 150)].zajete = 3;//wrog
                            break;
                    }

                }
            }
            else
            {
                //test
                wrog1 = Instantiate(cube_wrog, new Vector3(159, 2.5F, 159), Quaternion.identity) as GameObject; ;
                //miasto_prostokat[licznik]=Instantiate (cube, new Vector3 (pozycja_x_, 2.5F, pozycja_z_), Quaternion.identity) as GameObject;
                //wrog1.GetComponent<Renderer>().material.color = Color.red;
                wrog1.GetComponent<Renderer>().material.mainTexture = warpunTexture;
                wrog1.tag = "Postac_wrog";
                wrog_nr_1 = new wrog_potwor("Warpun", 0, 150, 150, 4, 2, 4, 4, 0, 0, 500);
                for (i = 0; i < 8; i++)
                {
                    wrog_nr_1.sasiednie_pola[i] = 0;
                }
                tablica_malego_terenu[((159 - 150) * 25) + (159 - 150)].zajete = 3;//wrog
            }
        }
        return;

    }
    public void powrot_kamery()
	{
		Debug.Log ("Kamera wraca");
		wizyta_w_miescie = false;
		camera_.transform.position = new Vector3(50, 40, 50);
		return;
	}
	public void koniecgry(int powod)
	{
		if (powod == 0)
			smierglodowa = true;
        if (powod == 1)
            smiercpokonani = true;
	}
	public void ukryj_ekwipunek_i_asortyment()
	{
		for (int i=0;i<20;i++)
		{
			Destroy(asortyment_sklepu[i]);
		}
		for (int i=0; i<13; i++) 
		{
			Destroy(ekwipunek_postaci_box[i]);
		}
	}
    public void ukryj_przedmioty_na_ziemi()
    {
        for (int i = 0; i < 4; i++)
        {
            Destroy(przedmioty_na_ziemi[i]);
        }
    }
    public void ukryj_ekwipunek_postaci()
    {
        for (int i = 0; i < 13; i++)
        {
            Destroy(ekwipunek_postaci_box[i]);
        }
    }
    public void ukryj_ekwipunek_i_przedmioty_na_ziemi()
    {
        ukryj_przedmioty_na_ziemi();
        ukryj_ekwipunek_postaci();
    }
    void rysuj_ekwipunek_postaci()
	{
		for (int i=0; i<13; i++) 
		{
			ekwipunek_postaci_box[i].GetComponent<Renderer>().material.mainTexture=tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].tablica_ekwipunku[i].obrazek;
		}
		return;
	}
	void wyjdz()
	{
		przedmiot_klikniety=false;
		pokazuje_na_przedmiot=false;
		pokazuje_na_przedmiot_postaci = false;
		przedmiot_postaci_klikniety = false;
		index_ekwipunku_postaci = -1;
		index_ekwipunku_sklepu=-1;
		return;
	}
    string zwroc_rase(int rasa)
    {
        string s_rasa;
        switch (rasa)
        {
            case 0:
                s_rasa = "Ogr";
                break;
            case 1:
                s_rasa = "Krasnolud";
                break;
            case 2:
                s_rasa = "Mag";
                break;
            case 3:
                s_rasa = "Elf";
                break;
            case 4:
                s_rasa = "Czlowiek";
                break;
            case 5:
                s_rasa = "Hobbit";
                break;
            case 6:
                s_rasa = "Kotolak";
                break;
            case 7:
                s_rasa = "Jaszczuroludz";
                break;
            case 8:
                s_rasa = "Ork";
                break;
            case 9:
                s_rasa = "Amazonka";
                break;
            default:
                s_rasa = "blad";
                break;
        }
        return s_rasa;
    }
    postac tworz_postac(int numer)
    {
        int rasa, hp,sila,zrecznosc,atak,obrona,mana;
        string imie;
        postac postac1;

        rasa = UnityEngine.Random.Range(0, 9);

        hp = -1;
        sila = -1;
        zrecznosc = -1;
        atak = -1;
        obrona = -1;
        mana = -1;


        switch (rasa)
        {
            case 0: //ogr
                hp = UnityEngine.Random.Range(90, 120);
                sila = 4;
                zrecznosc = 1;
                atak = 3;
                obrona = 3;
                mana= UnityEngine.Random.Range(5, 20);
                break;
            case 1: //krasnolud
                hp = UnityEngine.Random.Range(60, 90);
                sila = 3;
                zrecznosc = 1;
                atak = 3;
                obrona = 3;
                mana = UnityEngine.Random.Range(10, 30);
                break;
            case 2: //mag
                hp = UnityEngine.Random.Range(15, 30);
                sila = 1;
                zrecznosc = 1;
                atak = 1;
                obrona = 1;
                mana = UnityEngine.Random.Range(80, 100);
                break;
            case 3: //elf
                hp = UnityEngine.Random.Range(30, 60);
                sila = 2;
                zrecznosc = 3;
                atak = 2;
                obrona = 2;
                mana = UnityEngine.Random.Range(40, 60);
                break;
            case 4: //czlowiek
                hp = UnityEngine.Random.Range(30, 60);
                sila = 2;
                zrecznosc = 2;
                atak = 2;
                obrona = 2;
                mana = UnityEngine.Random.Range(30, 50);
                break;
            case 5: //hobbit
                hp = UnityEngine.Random.Range(10, 20);
                sila = 1;
                zrecznosc = 3;
                atak = 1;
                obrona = 1;
                mana = UnityEngine.Random.Range(30, 50);
                break;
            case 6: //kotolak
                hp = UnityEngine.Random.Range(30, 60);
                sila = 2;
                zrecznosc = 2;
                atak = 2;
                obrona = 2;
                mana = UnityEngine.Random.Range(70, 90);
                break;
            case 7: //jaszczuroludz
                hp = UnityEngine.Random.Range(60, 90);
                sila = 2;
                zrecznosc = 1;
                atak = 1;
                obrona = 2;
                mana = UnityEngine.Random.Range(70, 90);
                break;
            case 8: //ork
                hp = UnityEngine.Random.Range(30, 60);
                sila = 3;
                zrecznosc = 1;
                atak = 3;
                obrona = 2;
                mana = UnityEngine.Random.Range(10, 30);
                break;
            case 9: //Amazonka
                hp = UnityEngine.Random.Range(25, 55);
                sila = 1;
                zrecznosc = 3;
                atak = 1;
                obrona = 1;
                mana = UnityEngine.Random.Range(10, 30);
                break;
        }

        imie = "Postac " + numer;
        postac1 = new postac(rasa, hp, hp, sila, zrecznosc, atak, obrona, mana, mana, imie, true);

        return postac1;
    }
    void gm_wczytaj_przedmioty_na_ziemi()
    {
        /* aktualna_postac = 0;
         while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
         {
             if (aktualna_postac == 9)
             {
                 aktualna_postac = 0;
             }
             else
                 aktualna_postac++;
         }
         */
        int licznik, x, z;
        x = (int)(test1[aktualna_postac] - 150);
        z = (int)(test2[aktualna_postac] - 150);
        licznik =x * 25 + z;
        Debug.Log("X=" + x);
        Debug.Log("Z=" + z);
        Debug.Log("Licznik=" + licznik);
        ekwipunek_przedmioty_na_ziemi[0] = tablica_malego_terenu[licznik].rzeczy_na_ziemi[0];
        przedmioty_na_ziemi[0].GetComponent<Renderer>().material.mainTexture = ekwipunek_przedmioty_na_ziemi[0].obrazek;
        ekwipunek_przedmioty_na_ziemi[1] = tablica_malego_terenu[licznik].rzeczy_na_ziemi[1];
        przedmioty_na_ziemi[1].GetComponent<Renderer>().material.mainTexture = ekwipunek_przedmioty_na_ziemi[1].obrazek;
        ekwipunek_przedmioty_na_ziemi[2] = tablica_malego_terenu[licznik].rzeczy_na_ziemi[2];
        przedmioty_na_ziemi[2].GetComponent<Renderer>().material.mainTexture = ekwipunek_przedmioty_na_ziemi[2].obrazek;
        ekwipunek_przedmioty_na_ziemi[3] = tablica_malego_terenu[licznik].rzeczy_na_ziemi[3];
        przedmioty_na_ziemi[3].GetComponent<Renderer>().material.mainTexture = ekwipunek_przedmioty_na_ziemi[3].obrazek;
    }
    void OnGUI () 
	{
		// Make a background box
		//GUI.Box(new Rect(10,10,100,90), "Loader Menu");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		//if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
		//	Application.LoadLevel(1);
		//}
		
		// Make the second button.
		//if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
		//	Application.LoadLevel(2);
		//}
		if (menu_wyboru_graczy == true) 
		{
			GUI.Label (new Rect (350, 250, 100, 50), "Imię gracza:");
			imie_gracza=GUI.TextField (new Rect (530, 250, 100, 30), imie_gracza);
			GUI.Label (new Rect (350, 300, 100, 50), "Imię pierwszego przeciwnika:");
			imie_gracza_1=GUI.TextField (new Rect (530, 300, 100, 30), imie_gracza_1);
			GUI.Label (new Rect (350, 350, 200, 50), "Imię drugiego przeciwnika:");
			imie_gracza_2=GUI.TextField (new Rect (530, 350, 100, 30), imie_gracza_2);
			GUI.Label (new Rect (350, 400, 200, 50), "Imię trzeciego przeciwnika:");
			imie_gracza_3=GUI.TextField (new Rect (530, 400, 100, 30), imie_gracza_3);

			if(GUI.Button(new Rect(460,450,80,20), "Potwierdz")) 
			{
				//tablica_graczy[1] = new gracz(Color.red,1,imie_gracza,0,1000,0);
				menu_wyboru_graczy=false;
				camera_.transform.position = new Vector3(50, 40, 50);
				Destroy(tlo);
				nowa_gra();
			}

		}

		if (kupowanie_jedzenia_ == true) 
		{
			GUI.Label (new Rect (25, 25, 200, 50), "Ilość jedzenia w spichlerzu:"+ilosc_dostepnego_jedzenia);
			GUI.Label (new Rect (230, 25, 200, 50), "Cena jedzenia 1 jednostka 1 zloto");
			GUI.Label (new Rect (25, 75, 200, 50), "Ilość jedzenia do kupienia:");
			ilosc_jedzenia_do_kupienia=GUI.TextField (new Rect (25, 125, 100, 30), ilosc_jedzenia_do_kupienia);
			if(GUI.Button(new Rect(180,75,80,20), "Maksimum")) {
                if (ilosc_dostepnego_jedzenia < tablica_graczy[1].pieniadze)
                {
                    ilosc_jedzenia_do_kupienia = ilosc_dostepnego_jedzenia.ToString();
                }
                else
                {
                    ilosc_jedzenia_do_kupienia = tablica_graczy[1].pieniadze.ToString();
                }
			}
			if(GUI.Button(new Rect(130,125,80,20), "Kup")) 
			{
                if (Int32.Parse(ilosc_jedzenia_do_kupienia) <= tablica_graczy[1].pieniadze)
                {
                    ilosc_dostepnego_jedzenia = ilosc_dostepnego_jedzenia - Int32.Parse(ilosc_jedzenia_do_kupienia);
                    tablica_graczy[1].pieniadze = tablica_graczy[1].pieniadze - Int32.Parse(ilosc_jedzenia_do_kupienia);
                    tablica_druzyn[aktualna_druzyna_index].zywnosc = tablica_druzyn[aktualna_druzyna_index].zywnosc + Int32.Parse(ilosc_jedzenia_do_kupienia);
                }
                else
                {
                    texthint.text = "Za malo zlota";
                    Debug.Log("Za malo pieniedzy");

                }
               
            }
			if(GUI.Button(new Rect(25,170,80,20), "Wyjdz")) 
			{
				kupowanie_jedzenia_=false;
				camera_.transform.position = new Vector3(160, 40, 160);
				Destroy(tlo);
			}
		}
        if (badam_cialo==true)
        {
            GUI.Label(new Rect(1000, 25, 200, 50), "Postać: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].imie);
            if (pokazuje_na_przedmiot == true)
            {
                GUI.Label(new Rect(130, 25, 200, 50), "Przedmiot:" + aktualny_przedmiot.wlasciwosc);
                GUI.Label(new Rect(130, 75, 200, 50), "Cena:" + aktualny_przedmiot.cena);
            }

            if (GUI.Button(new Rect(1200, 500, 80, 20), ">>"))
            {
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac < 9/*(tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1)*/)
                    {
                        aktualna_postac++;
                    }
                    else if (aktualna_postac == 9/*tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1*/)
                    {
                        aktualna_postac = 0;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 9)
                        {
                            aktualna_postac = 0;
                        }
                        else
                            aktualna_postac++;
                    }
                }
                /*
                if (aktualna_postac < (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1))
                {
                    aktualna_postac++;
                }
                else if (aktualna_postac == tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1)
                {
                    aktualna_postac = 0;
                }
                */
                rysuj_ekwipunek_postaci();
                gm_wczytaj_przedmioty_na_ziemi();

            }
            if (GUI.Button(new Rect(1100, 500, 80, 20), "<<"))
            {
                /*
                if ((aktualna_postac > 0))
                {
                    aktualna_postac--;
                }
                else if (aktualna_postac == 0)
                {
                    aktualna_postac = tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1;
                }
                */
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac > 0)
                    {
                        aktualna_postac--;
                    }
                    else if (aktualna_postac == 0)
                    {
                        aktualna_postac = 9;// tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 0)
                        {
                            aktualna_postac = 9;
                        }
                        else
                            aktualna_postac--;
                    }
                }
                rysuj_ekwipunek_postaci();
                gm_wczytaj_przedmioty_na_ziemi();
            }
            //GUI.Label (new Rect (230, 25, 200, 50), "Cena jedzenia 1 jednostka 1 zloto");
            //GUI.Label (new Rect (25, 75, 200, 50), "Ilość jedzenia do kupienia:");
            //ilosc_jedzenia_do_kupienia=GUI.TextField (new Rect (25, 125, 100, 30), ilosc_jedzenia_do_kupienia);
            //if(GUI.Button(new Rect(180,75,80,20), "Maksimum")) {
            //	ilosc_jedzenia_do_kupienia=ilosc_dostepnego_jedzenia.ToString();
            //}
            /*
			if(GUI.Button(new Rect(130,125,80,20), "Kup")) 
			{
				ilosc_dostepnego_jedzenia=ilosc_dostepnego_jedzenia-Int32.Parse(ilosc_jedzenia_do_kupienia);
			}
			*/
            if (GUI.Button(new Rect(25, 80, 80, 20), "Wyjdz"))
            {
                badam_cialo = false;
                inwentarz_narysowany = false;
                pokazuje_inwentarz = false;
                wyjdz();
                camera_.transform.position = new Vector3(160, 40, 160);
                Destroy(tlo);
                ukryj_ekwipunek_i_przedmioty_na_ziemi();
                aktualna_postac = 0;
                zaznaczona_druzyna=false;
            }



        }
        if (inwentarz_narysowany==true)
        {
            GUI.Label(new Rect(800, 25, 200, 50), "Postać: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].imie);
            int rasa = tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].rasa;
            string s_rasa=zwroc_rase(rasa);
            GUI.Label(new Rect(800, 55, 200, 50), "Rasa: " + s_rasa);
            GUI.Label(new Rect(800, 85, 200, 50), "HP: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_hp + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_hp);
            GUI.Label(new Rect(800, 115, 200, 50), "Mana: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_mana + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_mana);
            GUI.Label(new Rect(800, 145, 200, 50), "Sila: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].sila + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_sila + sprawdz_ekwipunek_postaci_sila(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 175, 200, 50), "Zrecznosc: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zrecznosc + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_zrecznosc + sprawdz_ekwipunek_postaci_zrecznosc(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 205, 200, 50), "Atak: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].atak + sprawdz_ekwipunek_postaci_atak(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 235, 200, 50), "Obrona: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].obrona + sprawdz_ekwipunek_postaci_obrona(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 265, 200, 50), "Exp: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].exp);
            GUI.Label(new Rect(800, 295, 200, 50), "Lvl: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].lvl);
         //   GUI.DrawTexture(new Rect(800, 300, 200, 50), Test_paska_zdrowia);
            //GUI.Label(new Rect(1200, 25, 200, 50), "Rasa: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].rasa.ToString);
            if (pokazuje_na_przedmiot == true)
            {
                GUI.Label(new Rect(130, 25, 200, 50), "Przedmiot:" + aktualny_przedmiot.wlasciwosc);
                GUI.Label(new Rect(130, 75, 200, 50), "Cena:" + aktualny_przedmiot.cena);
            }

            if (GUI.Button(new Rect(1200, 500, 80, 20), ">>"))
            {
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac < 9/*(tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1)*/)
                    {
                        aktualna_postac++;
                    }
                    else if (aktualna_postac == 9/*tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1*/)
                    {
                        aktualna_postac = 0;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 9)
                        {
                            aktualna_postac = 0;
                        }
                        else
                            aktualna_postac++;
                    }
                }
                rysuj_ekwipunek_postaci();
                gm_wczytaj_przedmioty_na_ziemi();
            }
            if (GUI.Button(new Rect(1100, 500, 80, 20), "<<"))
            {
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac > 0)
                    {
                        aktualna_postac--;
                    }
                    else if (aktualna_postac == 0)
                    {
                        aktualna_postac = 9;// tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 0)
                        {
                            aktualna_postac = 9;
                        }
                        else
                            aktualna_postac--;
                    }
                }
                rysuj_ekwipunek_postaci();
                gm_wczytaj_przedmioty_na_ziemi();
            }
            if (GUI.Button(new Rect(25, 80, 80, 20), "Wyjdz"))
            {
                inwentarz_narysowany = false;
                pokazuje_inwentarz = false;
                wyjdz();
                camera_.transform.position = new Vector3(160, 40, 160);
                Destroy(tlo);
                ukryj_ekwipunek_i_przedmioty_na_ziemi();
                aktualna_postac = 0;
                zaznaczona_druzyna = false;
            }

        }

        if (kupowanie_u_platnerza == true) 
		{
			GUI.Label (new Rect (25, 25, 200, 50), "Złoto:"+tablica_graczy[1].pieniadze);
			//GUI.Label (new Rect (130, 25, 200, 50), "Cena:");
			if (pokazuje_na_przedmiot==true)
			{
				GUI.Label (new Rect (130, 25, 200, 50), "Przedmiot:"+aktualny_przedmiot.wlasciwosc);
				GUI.Label (new Rect (130, 75, 200, 50), "Cena:"+aktualny_przedmiot.cena);
			}
			GUI.Label (new Rect (1000,25,200,50),"Postać: "+tablica_druzyn [aktualna_druzyna_index].tablica_postaci[aktualna_postac].imie);
            int rasa = tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].rasa;
            string s_rasa = zwroc_rase(rasa);
            GUI.Label(new Rect(800, 55, 200, 50), "Rasa: " + s_rasa);
            GUI.Label(new Rect(800, 85, 200, 50), "HP: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_hp + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_hp);
            GUI.Label(new Rect(800, 115, 200, 50), "Mana: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_mana + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_mana);
            GUI.Label(new Rect(800, 145, 200, 50), "Sila: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].sila + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_sila+ sprawdz_ekwipunek_postaci_sila(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 175, 200, 50), "Zrecznosc: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zrecznosc + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_zrecznosc+ sprawdz_ekwipunek_postaci_zrecznosc(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 205, 200, 50), "Atak: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].atak + sprawdz_ekwipunek_postaci_atak(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 235, 200, 50), "Obrona: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].obrona + sprawdz_ekwipunek_postaci_obrona(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 265, 200, 50), "Exp: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].exp);
            GUI.Label(new Rect(800, 295, 200, 50), "Lvl: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].lvl);
            if (GUI.Button(new Rect(1200,500,80,20), ">>")) 
			{
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac < 9/*(tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1)*/)
                    {
                        aktualna_postac++;
                    }
                    else if (aktualna_postac == 9/*tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1*/)
                    {
                        aktualna_postac = 0;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 9)
                        {
                            aktualna_postac = 0;
                        }
                        else
                            aktualna_postac++;
                    }
                }
             /*   if (aktualna_postac < (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1))
				{
					aktualna_postac++;
				}
				else if (aktualna_postac == tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1)
				{
					aktualna_postac=0;
				}
                */
				rysuj_ekwipunek_postaci();
			}
			if(GUI.Button(new Rect(1100,500,80,20), "<<")) 
			{
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac > 0)
                    {
                        aktualna_postac--;
                    }
                    else if (aktualna_postac == 0)
                    {
                        aktualna_postac = 9;// tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 0)
                        {
                            aktualna_postac = 9;
                        }
                        else
                            aktualna_postac--;
                    }
                }
                /*
				if ((aktualna_postac > 0))
				{
					aktualna_postac--;
				}
				else if (aktualna_postac == 0)
				{
					aktualna_postac=tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1;
				}
                */
                rysuj_ekwipunek_postaci();
			}
			//GUI.Label (new Rect (230, 25, 200, 50), "Cena jedzenia 1 jednostka 1 zloto");
			//GUI.Label (new Rect (25, 75, 200, 50), "Ilość jedzenia do kupienia:");
			//ilosc_jedzenia_do_kupienia=GUI.TextField (new Rect (25, 125, 100, 30), ilosc_jedzenia_do_kupienia);
			//if(GUI.Button(new Rect(180,75,80,20), "Maksimum")) {
			//	ilosc_jedzenia_do_kupienia=ilosc_dostepnego_jedzenia.ToString();
			//}
			/*
			if(GUI.Button(new Rect(130,125,80,20), "Kup")) 
			{
				ilosc_dostepnego_jedzenia=ilosc_dostepnego_jedzenia-Int32.Parse(ilosc_jedzenia_do_kupienia);
			}
			*/
			if(GUI.Button(new Rect(25,80,80,20), "Wyjdz")) 
			{
				kupowanie_u_platnerza=false;
				wyjdz();
				camera_.transform.position = new Vector3(160, 40, 160);
				Destroy(tlo);
				ukryj_ekwipunek_i_asortyment();
				aktualna_postac=0;
			}
		}
		if (kupowanie_w_bibliotece == true) 
		{
            //GUI.contentColor = Color.black;
            GUI.Label (new Rect (25, 25, 200, 50), "Złoto:"+tablica_graczy[1].pieniadze);
			//GUI.Label (new Rect (130, 25, 200, 50), "Cena:");
			if (pokazuje_na_przedmiot==true)
			{
				GUI.Label (new Rect (130, 25, 200, 50), "Przedmiot:"+aktualny_przedmiot.wlasciwosc);
				GUI.Label (new Rect (130, 75, 200, 50), "Cena:"+aktualny_przedmiot.cena);
			}
            GUI.contentColor = Color.blue;
            GUI.Label (new Rect (1000,25,200,50),"Postać: "+tablica_druzyn [aktualna_druzyna_index].tablica_postaci[aktualna_postac].imie);
            int rasa = tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].rasa;
            string s_rasa = zwroc_rase(rasa);
            GUI.Label(new Rect(800, 55, 200, 50), "Rasa: " + s_rasa);
            GUI.Label(new Rect(800, 85, 200, 50), "HP: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_hp + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_hp);
            GUI.Label(new Rect(800, 115, 200, 50), "Mana: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_mana + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_mana);
            GUI.Label(new Rect(800, 145, 200, 50), "Sila: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].sila + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_sila+sprawdz_ekwipunek_postaci_sila(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 175, 200, 50), "Zrecznosc: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zrecznosc + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_zrecznosc + sprawdz_ekwipunek_postaci_zrecznosc(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 205, 200, 50), "Atak: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].atak + sprawdz_ekwipunek_postaci_atak(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 235, 200, 50), "Obrona: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].obrona + sprawdz_ekwipunek_postaci_obrona(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 265, 200, 50), "Exp: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].exp);
            GUI.Label(new Rect(800, 295, 200, 50), "Lvl: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].lvl);
            //GUI.Label (new Rect (230, 25, 200, 50), "Cena jedzenia 1 jednostka 1 zloto");
            //GUI.Label (new Rect (25, 75, 200, 50), "Ilość jedzenia do kupienia:");
            //ilosc_jedzenia_do_kupienia=GUI.TextField (new Rect (25, 125, 100, 30), ilosc_jedzenia_do_kupienia);
            //if(GUI.Button(new Rect(180,75,80,20), "Maksimum")) {
            //	ilosc_jedzenia_do_kupienia=ilosc_dostepnego_jedzenia.ToString();
            //}
            /*
			if(GUI.Button(new Rect(130,125,80,20), "Kup")) 
			{
				ilosc_dostepnego_jedzenia=ilosc_dostepnego_jedzenia-Int32.Parse(ilosc_jedzenia_do_kupienia);
			}
			*/
            GUI.contentColor = Color.white;
            if (GUI.Button(new Rect(1200,500,80,20), ">>")) 
			{
                /*
				if (aktualna_postac < (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1))
				{
					aktualna_postac++;
				}
				else if (aktualna_postac == tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1)
				{
					aktualna_postac=0;
				}
                */
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac < 9/*(tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1)*/)
                    {
                        aktualna_postac++;
                    }
                    else if (aktualna_postac == 9/*tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1*/)
                    {
                        aktualna_postac = 0;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 9)
                        {
                            aktualna_postac = 0;
                        }
                        else
                            aktualna_postac++;
                    }
                }
                rysuj_ekwipunek_postaci();
			}
			if(GUI.Button(new Rect(1100,500,80,20), "<<")) 
			{
                /*
				if ((aktualna_postac > 0))
				{
					aktualna_postac--;
				}
				else if (aktualna_postac == 0)
				{
					aktualna_postac=tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1;
				}
                */
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac > 0)
                    {
                        aktualna_postac--;
                    }
                    else if (aktualna_postac == 0)
                    {
                        aktualna_postac = 9;// tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 0)
                        {
                            aktualna_postac = 9;
                        }
                        else
                            aktualna_postac--;
                    }
                }
                rysuj_ekwipunek_postaci();
			}
            
            if (GUI.Button(new Rect(25,80,80,20), "Wyjdz")) 
			{
				kupowanie_w_bibliotece=false;
				wyjdz();
				camera_.transform.position = new Vector3(160, 40, 160);
				Destroy(tlo);
				ukryj_ekwipunek_i_asortyment();
				aktualna_postac=0;
			}

		}
		if (kupowanie_u_alchemika == true) 
		{
			GUI.Label (new Rect (25, 25, 200, 50), "Złoto:"+tablica_graczy[1].pieniadze);
			//GUI.Label (new Rect (130, 25, 200, 50), "Cena:");
			if (pokazuje_na_przedmiot==true)
			{
				GUI.Label (new Rect (130, 25, 200, 50), "Przedmiot:"+aktualny_przedmiot.wlasciwosc);
				GUI.Label (new Rect (130, 75, 200, 50), "Cena:"+aktualny_przedmiot.cena);
			}
            GUI.contentColor = Color.black;
            GUI.Label (new Rect (1000,25,200,50),"Postać: "+tablica_druzyn [aktualna_druzyna_index].tablica_postaci[aktualna_postac].imie);
            int rasa = tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].rasa;
            string s_rasa = zwroc_rase(rasa);
            GUI.Label(new Rect(800, 55, 200, 50), "Rasa: " + s_rasa);
            GUI.Label(new Rect(800, 85, 200, 50), "HP: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_hp + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_hp);
            GUI.Label(new Rect(800, 115, 200, 50), "Mana: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_mana + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_mana);
            GUI.Label(new Rect(800, 145, 200, 50), "Sila: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].sila + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_sila+sprawdz_ekwipunek_postaci_sila(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 175, 200, 50), "Zrecznosc: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zrecznosc + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_zrecznosc + sprawdz_ekwipunek_postaci_zrecznosc(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 205, 200, 50), "Atak: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].atak + sprawdz_ekwipunek_postaci_atak(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 235, 200, 50), "Obrona: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].obrona + sprawdz_ekwipunek_postaci_obrona(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 265, 200, 50), "Exp: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].exp);
            GUI.Label(new Rect(800, 295, 200, 50), "Lvl: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].lvl);
            //GUI.Label (new Rect (230, 25, 200, 50), "Cena jedzenia 1 jednostka 1 zloto");
            //GUI.Label (new Rect (25, 75, 200, 50), "Ilość jedzenia do kupienia:");
            //ilosc_jedzenia_do_kupienia=GUI.TextField (new Rect (25, 125, 100, 30), ilosc_jedzenia_do_kupienia);
            //if(GUI.Button(new Rect(180,75,80,20), "Maksimum")) {
            //	ilosc_jedzenia_do_kupienia=ilosc_dostepnego_jedzenia.ToString();
            //}
            /*
			if(GUI.Button(new Rect(130,125,80,20), "Kup")) 
			{
				ilosc_dostepnego_jedzenia=ilosc_dostepnego_jedzenia-Int32.Parse(ilosc_jedzenia_do_kupienia);
			}
			*/
            GUI.contentColor = Color.white;
            if (GUI.Button(new Rect(1200,500,80,20), ">>")) 
			{
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac < 9/*(tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1)*/)
                    {
                        aktualna_postac++;
                    }
                    else if (aktualna_postac == 9/*tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1*/)
                    {
                        aktualna_postac = 0;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 9)
                        {
                            aktualna_postac = 0;
                        }
                        else
                            aktualna_postac++;
                    }
                }
                /*
                if (aktualna_postac < (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1))
				{
					aktualna_postac++;
				}
				else if (aktualna_postac == tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1)
				{
					aktualna_postac=0;
				}
                */
				rysuj_ekwipunek_postaci();
			}
			if(GUI.Button(new Rect(1100,500,80,20), "<<")) 
			{
                /*
				if ((aktualna_postac > 0))
				{
					aktualna_postac--;
				}
				else if (aktualna_postac == 0)
				{
					aktualna_postac=tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1;
				}
                */
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac > 0)
                    {
                        aktualna_postac--;
                    }
                    else if (aktualna_postac == 0)
                    {
                        aktualna_postac = 9;//tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 0)
                        {
                            aktualna_postac = 9;
                        }
                        else
                            aktualna_postac--;
                    }
                }
                rysuj_ekwipunek_postaci();
			}
			if(GUI.Button(new Rect(25,80,80,20), "Wyjdz")) 
			{
				kupowanie_u_alchemika=false;
				wyjdz();
				camera_.transform.position = new Vector3(160, 40, 160);
				Destroy(tlo);
				ukryj_ekwipunek_i_asortyment();
				aktualna_postac=0;
			}
		}
		if (kupowanie_u_mysliwego == true) 
		{
			GUI.Label (new Rect (25, 25, 200, 50), "Złoto:"+tablica_graczy[1].pieniadze);
			if (pokazuje_na_przedmiot==true)
			{
				GUI.Label (new Rect (130, 25, 200, 50), "Przedmiot:"+aktualny_przedmiot.wlasciwosc);
				GUI.Label (new Rect (130, 75, 200, 50), "Cena:"+aktualny_przedmiot.cena);
			}
				//GUI.Label (new Rect (230, 25, 200, 50), "Cena jedzenia 1 jednostka 1 zloto");
			//GUI.Label (new Rect (25, 75, 200, 50), "Ilość jedzenia do kupienia:");
			//ilosc_jedzenia_do_kupienia=GUI.TextField (new Rect (25, 125, 100, 30), ilosc_jedzenia_do_kupienia);
			//if(GUI.Button(new Rect(180,75,80,20), "Maksimum")) {
			//	ilosc_jedzenia_do_kupienia=ilosc_dostepnego_jedzenia.ToString();
			//}
			/*
			if(GUI.Button(new Rect(130,125,80,20), "Kup")) 
			{
				ilosc_dostepnego_jedzenia=ilosc_dostepnego_jedzenia-Int32.Parse(ilosc_jedzenia_do_kupienia);
			}
			*/
			GUI.Label (new Rect (1000,25,200,50),"Postać: "+tablica_druzyn [aktualna_druzyna_index].tablica_postaci[aktualna_postac].imie);
            int rasa = tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].rasa;
            string s_rasa = zwroc_rase(rasa);
            GUI.Label(new Rect(800, 55, 200, 50), "Rasa: " + s_rasa);
            GUI.Label(new Rect(800, 85, 200, 50), "HP: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_hp + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_hp);
            GUI.Label(new Rect(800, 115, 200, 50), "Mana: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].actual_mana + "/" + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].max_mana);
            GUI.Label(new Rect(800, 145, 200, 50), "Sila: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].sila + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_sila + sprawdz_ekwipunek_postaci_sila(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 175, 200, 50), "Zrecznosc: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zrecznosc + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].temp_zrecznosc + sprawdz_ekwipunek_postaci_zrecznosc(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 205, 200, 50), "Atak: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].atak + sprawdz_ekwipunek_postaci_atak(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 235, 200, 50), "Obrona: " + (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].obrona + sprawdz_ekwipunek_postaci_obrona(tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac])));
            GUI.Label(new Rect(800, 265, 200, 50), "Exp: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].exp);
            GUI.Label(new Rect(800, 295, 200, 50), "Lvl: " + tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].lvl);
            if (GUI.Button(new Rect(1200,500,80,20), ">>")) 
			{
				Debug.Log("aktualna_druzyna_index,zmiana postaci >>"+aktualna_druzyna_index);
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac < 9/*(tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1)*/)
                    {
                        aktualna_postac++;
                    }
                    else if (aktualna_postac == 9/*tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1*/)
                    {
                        aktualna_postac = 0;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 9)
                        {
                            aktualna_postac = 0;
                        }
                        else
                            aktualna_postac++;
                    }
                }
                /*
                if (aktualna_postac < (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1))
				{
					aktualna_postac++;
				}
				else if (aktualna_postac == tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1)
				{
					aktualna_postac=0;
				}
                */
				rysuj_ekwipunek_postaci();
			}
			if(GUI.Button(new Rect(1100,500,80,20), "<<")) 
			{
				Debug.Log("aktualna_druzyna_index,zmiana postaci <<"+aktualna_druzyna_index);
                /*
                if ((aktualna_postac > 0))
				{
					aktualna_postac--;
				}
				else if (aktualna_postac == 0)
				{
					aktualna_postac=tablica_druzyn[aktualna_druzyna_index].ilosc_postaci-1;
				}
                */
                if (tablica_druzyn[aktualna_druzyna_index].ilosc_postaci != 1)
                {
                    if (aktualna_postac > 0)
                    {
                        aktualna_postac--;
                    }
                    else if (aktualna_postac == 0)
                    {
                        aktualna_postac = 9;//tablica_druzyn[aktualna_druzyna_index].ilosc_postaci - 1;
                    }
                    while (tablica_druzyn[aktualna_druzyna_index].tablica_postaci[aktualna_postac].zywy == false)
                    {
                        if (aktualna_postac == 0)
                        {
                            aktualna_postac = 9;
                        }
                        else
                            aktualna_postac--;
                    }
                }
                rysuj_ekwipunek_postaci();
			}
			if(GUI.Button(new Rect(25,80,80,20), "Wyjdz")) 
			{
				kupowanie_u_mysliwego=false;
				wyjdz();
				camera_.transform.position = new Vector3(160, 40, 160);
				aktualna_postac=0;
				Destroy(tlo);
				ukryj_ekwipunek_i_asortyment();
			}
		}
		if (smierglodowa == true) 
		{
			GUI.Label (new Rect (230, 25, 200, 50), "Smierc glodowa");
			camera_.transform.position = new Vector3(200, 40, 200);
			tlo = Instantiate (cube_tlo, new Vector3 (200, 1.5F, 200), Quaternion.identity) as GameObject;
			tlo.GetComponent<Renderer> ().material.mainTexture=smiercTexture;
			tlo.transform.localScale += new Vector3(100, 0, 100);
		}
        if (smiercpokonani == true)
        {
            GUI.Label(new Rect(230, 25, 200, 50), "Zostales pokonany");
            camera_.transform.position = new Vector3(200, 40, 200);
            tlo = Instantiate(cube_tlo, new Vector3(200, 1.5F, 200), Quaternion.identity) as GameObject;
            tlo.GetComponent<Renderer>().material.mainTexture = smiercTexture;
            tlo.transform.localScale += new Vector3(100, 0, 100);
        }
        //Debug.Log (ilosc_jedzenia_do_kupienia);

    }
    public void kopiuj_postac(postac destination,postac source)
    {
        int licznik = 0;
        destination.imie = source.imie;
        destination.rasa = source.rasa;
        destination.actual_hp = source.actual_hp;
        destination.max_hp = source.max_hp;
        destination.sila = source.sila;
        destination.actual_mana = source.actual_mana;
        destination.max_mana = source.max_mana;
        destination.exp = source.exp;
        destination.lvl = source.lvl;
        destination.zrecznosc = source.zrecznosc;
        destination.atak = source.atak;
        destination.obrona = source.obrona;
        destination.zywy = source.zywy;
        destination.temp_obrona = source.temp_obrona;
        destination.temp_sila = source.temp_sila;
        destination.temp_zrecznosc = source.temp_zrecznosc;
        for (licznik = 0; licznik < 13; licznik++)
        {
            destination.tablica_ekwipunku[licznik] = source.tablica_ekwipunku[licznik];
        }
    }
    public void wyzeruj_postac(postac destination)
    {
        int licznik = 0;
        destination.imie = "";
        destination.rasa = -1;
        destination.actual_hp = -1;
        destination.max_hp = -1;
        destination.sila =-1;
        destination.actual_mana = -1;
        destination.max_mana = -1;
        destination.exp = -1;
        destination.lvl = -1;
        destination.zrecznosc = -1;
        destination.atak = -1;
        destination.obrona = -1;
        destination.temp_zrecznosc = -1;
        destination.temp_sila = -1;
        destination.temp_obrona = -1;
        for (licznik = 0; licznik < 13; licznik++)
        {
            destination.tablica_ekwipunku[licznik].numer = -1;
            destination.tablica_ekwipunku[licznik].rodzaj = -1;
            destination.tablica_ekwipunku[licznik].wlasciwosc = "brak";
            destination.tablica_ekwipunku[licznik].cena = -1;
            destination.tablica_ekwipunku[licznik].obrazek = emptyTexture;
            //destination.tablica_ekwipunku[licznik] = source.tablica_ekwipunku[licznik];
            //   public int numer;
            //   public int rodzaj;
            //   public string wlasciwosc;
            //    public int cena;
            //    public Texture2D obrazek;
            // new ekwipunek(-1, -1, "brak", -1, emptyTexture);
        }
    }
}




	
