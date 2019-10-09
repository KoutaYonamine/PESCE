using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashedFishMove : MonoBehaviour {

    public float XForce = 100;
    public float YForce = 350;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(new Vector2(100, 350));
    }
	
	// Update is called once per frame
	void Update () {
        if(transform.position.y <= -10)
        {
            Destroy(gameObject);
        }
    }
}
