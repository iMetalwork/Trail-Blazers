using UnityEngine;
using System.Collections;

public class BlastSkill : MonoBehaviour {

    
    Transform player;
    public Boundaries bounds;
    Rigidbody2D blastbody;
    EnemyHealth enemyhealth;
    Vector3 pos;
    
    public float speed;
    GameObject[] enemies;
    public int damage;
    float timer;
    // Use this for initialization
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        blastbody = GetComponent<Rigidbody2D>();

        enemyhealth = GetComponent<EnemyHealth>();

    }

    void Start()
    {
        bounds = GameObject.Find("Boundaries").GetComponent<Boundaries>();
    }

    void Update()
    {
       
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
         Attack();
        

    }
    // Update is called once per frame
    void FixedUpdate()
    {
        pos = transform.position;

        if (pos.x > bounds.upperRight.x)
        {
           blastbody.velocity = new Vector2(speed, 0);
        }

        if (pos.x > bounds.lowerLeft.x)
        {
            Destroy(gameObject);
        }

    }

  
    void Attack()
    {
        
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<EnemyHealth>().SkillRange() && enemies[i].GetComponent<EnemyHealth>().currenthealth > 0 )
            {
                enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);

            }
        }
    }
}
