using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugaharaTestScript : MonoBehaviour
{
    public GameObject p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float speed = 5.0f;
        Vector3 vel = new Vector3(0, 0, 0);
        if (Input.GetKey(KeyCode.UpArrow)) vel += new Vector3(0, speed, 0);
        if (Input.GetKey(KeyCode.DownArrow)) vel += new Vector3(0, -speed, 0);
        if (Input.GetKey(KeyCode.RightArrow)) vel += new Vector3(speed, 0, 0);
        if (Input.GetKey(KeyCode.LeftArrow)) vel += new Vector3(-speed, 0, 0);

        p.transform.position += vel * Time.deltaTime;

    }
}
