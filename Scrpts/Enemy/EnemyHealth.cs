using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
    public float health;
    public float currenthealth;
    public float healamount;
    public bool playerinrange;
    public bool skillinrange;
    private GameObject lmanager;
    private LevelManager manager;

    Animator anim;

	// Use this for initialization
	void Awake () {

        anim = GetComponent<Animator>();
        currenthealth = health;
        lmanager = GameObject.FindGameObjectWithTag("GameController");
        manager = lmanager.GetComponent<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}

   public void TakeDamage(float damage)
    {
        
        anim.SetTrigger("IsHit");
        
        currenthealth -= damage;
        
        if (currenthealth <= 0)
        {
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerinrange = true;
        }
        else if(other.gameObject.tag == "Skill")
        {
            skillinrange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerinrange = false;
        }
        else if (other.gameObject.tag == "Skill")
        {
            skillinrange = false;
        }
    }
    public bool InRange()
    {
        if (playerinrange == true)
        {
            return true;
        }

        return false;
    }

    public bool SkillRange()
    {
        if (skillinrange == true)
        {
            return true;
        }

        return false;
    }

    public void Heal()
    {
        currenthealth += healamount;
    }

    void Death()
    {
        anim.SetTrigger("Dead");
        Destroy (gameObject, 1f);
        manager.DestroyIncrement();
    }



}
