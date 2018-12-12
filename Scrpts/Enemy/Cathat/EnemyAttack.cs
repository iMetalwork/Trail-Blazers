using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour {

    GameObject player;
    Animator anim;

    Playerhealth playerhealth;
    EnemyHealth enemyhealth;
    
    public float timebetweenattacks = 5f;
    
    float timer;
    public float damage = 5f;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<Playerhealth>();
        enemyhealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();


    }

    

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= timebetweenattacks && enemyhealth.InRange() && enemyhealth.currenthealth > 0)
        {
            
            anim.SetTrigger("IsAttacking");
             Attack();
            


        }

    }

    void Attack()
    {
        timer = 0f;
        //anim.Play("Cathat_Attack");
       
        if(playerhealth.currenthealth > 0)
         {
             playerhealth.TakeDamage(damage);
          }
       
    }

   
}
