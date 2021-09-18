using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kozakana : MonoBehaviour
{
    Vector3 velocity;
    public GameObject point1, point2;
    Vector3 nextPos;
    bool deadFlag;
    private GameObject gameManager;
    private Data data;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("DataOBJ");
        data = gameManager.GetComponent<Data>();

        deadFlag = false;
        nextPos = point1.transform.position;
        velocity = Vector3.zero;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            deadFlag = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!data.GetStageMoveFlag())
        {
            Move();
            CheckDead();
        }
    }
    private void Move()
    {
        float speed = 0.05f;
        velocity = ( nextPos- transform.position ).normalized * speed;

        if ((transform.position-point1.transform.position).magnitude <= speed)
        {
            nextPos = point2.transform.position;
        }
        if ((transform.position-point2.transform.position).magnitude <= speed)
        {
            nextPos = point1.transform.position;
        }
        transform.position += velocity;
    }
    void CheckDead()
    {
        if(deadFlag)
        {
            Destroy(gameObject);
        }
    }
}
