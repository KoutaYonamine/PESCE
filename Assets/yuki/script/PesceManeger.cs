using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesceManeger : MonoBehaviour {

    float Count = 0;
    float LimitCount = 0;
    float Frequency = 1.5f;

    public GameObject[] PesceObj;
    public Vector2[] InstantiatePos;

    public int[] PesceCount;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(LimitCount);

        LimitCount += Time.deltaTime;
        InstantiateTime();
	}

    void InstantiatePesce(int i)
    {
        if (PesceCount[i] > 0)
        {
            Instantiate(PesceObj[i], InstantiatePos[i], Quaternion.identity);
            PesceCount[i]--;
            Count = 0;
        }else if(PesceCount[i] == 0)
        {
            for(int j=0; PesceObj.Length-1 > j;)
            {
                if(PesceCount[j] > 0)
                {
                    Instantiate(PesceObj[j], InstantiatePos[j], Quaternion.identity);
                    PesceCount[j]--;
                    Count = 0;
                    break;
                }else if(PesceCount[j] == 0)
                {
                    j++;
                }
            }
        }
    }

    void InstantiateTime()
    {
        Count += Time.deltaTime;
        //Debug.Log(Count);

        if(Count > Frequency)
        {
            int i;

            if(LimitCount > 0 && LimitCount <= 10)
            {
                i = Random.Range(0, 4);
                InstantiatePesce(i);
            }
            else if(LimitCount > 10 && LimitCount <= 35)
            {
                Frequency = 1.2f;
                i = Random.Range(0, 5);
                InstantiatePesce(i);
            }
            else if(LimitCount > 35)
            {
                Frequency = 0.8f;
                i = Random.Range(0, 5);
                InstantiatePesce(i);
            }
            if(LimitCount > 59&&LimitCount <= 60)
            {
                Instantiate(PesceObj[4], InstantiatePos[4], Quaternion.identity);
            }

        }
    }
}
