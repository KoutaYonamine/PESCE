using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolTimeManager: MonoBehaviour
{

    public float slashCoolTime = 0.5f; // 斬ったあと、次に斬れるようになれるまでの時間。inspectorから値を変更でき、初期化などに使う。
    private float WaitTime; // プログラムの中で実際に使う時間

    void Start()
    {
        WaitTime = 0;
    }

    void Update()
    {

        // WaitTimeが0以上のとき、時間を引いていく。
        if (0 <= WaitTime)
        {
            WaitTime -= Time.deltaTime;
        }

    }

    // 他のオブジェクトから、WaitTimeを参照できるようにする
    public float GetWaitTime()
    {
        return WaitTime;
    }

    // 他のオブジェクトでヒット判定がOKだったとき、クールタイムを設定できる。
    public void SetWaitTime()
    {
        WaitTime = slashCoolTime;
    }
}
