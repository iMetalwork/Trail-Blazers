using UnityEngine;
using System.Collections;

public class BladerController : MonoBehaviour {

    
    public Rigidbody2D bladerbody;
    public float speed = 10f;
    public Boundaries bounds;
    Vector3 pos;
   
    
   
    
    // Use this for initialization
    void Awake () {
        
        bladerbody = GetComponent<Rigidbody2D>();
        
	}

    void Start ()
    {
        bounds = GameObject.Find("Boundaries").GetComponent<Boundaries>();
    }
	
	// Update is called once per frame

    
	void FixedUpdate() {

        float hmove = Input.GetAxis("Horizontal");
        float vmove = Input.GetAxis("Vertical");
        pos = transform.position;

        bladerbody.velocity = new Vector2(hmove * speed, vmove * speed);

        if (pos.y > bounds.upperRight.y)
        {
            pos.y = bounds.upperRight.y;
            transform.position = pos;
        }

        if (pos.y < bounds.lowerLeft.y)
        {
            pos.y = bounds.lowerLeft.y;
            transform.position = pos;
        }

        if (pos.x < bounds.upperRight.x)
        {
            pos.x = bounds.upperRight.x;
            transform.position = pos;
        }

        if (pos.x > bounds.lowerLeft.x)
        {
            pos.x = bounds.lowerLeft.x;
            transform.position = pos;
        }

    }

   

   
}
