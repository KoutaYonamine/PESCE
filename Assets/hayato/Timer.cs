using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float countTime = 60;
    public GameObject Result;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        countTime -= Time.deltaTime; //スタートしてからの秒数を格納
        GetComponent<Text>().text = countTime.ToString("F0") + "秒"; //小数2桁にして表示
        if(countTime <= 0)
        {
            Instantiate(Result);
            Destroy(gameObject);
        }
    }
}