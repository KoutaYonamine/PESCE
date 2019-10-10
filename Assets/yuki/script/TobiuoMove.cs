using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TobiuoMove : MonoBehaviour {
    Transform Mytransform;
    Vector2 pos;
    [SerializeField] float Speed;

    float time = 0;
    // Use this for initialization
    void Start () {

        Mytransform = this.transform;
        pos = Mytransform.position;
    }

    // Update is called once per frame
    void Update () {
        Move();
        DltTime(5);
	}

    private void Move()
    {
        pos.x += Speed;
        Mytransform.position = pos;
    }

    private void DltTime(int T)
    {
        time += Time.deltaTime;
        if (time > T)
        {
            Destroy(this.gameObject);
        }
    }
}
