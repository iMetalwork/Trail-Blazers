using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Skillbar : MonoBehaviour {

    private float fillAmount;
    BladerAttack attack;
    GameObject player;

    public Image skill;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attack = player.GetComponent<BladerAttack>();
    }



    // Update is called once per frame
    void Update()
    {
        BarHandler();
    }

    private void BarHandler()
    {
		skill.fillAmount = FillHandler(attack.skill1.GetSkillTimer(), attack.skill1.GetCooldown(), 0f);
    }

    private float FillHandler(float value, float maxHealth, float minHealth)
    {
        return (value - 0f) * (1f - 0f) / (maxHealth - minHealth) + 0f;
    }
}
