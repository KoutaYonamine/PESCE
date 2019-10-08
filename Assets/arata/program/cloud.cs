using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloud : MonoBehaviour {
    float X = 6,Y=3;//オブジェクト初期位置
    float goal = -8; //雲の最終位置
    Transform tb;
    Vector2 pos;
	// Use this for initialization
	void Start () {
        tb = this.gameObject.transform;
        pos = tb.position;
     
    }
	
	// Update is called once per frame
	void Update () {
		Vector2 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector2(pos.x - 0.01f, pos.y);
        if (pos.x < goal)
        {
            this.gameObject.transform.position = new Vector2(X, pos.y);
            Debug.Log("そおい");
        }
	}
}
