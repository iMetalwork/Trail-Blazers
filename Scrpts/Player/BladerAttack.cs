using UnityEngine;
using System.Collections;

public class BladerAttack : MonoBehaviour {

    Vector3 pos;
    public Skill skill1;
    public Skill skill2;
    public Animator anim;
    int tap = 0;
    private bool isAttacking;
    public float timer, timer2;
	private bool isAnimating = false;
   
    
    public float timeBetweenAttacks = .15f;
    private float comboTimer = 5f;
	[SerializeField]
    private int damage1;
    private int damage2;
    private int damage3;
    private bool enemyinrange;
    private float magic = 100f;
    private float currentmagic;
    
    
    GameObject[] enemies;
    
    public GameObject sprite1;
    public GameObject sprite2;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        currentmagic = magic;
        skill1 = sprite1.GetComponent<Skill>();
        skill2 = sprite2.GetComponent<Skill>();

    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
		timer2 += Time.deltaTime;
		skill1.setSkillTimer( Time.deltaTime);
		skill2.setSkillTimer( Time.deltaTime);

        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        Magicincrement();
		if (isAnimating == false)
		{
			IsAttacking ();
		}

		if(timer2 % 5f == 0f)
		{
			Debug.Log("isAnimating = " + isAnimating);
			Debug.Log("isAttacking = " + isAttacking);
		}
	}

    void FixedUpdate()
    {

        pos = transform.position;
    }
	//find out if the player is attacking or not
    void IsAttacking()
    {
      //checks if the attack button has been pressed 
        if (Input.GetButtonUp("Fire1") && timer > timeBetweenAttacks)
        {
			isAnimating = true;
            anim.SetBool("IsAttacking", true);
			Debug.Log ("IsAttacking = true");
			isAttacking = true;
            Attack();

        }
		// reset combo timer if player waits to long to attack
        else if(timer > comboTimer)
        {
            
            anim.SetBool("IsAttacking", false);
			isAttacking = false;
			//Debug.Log("IsAttacking = false");
            tap = 0;

        }
		//check if skill1 button has been pressed 
        else if (Input.GetButtonUp("Fire2") && skill1.IsActive() && currentmagic >= skill1.GetCost())
        {
            SpecialAttack(1);
            Magicdecrement(skill1.GetCost());
            tap = 0;
        }
		//check if skill2 button has been pressed 
        else if (Input.GetButtonUp("Fire3") && skill2.IsActive() && currentmagic >= skill2.GetCost())
        {
            SpecialAttack(2);
            Magicdecrement(skill2.GetCost());
            tap = 0;
        }

    }
	//the attack function called if damage is dealt
    void Attack()
    {
		//reset the combo timer to start the attack string  
        timer = 0f;
        switch (tap)
        {
		case 0:
			//start the animation for the first attack
			anim.SetTrigger ("Attack1");
               // anim.Play("Blader_Attack01");
               // anim.ResetTrigger("Attack1");
			Debug.Log ("Attack1");
               
               
			Debug.Log ("Tap increment");
			    tap += 1;
                break;
                
            case 1:
                anim.SetTrigger("Attack2");
                // anim.Play("Blader_Attack02");
                // anim.ResetTrigger("Attack2");
			Debug.Log("Attack2");
			Debug.Log ("Tap increment");
			    tap += 1;
                break;

            case 2:
                anim.SetTrigger("Attack3");
                //anim.Play("Blader_Attack03");
                // anim.ResetTrigger("Attack3");
			Debug.Log("Attack3");
			Debug.Log ("Tap reset");
                tap = 0;
                break;

        }

       
    }

	void Dealdamage(int damage)
	{
		//checks for the enemies in range of the attack and deals damage only to the ones within range
		for (int i = 0; i < enemies.Length; i++)
		{
			if (enemies[i].GetComponent<EnemyHealth>().InRange() && enemies[i].GetComponent<EnemyHealth>().currenthealth > 0)
			{
				enemies[i].GetComponent<EnemyHealth>().TakeDamage(damage);

			}
		}
	}

	void setAnimate()
	{
		isAnimating = false;
		Debug.Log("isAnimating = " + isAnimating);
	}
	//decrease the players current amount of magic 
    void Magicdecrement(float cost)
    {
        currentmagic -= cost;
    }

	//increase the players current amount of magic 
    void Magicincrement()
    {
        if (currentmagic < magic)
        {
            currentmagic += .042f;
        }
    }

	//get the current amount of magic the player has
	public float Getcurrentmagic()
	{
	
		return currentmagic;
	}

	// get the set amount of magic a player has 
	public float Getbasemagic()
	{
		return magic;
	}

	//function used to activate 
    void SpecialAttack(int skill)
    {
        switch (skill)
        {
            case 1:
			skill1.setSkillTimer(0f);
                sprite1.transform.position = pos + new Vector3(.75f, 0.45f, 0.0f);
               GameObject.Instantiate(sprite1);
                break;

            case 2:
			skill2.setSkillTimer(0f);
                anim.SetTrigger("Special2");
                sprite2.transform.position = pos + new Vector3(.75f, 0.45f, 0.0f);
                GameObject.Instantiate(sprite2);
                break;
        }
    }


}
