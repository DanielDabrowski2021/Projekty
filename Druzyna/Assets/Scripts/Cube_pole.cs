using UnityEngine;
using System.Collections;

public class Cube_pole : MonoBehaviour
{

    // Use this for initialization
    private GeneratorMAPY gm;
    void Awake()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<GeneratorMAPY>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnMouseDown()
    {
        if (gm.zaznaczona_druzyna == true) 
        {
            Debug.Log("Kliknięte pole duzego terenu");
            Debug.Log("Pozycja docelowego x=" + (int)this.transform.position.x + "\n");
            Debug.Log("Pozycja docelowego z=" + (int)this.transform.position.z + "\n");
            gm.pozycjax_kliknietego = (int)this.transform.position.x;
            gm.pozycjaz_kliknietego = (int)this.transform.position.z;
            gm.zaznaczone_pole_docelowe = true;
            return;
        }
    }
}