using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightGurukunMove : MonoBehaviour {
    Transform Mytransform;
    Vector2 pos;

    float Xpos = 0.15f;
    float Ypos = 0.21f;
    float Mii = 0.004f;

    float time = 0;
    // Use this for initialization
    void Start () {

        Mytransform = this.transform;
        pos = Mytransform.position;
    }

    // Update is called once per frame
    void Update () {
        Move();
        DltTime(5);
	}

    private void Move()
    {
        pos.x -= Xpos;
        pos.y += Ypos;
        if(Ypos > 0)
        {
            Ypos -= Mii;
        }
        else if (Ypos <= 0)
        {
            Ypos -= Mii * 0.5f;
        }

        Mytransform.position = pos;
    }

    private void DltTime(int T)
    {
        time += Time.deltaTime;
        if (time > T)
        {
            Destroy(this.gameObject);
        }
    }
}
