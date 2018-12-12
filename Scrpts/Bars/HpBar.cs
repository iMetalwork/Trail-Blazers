using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HpBar : MonoBehaviour {

    private float fillAmount;
    Playerhealth health;
    GameObject player;

    public Image hpbar; 
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Playerhealth>();
    }

   
	
	// Update is called once per frame
	void Update ()
    {
        BarHandler();
	}

    private void BarHandler()
    {
        hpbar.fillAmount = FillHandler(health.currenthealth, health.health, 0f);
    }

    private float FillHandler(float value, float maxHealth, float minHealth)
    {
        return (value- 0f) * (1f-0f) / (maxHealth - minHealth) + 0f;
    } 
}
