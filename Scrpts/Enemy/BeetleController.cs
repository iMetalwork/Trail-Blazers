using UnityEngine;
using System.Collections;

public class BeetleController : MonoBehaviour {

    Transform player;
    public Boundaries bounds;
    
    EnemyHealth enemyhealth;
    Playerhealth playerhealth;
    private GameObject lmanager;
    private LevelManager manager;
    public float spawntimer;

    public float speed = -9f;
    Rigidbody2D enemybody;
    public float hmove = 0f;
     Vector3 pos;
   public bool playerinrange = false;


    void Awake ()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemybody = GetComponent<Rigidbody2D>();
        playerhealth = player.GetComponent<Playerhealth>();
        enemyhealth = GetComponent<EnemyHealth>();
        lmanager = GameObject.FindGameObjectWithTag("GameController");
        manager = lmanager.GetComponent<LevelManager>();
    }

	// Use this for initialization
	void Start () {
        bounds = GameObject.Find("Boundaries").GetComponent<Boundaries>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        pos = transform.position;

        if (pos.x > bounds.enemyline.x)
        {
            if (playerinrange == true)
            {
                enemybody.velocity = new Vector2(0, 0);
            }
            else
            {
                enemybody.velocity = new Vector2(speed, 0);
            }
           
        }
        else
        {
            playerhealth.TownDamage(enemyhealth.currenthealth);
            Destroy(gameObject);
            manager.DestroyIncrement();
        }
        if (pos.x > bounds.lowerLeft.x)
        {
            pos.x = bounds.lowerLeft.x;
            transform.position = pos;
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerinrange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerinrange = false;
        }
    }


}
