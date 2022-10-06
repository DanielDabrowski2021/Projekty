using UnityEngine;
using System.Collections;
using System;
public class NewCubeScript : MonoBehaviour {

	// Use this for initialization
	private GeneratorMAPY gm;
    //public Static string string1;
    //string1 =  "asortyment_sklepu" ;
    public bool x_ok, z_ok;//,wybrany_wrog;
    public bool wrog_x_ok, wrog_z_ok;
    public bool walka_z_wrogiem;

    void Awake()
	{
		
		gm=GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();
        x_ok = false;
        z_ok = false;
        wrog_x_ok = false;
        wrog_z_ok = false;
        walka_z_wrogiem = false;
        //wybrany_wrog = false;

    }
	void Start () {

    }
    void zadaj_obrazenia(int obrazenia)
    {
        gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp = gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].actual_hp - obrazenia;
        return;
    }
   
    void idz_na_pole(int b_p)
    {
        int i, aktualna_postac_numer_pola, help;
       // Debug.Log("Pozycja aktualna x=" + gm.postac_gracza_positionx + "\n");
       // Debug.Log("Pozycja aktualna z=" + gm.postac_gracza_positionz + "\n");
        Debug.Log("Postac wybrana.Cel zaznaczony");
        Debug.Log("Postac biezaca"+b_p+"\n");
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
                x_ok =true;
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
    
    // Update is called once per frame
    void Update () {
  //      if (Input.GetKeyDown("o"))
   //     {
   //         gm.pause = !gm.pause;
  //     }
        
        

        //gm.smiercTexture
        //  if ((gm.walka_w_trakcie == true) && (this.tag=="Postac_wrog")&&(gm.pause == false))
        //   {
        //      walcz();
        //  }
        if ((gm.pokazuje_inwentarz==true) && (gm.inwentarz_narysowany==false))
        {
           // gm.pause = true;
            Debug.Log("rysuje inwentarz");
            gm.camera_.transform.position = new Vector3(200, 40, 200);
            gm.tlo = Instantiate(gm.cube_tlo, new Vector3(200, 1.5F, 200), Quaternion.identity) as GameObject;
            //gm.tlo.GetComponent<Renderer>().material.mainTexture = gm.platnerzTexture;
            gm.tlo.GetComponent<Renderer>().material.color = gm.wybierzkolor(1);
            gm.tlo.transform.localScale += new Vector3(100, 0, 100);
            rysuj_ekwipunek_i_przedmioty_na_ziemi();
            /*
            gm.ekwipunek_przedmioty_na_ziemi[0] = new ekwipunek(0, 0, "Skora wilka, +5 pancerza", 100, gm.skoraTexture);
            gm.przedmioty_na_ziemi[0].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[0].obrazek;
            gm.ekwipunek_przedmioty_na_ziemi[1] = gm.tablica_malego_terenu[gm.index_w_tabeli].rzeczy_na_ziemi[1];
            gm.przedmioty_na_ziemi[1].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[1].obrazek;
            */
            // gm.ekwipunek_przedmioty_na_ziemi[1] = new ekwipunek(7, 10, "Mięso, 100 jednostek żywności", 100, gm.miesoTexture);
            // gm.przedmioty_na_ziemi[1].GetComponent<Renderer>().material.mainTexture = gm.ekwipunek_przedmioty_na_ziemi[1].obrazek;
            //*/
            //gm.index_w_tabeli = ((int)(this.transform.position.x - 150) * 25) + (int)(this.transform.position.z - 150);
            gm.index_w_tabeli[gm.aktualna_postac] = ((int)(gm.test1[gm.aktualna_postac] - 150) * 25) + (int)(gm.test2[gm.aktualna_postac] - 150);
            wczytaj_przedmioty_na_ziemi();
            gm.inwentarz_narysowany = true;
        }
    }
	
    float zwroc_numer_przedmiotu_na_ziemi(float position_x)
    {
        return (position_x - 155) / 5;
    }
    
    void rysuj_ekwipunek_i_asortyment()
	{
		for (int i=0;i<10;i++)
		{
			gm.asortyment_sklepu[i]=Instantiate (gm.cube_asortyment_sklepu, new Vector3 (155+i*5, 2.0F, 200), Quaternion.identity) as GameObject;
			gm.asortyment_sklepu[i].GetComponent<Renderer>().material.color=Color.white;
			gm.asortyment_sklepu[i].transform.localScale+= new Vector3(3, 0, 3);
			gm.asortyment_sklepu[i].tag="asortyment_sklepu";
		}
		for (int i=0;i<10;i++)
		{
			gm.asortyment_sklepu[i+10]=Instantiate (gm.cube_asortyment_sklepu, new Vector3 (155+i*5, 2.0F, 195), Quaternion.identity) as GameObject;
			gm.asortyment_sklepu[i+10].GetComponent<Renderer>().material.color=Color.white;
			gm.asortyment_sklepu[i+10].transform.localScale+= new Vector3(3, 0, 3);
			gm.asortyment_sklepu[i+10].tag="asortyment_sklepu";
		}
		/* głowa*/
		for (int i=0;i<4;i++)
		{
			gm.ekwipunek_postaci_box[i]=Instantiate (gm.cube_ekwipunek_postaci, new Vector3 (230+i*5, 2.0F, 195), Quaternion.identity) as GameObject;
			gm.ekwipunek_postaci_box[i].GetComponent<Renderer>().material.color=Color.white;
			gm.ekwipunek_postaci_box[i].GetComponent<Renderer>().material.mainTexture=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[i].obrazek;
			gm.ekwipunek_postaci_box[i].transform.localScale+= new Vector3(3, 0, 3);
			gm.ekwipunek_postaci_box[i].tag="ekwipunek_postaci_kieszenie";
		}
		for (int i=0;i<4;i++)
		{
			gm.ekwipunek_postaci_box[i+4]=Instantiate (gm.cube_ekwipunek_postaci, new Vector3 (230+i*5, 2.0F, 190), Quaternion.identity) as GameObject;
			gm.ekwipunek_postaci_box[i+4].GetComponent<Renderer>().material.color=Color.white;
			gm.ekwipunek_postaci_box[i+4].GetComponent<Renderer>().material.mainTexture=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[i+4].obrazek;
			gm.ekwipunek_postaci_box[i+4].transform.localScale+= new Vector3(3, 0, 3);
			gm.ekwipunek_postaci_box[i+4].tag="ekwipunek_postaci_kieszenie";
		}
		for (int i=0;i<3;i++)
		{
			gm.ekwipunek_postaci_box[i+8]=Instantiate (gm.cube_ekwipunek_postaci, new Vector3 (235, 2.0F, 205+i*5), Quaternion.identity) as GameObject;
			gm.ekwipunek_postaci_box[i+8].GetComponent<Renderer>().material.color=Color.white;
			gm.ekwipunek_postaci_box[i+8].transform.localScale+= new Vector3(3, 0, 3);
		}

		//gm.ekwipunek_postaci_box[10].GetComponent<Renderer>().material.mainTexture=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[10].obrazek;
		//gm.ekwipunek_postaci_box[9].GetComponent<Renderer>().material.mainTexture=gm.tulowTexture;
		//gm.ekwipunek_postaci_box[8].GetComponent<Renderer>().material.mainTexture=gm.nogiTexture;	


		gm.ekwipunek_postaci_box[11]=Instantiate (gm.cube_ekwipunek_postaci, new Vector3 (240, 2.0F, 210), Quaternion.identity) as GameObject;
		gm.ekwipunek_postaci_box[11].GetComponent<Renderer>().material.color=Color.white;
		gm.ekwipunek_postaci_box[11].transform.localScale+= new Vector3(3, 0, 3);
		gm.ekwipunek_postaci_box[12]=Instantiate (gm.cube_ekwipunek_postaci, new Vector3 (230, 2.0F, 210), Quaternion.identity) as GameObject;
		gm.ekwipunek_postaci_box[12].GetComponent<Renderer>().material.color=Color.white;
		gm.ekwipunek_postaci_box[12].transform.localScale+= new Vector3(3, 0, 3);
		//gm.ekwipunek_postaci_box[11].GetComponent<Renderer>().material.mainTexture=gm.prawarekaTexture;
		//gm.ekwipunek_postaci_box[12].GetComponent<Renderer>().material.mainTexture=gm.lewarekaTexture;
		gm.ekwipunek_postaci_box[10].tag="ekwipunek_postaci_glowa";
		gm.ekwipunek_postaci_box[9].tag="ekwipunek_postaci_tulow";
		gm.ekwipunek_postaci_box[8].tag="ekwipunek_postaci_nogi";
		gm.ekwipunek_postaci_box[11].tag="ekwipunek_postaci_prawa_reka";
		gm.ekwipunek_postaci_box[12].tag="ekwipunek_postaci_lewa_reka";
		for (int i=8; i<13; i++) 
		{
			gm.ekwipunek_postaci_box[i].GetComponent<Renderer>().material.mainTexture=gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].tablica_ekwipunku[i].obrazek;
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
    void rysuj_ekwipunek_i_przedmioty_na_ziemi()
    {
        while(gm.tablica_druzyn[gm.aktualna_druzyna_index].tablica_postaci[gm.aktualna_postac].zywy==false)
        {
            if (gm.aktualna_postac == 9)
            {
                gm.aktualna_postac = 0;
            }
            else
                gm.aktualna_postac++;
        }
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
	void OnMouseEnter()
	{
        if ((gm.wizyta_w_miescie == true) && (this.tag=="Spichlerz")) 
		{
			//GUI.Label (new Rect (230, 25, 200, 50), "Spichlerz");
			Debug.Log("Spichlerz");
			return;
		}
        

		

		//|| (this.tag == "ekwipunek_postaci_tulow") || (this.tag=="ekwipunek_postaci_prawa_reka") || (this.tag=="ekwipunek_postaci_lewa_reka") || (this.tag=="ekwipunek_postaci_nogi") || (this.tag=="ekwipunek_postaci_glowa"))
	}
//    void OnKeyDown()
//    {
//        if (Input.GetKeyDown("o"))
 //       {
//            gm.pause = !gm.pause;
//        }
 //   }
	void OnMouseExit()
	{
		if (gm.przedmiot_klikniety == false) 
		{
			gm.pokazuje_na_przedmiot = false;
			gm.pokazuje_na_przedmiot_postaci=false;
			gm.index_ekwipunku_postaci=-1;
			return;
		}
	}
	void OnMouseDown()
	{
		//if (this.tag== "Postac_gracza")
     //   {
            ///*(gm.wybrana_postac==false) && (*/
            
          //  gm.postac_gracza_positionx = this.transform.position.x;
          //  gm.postac_gracza_positionz = this.transform.position.z;

     //   }
       
       
        
       // if (gm.pokazuje_na_przedmiot == true)
      //  {
            
           
           
            
            
            
            // gm.ekwipunek_postaci_box[11].tag = "ekwipunek_postaci_prawa_reka";
            //  gm.ekwipunek_postaci_box[12].tag = "ekwipunek_postaci_lewa_reka";
            
      //  }
       
		
		
		
		
        /*SPRZEDAZ*/
        /*Zrzucenie rzeczy na ziemie*/
       
        
		
		
	}
}
