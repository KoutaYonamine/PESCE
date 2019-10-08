using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHitBox : MonoBehaviour {

    GameObject baseObj;
    CoolTimeManager script;

    GameObject pointObj;
    PointPlusMethod pointscript;

    void Start () {
		baseObj = GameObject.Find("CoolTimeManager");
        script = baseObj.GetComponent<CoolTimeManager>();
        pointObj = GameObject.Find("PointManager");
        pointscript = pointObj.GetComponent<PointPlusMethod>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (AttackLeft())
        {
            if (collider.gameObject.tag == "Fish")
            {
                script.SetWaitTime();
                pointscript.PointPlus(0);
                Debug.Log("←左への攻撃でぐるくんを捌いたゾ");
            } else if (collider.gameObject.tag == "Pesce")
            {
                script.SetWaitTime();
                pointscript.PointPlus(1);
                Debug.Log("←左への攻撃でトビウオを捌いたゾ");
            }
        }

        Debug.Log("左に魚がふれている");
    }

    void Update () {
        AttackLeft();
	}

    // 押されて攻撃した場合、trueを返します。押されていなかった場合、falseを返します。
    // 侍のアニメーションに使えるはずです。
    public bool AttackLeft()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && script.GetWaitTime() <= 0)
        {
            Debug.Log("左へ攻撃した");
            script.SetWaitTime();
            return true;
        }
        return false;

    }

}
