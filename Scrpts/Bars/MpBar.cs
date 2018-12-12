using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MpBar : MonoBehaviour {
    private float fillAmount;
    BladerAttack magic;
    GameObject player;

    [SerializeField]
    private Image mpbar;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
		magic = player.GetComponent<BladerAttack>();
    }



    // Update is called once per frame
    void Update()
    {
        BarHandler();
    }

    private void BarHandler()
    {
		mpbar.fillAmount = FillHandler(magic.Getcurrentmagic(), magic.Getbasemagic(), 0f);
    }

    private float FillHandler(float value, float maxHealth, float minHealth)
    {
        return (value - 0f) * (1f - 0f) / (maxHealth - minHealth) + 0f;
    }
}

