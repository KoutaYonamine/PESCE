using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHitBox : MonoBehaviour {

    GameObject baseObj;
    CoolTimeManager script;

    GameObject pointObj;
    PointPlusMethod pointscript;

    void Start()
    {
        baseObj = GameObject.Find("CoolTimeManager");
        script = baseObj.GetComponent<CoolTimeManager>();
        pointObj = GameObject.Find("PointManager");
        pointscript = pointObj.GetComponent<PointPlusMethod>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Fish" && AttackUp() == true)
        {
            script.SetWaitTime();
            pointscript.PointPlus(2);
            Debug.Log("↑上への攻撃でたまんを捌いたゾ");
        }
        Debug.Log("上に魚がふれている");
    }

    void Update()
    {
        AttackUp();
    }

    // 押されて攻撃した場合、trueを返します。押されていなかった場合、falseを返します。
    public bool AttackUp()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && script.GetWaitTime() <= 0)
        {
            Debug.Log("上へ攻撃した");
            script.SetWaitTime();
            return true;
        }
        return false;
    }
}
