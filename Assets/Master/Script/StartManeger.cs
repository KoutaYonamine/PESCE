using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManeger : MonoBehaviour {
    public GameObject PesceManeger;
    public GameObject Text;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            PesceManeger.SetActive(true);
            Text.SetActive(true);
        }
    }
}
