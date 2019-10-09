using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wave: MonoBehaviour {
    float X = 0;
    float movex = 0.05f;

    float time = 0;
    // Use this for initialization
    void Start () {
       

    }

    // Update is called once per frame
    void Update() {
        //Vector2 pos = this.gameObject.transform.position;
        //this.gameObject.transform.Translate(-movex, 0, 0);
        //if (pos.x <= -1f)
        //{
        //    pos.x = -1f;
        //    movex *= -1;
        //}
        //if (pos.x >= 1f)
        //{
        //    pos.x = 1f;
        //    movex *= -1;
        //}
        TimeCount();
        MoveWave();
    }

    void MoveWave()
    {
        Vector2 pos = this.gameObject.transform.position;
        this.gameObject.transform.Translate(movex, 0, 0);

    }

    void TimeCount()
    {
        time += Time.deltaTime;
        if(time > 0.5){
            movex *= -1;
            time = 0;
        }
    }
}
