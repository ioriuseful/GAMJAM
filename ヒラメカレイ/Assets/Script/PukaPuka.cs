using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukaPuka : MonoBehaviour
{
    // Start is called before the first frame update

    public float nowPosi;

    public bool flag;
    float count = 0.5f;

    void Start()
    {
        nowPosi = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        count -= Time.deltaTime;

        if (count > 0 && flag) return;

        if(flag)
        {
            transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time / 3, 0.5f), transform.position.z);
        }
        else
        {
            transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time / 3, 0.4f), transform.position.z);
        }

        //transform.position = new Vector3(transform.position.x, nowPosi + Mathf.PingPong(Time.time / 3, 0.3f), transform.position.z);
    }
}
