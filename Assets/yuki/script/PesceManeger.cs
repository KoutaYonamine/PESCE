using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesceManeger : MonoBehaviour {

    float Count = 0;

    public GameObject[] PesceObj;
    public Vector2[] InstantiatePos;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        InstantiateTime();
	}

    void InstantiateTime()
    {
        Count += Time.deltaTime;
        if(Count > 2)
        {
            int i = Random.Range(0, 5);
            Instantiate(PesceObj[i], InstantiatePos[i], Quaternion.identity);
            Count = 0;
        }
    }
}
