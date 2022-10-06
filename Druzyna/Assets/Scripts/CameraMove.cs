using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	public float ZoomLevel = 2.0f;    
	public float ZoomInSpeed = 100.0f;    
	public float ZoomOutSpeed = 100.0f;    
	private float initFOV;
	//private float moveSpeed=5f;
	// Use this for initialization
	void Start () {
		initFOV = Camera.main.fieldOfView;
	}
	
	// Update is called once per frame
	//void Update () {
	//	float h = Input.GetAxis ("Horizontal");// * Time.deltaTime * moveSpeed;
	//	float v = Input.GetAxis ("Vertical");// * Time.deltaTime * moveSpeed;
		//	transform.Translate(h,40,v);
	//}
	public float range=50f;
	public GUIText textOutput;
	public float moveSpeed =100f;//2f
	
	void Update () 
	{

		
		// Update is called once per frame

			//float h=Input.GetAxis("Horizontal")*Time.deltaTime*moveSpeed;
			//float v=Input.GetAxis("Vertical")*Time.deltaTime*moveSpeed;
		    float h=Input.GetAxis("Horizontal")*moveSpeed;
		    float v=Input.GetAxis("Vertical")*moveSpeed;
			transform.Translate(h,v,0);
			if (/*Input.GetKey(KeyCode.Mouse0)*/ Input.GetAxis("Mouse ScrollWheel") > 0)
			{            
				ZoomView();        
			}
			else if (Input.GetAxis("Mouse ScrollWheel") < 0)
			{            
				ZoomOut(); 
			}

		/*
		if (Input.GetKeyDown (KeyCode.W)) 
		{
			transform.position = new Vector3(transform.position.x, 40, transform.position.z-3);
			return;
		}
		if (Input.GetKeyDown (KeyCode.S)) 
		{
			transform.position = new Vector3(transform.position.x, 40, transform.position.z+3);
			return;
		}
		if (Input.GetKeyDown (KeyCode.A)) 
		{
			transform.position = new Vector3(transform.position.x-3, 40, transform.position.z);
			return;
		}
		if (Input.GetKeyDown (KeyCode.D)) 
		{
			transform.position = new Vector3(transform.position.x+3, 40, transform.position.z);
			return;
		}
		*/	/*
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		Debug.Log ("h=" + h);
		Debug.Log ("v=" + v);
		float xPos = h * range;
		float yPos = v * range;
		Debug.Log ("xPos="+xPos);
		Debug.Log ("yPos="+yPos);
		transform.position = new Vector3(xPos, 40, yPos);
		*/
		//Debug.Log ("Horizontal Value Returned: "+h.ToString("F2")); 
		//Debug.Log ("Vertical Value Returned: " + v.ToString ("F2"));
	}
	    //private Vignetting vignette;    //public float vignetteAmount = 10.0f;
	void ZoomView()
	{        
		if (Mathf.Abs(Camera.main.fieldOfView - (initFOV / ZoomLevel)) < 0.5f)
		{           
			Camera.main.fieldOfView = initFOV / ZoomLevel;   // vignette. intensity = vignetteAmount;        
		}
		else if (Camera.main.fieldOfView - (Time.deltaTime * ZoomInSpeed) >= (initFOV / ZoomLevel))
		{            
			Camera.main.fieldOfView -= (Time.deltaTime * ZoomInSpeed);           // vignette. intensity = vignetteAmount * (Camera.main. fieldOfView - initFOV)/((initFOV / ZoomLevel) - initFOV);        
		
		}    
	}
	void ZoomOut()
	{        
		if (Mathf.Abs (Camera.main.fieldOfView - initFOV) < 0.5f) 
		{            
			Camera.main.fieldOfView = initFOV;         
		} 
		else if (Camera.main.fieldOfView + (Time.deltaTime * ZoomOutSpeed) <= initFOV) 
		{            
			Camera.main.fieldOfView += (Time.deltaTime * ZoomOutSpeed); 
		}

	}
}
