using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftTamanMove : MonoBehaviour
{
    Transform Mytransform;

    bool Phase = true;
    bool Add = true;

    Vector2 Pos;
    Vector2 wPos;

    float Xpos = 0.05f;
    float Ypos = 0.1f;
    float Mii = 0.002f;

    float time = 0;
    // Use this for initialization
    void Start()
    {
        Mytransform = this.transform;
        Pos = Mytransform.position;
        wPos = Pos;
    }

    // Update is called once per frame
    void Update()
    {
        if (Phase == true)
        OneMove();
        if (Phase == false)
        TwoMove();
        DltTime(5);
    }

    private void OneMove()
    {
        Pos.x += Xpos;
        Pos.y += Ypos;
        if (Pos.y > wPos.y)
        {
            Ypos -= Mii;
        }else if(Pos.y < wPos.y)
        {
            Ypos = 0;
            Xpos = 0;
            Phase = false;
        }

        Mytransform.position = Pos;
    }
    private void TwoMove()
    {
        if (Add)
        {
            Ypos = 0.32f;
            Add = false;
        }

        Pos.x += 0.04f;
        Pos.y += Ypos;
        if(Pos.y > wPos.y)
        {
            Ypos -= 0.005f;
            //Debug.Log("a");
        }
        else if(Pos.y < wPos.y)
        {

        }
        Mytransform.position = Pos;
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
