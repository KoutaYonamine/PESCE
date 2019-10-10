using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title2 : MonoBehaviour
{

    public int MoveDirection = 1;   // 決定キー押した後にタイトルロゴが動く方向。1で右、0で左。
    public float Fadespeed = 0.3f;   // フェードインとフェードアウトにかかる時間。
    public float slideSpeed = 0.05f;  // 横にずれるアニメーションの速度

    private float Fade;
    private int State;
    private float red, green, blue, alpha;    //RGBを操作するための変数

    void Start()
    {
        Fade = 0;
        State = 0;
        red = GetComponent<SpriteRenderer>().color.r;
        green = GetComponent<SpriteRenderer>().color.g;
        blue = GetComponent<SpriteRenderer>().color.b;
        alpha = 0;
        GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
        if (MoveDirection != 1)
        {
            MoveDirection = -1;
        }
    }

    void Update()
    {
        if (State <= 0)
        {

            GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
            alpha += Fadespeed;
            if (1 <= alpha || Input.GetKeyDown(KeyCode.UpArrow))
            {
                alpha = 1;
                State = 1;
                GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
            }

        }
        else if (State == 1)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                State = 2;
            }
        }

        else if (State == 2)
        {

            GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
            alpha -= Fadespeed;
            gameObject.transform.Translate(-slideSpeed * -MoveDirection, 0, 0);
            if (alpha <= 0)
            {
                alpha = 0;
                State = 3;
                GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
            }
        }
    }

    public int GetStage()
    {
        return State;
    }
}
