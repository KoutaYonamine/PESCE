using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonController : MonoBehaviour {

    public float FlashSpeed = 0.03f;
    public float MinAlpha = 0.5f;
    private float red, green, blue, alpha;    //RGBを操作するための変数

    void Start () {
        red = GetComponent<SpriteRenderer>().color.r;
        green = GetComponent<SpriteRenderer>().color.g;
        blue = GetComponent<SpriteRenderer>().color.b;
        alpha = MinAlpha;
        GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
    }
	
	void Update () {
        GetComponent<SpriteRenderer>().color = new Color(red, green, blue, alpha);
        alpha += FlashSpeed;
        if ( alpha <= MinAlpha || alpha >= 1)
        {
            alpha -= FlashSpeed;
            FlashSpeed *= -1;
            
        }
	}
}
