using UnityEngine;
using System.Collections;

public class Skill : MonoBehaviour {

	public float skillcost;
    public float cooldown;
	private  float skilltimer;
	//skilltimer acts as a measure for how long it has been since the skill was last used
    // Use this for initialization
    void Start () {
		skilltimer = 0f;
	}
	
	// Update is called once per frame
	void Update () {
        skilltimer += Time.deltaTime;

	
    }

    public bool IsActive()
    {
		//if the amount of time since the skill was last used is greater or eaqual to its cooldown it should be usable 
        if (skilltimer >= cooldown)
        {
            return true;
        }
        return false;
    }

    public float GetCost()
    {
        return skillcost;
    }

	public float GetSkillTimer()
	{
		return skilltimer;
	}

	public  void setSkillTimer(float time)
	{
		skilltimer = time;
	}

	public float GetCooldown()
	{
		return cooldown;
	}
}
