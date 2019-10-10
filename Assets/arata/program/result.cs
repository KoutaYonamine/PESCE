using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class result : MonoBehaviour {
    float X = 0, Y = -11;//オブジェクト初期位置
    float goalX = 0, goalY = 0; //リザルトの最終位置
    Transform tb;
    Vector2 pos;
    int score = 0;
    int ResultRanku;

    private GameObject pointObj;
    PointPlusMethod pointScript;

    public GameObject[] ranku;


 [SerializeField]float speed;

 

    // Use this for initialization
    void Start () {
        //score = 5000;
        tb = this.gameObject.transform;
        pos = tb.position;

        for(int i = ranku.Length-1; i>=0; i--)
        {
            this.ranku[i].SetActive(false);
        }
        pointObj = GameObject.Find("PointManager");
        pointScript = pointObj.GetComponent<PointPlusMethod>();
        score = pointScript.GetPoint();
        Debug.Log(score);
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector2(pos.x, pos.y+=speed);
        if (pos.y > goalY)
        {
            this.gameObject.transform.position = new Vector2(goalX,goalY);
            Debug.Log("そおい");
        }
        rankuwake();
        switch (ResultRanku)
        {
            case 1:
                this.ranku[0].SetActive(true);
                break;
            case 2:
                this.ranku[1].SetActive(true);
                break;
            case 3:
                this.ranku[2].SetActive(true);
                break;
            case 4:
                this.ranku[3].SetActive(true);
                break;



        }
    }
    void rankuwake()
    {
        if (score <= 6999)
            ResultRanku = 1;
        else if (score <= 7999)
            ResultRanku = 2;
        else if (score <= 8999)
            ResultRanku = 3;
        else if (score >= 9000)
            ResultRanku = 4;
    }
}

