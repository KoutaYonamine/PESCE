﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpHitBox : MonoBehaviour {

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
        if (collider.gameObject.tag == "Peste" && AttackUp() == true)
        {
            script.SetWaitTime();
            pointscript.PointPlus(2);
            Destroy(collider.gameObject);
            Instantiate(SlashdFishPrefab);
            Debug.Log("↑上への攻撃でたまんを捌いたゾ");
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
