using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

    private Animator anim;
    private GameObject player;
    private Playerhealth playerhealth;
    private GameObject lmanager;
    private LevelManager manager;
    

    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerhealth = player.GetComponent<Playerhealth>();
        lmanager = GameObject.FindGameObjectWithTag("GameController");
        manager = lmanager.GetComponent<LevelManager>();
        
    }
	
	// Update is called once per frame
	void Update () {
        if (playerhealth.CheckPlayerHealth() || playerhealth.CheckTownHealth())
        {
            manager.Notplaying();
            anim.SetTrigger("GameOver");
            anim.Play("GameOver");
            anim.ResetTrigger("GameOver");
        }

        if (manager.LevelCheck())
        {
            anim.SetTrigger("LevelComplete");
            
            if (manager.getLevel() < 4)
            {
                changeScene();
            }
            else
            {
                GameObject.Destroy(manager.info);
                SceneManager.LoadScene(0);
            }
            

        }
    }

  public  void changeScene()
    {
        SceneManager.LoadScene(manager.getLevel() + 1);
    }

}
