using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHitBox : MonoBehaviour {

    GameObject baseObj;
    CoolTimeManager script;

    GameObject pointObj;
    PointPlusMethod pointscript;

    public GameObject SlashdFishPrefab;

    public int HyoroVoiceRandomVar = 20;

    public AudioClip SlashSound;

    public AudioClip NormalATKVoice1;
    public AudioClip NormalATKVoice2;
    public AudioClip NormalATKVoide3;

    public AudioClip HyoroATKVoice1;
    public AudioClip HyoroATKVoice2;
    public AudioClip HyoroATKVoice3;

    AudioSource audioSource;

    void Start()
    {
        baseObj = GameObject.Find("CoolTimeManager");
        script = baseObj.GetComponent<CoolTimeManager>();
        pointObj = GameObject.Find("PointManager");
        pointscript = pointObj.GetComponent<PointPlusMethod>();
        audioSource = gameObject.GetComponent<AudioSource>();
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
            // 0~10000の乱数を発生させて、HyoroVoiceRandomVar以上ならひょろボイス再生
            if (Random.Range(0, 100) <= HyoroVoiceRandomVar)
            {
                RandomizeSfx(HyoroATKVoice1, HyoroATKVoice2, HyoroATKVoice3);
            }
            else
            {
                RandomizeSfx(NormalATKVoice1, NormalATKVoice2, NormalATKVoide3);
            }
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
            audioSource.PlayOneShot(SlashSound);
            return true;
        }
        return false;
    }

    public void RandomizeSfx(params AudioClip[] clips)
    {
        var randomIndex = Random.Range(0, clips.Length);
        audioSource.PlayOneShot(clips[randomIndex]);
    }
}
