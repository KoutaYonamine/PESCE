using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************
 * プレイヤーのアニメーションを実行、向きの反転を行います
 ************************************************************/
public class PlayerAnimation : MonoBehaviour
{
    private Vector3 defalutScale;   //デフォルトスケール


    // Start is called before the first frame update
    void Start()
    {
        // 開始時のローカルスケールの値を記憶しておく
        defalutScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.localScale = defalutScale;
            GetComponent<Animator>().SetTrigger("OnceAttack2");
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localScale = defalutScale;
            GetComponent<Animator>().SetTrigger("OnceAttack");
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            // ローカルスケールのXの値を反転させることで、スプライトを反転させる
            transform.localScale = new Vector3(-defalutScale.x, defalutScale.y, defalutScale.z);
            GetComponent<Animator>().SetTrigger("OnceAttack");
        }
    }


}
