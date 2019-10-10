using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailGenerator : MonoBehaviour {

    public GameObject RightTrail;
    public GameObject LeftTrail;
    public GameObject UpTrail;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject RT = Instantiate(RightTrail) as GameObject;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            GameObject LT = Instantiate(LeftTrail) as GameObject;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            GameObject UT = Instantiate(UpTrail) as GameObject;
        }

        //Destroy(gameObject, 1.0f);
        //Destroy(gameObject, 0.01f);
        //Destroy(gameObject, 0.01f);
    }
}
