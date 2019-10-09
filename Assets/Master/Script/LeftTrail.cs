using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTrail : MonoBehaviour {
    public GameObject lefttrail;
	// Use this for initialization
	void Start () {
        lefttrail = GameObject.Find("TrailLeft");
        //lefttrail.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.00f);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("うす");
            Instantiate(lefttrail);
            //lefttrail.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.00f);
            
        }
        Destroy(lefttrail, 1.0f);
    }
}
