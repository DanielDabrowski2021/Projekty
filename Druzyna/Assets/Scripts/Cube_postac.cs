using UnityEngine;
using UnityEngine.UI;//
using System.Collections;
using System;
public class Cube_postac : MonoBehaviour
{

    // Use this for initialization
    // Use this for initialization
    private GeneratorMAPY gm;
    //public GameObject pasek_zdrowia_;
    public GameObject pasek_zdrowia;
    public GameObject pocisk;
    public GameObject pocisk2;//fireball
    public GameObject pocisk3;//magiczny pocisk
    public GameObject blyskawica;
    public GameObject pocisk_proca;
    public GameObject pocisk_katapulta;
    private GameObject pocisk1;
    //private GameObject pocisk1_;
    public bool x_ok, z_ok;//,wybrany_wrog;
    public bool wrog_x_ok, wrog_z_ok;
    public bool walka_z_wrogiem;
    public bool zywy;
    public int moj_numer;
    Vector3 direction;
    Vector3 enemy_position;
    Vector3 pocisk_position;

    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();
        x_ok = false;
        z_ok = false;
        wrog_x_ok = false;
        wrog_z_ok = false;
        walka_z_wrogiem = false;
        pasek_zdrowia.SetActive(false);
        // moj_numer = -1;
    }
    void Usun_pasek_zdrowia()
    {
        if (pasek_zdrowia != null)
        {
            pasek_zdrowia.SetActive(false);
        }
    }
    void Start()
    {
        zywy = true;
    }
    // public void SetMyNumber(int number)
    // {
    //    moj_numer = number;
    // }
    void lvl_up(int numer_postaci)
    {
        switch (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].rasa)
        {
            case 0: /*Ogr*/
            case 1: /*Krasnolud*/
            case 8: /*Ork*/
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp +(int)(0.05f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp);
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl>1) && ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl % 5) == 1))
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].sila++;
                }
                break;
            case 2: /*Mag*/
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana + (int)(0.05f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana);
                break;
            case 3: /*Elf*/
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana + (int)(0.05f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana);
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp + (int)(0.05f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp);
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl > 1) && ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl % 5) == 1))
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].zrecznosc++;
                }
                break;
            case 4: /*Czlowiek*/
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana + (int)(0.02f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana);
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp + (int)(0.02f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp);
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl > 1) && ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl % 5) == 1))
                {
                    DateTime now = DateTime.Now;
                    UnityEngine.Random.seed = (now.Second + now.Minute + now.Millisecond);
                    int wylosowana_liczba;
                    wylosowana_liczba = UnityEngine.Random.Range(0, 2);
                    if (wylosowana_liczba == 0)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].zrecznosc++;
                    }
                    else
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].sila++;
                    }
                }
                break;
            case 5: /*Hobbit*/
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp + (int)(0.02f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp);
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl > 1) && ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl % 5) == 1))
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].zrecznosc++;
                }
                break;
            case 6: /*Kotolak*/
            case 7: /*Jaszczuroludz*/
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana + (int)(0.05f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_mana);
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp + (int)(0.02f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp);
                break;
            case 9: /*Amazonka*/
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp + (int)(0.02f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp);
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl > 1) && ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl % 5) == 1))
                {
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].zrecznosc++;
                }
                break;
            case 10:
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp + (int)(0.02f * gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].max_hp);
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl > 1) && ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].lvl % 5) == 1))
                {
                    DateTime now = DateTime.Now;
                    UnityEngine.Random.seed = (now.Second + now.Minute + now.Millisecond);
                    int wylosowana_liczba;
                    wylosowana_liczba = UnityEngine.Random.Range(0, 2);
                    if (wylosowana_liczba == 0)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].zrecznosc++;
                    }
                    else
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[numer_postaci].sila++;
                    }
                }
                break;
        }
    }
    bool czy_lvl_up(int lvl,int exp)
    {
        float prog = 1000;
        float przyrost=1000;
        for (int i=1;i<lvl;i++)
        {
            przyrost = przyrost + 0.1f * (przyrost);
            prog = prog + przyrost;
        }
        if (exp>=prog)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void dodaj_expa_druzynie(int exp)
    {
        int ilosc_postaci;
        int ilosc_expa_na_postac;

        ilosc_postaci = gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci;
        ilosc_expa_na_postac = exp / ilosc_postaci;
        for (int i = 0; i < 10; i++)
        {
            if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[i].zywy == true)
            {
                 gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[i].exp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[i].exp + ilosc_expa_na_postac;
                if (czy_lvl_up(gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[i].lvl, gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[i].exp))
                {
                    Debug.Log("Lvl up");
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[i].lvl++;
                    lvl_up(i);
                }
            }
        }
    }
    void idz_na_pole(int b_p)
    {
        int i, aktualna_postac_numer_pola, help;
        // Debug.Log("Pozycja aktualna x=" + gm.postac_gracza_positionx + "\n");
        // Debug.Log("Pozycja aktualna z=" + gm.postac_gracza_positionz + "\n");
        Debug.Log("Postac wybrana.Cel zaznaczony");
        Debug.Log("Postac biezaca" + b_p + "\n");
        //dla kazdej postaci w druzynie
        // for (i = 0; i < gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci; i++)
        // {
        if (gm.test1[b_p] < (gm.wybrane_pole_x[b_p]))
        {
            //aktualna_druzyna.transform.position.x=aktualna_druzyna.transform.position.x+1;
            this.transform.position = new Vector3(this.transform.position.x + 1, 2.5F, this.transform.position.z);
            gm.test1[b_p] = this.transform.position.x;
        }
        else if (gm.test1[b_p] > (gm.wybrane_pole_x[b_p]))
        {
            //aktualna_druzyna.transform.position.x=aktualna_druzyna.transform.position.x-1;
            this.transform.position = new Vector3(this.transform.position.x - 1, 2.5F, this.transform.position.z);
            gm.test1[b_p] = this.transform.position.x;
        }
        else
        {
            x_ok = true;
            //Debug.Log("x_ok"+x_ok);
        }
        if (gm.test2[b_p] < (gm.wybrane_pole_z[b_p]))
        {
            //aktualna_druzyna.transform.position.z=aktualna_druzyna.transform.position.z+1;
            this.transform.position = new Vector3(this.transform.position.x, 2.5F, this.transform.position.z + 1);
            gm.test2[b_p] = this.transform.position.z;
        }
        else if (gm.test2[b_p] > (gm.wybrane_pole_z[b_p]))
        {
            //aktualna_druzyna.transform.position.z=aktualna_druzyna.transform.position.z-1;
            this.transform.position = new Vector3(this.transform.position.x, 2.5F, this.transform.position.z - 1);
            gm.test2[b_p] = this.transform.position.z;
        }
        else
        {
            z_ok = true;
            //Debug.Log("z_ok+z_ok");
        }
        //}
    }
    void idz_do_wroga(int b_p)
    {
        int i, aktualna_postac_numer_pola, help;
        Debug.Log("Pozycja aktualna x=" + gm.test1 + "\n");
        Debug.Log("Pozycja aktualna z=" + gm.test2 + "\n");
        Debug.Log("Postac wybrana.Cel zaznaczony");
        //dla kazdej postaci w druzynie

        if (gm.test1[b_p] < (gm.test3[b_p] + 1))
        {
            //aktualna_druzyna.transform.position.x=aktualna_druzyna.transform.position.x+1;
            this.transform.position = new Vector3(this.transform.position.x + 1, 2.5F, this.transform.position.z);
            gm.test1[b_p] = this.transform.position.x;
        }
        else if (gm.test1[b_p] > (gm.test3[b_p] + 1))
        {
            //aktualna_druzyna.transform.position.x=aktualna_druzyna.transform.position.x-1;
            this.transform.position = new Vector3(this.transform.position.x - 1, 2.5F, this.transform.position.z);
            gm.test1[b_p] = this.transform.position.x;
        }
        else
        {
            wrog_x_ok = true;
            //Debug.Log("x_ok"+x_ok);
        }
        if (gm.test2[b_p] < (gm.test4[b_p] + 1))
        {
            //aktualna_druzyna.transform.position.z=aktualna_druzyna.transform.position.z+1;
            this.transform.position = new Vector3(this.transform.position.x, 2.5F, this.transform.position.z + 1);
            gm.test2[b_p] = this.transform.position.z;
        }
        else if (gm.test2[b_p] > (gm.test4[b_p] + 1))
        {
            //aktualna_druzyna.transform.position.z=aktualna_druzyna.transform.position.z-1;
            this.transform.position = new Vector3(this.transform.position.x, 2.5F, this.transform.position.z - 1);
            gm.test2[b_p] = this.transform.position.z;
        }
        else
        {
            wrog_z_ok = true;
            //Debug.Log("z_ok+z_ok");
        }

    }
    // Update is called once per frame
    void Update()
    {
        if ((zywy == true) && (moj_numer!=-1))
        {
         //   if (Input.GetButtonDown("Fire2")) 23.05.2020
        //    {
                // if (moj_numer == 0) 
                if ((gm.aktualna_postac == moj_numer) && (gm.polowanie == true) && (gm.test6[gm.aktualna_postac] == true))
                {
                //jeden strzal
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == 2) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 9)
                    && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 10) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj > 100))
                    {
                    //sprawdzenie czy prawa reka ma luk a lewa ma strzaly
                    //yield return new WaitForSeconds(0.35f);
                        pocisk1 = Instantiate(pocisk, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                     //   pocisk1_ = Instantiate(pocisk2, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                        pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                        enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                        pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                        direction = enemy_position - pocisk_position;
                        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                        pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                        pocisk1.GetComponent<Rigidbody>().velocity = direction;
                        pocisk1.GetComponent<Pocisk_strzelanie>().pauza = gm.pause;
                        pocisk1.GetComponent<Pocisk_strzelanie>().direction = direction;
                        gm.test6[gm.aktualna_postac] = false;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj--;
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc="Strzaly "+ (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj-100) + " sztuk";
                        Debug.Log("Strzal.Zostalo " + gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj + "strzal");
                        if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].rasa==3) || (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].rasa==9))
                        {
                        //ulubiona bron, wzmocnione strzaly
                            pocisk1.name = "wzmocnione";
                        }
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == 2) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 9)
               && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 10) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj > 100))
                {
                    //sprawdzenie czy prawa reka ma luk a lewa ma strzaly
                    pocisk1 = Instantiate(pocisk, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                   // pocisk1_ = Instantiate(pocisk2, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                    enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                    pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                    direction = enemy_position - pocisk_position;
                    float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                    pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                    pocisk1.GetComponent<Rigidbody>().velocity = direction;
                    pocisk1.GetComponent<Pocisk_strzelanie>().pauza = gm.pause;
                    pocisk1.GetComponent<Pocisk_strzelanie>().direction = direction;
                    gm.test6[gm.aktualna_postac] = false;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj--;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj - 100) + " sztuk";
                    Debug.Log("Strzal.Zostalo "+ gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj+ "strzal");
                    if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].rasa == 3) || (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].rasa == 9))
                    {
                        //ulubiona bron, wzmocnione strzaly
                        pocisk1.name = "wzmocnione";
                    }
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == 2) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 11)
                    && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 12) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj > 100))
                {
                    //sprawdzenie czy prawa reka ma luk a lewa ma strzaly
                    //yield return new WaitForSeconds(0.35f);
                    pocisk1 = Instantiate(pocisk_proca, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    //   pocisk1_ = Instantiate(pocisk2, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                    enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                    pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                    direction = enemy_position - pocisk_position;
                    float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                    pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                    pocisk1.GetComponent<Rigidbody>().velocity = direction;
                    pocisk1.GetComponent<Pocisk_strzelanie_proca>().pauza = gm.pause;
                    pocisk1.GetComponent<Pocisk_strzelanie_proca>().direction = direction;
                    gm.test6[gm.aktualna_postac] = false;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj--;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj - 100) + " sztuk";
                    Debug.Log("Pocisk.Zostalo " + gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj + "strzal");
                    if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].rasa == 5)
                    {
                        //ulubiona bron, wzmocnione strzaly
                        pocisk1.name = "wzmocniony_kamyk";
                    }
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == 2) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 11)
               && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 12) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj > 100))
                {
                    //sprawdzenie czy prawa reka ma luk a lewa ma strzaly
                    pocisk1 = Instantiate(pocisk_proca, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    // pocisk1_ = Instantiate(pocisk2, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                    enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                    pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                    direction = enemy_position - pocisk_position;
                    float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                    pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                    pocisk1.GetComponent<Rigidbody>().velocity = direction;
                    pocisk1.GetComponent<Pocisk_strzelanie_proca>().pauza = gm.pause;
                    pocisk1.GetComponent<Pocisk_strzelanie_proca>().direction = direction;
                    gm.test6[gm.aktualna_postac] = false;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj--;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj - 100) + " sztuk";
                    Debug.Log("Pocisk.Zostalo " + gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj + "strzal");
                    if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].rasa == 5)
                    {
                        //ulubiona bron, wzmocnione strzaly
                        pocisk1.name = "wzmocniony_kamyk";
                    }
                }
                //katapulta i kamien
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == 2) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 13)
                   && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == 2) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer ==14))
                {
                    //sprawdzenie czy prawa reka ma luk a lewa ma strzaly
                    //yield return new WaitForSeconds(0.35f);
                    pocisk1 = Instantiate(pocisk_katapulta, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    //   pocisk1_ = Instantiate(pocisk2, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                    enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                    pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                    direction = enemy_position - pocisk_position;
                    float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                    pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                    pocisk1.GetComponent<Rigidbody>().velocity = direction;
                    pocisk1.GetComponent<Pocisk_strzelanie_katapulta>().pauza = gm.pause;
                    pocisk1.GetComponent<Pocisk_strzelanie_katapulta>().direction = direction;
                    gm.test6[gm.aktualna_postac] = false;
                    //zniszczyc kamien u postaci
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].obrazek = gm.lewarekaTexture;
                    //gm.ekwipunek_postaci_box[12].GetComponent<Renderer>().material.mainTexture = gm.lewarekaTexture;
                    //gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12]= new ekwipunek(-1, -1, "", -1, gm.emptyTexture);
                    //gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj - 100) + " sztuk";
                    Debug.Log("Katapulta wystrzelila");
                    
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == 2) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 13)
               && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == 2) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer ==14))
                {
                    //sprawdzenie czy prawa reka ma luk a lewa ma strzaly
                    pocisk1 = Instantiate(pocisk_katapulta, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    // pocisk1_ = Instantiate(pocisk2, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                    pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                    enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                    pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                    direction = enemy_position - pocisk_position;
                    float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                    pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                    pocisk1.GetComponent<Rigidbody>().velocity = direction;
                    pocisk1.GetComponent<Pocisk_strzelanie_katapulta>().pauza = gm.pause;
                    pocisk1.GetComponent<Pocisk_strzelanie_katapulta>().direction = direction;
                    gm.test6[gm.aktualna_postac] = false;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer = -1;
                    gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].obrazek = gm.prawarekaTexture;
                    //gm.ekwipunek_postaci_box[11].GetComponent<Renderer>().material.mainTexture = gm.prawarekaTexture;
                    //gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11]= new ekwipunek(-1, -1, "", -1, gm.emptyTexture);
                    //gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj - 100) + " sztuk";
                    Debug.Log("Katapulta wystrzelila");
                    //zniszczyc kamien u postaci
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == 4) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 6)
                    && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == -1) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == -1))
                {
                    //sprawdzenie czy prawa reka pusta, lewa zwoj
                    if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana >= 50)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana - 50;
                        pocisk1 = Instantiate(pocisk2, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                        pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                        enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                        pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                        direction = enemy_position - pocisk_position;
                        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                        pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                        pocisk1.GetComponent<Rigidbody>().velocity = direction;
                        pocisk1.GetComponent<Pocisk_strzelanie2>().pauza = gm.pause;
                        pocisk1.GetComponent<Pocisk_strzelanie2>().direction = direction;
                        gm.test6[gm.aktualna_postac] = false;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj--;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj - 100) + " sztuk";
                        Debug.Log("Strzal.Fireball");
                    }
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == -1) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == -1)
                    && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 6) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == 4))
                {
                    //sprawdzenie czy lewa reka pusta, prawa zwoj
                    if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana >= 50)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana - 50;
                        pocisk1 = Instantiate(pocisk2, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                        pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                        enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                        pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                        direction = enemy_position - pocisk_position;
                        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                        pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                        pocisk1.GetComponent<Rigidbody>().velocity = direction;
                        pocisk1.GetComponent<Pocisk_strzelanie2>().pauza = gm.pause;
                        pocisk1.GetComponent<Pocisk_strzelanie2>().direction = direction;
                        gm.test6[gm.aktualna_postac] = false;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj--;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj - 100) + " sztuk";
                        Debug.Log("Strzal.Fireball");
                    }
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == 4) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 7)
                    && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == -1) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == -1))
                {
                    //sprawdzenie czy prawa reka pusta, lewa zwoj
                    if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana >= 25)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana - 25;
                        pocisk1 = Instantiate(pocisk3, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                        pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                        enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                        pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                        direction = enemy_position - pocisk_position;
                        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                        pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                        pocisk1.GetComponent<Rigidbody>().velocity = direction;
                        pocisk1.GetComponent<Pocisk_strzelanie3>().pauza = gm.pause;
                        pocisk1.GetComponent<Pocisk_strzelanie3>().direction = direction;
                        gm.test6[gm.aktualna_postac] = false;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj--;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj - 100) + " sztuk";
                        Debug.Log("Strzal.Magiczny pocisk");
                    }
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == -1) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == -1)
                    && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 7) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == 4))
                {
                    //sprawdzenie czy lewa reka pusta, prawa zwoj
                    if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana >= 25)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana - 25;
                        pocisk1 = Instantiate(pocisk3, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;
                        pocisk1.transform.Rotate(0.0f, 0.0f, 90.0f);
                        enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                        pocisk_position = new Vector3(this.transform.position.x, 4.5F, this.transform.position.z);
                        direction = enemy_position - pocisk_position;
                        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                        pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                        pocisk1.GetComponent<Rigidbody>().velocity = direction;
                        pocisk1.GetComponent<Pocisk_strzelanie3>().pauza = gm.pause;
                        pocisk1.GetComponent<Pocisk_strzelanie3>().direction = direction;
                        gm.test6[gm.aktualna_postac] = false;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj--;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj - 100) + " sztuk";
                        Debug.Log("Strzal.Magiczny pocisk");
                    }
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == 4) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 8)
                    && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == -1) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == -1))
                {
                    //sprawdzenie czy prawa reka pusta, lewa zwoj
                    if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana >= 50)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana - 50;
                        pocisk1 = Instantiate(blyskawica, new Vector3(gm.test3[gm.aktualna_postac], 10.0f, gm.test4[gm.aktualna_postac]), Quaternion.identity) as GameObject;
                        pocisk1.transform.Rotate(90.0f, 90.0f, 0.0f);
                        enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                        pocisk_position = new Vector3(gm.test3[gm.aktualna_postac], 10.0f, gm.test4[gm.aktualna_postac]);
                        direction = enemy_position - pocisk_position;
                        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                        pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                        pocisk1.GetComponent<Rigidbody>().velocity = direction;
                        pocisk1.GetComponent<Pocisk_strzelanie4>().pauza = gm.pause;
                        pocisk1.GetComponent<Pocisk_strzelanie4>().direction = direction;
                        gm.test6[gm.aktualna_postac] = false;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj--;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj - 100) + " sztuk";
                        Debug.Log("Strzal.Blyskawica");
                    }
                }
                if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == -1) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == -1)
                    && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 8) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == 4))
                {
                    //sprawdzenie czy lewa reka pusta, prawa zwoj
                    if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana >= 50)
                    {
                        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana - 50;
                        pocisk1 = Instantiate(blyskawica, new Vector3(gm.test3[gm.aktualna_postac], 10.0f, gm.test4[gm.aktualna_postac]), Quaternion.identity) as GameObject;
                        pocisk1.transform.Rotate(90.0f, 0.0f, 0.0f);//90f trzeci parametr
                        enemy_position = new Vector3(gm.test3[gm.aktualna_postac], 2.5f, gm.test4[gm.aktualna_postac]);
                        pocisk_position = new Vector3(gm.test3[gm.aktualna_postac], 10.0f, gm.test4[gm.aktualna_postac]);
                        direction = enemy_position - pocisk_position;
                        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;
                        pocisk1.transform.Rotate(angle, 0.0f, 0.0f);
                        pocisk1.GetComponent<Rigidbody>().velocity = direction;
                        pocisk1.GetComponent<Pocisk_strzelanie4>().pauza = gm.pause;
                        pocisk1.GetComponent<Pocisk_strzelanie4>().direction = direction;
                        gm.test6[gm.aktualna_postac] = false;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj--;
                        // gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].wlasciwosc = "Strzaly " + (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj - 100) + " sztuk";
                        Debug.Log("Strzal.Blyskawica");
                    }
                }
            }
                
                // 23.05.2020
         //       {
                    
                    // pocisk1=Instantiate(pocisk, this.transform.position, this.transform.rotation) as GameObject;
                    //03.05.2020 pocisk1= Instantiate(pocisk, new Vector3(this.transform.position.x-5, 2.5F, this.transform.position.z), Quaternion.identity) as GameObject;
         //           pocisk1 = Instantiate(pocisk, new Vector3(this.transform.position.x, 4.5F, this.transform.position.z), Quaternion.identity) as GameObject;//2.5f
                    //pocisk1.GetComponent<Transform>().rotation = new Quaternion(0f,0f,45.0f,0f);
                    //pocisk od razu ma sile/predkosc i kierunek??
                    //pocisk1.GetComponent<Renderer> ().sharedMaterial.color = Color.red;
                    // pocisk1.GetComponent<Rigidbody>().velocity = new Vector2(-50.0f,0.0f); //new Vector2(4.0f * transform.right.x, 0);
                    //m_CurrentMagazineAmount--;
         //       }
         //   }

            if ((gm.aktualna_postac == moj_numer) && (gm.polowanie == true))
            {
                float wypelnienie;
                pasek_zdrowia.SetActive(true);
                wypelnienie = ((float)gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp) / ((float)gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp);
                pasek_zdrowia.GetComponent<Image>().fillAmount = wypelnienie;//0.5f;
            }
            if ((gm.inwentarz_narysowany == false) && (gm.pause == false))
            {
                float x, z;
                int i, b_p;
                b_p = moj_numer;
                //  Debug.Log("ilosc_postaci=" + gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci + "\n");
                //       for (i = 0; i < gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci; i++)
                //       {
                //  Debug.Log("i=" + i + "\n");
                //           if ((gm.test1[i] == this.transform.position.x) && (gm.test2[i] == this.transform.position.z))
                //          {
                //               b_p = i;
                //               break;
                //           }

                //        }
                if (gm.wybrane_pole[b_p] == true)
                {
                    idz_na_pole(b_p);
                }
                if ((x_ok == true) && (z_ok == true))
                {
                    gm.wybrane_pole[b_p] = false;
                    x_ok = false;
                    z_ok = false;
                }
            }
            if ((gm.inwentarz_narysowany == false) && (gm.walka_w_trakcie == true) && (this.tag == "Postac_gracza") && (gm.pause == false))
            {
                //idz_do_wroga();
                float x, z;
                int i, b_p, j;
                b_p = 0;
                bool koniec_walki = false;
                b_p = moj_numer;
                //  Debug.Log("ilosc_postaci=" + gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci + "\n");
                //    for (i = 0; i < gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci; i++)
                //       {
                //     Debug.Log("i=" + i + "\n");
                //         if ((gm.test1[i] == this.transform.position.x) && (gm.test2[i] == this.transform.position.z))
                //        {
                //             b_p = i;
                //             break;
                //          }

                //      }
                if (gm.test5[b_p] == true)
                {
                    idz_do_wroga(b_p);
                }
                if ((wrog_x_ok == true) && (wrog_z_ok == true))
                {
                    gm.test5[b_p] = false;
                    wrog_x_ok = false;
                    wrog_z_ok = false;
                    walka_z_wrogiem = true;
                    if (gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete == 1)
                    {
                        gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete = 2;//postac gracza
                        gm.wrog_nr_1.sasiednie_pola[0] = 1;//postac gracza walczy z wrogiem
                    }
                    else if (gm.tablica_malego_terenu[(((int)this.transform.position.x - 1 - 150) * 25) + ((int)this.transform.position.z - 150)].zajete == 1)
                    {
                        this.transform.position = new Vector3(this.transform.position.x - 1, 2.5F, this.transform.position.z);
                        gm.test1[b_p] = this.transform.position.x;
                        gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete = 2;//postac gracza
                        gm.wrog_nr_1.sasiednie_pola[1] = 1;//postac gracza walczy z wrogiem
                    }
                    else if (gm.tablica_malego_terenu[(((int)this.transform.position.x - 2 - 150) * 25) + ((int)this.transform.position.z - 150)].zajete == 1)
                    {
                        this.transform.position = new Vector3(this.transform.position.x - 2, 2.5F, this.transform.position.z);
                        gm.test1[b_p] = this.transform.position.x;
                        gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete = 2;//postac gracza
                        gm.wrog_nr_1.sasiednie_pola[2] = 1;//postac gracza walczy z wrogiem
                    }
                    else if (gm.tablica_malego_terenu[(((int)this.transform.position.x - 2 - 150) * 25) + ((int)this.transform.position.z - 1 - 150)].zajete == 1)
                    {
                        this.transform.position = new Vector3(this.transform.position.x - 2, 2.5F, this.transform.position.z - 1);
                        gm.test1[b_p] = this.transform.position.x;
                        gm.test2[b_p] = this.transform.position.z;
                        gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete = 2;//postac gracza
                        gm.wrog_nr_1.sasiednie_pola[3] = 1;//postac gracza walczy z wrogiem
                    }
                    else if (gm.tablica_malego_terenu[(((int)this.transform.position.x - 2 - 150) * 25) + ((int)this.transform.position.z - 2 - 150)].zajete == 1)
                    {
                        this.transform.position = new Vector3(this.transform.position.x - 2, 2.5F, this.transform.position.z - 2);
                        gm.test1[b_p] = this.transform.position.x;
                        gm.test2[b_p] = this.transform.position.z;
                        gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete = 2;//postac gracza
                        gm.wrog_nr_1.sasiednie_pola[4] = 1;//postac gracza walczy z wrogiem
                    }
                    else if (gm.tablica_malego_terenu[(((int)this.transform.position.x - 1 - 150) * 25) + ((int)this.transform.position.z - 2 - 150)].zajete == 1)
                    {
                        this.transform.position = new Vector3(this.transform.position.x - 1, 2.5F, this.transform.position.z - 2);
                        gm.test1[b_p] = this.transform.position.x;
                        gm.test2[b_p] = this.transform.position.z;
                        gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete = 2;//postac gracza
                        gm.wrog_nr_1.sasiednie_pola[5] = 1;//postac gracza walczy z wrogiem
                    }
                    else if (gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 2 - 150)].zajete == 1)
                    {
                        this.transform.position = new Vector3(this.transform.position.x, 2.5F, this.transform.position.z - 2);
                        gm.test2[b_p] = this.transform.position.z;
                        gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete = 2;//postac gracza
                        gm.wrog_nr_1.sasiednie_pola[6] = 1;//postac gracza walczy z wrogiem
                    }
                    else if (gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 1 - 150)].zajete == 1)
                    {
                        this.transform.position = new Vector3(this.transform.position.x, 2.5F, this.transform.position.z - 1);
                        gm.test2[b_p] = this.transform.position.z;
                        gm.tablica_malego_terenu[(((int)this.transform.position.x - 150) * 25) + ((int)this.transform.position.z - 150)].zajete = 2;//postac gracza
                        gm.wrog_nr_1.sasiednie_pola[7] = 1;//postac gracza walczy z wrogiem
                    }
                }
                if (walka_z_wrogiem == true)
                {
                    koniec_walki = gm.walcz(gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[b_p], gm.wrog_nr_1);
                    if (koniec_walki == true)
                    {
                        walka_z_wrogiem = false;
                        if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[b_p].actual_hp <= 0)
                        {
                            Debug.Log("Postac zabita");
                            Usun_pasek_zdrowia();
                            gm.postacie[b_p].GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                            if (b_p != gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci - 1)
                            {
                                //  for (j = b_p; j < gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci - 1; j++)
                                //  {
                                //kopiuj dane[b_p]=dane[b_p+1];
                                //      gm.kopiuj_postac(gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[j], gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[j + 1]);
                                //      gm.test1[j] = gm.test1[j+1];
                                //      gm.test2[j] = gm.test1[j+1];
                                // gm.postacie[j].GetComponent<Cube_postac>().moj_numer = j+1;
                                // gm.postacie[j+1].GetComponent<Cube_postac>().moj_numer = j;// gm.postacie[j+1].GetComponent<Cube_postac>().moj_numer;
                                //  }
                                //  gm.wyzeruj_postac(gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci - 1]);
                                // gm.wyzeruj_postac(gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.tablica_druzyn[gm.aktualna_druzyna_index].b_p);
                                gm.wyzeruj_postac(gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[b_p]);
                                gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci--;
                                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[b_p].zywy = false;
                            }
                            else
                            {
                                gm.wyzeruj_postac(gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci - 1]);
                                gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci--;
                                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[b_p].zywy = false;
                            }
                            //gm.postacie[b_p].GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                            zywy = false;
                            moj_numer = -1;
                            if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci == 0) && (gm.tablica_graczy[1].liczba_druzyn == 1))
                            {
                                //kopiowanie druzyn?
                                //koniec gry
                                gm.smiercpokonani = true;
                                Debug.Log("Koniec gry");
                                Usun_pasek_zdrowia();
                                return;
                            }
                            else
                            {
                                gm.aktualna_postac = 0;// gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci - 1;
                                while (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].zywy == false)
                                {
                                    if (gm.aktualna_postac == 9)
                                    {
                                        gm.aktualna_postac = 0;
                                    }
                                    else
                                        gm.aktualna_postac++;
                                }
                            }
                        }
                        if ((gm.wrog_nr_1.actual_hp <= 0) && (gm.wrog_nr_1.exp_dodany==0))
                        {
                            int licznik = 0;
                            Debug.Log("Wrog zabity");
                            gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                            //test
                            licznik = ((int)gm.test3[b_p]-150) * 25 + ((int)gm.test4[b_p]-150);
                            Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
                            Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                            Debug.Log("Licznik="+ licznik);
                            gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                            gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

                            gm.tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
                            dodaj_expa_druzynie(gm.wrog_nr_1.exp);
                            gm.wrog_nr_1.exp_dodany = 1;
                            //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
                        }
                    }
                }
            }
        }
    }
    void OnMouseDown()
    {
        if (zywy == true)
        {
            float x, z, wypelnienie;
            int i;
            gm.aktualna_postac = moj_numer; ;
            Debug.Log("ilosc_postaci=" + gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci + "\n");
            //    for (i = 0; i < gm.tablica_druzyn[gm.aktualna_druzyna_index].ilosc_postaci; i++)
            //    {
            //        Debug.Log("i=" + i + "\n");
            //        if ((gm.test1[i] == this.transform.position.x) && (gm.test2[i] == this.transform.position.z))
            //        {
            //           gm.aktualna_postac = i;
            //          break;
            //        }

            //   }

            Debug.Log("wybrana_postac=" + gm.aktualna_postac + "\n");
            gm.wybrana_postac = true;
            wypelnienie = ((float)gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp) / ((float)gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].max_hp);
            pasek_zdrowia.SetActive(true);
            pasek_zdrowia.GetComponent<Image>().fillAmount = wypelnienie;//0.5f;
                                                                         //postacie[i].GetComponent<Cube_postac>().moj_numer = i;
                                                                         //   pasek_zdrowia_ = Instantiate(pasek_zdrowia, new Vector3(200, 2.5F, 200), Quaternion.identity) as GameObject;
                                                                         //  GUI.DrawTexture(new Rect(10, 10, 60, 60), pasek_zdrowia, ScaleMode.ScaleToFit, true, 10.0F);
        }
    }
    void lecz(int ilosc_hp)
    {
            if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[moj_numer].actual_hp + ilosc_hp < gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[moj_numer].max_hp)
            {
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[moj_numer].actual_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[moj_numer].actual_hp + ilosc_hp;
            }
            else
            {
                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[moj_numer].actual_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[moj_numer].max_hp;
            }
            return;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
           // if (gm.aktualna_postac != moj_numer)
           // {
                //do stuff here
                Debug.Log("Klikam prawym na przyjacielu");
                if (gm.wybrana_postac == true)
                {
                    if (this.GetComponent<Renderer>().material.mainTexture != gm.smiercTexture)
                    {
                        //  gm.test6[gm.aktualna_postac] = true;
                        //  gm.test3[gm.aktualna_postac] = this.transform.position.x;
                        //  gm.test4[gm.aktualna_postac] = this.transform.position.z;
                        //  gm.test1[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.x;
                        //  gm.test2[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.z;
                        //  gm.walka_w_trakcie = true;
                        if ((gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].rodzaj == 4) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[11].numer == 5)
                          || (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].rodzaj == 4) && (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[12].numer == 5))
                        {
                            //sprawdzenie czy prawa reka ma luk a lewa ma strzaly
                          // czy wystarczajaca ilosc many?
                          if (gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana>=30)
                          {
                                gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_mana - 30;
                                //  gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[moj_numer].actual_hp
                                lecz(30);
                                Debug.Log("Wyleczyli mnie");
                            }
                            Debug.Log("Chcialem mnie wyleczyc");
                        }
                        Debug.Log("Klikam prawym na zywym przyjacielu");
                    }
                }
          //  }
            return;
        }
    }
    void OnDestroy()
    {
        Debug.Log("niszcze postac=" + gm.aktualna_postac + "\n");
        Usun_pasek_zdrowia();
    }
}
   