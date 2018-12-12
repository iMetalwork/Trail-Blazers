using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public float scrollspeed;
    public float tilesize;

    private Vector3 startposition;

	// Use this for initialization
	void Start () {
        startposition = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {

        float newposition = Mathf.Repeat(Time.time * scrollspeed, tilesize);
        transform.position = startposition + Vector3.right * newposition;

	}
}
