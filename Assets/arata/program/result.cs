using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class result : MonoBehaviour {
    float X = 0, Y = -11;//オブジェクト初期位置
    float goalX = 0, goalY = 0; //リザルトの最終位置
    Transform tb;
    Vector2 pos;
    int score = 0;
    int ResultRanku;
    bool soundflag=true;
    //bool voiceflag = true;
   
   

    private GameObject pointObj;
    PointPlusMethod pointScript;

    public GameObject[] ranku;
    public AudioClip[] sound;
    public AudioSource spika;

 [SerializeField]float speed;

 

    // Use this for initialization
    void Start () {
        //score = 8000;
        tb = this.gameObject.transform;
        pos = tb.position;

        for(int i = ranku.Length-1; i>=0; i--)
        {
            this.ranku[i].SetActive(false);
        }
        pointObj = GameObject.Find("PointManager");
        pointScript = pointObj.GetComponent<PointPlusMethod>();
        score = pointScript.GetPoint();
        Debug.Log(score);
    }
	
	// Update is called once per frame
	void Update () {
        Vector2 pos = this.gameObject.transform.position;
        this.gameObject.transform.position = new Vector2(pos.x, pos.y+=speed);
        if (pos.y > goalY)
        {
            this.gameObject.transform.position = new Vector2(goalX,goalY);
            Debug.Log("そおい");
        }
        rankuwake();
        switch (ResultRanku)
        {
            case 1:
                if (soundflag)
                {
                    this.ranku[0].SetActive(true);
                    soundflag = false;
                    spika.PlayOneShot(sound[0]);
                    StartCoroutine( Voice(3f, ResultRanku));
                }
                break;
            case 2:
                if (soundflag)
                {
                    this.ranku[1].SetActive(true);
                    soundflag = false;
                    spika.PlayOneShot(sound[0]);
                    StartCoroutine(Voice(3f, 2));
                }
                break;
            case 3:
                if (soundflag)
                {
                    this.ranku[2].SetActive(true);
                    soundflag = false;
                    spika.PlayOneShot(sound[0]);
                    StartCoroutine(Voice(3f, 3));
                }
                break;
            case 4:
                if (soundflag)
                {
                    this.ranku[3].SetActive(true);
                    soundflag = false;
                    spika.PlayOneShot(sound[0]);
                    spika.PlayOneShot(sound[4]);
                    //StartCoroutine(Voice(3f, 4));
                }
                //if (voiceflag)
                //{
                //    //this.ranku[4].SetActive(true);
                //    voiceflag = false;
                //    spika.PlayOneShot(sound[4]);
                //}
                break;

               

        }
        if (Input.GetKeyDown(KeyCode.UpArrow)&&pos.x>=goalX&&pos.y>=goalY)
        {
            SceneManager.LoadScene("MasterScenes");
            Debug.Log("おっぱい！！！！");
        }
    }
    void rankuwake()
    {
        if (score <= 5999)
        {
            ResultRanku = 1;
            Debug.Log("1");
        }
        else if (score <= 6999)
        {
            ResultRanku = 2;
            Debug.Log("2");
        }
        else if (score <= 7999)
        {
            ResultRanku = 3;
            Debug.Log("3");
        }
        else if (score >= 8000)
        {
            ResultRanku = 4;
            Debug.Log("4");
        }
    }
    IEnumerator Voice(float time, int i)
    {
        yield return new WaitForSeconds(time);
        spika.PlayOneShot(sound[i]);
    }
}

