using UnityEngine;
using System.Collections;

public class BeetleAttack : MonoBehaviour {

    GameObject player;
    Animator anim;
   
    Playerhealth playerhealth;
    EnemyHealth enemyhealth;
    public bool playerinrange;
    public float timebetweenattacks = 3f;
    public float spellcooldown = 5f;
    public float timer;
    public float spelltimer;
    public float damage = 5f;
    
    // Use this for initialization
    void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<Playerhealth>();
        enemyhealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
        

    }

    

    // Update is called once per frame
    void Update () {

        timer += Time.deltaTime;
        spelltimer += Time.deltaTime;

        if (timer >= timebetweenattacks && enemyhealth.InRange() && enemyhealth.currenthealth > 0)
        {
            if (enemyhealth.currenthealth <= 10 && timer >= spellcooldown)
            {
            anim.SetTrigger("IsCasting");
            Cast();
            }
            else
            {
                anim.SetTrigger("IsAttacking");
                Attack();
            }
            
            
        }

	}

    void Attack()
    {
        timer = 0f;
       // anim.Play("Beetle_Attack");
        
        if(playerhealth.currenthealth > 0)
        {
            playerhealth.TakeDamage(damage);
        }
        

    }

    void Cast()
    {
        spelltimer = 0f;
       // anim.Play("Beetle_Spell");
        enemyhealth.Heal();
       
    }
}
