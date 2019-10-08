using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointPlusMethod : MonoBehaviour
{
    public int Fish_0_point;
    public int Fish_1_point;
    public int Fish_2_point;

    private int Point;  // 合計点

    void Start()
    {
        Point = 0;
    }

    public int GetPoint()
    {
        return Point;
    }

    // 0...ぐるくん、1...トビウオ、2...タマン。
    public void PointPlus(int FishType)
    {
        if(FishType == 0)
        {
            Point += Fish_0_point;
        } else if (FishType == 1)
        {
            Point += Fish_1_point;
        } else if (FishType == 2)
        {
            Point += Fish_2_point;
        }
    }
}