using UnityEngine;
using System.Collections;

public class Pole : MonoBehaviour {

	private Starter s;
	private ruchkulki rs;
	private int numer;
	private int mozna;
	private int[] dosprawdzenia=new int[81];
	public GUIText komunikat;
	// Use this for initialization
	void Awake()
	{

		s=GameObject.FindGameObjectWithTag("GameController").GetComponent<Starter>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseDown()
	{

		if (s.numeraktualny!=-1)
		{

			numer=s.Znajdznumer(this.transform.position.x,this.transform.position.z,0);

			if (numer>-1)
			{

				
				if (s.tablica[numer].zajete==0)
				{
					mozna=sprawdz_droge(s.numeraktualny,numer);
					if (mozna==0)
					{
						komunikat.SendMessage("Wyswietl","Ruch niemozliwy");
				
						return;
					}
					komunikat.SendMessage("Wyswietl","");
					s.aktualnakulka.transform.position=new Vector3(this.transform.position.x, 1.5F, this.transform.position.z);//this.transform.position.x;

					s.tablica[s.numeraktualny].zajete=0;
					s.tablica[numer].zajete=1;
					s.tablica[numer].kolor=s.tablica[s.numeraktualny].kolor;
					s.tablica[s.numeraktualny].kolor=-1;
					s.kulka[s.numeraktualny]=null;
					s.kulka[numer]=s.aktualnakulka;
					s.numeraktualny=-1;
					
					if (s.liczpunkty(numer,0)==0)
					{
						s.losuj_trzy();
						rs=s.aktualnakulka.GetComponent<ruchkulki>();
						rs.zmieniaj=false;
					}
				}
			}
		}
	}
	int sprawdz_droge(int tu,int tam)
	{
		int result;
		result=0;

		for (int i=0;i<81;i++)
		{
			dosprawdzenia[i]=0;	
		}
		if (tu<tam)
		{
			if ((tu%9)<(tam%9))
			{
				if ((tu%9)!=8) //up
				result=sprawdz_pole(tu+1,tam);
				if (result!=1) //right
				{
					if (tu<72) 
						result=sprawdz_pole(tu+9,tam);
				}
				if (result!=1) //down
				{
					if ((tu%9)!=0) 
						result=sprawdz_pole(tu-1,tam);
				}
				if (result!=1)
				{
					if (tu>9) //left
						result=sprawdz_pole(tu-9,tam);
				}
			}
			else if ((tu%9)==(tam%9))
			{
				//right
				if (tu<72) 
					result=sprawdz_pole(tu+9,tam);
				//up
				if (result!=1)
				{
					if ((tu%9)!=8) //up
						result=sprawdz_pole(tu+1,tam);
				}
				if (result!=1) //down
				{
					if ((tu%9)!=0) 
						result=sprawdz_pole(tu-1,tam);
				}
				if (result!=1)
				{
					if (tu>9) //left
						result=sprawdz_pole(tu-9,tam);
				}
			}
			else
			{
				if ((tu%9)!=0) //down
					result=sprawdz_pole(tu-1,tam);
				if (result!=1) //right
				{
					if (tu<72) 
						result=sprawdz_pole(tu+9,tam);
				}
					//up
				if (result!=1)
				{
					if ((tu%9)!=8) //up
						result=sprawdz_pole(tu+1,tam);
				}
				if (result!=1)
				{
					if (tu>9) //left
						result=sprawdz_pole(tu-9,tam);
				}
			}
		}
		else
		{
			if ((tu%9)<(tam%9))
			{
				if ((tu%9)!=8) //up
				result=sprawdz_pole(tu+1,tam);
				if (result!=1)
				{
					if (tu>9) //left
						result=sprawdz_pole(tu-9,tam);
				}
				if (result!=1) //down
				{
					if ((tu%9)!=0) 
						result=sprawdz_pole(tu-1,tam);
				}
				if (result!=1) //right
				{
					if (tu<72) 
						result=sprawdz_pole(tu+9,tam);
				}
				
				
			}
			else if ((tu%9)==(tam%9))
			{
				if (tu>9) //left
						result=sprawdz_pole(tu-9,tam);

				//up
				if (result!=1)
				{
					if ((tu%9)!=8) //up
						result=sprawdz_pole(tu+1,tam);
				}
				if (result!=1) //down
				{
					if ((tu%9)!=0) 
						result=sprawdz_pole(tu-1,tam);
				}
				if (result!=1)
				{
					if (tu<72) //right
						result=sprawdz_pole(tu+9,tam);
				}
			}
			else
			{
				if ((tu%9)!=0) //down
					result=sprawdz_pole(tu-1,tam);
				if (result!=1)
				{
					if (tu>9) //left
						result=sprawdz_pole(tu-9,tam);
				}
				//up
				if (result!=1)
				{
					if ((tu%9)!=8) //up
						result=sprawdz_pole(tu+1,tam);
				}
				if (result!=1) //right
				{
					if (tu<72) 
						result=sprawdz_pole(tu+9,tam);
				}
			}
		}
		

		if (result!=1)
			return 0;
		return 1;
	}
	int sprawdz_pole(int tu,int tam)
	{
		int result;
		result=0;
		if (s.tablica[tu].zajete==1)
		{
			dosprawdzenia[tu]=1;
			return 0;
		}
		if (tu==tam)
		{
			dosprawdzenia[tu]=2;
			return 1;
		}
		dosprawdzenia[tu]=3;

		
		if (tu<tam)
		{
			if ((tu%9)<(tam%9))
			{
				if ((tu%9)!=8) //up
				{	
					if (dosprawdzenia[tu+1]==0)
						result=sprawdz_pole(tu+1,tam);
				}
				if (result!=1) //right
				{
					if (tu<72) 
					{
						if (dosprawdzenia[tu+9]==0)		
							result=sprawdz_pole(tu+9,tam);
					}
				}
				if (result!=1) //down
				{
					if ((tu%9)!=0) 
					{
						if (dosprawdzenia[tu-1]==0)
						result=sprawdz_pole(tu-1,tam);
					}
				}
				if (result!=1)
				{
					if (tu>9) //left
					{
						if (dosprawdzenia[tu-9]==0)
							result=sprawdz_pole(tu-9,tam);
					}
				}
			}
			else if ((tu%9)==(tam%9))
			{
				//right
				if (tu<72) 
				{
					if (dosprawdzenia[tu+9]==0)
						result=sprawdz_pole(tu+9,tam);
				}
					//up
				if (result!=1)
				{
					if ((tu%9)!=8) //up
					{
						if (dosprawdzenia[tu+1]==0)
							result=sprawdz_pole(tu+1,tam);
					}
				}
				if (result!=1) //down
				{
					if ((tu%9)!=0)
					{
						if (dosprawdzenia[tu-1]==0)
							result=sprawdz_pole(tu-1,tam);
					}
				}
				if (result!=1)
				{
					if (tu>9) //left
					{
						if (dosprawdzenia[tu-9]==0)
						result=sprawdz_pole(tu-9,tam);
					}
				}
			}
			else
			{
				if ((tu%9)!=0) //down
				{
					if (dosprawdzenia[tu-1]==0)
						result=sprawdz_pole(tu-1,tam);
				}
				if (result!=1) //right
				{
					if (tu<72)
					{
						if (dosprawdzenia[tu+9]==0)
							result=sprawdz_pole(tu+9,tam);
					}
				}
					//up
				if (result!=1)
				{
					if ((tu%9)!=8) //up
					{
						if (dosprawdzenia[tu+1]==0)
							result=sprawdz_pole(tu+1,tam);
					}
				}
				if (result!=1)
				{
					if (tu>9) //left
					{
						if (dosprawdzenia[tu-9]==0)
						result=sprawdz_pole(tu-9,tam);
					}
				}
			}
		}
		else
		{
			if ((tu%9)<(tam%9))
			{
				if ((tu%9)!=8) //up
				{
					if (dosprawdzenia[tu+1]==0)
						result=sprawdz_pole(tu+1,tam);
				}
				if (result!=1)
				{
					if (tu>9) //left
					{
						if (dosprawdzenia[tu-9]==0)
							result=sprawdz_pole(tu-9,tam);
					}
				}
				if (result!=1) //down
				{
					if ((tu%9)!=0)
					{
						if (dosprawdzenia[tu-1]==0)
							result=sprawdz_pole(tu-1,tam);
					}
				}
				if (result!=1) //right
				{
					if (tu<72)
					{
						if (dosprawdzenia[tu+9]==0)
							result=sprawdz_pole(tu+9,tam);
					}
				}
				
				
			}
			else if ((tu%9)==(tam%9))
			{
				if (tu>9) //left
				{
					if (dosprawdzenia[tu-9]==0)
						result=sprawdz_pole(tu-9,tam);
				}
				//up
				if (result!=1)
				{
					if ((tu%9)!=8) //up
					{
						if (dosprawdzenia[tu+1]==0)
							result=sprawdz_pole(tu+1,tam);
					}
				}
				if (result!=1) //down
				{
					if ((tu%9)!=0)
					{
						if (dosprawdzenia[tu-1]==0)
							result=sprawdz_pole(tu-1,tam);
					}
				}
				if (result!=1)
				{
					if (tu<72) //right
					{
						if (dosprawdzenia[tu+9]==0)
							result=sprawdz_pole(tu+9,tam);
					}
				}
			}
			else
			{
				if ((tu%9)!=0) //down
				{
					if (dosprawdzenia[tu-1]==0)
					result=sprawdz_pole(tu-1,tam);
				}
				if (result!=1)
				{
					if (tu>9) //left
					{
						if (dosprawdzenia[tu-9]==0)
							result=sprawdz_pole(tu-9,tam);
					}
				}
				//up
				if (result!=1)
				{
					if ((tu%9)!=8) //up
					{
						if (dosprawdzenia[tu+1]==0)
							result=sprawdz_pole(tu+1,tam);
					}
				}
				if (result!=1) //right
				{
					if (tu<72)
					{
						if (dosprawdzenia[tu+9]==0)
							result=sprawdz_pole(tu+9,tam);
					}
				}
			}
		}
		dosprawdzenia[tu]=1;
		if (result!=1)
			return 0;
		return 1;
	}
}
