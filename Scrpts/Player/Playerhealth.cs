using UnityEngine;
using System.Collections;

public class Playerhealth : MonoBehaviour {

    public float health;
    public float currenthealth;
    public float townhealth;
    public float currenttownhealth;
    public float healamount;
    

    

    // Use this for initialization
    void Awake()
    {

        
        currenthealth = health;
        currenttownhealth = townhealth; 
    }

    // Update is called once per frame
    void Update()
    {

    }

   public  void TakeDamage(float damage)
    {
        currenthealth -= damage;
        
    }

   public  void TownDamage(float damage)
    {
        currenttownhealth -= damage;
        
    }

    void Heal()
    {
        currenthealth += healamount;
    }

    public bool CheckPlayerHealth()
    {
        if (currenthealth <= 0)
        {
            return true;
        }
        return false;
    }

    public bool CheckTownHealth()
    {
        if (currenttownhealth <= 0)
        {
            return true;
        }
        return false;
    }
}
