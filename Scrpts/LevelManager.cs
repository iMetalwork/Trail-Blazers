using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public Boundaries bounds;
    public GameObject[] enemies;
    public CharacterSelect choice;
    int random;
    public int level;
    public float[] timer;
    
    [SerializeField]
    private int enemycount = 20;
    private int currentenemycount;
    [SerializeField]
    private int enemiesdestroyed = 0;
    Vector3 place;
    private bool playing = true;
    public GameObject info;
    //CharacterSelect selection;
    // Use this for initialization
    void Awake()
    {
        bounds = GameObject.Find("Boundaries").GetComponent<Boundaries>();
        currentenemycount = enemycount;
        info = GameObject.Find("Selectmanager");
        DontDestroyOnLoad(info);
        choice = info.GetComponent<CharacterSelect>();
        Instantiate(choice.character[choice.getSelected()]);
        
        
    }

    
    // Update is called once per frame
    void Update()
    {
       
        for (int i = 0; i < timer.Length; i++)
        {
            timer[i] += Time.deltaTime;
        }


            Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].GetComponent<BeetleController>().spawntimer <= timer[i] && playing && currentenemycount > 0)
            {
                place = new Vector3(bounds.lowerLeft.x, Random.Range(bounds.lowerLeft.y, bounds.upperRight.y), 0.0f);
                timer[i] = 0.0f;
                enemies[i].transform.position = place;
                Instantiate(enemies[i]);
                currentenemycount--;
            }
        }
        
        
    }

    public bool LevelCheck()
    {
        if (enemiesdestroyed == enemycount)
        {
            return true;
        }
        return false;
    }

    public int getLevel()
    {
        return level;
    }


    public void DestroyIncrement()
    {
        enemiesdestroyed++;   
    }

    public void Notplaying()
    {
      playing = false;
    }

}
