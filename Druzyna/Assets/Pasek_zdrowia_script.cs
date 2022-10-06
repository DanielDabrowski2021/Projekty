using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pasek_zdrowia_script : MonoBehaviour {

    public Sprite pasek_zielony_Texture;
    public Sprite pasek_pomaranczowy_Texture;
    public Sprite pasek_czerwony_Texture;
    private Image healthbarFilling;
    // Use this for initialization
    void Start () {
       healthbarFilling = this.GetComponent<Image>();
    }
	
	// Update is called once per frame
	void Update () {
	    if (healthbarFilling.fillAmount>0.66f)
        {
            healthbarFilling.sprite = pasek_zielony_Texture;
        }
        else if ((healthbarFilling.fillAmount > 0.33f) && (healthbarFilling.fillAmount < 0.66f))
        {
            healthbarFilling.sprite = pasek_pomaranczowy_Texture;
        }
        else
        {
            healthbarFilling.sprite = pasek_czerwony_Texture;
        }
    }
}
