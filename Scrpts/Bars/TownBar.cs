using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TownBar : MonoBehaviour {

    private float fillAmount;
    Playerhealth health;
    GameObject player;

    [SerializeField]
    private Image tpbar;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        health = player.GetComponent<Playerhealth>();
    }



    // Update is called once per frame
    void Update()
    {
        BarHandler();
    }

    private void BarHandler()
    {
        tpbar.fillAmount = FillHandler(health.currenttownhealth, health.townhealth, 0.0f);
    }

    private float FillHandler(float value, float maxHealth, float minHealth)
    {
        return (value - 0f) * (1f - 0f) / (maxHealth - minHealth) + 0f;
    }
}

