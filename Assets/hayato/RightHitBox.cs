using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHitBox : MonoBehaviour {

    GameObject baseObj;
    CoolTimeManager script;

    GameObject pointObj;
    PointPlusMethod pointscript;

    public GameObject SlashdFishPrefab;

    void Start()
    {
        baseObj = GameObject.Find("CoolTimeManager");
        script = baseObj.GetComponent<CoolTimeManager>();
        pointObj = GameObject.Find("PointManager");
        pointscript = pointObj.GetComponent<PointPlusMethod>();
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Fish" && AttackRight() == true)
        {
            script.SetWaitTime();
            pointscript.PointPlus(0);
            Destroy(collider.gameObject);
            Instantiate(SlashdFishPrefab);
            Debug.Log("→右への攻撃でぐるくんを捌いたゾ");
        }
        Debug.Log("右に魚がふれている");
    }

    void Update()
    {
        AttackRight();
    }

    // 押されて攻撃した場合、trueを返します。押されていなかった場合、falseを返します。
    public bool AttackRight()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && script.GetWaitTime() <= 0)
        {
            Debug.Log("右へ攻撃した");
            script.SetWaitTime();
            return true;
        }
        return false;
    }
}
