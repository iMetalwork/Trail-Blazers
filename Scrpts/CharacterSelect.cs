using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class CharacterSelect : MonoBehaviour {
    public int selected;
    public GameObject[] character;

    void Awake()
    {
        GameObject info = GameObject.Find("Selectmanager");
        DontDestroyOnLoad(info);
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
  public  void setSelected(int choice)
    {
        selected = choice;
        SceneManager.LoadSceneAsync(2);
    }

    public int getSelected()
    {
        return selected;
    }
}
