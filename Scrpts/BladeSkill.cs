using UnityEngine;
using System.Collections;

public class BladeSkill : MonoBehaviour {

   
    Transform player;
    public Boundaries bounds;
    Rigidbody2D bladebody;
    EnemyHealth enemyhealth;
    Vector3 pos;
   
    bool playerinrange;
    public float speed;
    GameObject[] enemies;
    public int damage;
    float timer;

    // Use this for initialization
    void Awake () {
		playerinrange = false;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        bladebody = GetComponent<Rigidbody2D>();
        
        enemyhealth = GetComponent<EnemyHealth>();
      
    }

    void Start()
    {
        bounds = GameObject.Find("Boundaries").GetComponent<Boundaries>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        
        pos = transform.position;

        if (pos.x > bounds.upperRight.x)
        {
            if (playerinrange == true)
            {
                Destroy(gameObject);
            }
            else
            {
                bladebody.velocity = new Vector2(speed, 0);
            }

        }
        else
        {
           
            Destroy(gameObject);
            
        }

        if (pos.x > bounds.lowerLeft.x)
        {
            speed = -9;
            transform.position = pos;
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

    void Update()
    {
        
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); 
        Attack(); 
    }

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player")
		{
			playerinrange = true;
		}
	}
}

