using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PesceManeger : MonoBehaviour {

    float Count = 0;
    float LimitCount = 0;
    float Frequency = 1.3f;

    bool LastFlg = true;

    public GameObject AlarmTobiuo;
    public GameObject[] PesceObj;
    public Vector2[] InstantiatePos;

    public int[] PesceCount;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
       // Debug.Log(LimitCount);

        LimitCount += Time.deltaTime;
        InstantiateTime();
        //Debug.Log(LimitCount);
    }

    void InstantiatePesce(int i)
    {
        if (PesceCount[i] > 0)
        {
            if(PesceObj[i] == PesceObj[4])
            {
                Instantiate(AlarmTobiuo, new Vector2(11, 0f), Quaternion.identity);
            }

            Instantiate(PesceObj[i], InstantiatePos[i], Quaternion.identity);
            PesceCount[i]--;
            Count = 0;
        }else if(PesceCount[i] == 0)
        {
            for(int j=0; PesceObj.Length-1 > j;)
            {
                //Debug.Log(PesceObj.Length - 1);
                //Debug.Log(j);
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
                else
                {
                    PesceCount[PesceObj.Length - 1] = 1;
                    break;
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
            Debug.Log("!!!!!");
            if(LimitCount > 0 && LimitCount <= 10)
            {
                i = Random.Range(0, 4);
                InstantiatePesce(i);
            }
            else if(LimitCount > 10 && LimitCount <= 20)
            {
                Frequency = 1.1f;
                i = Random.Range(0, 5);
                InstantiatePesce(i);
            }
            else if(LimitCount > 20 && LimitCount <= 35)
            {
                Frequency = 1.0f;
                i = Random.Range(0, 5);
                InstantiatePesce(i);
            }
            else if(LimitCount > 35)
            {
                Frequency = 0.8f;
                i = Random.Range(0, 5);
                InstantiatePesce(i);
            }
            if(LimitCount > 59f && LastFlg == true)
            {
                
                Instantiate(PesceObj[4], InstantiatePos[4], Quaternion.identity);
                Instantiate(AlarmTobiuo, new Vector2(11, 3.5f), Quaternion.identity);
                LastFlg = false;
            }
            else
            {
                Count = 0;
            }
        }
    }
}
