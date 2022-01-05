using UnityEngine;
using System.Collections;
using System;
public class obiektpole
{
	public int kolor;
	public int positionx;
	public int positionz;
	public int number;
	public int zajete;
	public obiektpole(int x,int z,int number_,int zajete_,int kolor_)
	{
		positionx=x;
		positionz=z;
		number=number_;
		zajete=zajete_;
		kolor=kolor_;
	}
		
}
public class klocek
{
	public int kolor;
	public int rodzaj;
	public int p1,p2,p3,p4;
	public int obrot;
	public klocek(int kolor_,int rodzaj_,int p1_,int p2_,int p3_,int p4_)
	{
		kolor=kolor_;
		rodzaj=rodzaj_;
		p1=p1_;
		p2=p2_;
		p3=p3_;
		p4=p4_;
		obrot=0;
	}
		
}
public class Starter : MonoBehaviour {

	// Use this for initialization
	public obiektpole[] tablica=new obiektpole[180];
	public GameObject cube_;
	public GameObject[] pole=new GameObject[180];
	public GUIText licznik_punktow;
	public GUIText rekord_p;
	public GUIText poziom;
	public GUIText komunikat;
	public float pozycjax,pozycjaz;
	int licznik=0;
	int start=0;
	int nastepny=0;
	int punkty=0;
	int rekord=0;
	int koniec_gry_=0;
	int poziom_=1;
	DateTime starttime=new DateTime(6);
	private klocek kloc;
	void Start () {
			
		for (int i=0;i<18;i++)
			{
				for (int j=0;j<10;j++)
				{
					tablica[licznik]=new obiektpole(i-4,j-2,licznik,0,255);

					pozycjax=i-4;
					pozycjaz=j-2;
					pole[licznik]=Instantiate (cube_, new Vector3(pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
					pole[licznik].GetComponent<Renderer>().material.color=wybierzkolor(255);
					tablica[licznik].kolor=255;
					licznik++;
				}
			}
		losuj_klocek();
	}
	
	// Update is called once per frame
	void Update () {
		if (koniec_gry_==1)
		{
			if (Input.GetButtonUp("Jump"))
			{
				nowa_gra();
			}
		}
		if(Input.GetKeyDown(KeyCode.A))
		{
			//left
			wlewo();
		}
		if(Input.GetKeyDown(KeyCode.S))
		{
			//down
			nastepny=0;
			while(nastepny!=1)
			{
				wdol();
			}
			if (nastepny==1)
			{
					
				for (int v=170;v<180;v++)
				{
					if(tablica[v].zajete==1)
					{
						koniec_gry();
					}
				}
				kasuj_linie();
				losuj_klocek();
			}
		}
		if(Input.GetKeyDown(KeyCode.D))
		{

			wprawo();
		}
		if(Input.GetKeyDown(KeyCode.W))
		{
			
			obrotwprawo();
		}
		if(Input.GetKeyDown(KeyCode.Z))
		{
			
			obrotwlewo();
		}
		if (koniec_gry_!=1)
		{
			if (start==0)
			{
			    starttime=DateTime.Now;
				start=1;
			}
			if ((start==1) && (nastepny!=2))
			{
				DateTime nowtime=DateTime.Now;
				TimeSpan diff = nowtime.Subtract(starttime);
				if (diff.TotalMilliseconds>=(1000-(poziom_*100)))
				{
				   Debug.Log (diff.TotalMilliseconds);
					start=0;
					nastepny=0;
				   wdol();
					if (nastepny==1)
					{
				
						for (int v=170;v<180;v++)
						{
							if(tablica[v].zajete==1)
							{
								koniec_gry();
							}
						}
						kasuj_linie();
						losuj_klocek();
					}
				}
			}
		}
	}
	void nowa_gra()
	{
		komunikat.text="";
		koniec_gry_=0;
		licznik=0;
		start=0;
		nastepny=0;
		punkty=0;
		poziom_=1;
		poziom.text=poziom_.ToString();
		licznik_punktow.text=punkty.ToString();
		for (int i=0;i<18;i++)
			{
				for (int j=0;j<10;j++)
				{
					tablica[licznik].zajete=0;
					tablica[licznik].kolor=255;
					pole[licznik].GetComponent<Renderer>().material.color=wybierzkolor(255);
					licznik++;
				}
			}
		losuj_klocek();
	}
	void kasuj_linie()
	{
		int zliczaj=0;
		int i=0;
		while (i<18)
		{
			for (int j=0;j<10;j++)
			{
				if 	(tablica[j+i*10].zajete==1)
				{
				   zliczaj++;	
				}
			}
			if (zliczaj==10)
			{
				punkty++;
				licznik_punktow.text=punkty.ToString();
				if ((punkty%30)==0)
					poziom_++;
				poziom.text=poziom_.ToString();
				for (int j=0;j<10;j++)
				{
					tablica[j+i*10].zajete=0;
				    pole[j+i*10].GetComponent<Renderer>().material.color=wybierzkolor(255);	
				}	
			
				for (int k=i;k<18;k++)
				{
					for (int l=0;l<10;l++)
					{
						if (k==17)
						{
						
							tablica[l+k*10].zajete=0;
							pole[l+k*10].GetComponent<Renderer>().material.color=wybierzkolor(255);
						}
						else
						{
							tablica[l+k*10].zajete=tablica[l+(k+1)*10].zajete;
							tablica[l+k*10].kolor=tablica[l+(k+1)*10].kolor;
							pole[l+k*10].GetComponent<Renderer>().material.color=wybierzkolor(tablica[l+k*10].kolor-1);
						}
						
					}
				}
				i=0;
				zliczaj=0;
			
			}
			else
			{
				zliczaj=0;
				i++;
			}
		}
	}
	void wdol()
	{

		switch (kloc.rodzaj)
		{
		case 1:
			if (((kloc.p3-10)>-1)&& ((kloc.p4-10)>-1))
			{
				if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
				{
					tablica[kloc.p1].zajete=0;
					tablica[kloc.p2].zajete=0;
					tablica[kloc.p1].kolor=255;
					tablica[kloc.p2].kolor=255;
					pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
					pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
					kloc.p1=kloc.p1-10;
					kloc.p2=kloc.p2-10;
					kloc.p3=kloc.p3-10;
					kloc.p4=kloc.p4-10;
					pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					tablica[kloc.p3].zajete=1;
					tablica[kloc.p4].zajete=1;
					tablica[kloc.p3].kolor=kloc.kolor;
					tablica[kloc.p4].kolor=kloc.kolor;

				}
				else
					nastepny=1;
			}
			else
					nastepny=1;
			break;
		case 2:
			if (kloc.obrot==0)
			{
				if ((kloc.p4-10)>-1)
				{
					if (tablica[kloc.p4-10].zajete==0)
					{
						tablica[kloc.p1].zajete=0;
						tablica[kloc.p1].kolor=255;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
					{
						nastepny=1;
					
					}
					
				}
				else
				{
					nastepny=1;
			
				}
			
			}
			else
			{
				if (((kloc.p4-10)>-1) && ((kloc.p3-10)>-1)&&((kloc.p2-10)>-1)&&((kloc.p1-10)>-1))
				{
					if ((tablica[kloc.p4-10].zajete==0)&&(tablica[kloc.p3-10].zajete==0)&&(tablica[kloc.p2-10].zajete==0)&&(tablica[kloc.p1-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p4].zajete=1;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p3].zajete=1;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p2].zajete=1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
			}
			break;
		case 3:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p4-10)>-1)&&((kloc.p3-10)>-1))
				{
					if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			case 1:
				if (((kloc.p3-10)>-1)&&((kloc.p2-10)>-1)&&((kloc.p1-10)>-1))
				{
					if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p2-10].zajete==0)&&(tablica[kloc.p1-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			case 2:
				if ((kloc.p1-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
					{
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			case 3:
				if ((kloc.p4-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) &&(tablica[kloc.p2-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
					{
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			}
			break;
		case 4:
			switch (kloc.obrot)
			{
			case 0:
					if (((kloc.p3-10)>-1)&&((kloc.p4-10)>-1))
					{
						if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-10;
							kloc.p2=kloc.p2-10;
							kloc.p3=kloc.p3-10;
							kloc.p4=kloc.p4-10;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
						else
							nastepny=1;
					}
					else
							nastepny=1;
					break;
			case 1:
				if ((kloc.p4-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) &&(tablica[kloc.p2-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			case 2:
				if ((kloc.p1-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
					{
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			case 3:
				if ((kloc.p3-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) && (tablica[kloc.p2-10].zajete==0)&& (tablica[kloc.p3-10].zajete==0))
					{
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			}
			break;
		case 5:
			switch(kloc.obrot)
			{
			case 0:
				if ((kloc.p4-10)>-1)
				{
					if ((tablica[kloc.p4-10].zajete==0) && (tablica[kloc.p3-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p3].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			case 1:
				if ((kloc.p1-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) && (tablica[kloc.p2-10].zajete==0)&& (tablica[kloc.p4-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
					break;
				case 2:
				if ((kloc.p1-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) && (tablica[kloc.p3-10].zajete==0))
					{
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
				case 3:
				if ((kloc.p3-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) &&(tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
					{
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			}
			break;
		case 6:
			switch(kloc.obrot)
			{
			case 0:
				if (((kloc.p3-10)>-1)&&((kloc.p4-10)>-1))
				{
					if ((tablica[kloc.p4-10].zajete==0) && (tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p2-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
			break;
			case 1:
				if ((kloc.p4-10)>-1)
				{
					if ((tablica[kloc.p1-10].zajete==0) && (tablica[kloc.p4-10].zajete==0))
					{
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			}
			break;
		case 7:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p3-10)>-1)&&((kloc.p4-10)>-1))
				{
					if ((tablica[kloc.p4-10].zajete==0) && (tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p2-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
			break;
			case 1:
				if ((kloc.p2-10)>-1)
				{
					if ((tablica[kloc.p2-10].zajete==0) && (tablica[kloc.p3-10].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-10;
						kloc.p2=kloc.p2-10;
						kloc.p3=kloc.p3-10;
						kloc.p4=kloc.p4-10;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					else
						nastepny=1;
				}
				else
						nastepny=1;
				break;
			}
			break;
		}
		
	}
	void wlewo()
	{

		switch (kloc.rodzaj)
		{
		case 1:
			if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
			{
			    if ((kloc.p2%10)!=9)
				{
					if ((tablica[kloc.p2+1].zajete==0) && (tablica[kloc.p4+1].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						tablica[kloc.p3].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p3].kolor=255;
						kloc.p1=kloc.p1+1;
						kloc.p2=kloc.p2+1;
						kloc.p3=kloc.p3+1;
						kloc.p4=kloc.p4+1;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
				}
			}
			
			break;
		case 2:
		if (kloc.obrot==0)
		{
			if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
			{
			    if ((kloc.p1%10)!=9)
				{
					if ((tablica[kloc.p2+1].zajete==0) && (tablica[kloc.p4+1].zajete==0)&&(tablica[kloc.p3+1].zajete==0) && (tablica[kloc.p1+1].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1+1;
						kloc.p2=kloc.p2+1;
						kloc.p3=kloc.p3+1;
						kloc.p4=kloc.p4+1;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p4].zajete=1;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p3].zajete=1;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p2].zajete=1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
				}
				
			}
		}
		else
		{
			if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
			{
			    if ((kloc.p4%10)!=9)
				{
					if (tablica[kloc.p4+1].zajete==0)
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
												
						kloc.p1=kloc.p1+1;
						kloc.p2=kloc.p2+1;
						kloc.p3=kloc.p3+1;
						kloc.p4=kloc.p4+1;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p4].zajete=1;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p3].zajete=1;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p2].zajete=1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
				}
				
			}	
		}
			break;
		case 3:
			switch (kloc.obrot)
			{	
			case 0:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p4%10)!=9)
					{
						if ((tablica[kloc.p1+1].zajete==0) && (tablica[kloc.p2+1].zajete==0)&& (tablica[kloc.p4+1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 1:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p4%10)!=9)
					{
						if ((tablica[kloc.p4+1].zajete==0) && (tablica[kloc.p3+1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 2:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p3%10)!=9)
					{
						if ((tablica[kloc.p1+1].zajete==0) && (tablica[kloc.p2+1].zajete==0) && (tablica[kloc.p3+1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 3:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p1%10)!=9)
					{
						if ((tablica[kloc.p1+1].zajete==0) && (tablica[kloc.p4+1].zajete==0))
						{
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			}
			break;
		case 4:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p1%10)!=9)
					{
						if ((tablica[kloc.p1+1].zajete==0) && (tablica[kloc.p2+1].zajete==0)&& (tablica[kloc.p3+1].zajete==0))
						{

							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 1:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p3%10)!=9)
					{
						if ((tablica[kloc.p3+1].zajete==0) && (tablica[kloc.p4+1].zajete==0))
						{

							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 2:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p4%10)!=9)
					{
						if ((tablica[kloc.p1+1].zajete==0)&&(tablica[kloc.p2+1].zajete==0) && (tablica[kloc.p4+1].zajete==0))
						{
						
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 3:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p1%10)!=9)
					{
						if ((tablica[kloc.p1+1].zajete==0) && (tablica[kloc.p4+1].zajete==0))
						{

							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			}
			break;
		case 5:
			switch(kloc.obrot)
			{
			case 0:				
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p3%10)!=9)
					{
						if ((tablica[kloc.p1+1].zajete==0) && (tablica[kloc.p3+1].zajete==0)&& (tablica[kloc.p4+1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
					
				}
				break;
			case 1:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180))
				{
				    if ((kloc.p4%10)!=9)
					{
						if ((tablica[kloc.p3+1].zajete==0)&& (tablica[kloc.p4+1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p3].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
					
				}
				break;
			case 2:
				if (((kloc.p1+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p4+1)<180))
				{
				    if ((kloc.p4%10)!=9)
					{
						if ((tablica[kloc.p2+1].zajete==0)&& (tablica[kloc.p4+1].zajete==0)&& (tablica[kloc.p1+1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
					
				}
				break;
			case 3:
				if (((kloc.p1+1)<180)&&((kloc.p3+1)<180))
				{
				    if ((kloc.p1%10)!=9)
					{
						if ((tablica[kloc.p3+1].zajete==0)&& (tablica[kloc.p1+1].zajete==0))
						{
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1+1;
							kloc.p2=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p4=kloc.p4+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
					
				}
				break;
			}
			break;
		case 6:
			switch(kloc.obrot)
			{
			case 0:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p2%10)!=9)
					{
						if ((tablica[kloc.p2+1].zajete==0) && (tablica[kloc.p3+1].zajete==0))
						{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1+1;
						kloc.p2=kloc.p2+1;
						kloc.p3=kloc.p3+1;
						kloc.p4=kloc.p4+1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				
				}
			break;
			case 1:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p3%10)!=9)
					{
						if ((tablica[kloc.p2+1].zajete==0) && (tablica[kloc.p3+1].zajete==0)&& (tablica[kloc.p4+1].zajete==0))
						{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1+1;
						kloc.p2=kloc.p2+1;
						kloc.p3=kloc.p3+1;
						kloc.p4=kloc.p4+1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				
				}
				
				break;
			}
			break;
		case 7:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p4%10)!=9)
					{
						if ((tablica[kloc.p1+1].zajete==0) && (tablica[kloc.p4+1].zajete==0))
						{
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						kloc.p1=kloc.p1+1;
						kloc.p2=kloc.p2+1;
						kloc.p3=kloc.p3+1;
						kloc.p4=kloc.p4+1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
					
				}
				break;
			case 1:
				if (((kloc.p3+1)<180)&& ((kloc.p4+1)<180)&&((kloc.p2+1)<180)&& ((kloc.p1+1)<180))
				{
				    if ((kloc.p4%10)!=9)
					{
						if ((tablica[kloc.p2+1].zajete==0) &&(tablica[kloc.p3+1].zajete==0) && (tablica[kloc.p4+1].zajete==0))
						{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1+1;
						kloc.p2=kloc.p2+1;
						kloc.p3=kloc.p3+1;
						kloc.p4=kloc.p4+1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
					
				}
				break;
			}
			break;
		}
		
	}
	void wprawo()
	{

		switch (kloc.rodzaj)
		{
		case 1:
			if (((kloc.p3-1)>0)&& ((kloc.p4-1)>0)&&((kloc.p2-1)>0)&& ((kloc.p1-1)>0))
			{
			    if ((kloc.p3%10)!=0)
				{
					if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p3-1].zajete==0))
					{
						tablica[kloc.p2].zajete=0;
						tablica[kloc.p4].zajete=0;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p4].kolor=255;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						kloc.p1=kloc.p1-1;
						kloc.p2=kloc.p2-1;
						kloc.p3=kloc.p3-1;
						kloc.p4=kloc.p4-1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
					}
				}
			}
			
			break;
		case 2:
			if (kloc.obrot==0)
			{
			if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
			{
			    if ((kloc.p3%10)!=0)
				{
					if ((tablica[kloc.p2-1].zajete==0) && (tablica[kloc.p4-1].zajete==0)&&(tablica[kloc.p3-1].zajete==0) && (tablica[kloc.p1-1].zajete==0))
					{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-1;
						kloc.p2=kloc.p2-1;
						kloc.p3=kloc.p3-1;
						kloc.p4=kloc.p4-1;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p4].zajete=1;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p3].zajete=1;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p2].zajete=1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
					
						
				}
			
				
			}
			}
			else
			{
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p1%10)!=0)
					{
						if (tablica[kloc.p1-1].zajete==0)
						{
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p4].zajete=1;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p3].zajete=1;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p2].zajete=1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
							
					}
				
					
				}
			}

			break;
		case 3:
			switch (kloc.obrot)
			{
			case 0:		
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p1%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p2-1].zajete==0)&& (tablica[kloc.p3-1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 1:
				if (((kloc.p1-1)>-1))
				{
				    if ((kloc.p1%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p4-1].zajete==0))
						{
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 2:
				if (((kloc.p1-1)>-1))
				{
				    if ((kloc.p4%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) &&(tablica[kloc.p2-1].zajete==0)&&(tablica[kloc.p4-1].zajete==0))
						{
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			case 3:
				if (((kloc.p4-1)>-1))
				{
				    if ((kloc.p4%10)!=0)
					{
						if ((tablica[kloc.p3-1].zajete==0) &&(tablica[kloc.p4-1].zajete==0))
						{
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
			}
			break;
		case 4:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p4%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p2-1].zajete==0)&& (tablica[kloc.p4-1].zajete==0))
						{
							Debug.Log ("p1="+kloc.p1+"p2="+kloc.p2+"p4="+kloc.p4);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
			break;
			case 1:
				if (((kloc.p1-1)>-1)&& ((kloc.p4-1)>-1))
				{
				    if ((kloc.p1%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) &&(tablica[kloc.p4-1].zajete==0))
						{

							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
			break;
			case 2:
				if ((kloc.p1-1)>-1)
				{
				    if ((kloc.p1%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) &&(tablica[kloc.p2-1].zajete==0)&&(tablica[kloc.p3-1].zajete==0))
						{

							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
			break;	
			case 3:
				if ((kloc.p3-1)>-1)
				{
				    if ((kloc.p3%10)!=0)
					{
						if ((tablica[kloc.p4-1].zajete==0) &&(tablica[kloc.p3-1].zajete==0))
						{

							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
			break;		
			}
			break;
		case 5:
			switch (kloc.obrot)
			{
				case 0:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p1%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p2-1].zajete==0)&& (tablica[kloc.p4-1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				break;
				case 1:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p1%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p3-1].zajete==0))
						{
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}	
				
				break;
				case 2:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p3%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p3-1].zajete==0)&& (tablica[kloc.p4-1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}	
				
				break;
				case 3:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p4%10)!=0)
					{
						if ((tablica[kloc.p3-1].zajete==0)&& (tablica[kloc.p4-1].zajete==0))
						{
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p3].kolor=255;
							kloc.p1=kloc.p1-1;
							kloc.p2=kloc.p2-1;
							kloc.p3=kloc.p3-1;
							kloc.p4=kloc.p4-1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}	
				
				break;
			}
			
			break;
		case 6:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p4%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p4-1].zajete==0))
						{
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						kloc.p1=kloc.p1-1;
						kloc.p2=kloc.p2-1;
						kloc.p3=kloc.p3-1;
						kloc.p4=kloc.p4-1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				
				}
				break;
			case 1:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p1%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) &&(tablica[kloc.p2-1].zajete==0)&& (tablica[kloc.p4-1].zajete==0))
						{
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-1;
						kloc.p2=kloc.p2-1;
						kloc.p3=kloc.p3-1;
						kloc.p4=kloc.p4-1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				
				}
				break;
			}
			break;
		case 7:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p2%10)!=0)
					{
						if ((tablica[kloc.p2-1].zajete==0) && (tablica[kloc.p3-1].zajete==0))
						{
						tablica[kloc.p1].zajete=0;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p1].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-1;
						kloc.p2=kloc.p2-1;
						kloc.p3=kloc.p3-1;
						kloc.p4=kloc.p4-1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
					
				}
			break;
			case 1:
				if (((kloc.p3-1)>-1)&& ((kloc.p4-1)>-1)&&((kloc.p2-1)>-1)&& ((kloc.p1-1)>-1))
				{
				    if ((kloc.p2%10)!=0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p2-1].zajete==0) && (tablica[kloc.p4-1].zajete==0))
						{
						tablica[kloc.p2].zajete=0;
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p3].zajete=0;
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p2].kolor=255;
						tablica[kloc.p3].kolor=255;
						tablica[kloc.p4].kolor=255;
						kloc.p1=kloc.p1-1;
						kloc.p2=kloc.p2-1;
						kloc.p3=kloc.p3-1;
						kloc.p4=kloc.p4-1;
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
					
				}
				break;
			}
			break;
		}
		
	}
	void obrotwprawo()
	{
		switch(kloc.rodzaj)
		{
		case 2:
			if(kloc.obrot==0)
			{
				if (((kloc.p3+1)>0)&& ((kloc.p3-1)>0)&&((kloc.p3-2)>0))
				{
				    if (((kloc.p3%10)!=9)&&(((kloc.p3)%10)>1))
					{

						if ((tablica[kloc.p3+1].zajete==0) && (tablica[kloc.p3-1].zajete==0)&&(tablica[kloc.p3-2].zajete==0))
						{	
						
							kloc.obrot=1;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p3-2;
							kloc.p2=kloc.p3-1;
							kloc.p4=kloc.p3+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
			}
			else
			{
				if (((kloc.p3-10)>0)&& ((kloc.p3+20)>0)&&((kloc.p3+10)>0))
				{
				    if (((kloc.p3%10)!=9)&&(((kloc.p3)%10)>1))
					{
						if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p3+20].zajete==0)&&(tablica[kloc.p3+10].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p3+20;
							kloc.p2=kloc.p3+10;
							kloc.p4=kloc.p3-10;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
			}
			
			break;
		case 3:

			if (kloc.obrot==0)
			{
				

				if (((kloc.p4-20)>-1))
				{
				   
					if (((kloc.p4)%10)>1)
					{

						if ((tablica[kloc.p4+10].zajete==0) && (tablica[kloc.p3-1].zajete==0))
						{	
						

							kloc.obrot=1;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							kloc.p4=kloc.p2+1;
							kloc.p3=kloc.p3+1;
							kloc.p1=kloc.p1-21;
							kloc.p2=kloc.p2-10;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
			}
			else if (kloc.obrot==1)
			{
				if (((kloc.p4-20)>-1))
				{
				    if (((kloc.p4)%10)>1)
					{
						if ((tablica[kloc.p4-1].zajete==0) && (tablica[kloc.p3-10].zajete==0))
						{	
						
							kloc.obrot=2;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							kloc.p4=kloc.p4-1;
							kloc.p3=kloc.p4+1;
							kloc.p1=kloc.p3-20;
							kloc.p2=kloc.p3-10;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
				
			}
			else if (kloc.obrot==2)
			{
				if (((kloc.p1-12)>-1))
				{
				    if (((kloc.p4)%10)>0)
					{
						if ((tablica[kloc.p1-1].zajete==0) && (tablica[kloc.p2-2].zajete==0)&& (tablica[kloc.p4-12].zajete==0))
						{	
						
							kloc.obrot=3;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p4=kloc.p1-12;
							kloc.p3=kloc.p1-2;
							kloc.p2=kloc.p1-1;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
				
			}
			else if (kloc.obrot==3)
			{
				if (((kloc.p1-19)>-1))
				{
				    if (((kloc.p1)%10)!=9)
					{
						if ((tablica[kloc.p1-10].zajete==0) && (tablica[kloc.p1-20].zajete==0)&& (tablica[kloc.p1-19].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p4=kloc.p1-19;
							kloc.p3=kloc.p1-20;
							kloc.p2=kloc.p1-10;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
				
			}
			break;
		case 4:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p3-10)>-1))
				{
				    if (((kloc.p4)%10)!=0)
					{
						if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p4-1].zajete==0))
						{	
						
							kloc.obrot=1;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							kloc.p1=kloc.p3-2;
							kloc.p2=kloc.p3-1;
							kloc.p4=kloc.p3-10;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
				break;
			case 1:
				if (((kloc.p4-21)>-1))
				{
				    
						if ((tablica[kloc.p4-1].zajete==0) && (tablica[kloc.p4-11].zajete==0)&& (tablica[kloc.p4-21].zajete==0))
						{	
						
							kloc.obrot=2;
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							kloc.p1=kloc.p4-21;
							kloc.p2=kloc.p4-11;
							kloc.p3=kloc.p4-1;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
			case 2:
				if (((kloc.p4)%10)<8)
					{
				   	if ((tablica[kloc.p4-10].zajete==0) && (tablica[kloc.p4-9].zajete==0)&& (tablica[kloc.p4-8].zajete==0))
					{	
						
							kloc.obrot=3;
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							kloc.p1=kloc.p4-8;
							kloc.p2=kloc.p4-9;
							kloc.p3=kloc.p4-10;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
					}
					
				}
				break;
			case 3:
				if (((kloc.p1-21)>-1))
				{
				   	if ((tablica[kloc.p1-10].zajete==0) && (tablica[kloc.p1-20].zajete==0)&& (tablica[kloc.p1-21].zajete==0))
					{	
						
							kloc.obrot=0;
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p2=kloc.p1-10;
							kloc.p3=kloc.p1-20;
							kloc.p4=kloc.p1-21;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
					}
					
				}
				break;
			}
			break;
		case 5:
			switch (kloc.obrot)
			{
			case 0:
				if (((kloc.p3-21)>-1))
				{
				    if (((kloc.p4)%10)!=0)
					{
						if (tablica[kloc.p1-11].zajete==0)
						{	
						
							kloc.obrot=1;
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].kolor=255;
							kloc.p4=kloc.p3;
							kloc.p3=kloc.p1;
							kloc.p1=kloc.p1-11;
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
				break;	
			case 1:
				if (((kloc.p3-20)>-1))
				{
				    
						if (tablica[kloc.p2-10].zajete==0)
						{	
						
							kloc.obrot=2;
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].kolor=255;
							kloc.p4=kloc.p3;
							kloc.p3=kloc.p1;
							kloc.p1=kloc.p2-10;
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				
				break;
			case 2:
				if (((kloc.p4)%10)!=9)
				{
					if (tablica[kloc.p2+1].zajete==0)
					{	
							
						kloc.obrot=3;
						tablica[kloc.p4].zajete=0;
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
						tablica[kloc.p4].kolor=255;
						kloc.p4=kloc.p3;
						kloc.p3=kloc.p1;
						kloc.p1=kloc.p2+1;
								
								
						pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
						tablica[kloc.p1].zajete=1;
						tablica[kloc.p2].zajete=1;
						tablica[kloc.p3].zajete=1;
						tablica[kloc.p4].zajete=1;
						tablica[kloc.p1].kolor=kloc.kolor;
						tablica[kloc.p2].kolor=kloc.kolor;
						tablica[kloc.p3].kolor=kloc.kolor;
						tablica[kloc.p4].kolor=kloc.kolor;
					}
				}
				
				
				break;	
			case 3:
				if (tablica[kloc.p2+10].zajete==0)
				{	
						
					kloc.obrot=0;
					tablica[kloc.p4].zajete=0;
					pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
					tablica[kloc.p4].kolor=255;
					kloc.p4=kloc.p3;
					kloc.p3=kloc.p1;
					kloc.p1=kloc.p2+10;
							
							
					pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					tablica[kloc.p1].zajete=1;
					tablica[kloc.p2].zajete=1;
					tablica[kloc.p3].zajete=1;
					tablica[kloc.p4].zajete=1;
					tablica[kloc.p1].kolor=kloc.kolor;
					tablica[kloc.p2].kolor=kloc.kolor;
					tablica[kloc.p3].kolor=kloc.kolor;
					tablica[kloc.p4].kolor=kloc.kolor;
				}
					
				
				
				break;	
			}
			break;
		case 6:
			switch(kloc.obrot)
			{
			case 0:
				if (((kloc.p4-18)>-1))
				{
				    
						if ((tablica[kloc.p3+1].zajete==0)&&(tablica[kloc.p4-18].zajete==0))
						{	
						
							kloc.obrot=1;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p2=kloc.p1;	
							kloc.p4=kloc.p3-9;
							kloc.p1=kloc.p3;
							kloc.p3=kloc.p3+1;
							
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
				case 1:
				if (((kloc.p4-2)>-1)&&((kloc.p1%10)!=0))
				{
				    
						if ((tablica[kloc.p4-2].zajete==0)&&(tablica[kloc.p4-1].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p2=kloc.p2-9;	
							kloc.p4=kloc.p1-11;
							kloc.p3=kloc.p1-10;
							
							
							
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
			}
			break;
			case 7:
			
			switch(kloc.obrot)
			{
			
			case 0:
				if (((kloc.p3-10)>-1))
				{
				    
						if ((tablica[kloc.p3-10].zajete==0)&&(tablica[kloc.p4+10].zajete==0))
						{	
						
							kloc.obrot=1;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							kloc.p2=kloc.p3-10;	
							kloc.p4=kloc.p4+10;
							kloc.p1=kloc.p3;
							kloc.p3=kloc.p3+1;
							
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
				case 1:
				if ((kloc.p1%10)!=0)
				{
				    
						if ((tablica[kloc.p1-1].zajete==0)&&(tablica[kloc.p2+1].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p2=kloc.p1-1;	
							kloc.p4=kloc.p4-20;
							kloc.p3=kloc.p4-1;
							
							
							
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
			}
			break;
		}
		
	}
	void obrotwlewo()
	{
		switch(kloc.rodzaj)
		{
		case 2:
			if(kloc.obrot==0)
			{
				if (((kloc.p3+1)>0)&& ((kloc.p3-1)>0)&&((kloc.p3-2)>0))
				{
				    if (((kloc.p3%10)!=9)&&(((kloc.p3)%10)>1))
					{
						Debug.Log ("kloc.p3-1="+(kloc.p3-1));
						if ((tablica[kloc.p3+1].zajete==0) && (tablica[kloc.p3-1].zajete==0)&&(tablica[kloc.p3-2].zajete==0))
						{	
						
							kloc.obrot=1;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p3-2;
							kloc.p2=kloc.p3-1;
							kloc.p4=kloc.p3+1;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
			}
			else
			{
				if (((kloc.p3-10)>0)&& ((kloc.p3+20)>0)&&((kloc.p3+10)>0))
				{
				    if (((kloc.p3%10)!=9)&&(((kloc.p3)%10)>1))
					{
						if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p3+20].zajete==0)&&(tablica[kloc.p3+10].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p3+20;
							kloc.p2=kloc.p3+10;
							kloc.p4=kloc.p3-10;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				}
				
			}
			
			break;
		case 3:
		
			if (kloc.obrot==0)
			{
				

				if (((kloc.p4-11)>-1))
				{
				    
						if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p3+2].zajete==0))
						{	
						
							
							kloc.obrot=3;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							kloc.p2=kloc.p4;
							kloc.p4=kloc.p3-10;
							kloc.p1=kloc.p3+2;
														
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				
			}
			else if (kloc.obrot==1)
			{

				if ((kloc.p4%10)!=9)
				{
						if ((tablica[kloc.p3+1].zajete==0) && (tablica[kloc.p4+10].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							kloc.p4=kloc.p3+1;
							kloc.p1=kloc.p3+20;
							kloc.p2=kloc.p3+10;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
				
				}
				
			}
			else if (kloc.obrot==2)
			{
				if ((kloc.p4%10)>0)
				{
						if ((tablica[kloc.p2-1].zajete==0) && (tablica[kloc.p2-2].zajete==0))
						{	
						
							kloc.obrot=1;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p4=kloc.p4+1;
							kloc.p3=kloc.p4-10;
							kloc.p2=kloc.p3-1;
							kloc.p1=kloc.p3-2;
						
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				
				
			}
			else if (kloc.obrot==3)
			{
				if (((kloc.p2-20)>-1))
				{
				   
						if (tablica[kloc.p2-20].zajete==0)
						{	
						
							kloc.obrot=2;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p4=kloc.p3;
							kloc.p3=kloc.p2;
							kloc.p1=kloc.p2-20;
							kloc.p2=kloc.p2-10;
						
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				
				
			}
			break;
		case 4:
			switch (kloc.obrot)
			{
			case 0:
				
				    if (((kloc.p1)%10)!=9)
					{
						if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p3-9].zajete==0)&& (tablica[kloc.p3-11].zajete==0))
						{	
						
							kloc.obrot=3;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p3].kolor=255;
							kloc.p1=kloc.p4-8;
							kloc.p2=kloc.p2-20;
							kloc.p3=kloc.p4-10;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				break;
			case 1:
				
				    
						if ((tablica[kloc.p3+10].zajete==0) && (tablica[kloc.p3+20].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p3+20;
							kloc.p2=kloc.p3+10;
							kloc.p4=kloc.p3-1;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				
				break;
			case 2:
			
				 if (((kloc.p4)%10)>2)
				{
				   	if ((tablica[kloc.p3-1].zajete==0) && (tablica[kloc.p3-2].zajete==0))
					{	
						
							kloc.obrot=1;
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p1=kloc.p3-2;
							kloc.p2=kloc.p3-1;
							kloc.p4=kloc.p3-10;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
					}
				}
				
				break;
			case 3:

				 if (((kloc.p4)%10)>0)
				{
				   if (((kloc.p3-10)>-1)&&((kloc.p3-20)>-1))
					{
					if ((tablica[kloc.p3-10].zajete==0) && (tablica[kloc.p3-20].zajete==0))
					{	
						
							kloc.obrot=2;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p2=kloc.p3-10;
							kloc.p1=kloc.p3-20;
							kloc.p4=kloc.p3+1;
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
					}
					}
				}
				break;
			}
			break;
		case 5:
			switch (kloc.obrot)
			{
			case 0:
				
				    if (((kloc.p4)%10)!=0)
					{
						if (tablica[kloc.p2-1].zajete==0)
						{	
						
							kloc.obrot=3;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							kloc.p4=kloc.p2-1;
							kloc.p3=kloc.p2-10;
							kloc.p1=kloc.p2+1;
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					}
				
				
				break;	
			case 1:
				if (((kloc.p3-20)>-1))
				{
				    
						if (tablica[kloc.p3-20].zajete==0)
						{	
						
							kloc.obrot=0;
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							kloc.p4=kloc.p2-10;
							kloc.p3=kloc.p2+1;
							kloc.p1=kloc.p2+10;
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				
				break;
			case 2:
				if (((kloc.p4)%10)!=9)
				{
				if (tablica[kloc.p2+1].zajete==0)
				{	
						
					kloc.obrot=1;
					tablica[kloc.p1].zajete=0;
					pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
					tablica[kloc.p1].kolor=255;
					kloc.p1=kloc.p2-1;
					kloc.p3=kloc.p2+10;
					kloc.p4=kloc.p2+1;
							
							
					pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					tablica[kloc.p1].zajete=1;
					tablica[kloc.p2].zajete=1;
					tablica[kloc.p3].zajete=1;
					tablica[kloc.p4].zajete=1;
					tablica[kloc.p1].kolor=kloc.kolor;
					tablica[kloc.p2].kolor=kloc.kolor;
					tablica[kloc.p3].kolor=kloc.kolor;
					tablica[kloc.p4].kolor=kloc.kolor;	
				}
					
				}
				
				break;	
			case 3:
				if (tablica[kloc.p2+10].zajete==0)
				{	
						
					kloc.obrot=2;
					tablica[kloc.p1].zajete=0;
					pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
					tablica[kloc.p1].kolor=255;
					kloc.p4=kloc.p2+10;
					kloc.p3=kloc.p2-1;
					kloc.p1=kloc.p2-10;
							
							
					pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
					tablica[kloc.p1].zajete=1;
					tablica[kloc.p2].zajete=1;
					tablica[kloc.p3].zajete=1;
					tablica[kloc.p4].zajete=1;
					tablica[kloc.p1].kolor=kloc.kolor;
					tablica[kloc.p2].kolor=kloc.kolor;
					tablica[kloc.p3].kolor=kloc.kolor;
					tablica[kloc.p4].kolor=kloc.kolor;
				}					
				
				
				break;	
			}
			break;
		case 6:
			switch(kloc.obrot)
			{
			case 0:
				if (((kloc.p4-18)>-1))
				{
				    
						if ((tablica[kloc.p3+1].zajete==0)&&(tablica[kloc.p4-18].zajete==0))
						{	
						
							kloc.obrot=1;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p2=kloc.p1;	
							kloc.p4=kloc.p3-9;
							kloc.p1=kloc.p3;
							kloc.p3=kloc.p3+1;
							
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
				case 1:
				if (((kloc.p4-2)>-1)&&((kloc.p1%10)!=0))
				{
				    
						if ((tablica[kloc.p4-2].zajete==0)&&(tablica[kloc.p4-1].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p2].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p2=kloc.p2-9;	
							kloc.p4=kloc.p1-11;
							kloc.p3=kloc.p1-10;
							
							
							
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
			}
			break;
			case 7:
			
			switch(kloc.obrot)
			{
			
			case 0:
				if (((kloc.p3-10)>-1))
				{
				    
						if ((tablica[kloc.p3-10].zajete==0)&&(tablica[kloc.p4+10].zajete==0))
						{	
						
							kloc.obrot=1;
							tablica[kloc.p2].zajete=0;
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].zajete=0;
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p1].kolor=255;
							tablica[kloc.p2].kolor=255;
							kloc.p2=kloc.p3-10;	
							kloc.p4=kloc.p4+10;
							kloc.p1=kloc.p3;
							kloc.p3=kloc.p3+1;
							
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
				case 1:
				if ((kloc.p1%10)!=0)
				{
				    
						if ((tablica[kloc.p1-1].zajete==0)&&(tablica[kloc.p2+1].zajete==0))
						{	
						
							kloc.obrot=0;
							tablica[kloc.p3].zajete=0;
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p4].zajete=0;
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(255);
							tablica[kloc.p3].kolor=255;
							tablica[kloc.p4].kolor=255;
							kloc.p2=kloc.p1-1;	
							kloc.p4=kloc.p4-20;
							kloc.p3=kloc.p4-1;
							
							
							
							
							
							pole[kloc.p1].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p2].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p3].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							pole[kloc.p4].GetComponent<Renderer>().material.color=wybierzkolor(kloc.kolor-1);
							tablica[kloc.p1].zajete=1;
							tablica[kloc.p2].zajete=1;
							tablica[kloc.p3].zajete=1;
							tablica[kloc.p4].zajete=1;
							tablica[kloc.p1].kolor=kloc.kolor;
							tablica[kloc.p2].kolor=kloc.kolor;
							tablica[kloc.p3].kolor=kloc.kolor;
							tablica[kloc.p4].kolor=kloc.kolor;
						}
					
				}
				break;
			}
			break;
		}
		
	}
	void losuj_klocek()
	{
		int numer;
		DateTime now=DateTime.Now;
		UnityEngine.Random.seed=(now.Second+now.Minute+now.Millisecond);
		numer=UnityEngine.Random.Range (0,7);


		switch (numer)
		{
			case 0: 
			/* KK */
			/* KK */
			if ((tablica[175].zajete==0)&&(tablica[176].zajete==0)&&(tablica[166].zajete==0)&&(tablica[165].zajete==0))
			{
				tablica[175].kolor=1;
				tablica[175].zajete=1;
				tablica[176].kolor=1;
				tablica[176].zajete=1;
				tablica[166].kolor=1;
				tablica[166].zajete=1;
				tablica[165].kolor=1;
				tablica[165].zajete=1;
				pole[175].GetComponent<Renderer>().material.color=wybierzkolor(0);
				pole[176].GetComponent<Renderer>().material.color=wybierzkolor(0);
				pole[166].GetComponent<Renderer>().material.color=wybierzkolor(0);
				pole[165].GetComponent<Renderer>().material.color=wybierzkolor(0);
				kloc=new klocek(1,1,175,176,165,166);
			}
			else
				koniec_gry();			
			break;
			case 1:
			/*K*/
			/*K*/
			/*K*/
			/*K*/
			if ((tablica[175].zajete==0)&&(tablica[165].zajete==0)&&(tablica[155].zajete==0)&&(tablica[145].zajete==0))
			{
				tablica[175].kolor=2;
				tablica[175].zajete=1;
				tablica[165].kolor=2;
				tablica[165].zajete=1;
				tablica[155].kolor=2;
				tablica[155].zajete=1;
				tablica[145].kolor=2;
				tablica[145].zajete=1;
				pole[175].GetComponent<Renderer>().material.color=wybierzkolor(1);
				pole[165].GetComponent<Renderer>().material.color=wybierzkolor(1);
				pole[155].GetComponent<Renderer>().material.color=wybierzkolor(1);
				pole[145].GetComponent<Renderer>().material.color=wybierzkolor(1);
				kloc=new klocek(2,2,175,165,155,145);
				
			}
			else
				koniec_gry();
			break;
			case 2:
			/* K*/
			/* K*/
			/*KK*/
			
			if ((tablica[175].zajete==0)&&(tablica[165].zajete==0)&&(tablica[155].zajete==0)&&(tablica[156].zajete==0))
			{
				tablica[175].kolor=3;
				tablica[175].zajete=1;
				tablica[165].kolor=3;
				tablica[165].zajete=1;
				tablica[155].kolor=3;
				tablica[155].zajete=1;
				tablica[156].kolor=3;
				tablica[156].zajete=1;
				pole[175].GetComponent<Renderer>().material.color=wybierzkolor(2);
				pole[165].GetComponent<Renderer>().material.color=wybierzkolor(2);
				pole[155].GetComponent<Renderer>().material.color=wybierzkolor(2);
				pole[156].GetComponent<Renderer>().material.color=wybierzkolor(2);
				kloc=new klocek(3,3,175,165,155,156);
			}
			else
				koniec_gry();
			break;
			case 3:
			/*K*/
			/*K*/
			/*KK*/
			if ((tablica[175].zajete==0)&&(tablica[165].zajete==0)&&(tablica[155].zajete==0)&&(tablica[154].zajete==0))
			{
			tablica[175].kolor=3;
			tablica[175].zajete=1;
			tablica[165].kolor=3;
			tablica[165].zajete=1;
			tablica[155].kolor=3;
			tablica[155].zajete=1;
			tablica[154].kolor=3;
			tablica[154].zajete=1;
			pole[175].GetComponent<Renderer>().material.color=wybierzkolor(2);
			pole[165].GetComponent<Renderer>().material.color=wybierzkolor(2);
			pole[155].GetComponent<Renderer>().material.color=wybierzkolor(2);
			pole[154].GetComponent<Renderer>().material.color=wybierzkolor(2);
			kloc=new klocek(3,4,175,165,155,154);
			}
			else
				koniec_gry();
			break;
			case 4:
			/* K*/
			/*KK*/
			/* K*/
			if ((tablica[175].zajete==0)&&(tablica[165].zajete==0)&&(tablica[166].zajete==0)&&(tablica[155].zajete==0))
			{
			tablica[175].kolor=4;
			tablica[175].zajete=1;
			tablica[165].kolor=4;
			tablica[165].zajete=1;
			tablica[166].kolor=4;
			tablica[166].zajete=1;
			tablica[155].kolor=4;
			tablica[155].zajete=1;
			pole[175].GetComponent<Renderer>().material.color=wybierzkolor(3);
			pole[165].GetComponent<Renderer>().material.color=wybierzkolor(3);
			pole[166].GetComponent<Renderer>().material.color=wybierzkolor(3);
			pole[155].GetComponent<Renderer>().material.color=wybierzkolor(3);
			kloc=new klocek(4,5,175,165,166,155);
			}
			else
				koniec_gry();
			break;
			case 5:
			/* KK*/
			/*  KK*/
			if ((tablica[175].zajete==0)&&(tablica[176].zajete==0)&&(tablica[165].zajete==0)&&(tablica[164].zajete==0))
			{
			tablica[175].kolor=5;
			tablica[175].zajete=1;
			tablica[176].kolor=5;
			tablica[176].zajete=1;
			tablica[165].kolor=5;
			tablica[165].zajete=1;
			tablica[164].kolor=5;
			tablica[164].zajete=1;
			pole[175].GetComponent<Renderer>().material.color=wybierzkolor(4);
			pole[176].GetComponent<Renderer>().material.color=wybierzkolor(4);
			pole[165].GetComponent<Renderer>().material.color=wybierzkolor(4);
			pole[164].GetComponent<Renderer>().material.color=wybierzkolor(4);
			kloc=new klocek(5,6,175,176,165,164);
			}
			else
				koniec_gry();
			break;
			case 6:
			/*  KK */
			/* KK*/
			if ((tablica[175].zajete==0)&&(tablica[174].zajete==0)&&(tablica[166].zajete==0)&&(tablica[165].zajete==0))
			{
			tablica[175].kolor=5;
			tablica[175].zajete=1;
			tablica[174].kolor=5;
			tablica[174].zajete=1;
			tablica[165].kolor=5;
			tablica[165].zajete=1;
			tablica[166].kolor=5;
			tablica[166].zajete=1;
			pole[175].GetComponent<Renderer>().material.color=wybierzkolor(4);
			pole[174].GetComponent<Renderer>().material.color=wybierzkolor(4);
			pole[165].GetComponent<Renderer>().material.color=wybierzkolor(4);
			pole[166].GetComponent<Renderer>().material.color=wybierzkolor(4);
			kloc=new klocek(5,7,175,174,165,166);
			}
			else
				koniec_gry();
			break;
		}
	}
	void koniec_gry()
	{
		if (rekord<punkty)
		{
			rekord=punkty;
			punkty=0;
			rekord_p.text=rekord.ToString();
		}
		koniec_gry_=1;
		komunikat.text="Koniec gry.Wcisnij spacje";
	}
	Color wybierzkolor(int kolor)
	{
		Color kolorek1;
		switch(kolor)
		{
		case 0: 
			kolorek1=Color.green;		
			break;
		case 1:
			kolorek1=Color.red;
			break;
		case 2:
			kolorek1=Color.black;	
			break;
		case 3: 
			kolorek1=Color.blue;	
			break;
		case 4:
			kolorek1=Color.yellow;
			break;
		case 5:
			kolorek1=Color.cyan;	
			break;
		case 6:
			kolorek1=Color.magenta;	
			break;
		default:
			kolorek1=new Color(255.0F, 0.3F, 0.4F, 1F);
			break;
		}
		return kolorek1;
	}
}
