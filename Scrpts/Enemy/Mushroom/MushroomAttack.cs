using UnityEngine;
using System.Collections;

public class MushroomAttack : MonoBehaviour {
    GameObject player;
    

    Playerhealth playerhealth;
    EnemyHealth enemyhealth;
    
    public float timebetweenattacks = 5f;
    
    float timer;
    public float damage = 3f;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<Playerhealth>();
        enemyhealth = GetComponent<EnemyHealth>();
        


    }

  

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;

        if (timer >= timebetweenattacks && enemyhealth.InRange() && enemyhealth.currenthealth > 0)
        {
            Attack();



        }

    }

    void Attack()
    {
        timer = 0f;
        
        if (playerhealth.currenthealth > 0)
        {
            playerhealth.TakeDamage(damage);
        }

    }
}
