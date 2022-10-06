using UnityEngine;
using System.Collections;

public class Cube_wrog : MonoBehaviour {

    // Use this for initialization
    private GeneratorMAPY gm;
    private GameObject pocisk1;
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();

    }
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        //if (gm.walka_w_trakcie
        /*
        if (gm.wrog_nr_1.actual_hp <= 0)
        {
            this.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
        }
        */
    //    if (Input.GetButtonDown("Fire2"))
    //    {
            //  if ((gm.aktualna_postac == moj_numer) && (gm.polowanie == true)) 23.05.2020
            //       {

            // pocisk1=Instantiate(pocisk, this.transform.position, this.transform.rotation) as GameObject;
            //03.05.2020 pocisk1= Instantiate(pocisk, new Vector3(this.transform.position.x-5, 2.5F, this.transform.position.z), Quaternion.identity) as GameObject;
              //  public GameObject pocisk;
         //       private GameObject pocisk1;
          //      gm.test1[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.x;
           //     gm.test2[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.z;
             //   pocisk1 = Instantiate(gm.postacie[gm.aktualna_postac].pocisk, new Vector3(gm.postacie[gm.aktualna_postac].transform.position.x, 4.5F, gm.postacie[gm.aktualna_postac].transform.position.z), Quaternion.identity) as GameObject;//2.5f
            //pocisk1.GetComponent<Transform>().rotation = new Quaternion(0f,0f,45.0f,0f);
            //pocisk od razu ma sile/predkosc i kierunek??
            //pocisk1.GetComponent<Renderer> ().sharedMaterial.color = Color.red;
            // pocisk1.GetComponent<Rigidbody>().velocity = new Vector2(-50.0f,0.0f); //new Vector2(4.0f * transform.right.x, 0);
            //m_CurrentMagazineAmount--;
            //       }

     //   }
    }
    void rysuj_ekwipunek_i_przedmioty_na_ziemi()
    {
        for (int i = 0; i < 4; i++)
        {
            gm.przedmioty_na_ziemi[i] = Instantiate(gm.cube_przedmiot_na_ziemi, new Vector3(155 + i * 5, 2.0F, 200), Quaternion.identity) as GameObject;
            gm.przedmioty_na_ziemi[i].GetComponent<Renderer>().material.color = Color.white;
            gm.przedmioty_na_ziemi[i].GetComponent<Renderer>().material.mainTexture = gm.emptyTexture;
            gm.przedmioty_na_ziemi[i].transform.localScale += new Vector3(3, 0, 3);
            gm.przedmioty_na_ziemi[i].tag = "przedmiot_na_ziemi";
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
    void wczytaj_przedmioty_na_ziemi()
    {
        /*
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
        */
        int licznik, x, z;
        x = (int)(gm.test1[gm.aktualna_postac] - 150);
        z = (int)(gm.test2[gm.aktualna_postac] - 150);
        licznik = x * 25 + z;
        Debug.Log("X=" + x);
        Debug.Log("Z=" + z);
        Debug.Log("Licznik=" + licznik);
        gm.ekwipunek_przedmioty_na_ziemi[0] = gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0];
        gm.przedmioty_na_ziemi[0].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[0].obrazek;
        gm.ekwipunek_przedmioty_na_ziemi[1] = gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1];
        gm.przedmioty_na_ziemi[1].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[1].obrazek;
        gm.ekwipunek_przedmioty_na_ziemi[2] = gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[2];
        gm.przedmioty_na_ziemi[2].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[2].obrazek;
        gm.ekwipunek_przedmioty_na_ziemi[3] = gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[3];
        gm.przedmioty_na_ziemi[3].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[3].obrazek;
    }
    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            //do stuff here
            Debug.Log("Klikam prawym na wrogu");
            if (gm.wybrana_postac == true)
            {
                if (this.GetComponent<Renderer>().material.mainTexture != gm.smiercTexture)
                {
                    gm.test6[gm.aktualna_postac] = true;
                    gm.test3[gm.aktualna_postac] = this.transform.position.x;
                    gm.test4[gm.aktualna_postac] = this.transform.position.z;
                  //  gm.test1[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.x;
                  //  gm.test2[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.z;
                  //  gm.walka_w_trakcie = true;
                }
            }
            return;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Dostalem collision");
        Debug.Log("Nazwa col"+col.gameObject.name);
        if (col.gameObject.name == "Capsule(Clone)")
        {
            int obrazenia;
            obrazenia = gm.wrog_nr_1.obrona / 4;
            gm.wrog_nr_1.actual_hp = gm.wrog_nr_1.actual_hp - obrazenia;
            Debug.Log("Dostalem obrazenia: "+obrazenia);

            if(gm.wrog_nr_1.actual_hp <= 0)
            {
                int licznik = 0;
                Debug.Log("Wrog zabity");
                gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                //test
                licznik = ((int)159 - 150) * 25 + ((int)159 - 150);
               // Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
               // Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                //Debug.Log("Licznik=" + licznik);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

               // gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[2] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
               gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[3] = new ekwipunek(7, 1, "Bagienny korzeń", 5000, gm.korzenTexture);
               //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            }
            //Destroy(gameObject);
        }
        if (col.gameObject.name == "wzmocnione")
        {
            int obrazenia;
            obrazenia = gm.wrog_nr_1.obrona / 3;
            gm.wrog_nr_1.actual_hp = gm.wrog_nr_1.actual_hp - obrazenia;
            Debug.Log("Dostalem obrazenia: " + obrazenia);

            if (gm.wrog_nr_1.actual_hp <= 0)
            {
                int licznik = 0;
                Debug.Log("Wrog zabity");
                gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                //test
                licznik = ((int)159 - 150) * 25 + ((int)159 - 150);
                // Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
                // Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                //Debug.Log("Licznik=" + licznik);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

                // gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[2] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[3] = new ekwipunek(7, 1, "Bagienny korzeń", 5000, gm.korzenTexture);
                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            }
            //Destroy(gameObject);
        }
        if (col.gameObject.name == "Sphere(Clone)")
        {
            int obrazenia;
            obrazenia = 50;//gm.wrog_nr_1.obrona / 4;
            gm.wrog_nr_1.actual_hp = gm.wrog_nr_1.actual_hp - obrazenia;
            Debug.Log("Dostalem obrazenia: " + obrazenia);

            if (gm.wrog_nr_1.actual_hp <= 0)
            {
                int licznik = 0;
                Debug.Log("Wrog zabity");
                gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                //test
                licznik = ((int)159 - 150) * 25 + ((int)159 - 150);
                // Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
                // Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                //Debug.Log("Licznik=" + licznik);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            }
            //Destroy(gameObject);
        }
        if (col.gameObject.name == "Pocisk_(Clone)")
        {
            int obrazenia;
            obrazenia = 25;//gm.wrog_nr_1.obrona / 4;
            gm.wrog_nr_1.actual_hp = gm.wrog_nr_1.actual_hp - obrazenia;
            Debug.Log("Dostalem obrazenia: " + obrazenia);

            if (gm.wrog_nr_1.actual_hp <= 0)
            {
                int licznik = 0;
                Debug.Log("Wrog zabity");
                gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                //test
                licznik = ((int)159 - 150) * 25 + ((int)159 - 150);
                // Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
                // Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                //Debug.Log("Licznik=" + licznik);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            }
            //Destroy(gameObject);
        }
        if (col.gameObject.name == "Blyskawica(Clone)")
        {
            int obrazenia;
            obrazenia = 50;//gm.wrog_nr_1.obrona / 4;
            gm.wrog_nr_1.actual_hp = gm.wrog_nr_1.actual_hp - obrazenia;
            Debug.Log("Dostalem obrazenia: " + obrazenia);

            if (gm.wrog_nr_1.actual_hp <= 0)
            {
                int licznik = 0;
                Debug.Log("Wrog zabity");
                gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                //test
                licznik = ((int)159 - 150) * 25 + ((int)159 - 150);
                // Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
                // Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                //Debug.Log("Licznik=" + licznik);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            }
            //Destroy(gameObject);
        }
        if (col.gameObject.name == "kamyk(Clone)")
        {
            int obrazenia;
            obrazenia = gm.wrog_nr_1.obrona / 6;
            gm.wrog_nr_1.actual_hp = gm.wrog_nr_1.actual_hp - obrazenia;
            Debug.Log("Dostalem obrazenia: " + obrazenia);

            if (gm.wrog_nr_1.actual_hp <= 0)
            {
                int licznik = 0;
                Debug.Log("Wrog zabity");
                gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                //test
                licznik = ((int)159 - 150) * 25 + ((int)159 - 150);
                // Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
                // Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                //Debug.Log("Licznik=" + licznik);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            }
            //Destroy(gameObject);
        }
        if (col.gameObject.name == "wzmocniony_kamyk")
        {
            int obrazenia;
            obrazenia = gm.wrog_nr_1.obrona / 5;
            gm.wrog_nr_1.actual_hp = gm.wrog_nr_1.actual_hp - obrazenia;
            Debug.Log("Dostalem obrazenia: " + obrazenia);

            if (gm.wrog_nr_1.actual_hp <= 0)
            {
                int licznik = 0;
                Debug.Log("Wrog zabity");
                gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                //test
                licznik = ((int)159 - 150) * 25 + ((int)159 - 150);
                // Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
                // Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                //Debug.Log("Licznik=" + licznik);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            }
            //Destroy(gameObject);
        }
        if (col.gameObject.name == "kamien(Clone)")
        {
            int obrazenia;
            obrazenia = 75;
            gm.wrog_nr_1.actual_hp = gm.wrog_nr_1.actual_hp - obrazenia;
            Debug.Log("Dostalem obrazenia: " + obrazenia);

            if (gm.wrog_nr_1.actual_hp <= 0)
            {
                int licznik = 0;
                Debug.Log("Wrog zabity");
                gm.wrog1.GetComponent<Renderer>().material.mainTexture = gm.smiercTexture;
                //test
                licznik = ((int)159 - 150) * 25 + ((int)159 - 150);
                // Debug.Log("X=" + ((int)gm.test3[b_p] - 150));
                // Debug.Log("Z=" + ((int)gm.test4[b_p] - 150));
                //Debug.Log("Licznik=" + licznik);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
                gm.tablica_malego_terenu[licznik].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);

                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[0] = new ekwipunek(5, 4, "Zwoj: Leczenie, +30 punktow zdrowia,koszt uzycia: 30 pkt many", 50, gm.zwojTexture);
                //gm.tablica_malego_terenu[0].rzeczy_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            }
            //Destroy(gameObject);
        }
    }
    void OnTriggerEnter()
    {
        Debug.Log("Dostalem trigger");
    }
    void OnMouseDown()
    {
   //     if (Input.GetMouseButtonDown(1))
   //     {
   //         Debug.Log("Klikam prawym na wrogu");
  //          return;
   //     }

        if (gm.wybrana_postac == true)
        {
            if (this.GetComponent<Renderer>().material.mainTexture == gm.smiercTexture)
            {
                gm.wybrane_pole[gm.aktualna_postac] = true;
                gm.wybrane_pole_x[gm.aktualna_postac] = this.transform.position.x;
                gm.wybrane_pole_z[gm.aktualna_postac] = this.transform.position.z;
                gm.test1[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.x; //dla kazdej postaci w druzynie
                gm.test2[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.z;
                Debug.Log("Wybrane pole docelowe dla postaci " + gm.aktualna_postac + "\n");

            }
            else
            {
                gm.test5[gm.aktualna_postac] = true;
                gm.test3[gm.aktualna_postac] = this.transform.position.x;
                gm.test4[gm.aktualna_postac] = this.transform.position.z;
                gm.test1[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.x;
                gm.test2[gm.aktualna_postac] = gm.postacie[gm.aktualna_postac].transform.position.z;
                gm.walka_w_trakcie = true;
            }
        }

    }
}
