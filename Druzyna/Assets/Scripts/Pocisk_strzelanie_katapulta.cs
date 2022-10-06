using UnityEngine;
using System.Collections;

public class Pocisk_strzelanie_katapulta : MonoBehaviour {

    private float m_LifeTime = 10;
    private Rigidbody2D m_Rigidbody;
    public bool pauza = false;
    public Vector3 direction;
    Vector3 enemy_position;

    void Start()
    {
        //gameObject.GetComponent<Renderer>().sharedMaterial.color = Color.red;
        // gameObject.GetComponent<Transform>().rotation = new Quaternion(0.0f, 0.0f, 90.0f,0.0f);
        //  gameObject.transform.Rotate(0.0f, 0.0f, 90.0f); 23.05.2020
        //  gameObject.transform.Rotate(315.0f, 0.0f, 0.0f); 10.05.2020
        //direction=
        //    enemy_position = new Vector3(159.0f, 2.5f, 159.0f); 23.05.2020
        //   direction = enemy_position - transform.position; 23.05.2020
        //  Debug.DrawRay(transform.position, direction, Color.black);
        //03.05.2020 gameObject.GetComponent<Rigidbody>().velocity = new Vector2(10.0f,10.0f);//50.0f,50.0f      //gameObject.transform.localScale= new Vector3(0.5f,0.5f,0);
        Destroy(gameObject, m_LifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("o"))
        {
            pauza = !pauza;

        }
        //if ()
        if (pauza == true)
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector2(0.0f, 0.0f);
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().velocity = direction;
        }

        // }
        if (Input.GetKeyDown("z"))
        {
            gameObject.GetComponent<Rigidbody>().velocity = new Vector2(10.0f, 10.0f);
        }
        if (Input.GetKeyDown("r"))
        {
            enemy_position = new Vector3(159.0f, 4.5f, 159.0f);
            direction = enemy_position - transform.position;
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg - 90;//kat liczony dobrze ale nie na ta os?
            // float angle = Mathf.Atan2(direction.x, direction.z)*Mathf.Rad2Deg-90;
            //transform.eulerAngles = Vector3.forward * angle; 10.05.2020
            gameObject.transform.Rotate(angle, 0.0f, 0.0f);
        }
        if (Input.GetKeyDown("k"))
        {
            enemy_position = new Vector3(159.0f, 2.5f, 159.0f);
            direction = enemy_position - transform.position;
            gameObject.GetComponent<Rigidbody>().velocity = direction;
            //   Debug.DrawRay(transform.position, direction, Color.black);
            //   Debug.DrawLine(transform.position, enemy_position,Color.blue);
        }
        //gameObject.transform.Rotate(4.0f, 0.0f, 0.0f);
    }
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Trafilem collision");
        Debug.Log("Nazwa traf" + col.gameObject.name);
        Destroy(gameObject);
    }
    void OnTriggerEnter()
    {
        Debug.Log("Trafilem trigger");
    }
}
