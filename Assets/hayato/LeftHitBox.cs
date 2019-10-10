using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHitBox : MonoBehaviour {

    GameObject baseObj;
    CoolTimeManager script;

    GameObject pointObj;
    PointPlusMethod pointscript;

    public GameObject SlashdFishPrefab;

    public int HyoroVoiceRandomVar = 20;
    public int HyoroTobiuoRdmVar = 40;

    public AudioClip SlashSound;

    public AudioClip NormalATKVoice1;
    public AudioClip NormalATKVoice2;
    public AudioClip NormalATKVoide3;

    public AudioClip HyoroATKVoice1;
    public AudioClip HyoroATKVoice2;
    public AudioClip HyoroATKVoice3;

    public AudioClip TobiuoATKVoice1;
    public AudioClip TobiuoATKVoice2;
    public AudioClip TobiuoATKVoice3;

    AudioSource audioSource;

    

    void Start () {
		baseObj = GameObject.Find("CoolTimeManager");
        script = baseObj.GetComponent<CoolTimeManager>();
        pointObj = GameObject.Find("PointManager");
        pointscript = pointObj.GetComponent<PointPlusMethod>();
        audioSource = gameObject.GetComponent<AudioSource>();

        
    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (AttackLeft())
        {
            script.SetWaitTime();
            Destroy(collider.gameObject);
            Instantiate(SlashdFishPrefab);
            if (collider.gameObject.tag == "Fish")
            {
                pointscript.PointPlus(0);
                Debug.Log("←左への攻撃でぐるくんを捌いたゾ");
                // 0~10000の乱数を発生させて、HyoroVoiceRandomVar以上ならひょろボイス再生
                if(Random.Range(0, 100) <= HyoroVoiceRandomVar)
                {
                    RandomizeSfx(HyoroATKVoice1, HyoroATKVoice2, HyoroATKVoice3);
                }
                else
                {
                    RandomizeSfx(NormalATKVoice1, NormalATKVoice2, NormalATKVoide3);
                }
                
            } else if (collider.gameObject.tag == "Pesce")
            {
                pointscript.PointPlus(1);
                if (Random.Range(0, 100) <= HyoroVoiceRandomVar)
                {
                    audioSource.PlayOneShot(TobiuoATKVoice3);
                }
                else
                {
                    RandomizeSfx(TobiuoATKVoice1, TobiuoATKVoice2);
                }
                
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
