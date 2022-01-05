using UnityEngine;
using System.Collections;

public class ruchkulki : MonoBehaviour {

	public float r,g,b,a;
	public GameObject ob1;
	public bool zaznaczone=false;
	public bool zmieniaj=false;
	public float onTime;            
    public float offTime;
	private float timer;  
	public GameObject kulkis;
	private int numer;
	private Starter s;
	// Use this for initialization
	void Awake()
	{

		s=GameObject.FindGameObjectWithTag("GameController").GetComponent<Starter>();
	}
	void Start () {
	 	
		
	}
	
	void Update ()
    {
        // Increment the timer by the amount of time since the last frame.
        if (zmieniaj && s.numeraktualny==numer)
		{
		timer += Time.deltaTime;
        
        // If the beam is on and the onTime has been reached...
        if(GetComponent<Renderer>().enabled && timer >= onTime)
            // Switch the beam.
            SwitchColor();
        
        // If the beam is off and the offTime has been reached...
        if(!GetComponent<Renderer>().enabled && timer >= offTime)
            // Switch the beam.
            SwitchColor();
		}
		else
		{
			if (this.GetComponent<Renderer>().material.color==Color.grey)
			{
				this.GetComponent<Renderer>().material.color=new Color(r, g, b, a);	
			}
			zmieniaj=false;	
		}
			
	}
    
    void SwitchColor()
	{
		timer=0f;
	
		if (zaznaczone)
		{
			this.GetComponent<Renderer>().material.color=Color.grey;
	
		}
		else
		{
			this.GetComponent<Renderer>().material.color=new Color(r, g, b, a);	
		}
		zaznaczone=!zaznaczone;
	}
	void OnMouseDown()
	{

		if (zmieniaj==false)
		{
			zaznaczone=true;
			zmieniaj=true;
		}
		r=this.GetComponent<Renderer>().material.color.r;
		g=this.GetComponent<Renderer>().material.color.g;
		b=this.GetComponent<Renderer>().material.color.b;
		a=this.GetComponent<Renderer>().material.color.a;
	
		numer=s.Znajdznumer(this.transform.position.x,this.transform.position.z,1);
		s.aktualnakulka=this.gameObject;
	
	}
}
