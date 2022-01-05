using UnityEngine;
using System.Collections;
using System;
public class obiektkulka
{
	public int kolor;
	public int positionx;
	public int positionz;
	public int number;
	public int zajete;
	public obiektkulka(int x,int z,int number_,int zajete_,int kolor_)
	{
		positionx=x;
		positionz=z;
		number=number_;
		zajete=zajete_;
		kolor=kolor_;
	}
		
}
public class Starter : MonoBehaviour {

	public GameObject sphere;
	public GameObject aktualnakulka;
	public GameObject[] kulka=new GameObject[81];
	private Vector3 pozycja;

	private int pozycjax,pozycjaz,licznik;

	public obiektkulka[] tablica=new obiektkulka[81];
	public int[] dozniszczenia=new int[81];
	private int numer,licznikkulek,wylosowanykolor;
	private Color kolorek;
	public int numeraktualny;
	public int punkty=0;
	public int rekord=0;
	public GUIText licznik_punktow;
	public GUIText pole_rekord;
	public GUIText komunikat;
	
	public int koniec_gry=0;

	void Start () 
	{
		licznik=0;
		licznikkulek=0;

		for (int i=0;i<9;i++)
		{
			for (int j=0;j<9;j++)
			{
				tablica[licznik]=new obiektkulka(i-4,j-2,licznik,0,-1);
			
				licznik++;
			}
		}
	
		losuj_trzy();
		
   	}
	
	// Update is called once per frame
	void Update () {

		if (koniec_gry==1)
		{
			if (Input.GetButtonUp("Jump"))
			{
				nowa_gra();
				

			}
		}
	}
	public void nowa_gra()
	{
		koniec_gry=0;
		punkty=0;
		komunikat.SendMessage("Wyswietl","");
		licznik_punktow.SendMessage("Wyswietl",punkty);
		for (int i=0;i<81;i++)
		{

				tablica[i].kolor=-1;
				tablica[i].zajete=0;
				Destroy(kulka[i]);
				licznikkulek--;
		}	
		
		licznik=0;
	
		for (int i=0;i<9;i++)
		{
			for (int j=0;j<9;j++)
			{
				tablica[licznik]=new obiektkulka(i-4,j-2,licznik,0,-1);
			
				licznik++;
			}
		}
		losuj_trzy();
		
	}
	public void nowa_gra_2()
	{
		koniec_gry=0;
		punkty=0;
		komunikat.SendMessage("Wyswietl","");
		licznik_punktow.SendMessage("Wyswietl",punkty);
		for (int i=0;i<81;i++)
		{

				if (tablica[i].zajete==1)	
					Destroy(kulka[i]);
				tablica[i].kolor=-1;
				tablica[i].zajete=0;
				
		}	
		licznikkulek=0;
		licznik=0;

		for (int i=0;i<9;i++)
		{
			for (int j=0;j<9;j++)
			{
				tablica[licznik]=new obiektkulka(i-4,j-2,licznik,0,-1);

				licznik++;
			}
		}
		losuj_trzy();
		
	}
	public void losuj_trzy()
	{
			int counter=0;
			int help=0;
			while (counter<3 && licznikkulek<81)
			{
			DateTime now=DateTime.Now;

			UnityEngine.Random.seed=(now.Second+now.Minute+now.Millisecond);
			numer=UnityEngine.Random.Range (0,81);

			while ((tablica[numer].zajete!=0) && (licznikkulek<81))
			{

				numer=UnityEngine.Random.Range(0,81);
			
			}
			if (tablica[numer].zajete==0)
			{

				wylosowanykolor=UnityEngine.Random.Range(0,7);

				pozycjax=tablica[numer].positionx;
				pozycjaz=tablica[numer].positionz;
				tablica[numer].zajete=1;
				tablica[numer].kolor=wylosowanykolor;
				licznikkulek++;
		
				kulka[numer]=Instantiate (sphere, new Vector3(pozycjax, 1.5F, pozycjaz), Quaternion.identity) as GameObject;
				kulka[numer].GetComponent<Renderer>().material.color = wybierzkolor (wylosowanykolor);
			
				help=liczpunkty(numer,1);
				counter++;
			}
	
			}
		if (licznikkulek>=81)
		{
			if (punkty>rekord)
			{
				rekord=punkty;	
			}
			pole_rekord.SendMessage("Wyswietl",rekord);
			koniec_gry=1;
			komunikat.SendMessage("Wyswietl","Koniec gry.Wcisnij spacje");
		}
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
	public int Znajdznumer(float x,float z,int zmien)
	{
		for (int i=0;i<81;i++)
		{
			if ((tablica[i].positionx==x) && (tablica[i].positionz==z))
			{

				if (zmien!=0)
				{
					numeraktualny=i;
				}
				return i;
			}
		}
		return -1;
	}
	public int liczpunkty(int n,int option)
	{

		int licznikpion=0;
		int licznikpoziom=0;
		int licznikskosl=0;
		int licznikskosp=0;
		int lp=0;
		int przerwij=0;
		int dodajpunkty=0;
		int kolorek;
		kolorek=tablica[n].kolor;
		lp=n;
		for (int i=0;i<81;i++)
		{
			dozniszczenia[i]=0;
		}

		while(true)
		{
			if (lp<81)
			{
			
				if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
				{
					licznikpion++;

				}
				else 
					break;
			
			}
			else
				break;
			if (przerwij==1)
				break;
			if ((lp%9)==7)
			{
				przerwij=1;

			}
			if ((lp%9)==8)
			{
			
				break;	
			}
			lp++;
		}
		przerwij=0;
	
		//liczenie w dol
		lp=n;
		
		while(true)
		{

			if ((lp!=n) && (lp>-1))
			{

				if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
				{
					licznikpion++;
				
				}
				else 
					break;

			}
			if (przerwij==1)
				break;
			if ((lp%9)==1)
			{
				przerwij=1;

			}
			if ((lp%9)==0)
			{

				break;	
			}
			lp--;
		}

		przerwij=0;

		if (licznikpion>=5)
		{
			//liczenie w gore
			lp=n;
			while(true)
			{
				if (lp<81)
				{
					if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
					{

						dozniszczenia[lp]=1;
					}
					else 
					{

						break;
					}
				}
				else
					break;
				if (przerwij==1)
					break;
				if ((lp%9)==7)
				{
					przerwij=1;
					
				}
				if ((lp%9)==8)
				{
					
					break;	
				}
				lp++;
			}
			przerwij=0;
			
			//liczenie w dol
			lp=n;
			
			while(true)
			{
				
				if ((lp!=n) && (lp>-1))
				{
					
					if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
					{
						dozniszczenia[lp]=1;
					}
					else 
						break;
					
				}
				if (przerwij==1)
					break;
				if ((lp%9)==1)
				{
					przerwij=1;
				}
				if ((lp%9)==0)
				{
					break;	
				}
				lp--;
			}
							
		}
		
		//liczenie w prawo
		lp=n;
		while(true)
		{
			if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
			{
				licznikpoziom++;
			
			}
			else 
				break;
			if (lp>=72)
				break;
			lp=lp+9;
		}
		//liczenie w lewo
		lp=n;
		while(true)
		{
			if (lp!=n)
			{
				if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
				{
					licznikpoziom++;

				}
				else 
					break;
			}
			if (lp<9)
				break;
			lp=lp-9;
		}

		//zaznaczenie do znisczenia
		if (licznikpoziom>=5)
		{
			//liczenie w lewo
			lp=n;
			while(true)
			{
				if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
				{
					dozniszczenia[lp]=1;
				}
				else 
					break;
				if (lp>=72)
					break;
				lp=lp+9;
			}
			//liczenie w lewo
			lp=n;
			while(true)
			{
				if (lp!=n)
				{
					if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
					{
						dozniszczenia[lp]=1;
					}
					else 
						break;
				}
				if (lp<9)
					break;
				lp=lp-9;
			}
				
		}
		
		//liczenie w lewo dol
		lp=n;
		while(lp>-1)
		{
			if ((lp>-1)&& (lp<81))
			{
				if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
				{	
					licznikskosl++;

				}
				else 
					break;
			}
			if ((lp%9==0) || (lp<9))
			{
				break;
			}
			lp=lp-10;
		}
		lp=n;
		//liczenie w prawo gora
		while(lp<81)
		{
			if ((lp!=n)&& (lp>-1) &&(lp<81))
			{
				if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
				{	
					licznikskosl++;

				}
				else 
					break;
			}
			if (((lp%9)==8) || (lp>=72))
				break;
			lp=lp+10;
		}
	
		//niszczenie lewy skos
		
		if (licznikskosl>=5)
		{
			lp=n;
			while(lp>-1)
			{
				if ((lp>-1)&& (lp<81))
				{
					if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
					{	
						dozniszczenia[lp]=1;
					}
					else 
						break;
				}
				if ((lp%9==0) || (lp<9))
				{
					break;
				}
				lp=lp-10;
			}
			lp=n;
		//liczenie w prawo gora
			while(lp<81)
			{
				if ((lp!=n)&& (lp>-1) &&(lp<81))
				{
					if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
					{	
						dozniszczenia[lp]=1;
					}
					else 
						break;
				}
				if (((lp%9)==8) || (lp>=72))
					break;
				lp=lp+10;
			}
		
		}
		
		//liczenie w prawy skos
		//liczenie w lewo gora
		lp=n;
		while(lp>-1)
		{
			if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
			{
				licznikskosp++;
			
			}
			else 
				break;
			if (((lp%9)==8) || (lp<9))
				break;
			lp=lp-8;
		}
		lp=n;
		//liczenie w prawo dol
		while(lp<81)
		{
			if (lp!=n)
			{
				if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
				{
					licznikskosp++;
				
				}
				else 
					break;
			}
			if ((lp>71) && ((lp%9)==8))
				break;
			lp=lp+8;
		}

		
		if (licznikskosp>=5)
		{
			lp=n;
			while(lp>-1)
			{
				if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
				{
					dozniszczenia[lp]=1;
				}
				else 
					break;
				if (((lp%9)==8) || (lp<9))
					break;
				lp=lp-8;
			}
			lp=n;
			//liczenie w prawo dol
			while(lp<81)
			{
				if (lp!=n)
				{
					if ((tablica[lp].kolor==kolorek) && (tablica[lp].kolor!=-1))
					{
						dozniszczenia[lp]=1;
					}
					else 
						break;
				}
				if ((lp>71) && ((lp%9)==8))
					break;
				lp=lp+8;
			}
		
		}
		
		if (licznikpion>=5)
		{
			punkty=punkty+licznikpion;
			dodajpunkty=1;
		}
		if (licznikpoziom>=5)
		{
			punkty=punkty+licznikpoziom;
			dodajpunkty=1;
		}
		if (licznikskosl>=5)
		{
			punkty=punkty+licznikskosl;
			dodajpunkty=1;
		}
		if (licznikskosp>=5)
		{
			punkty=punkty+licznikskosp;
			dodajpunkty=1;
		}
	
		licznik_punktow.SendMessage("Wyswietl",punkty);
		if (dodajpunkty==1)
		{

			if (option==1)
			{
				for (int i=0;i<81;i++)
				{
				
					if (dozniszczenia[i]==1)
					{
						tablica[i].kolor=-1;
						tablica[i].zajete=0;
					
						Destroy(kulka[i]);
						licznikkulek--;
						
					}
				}
			}
			else
				StartCoroutine("niszczenie");
			return 1;
		}
		else
		{

			return 0;
		}
	}
	IEnumerator niszczenie()
	{
	
		yield return new WaitForSeconds(0.5f);
		for (int i=0;i<81;i++)
		{

			if (dozniszczenia[i]==1)
			{
				tablica[i].kolor=-1;
				tablica[i].zajete=0;
				Destroy(kulka[i]);
				licznikkulek--;
				
			}
		}	

	}
}
