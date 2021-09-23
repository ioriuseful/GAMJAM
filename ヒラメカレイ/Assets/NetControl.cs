using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetControl : MonoBehaviour
{
    Vector3 velocity;
    bool hitFlag;
    GameObject target;
    private GameObject gameManager;
    private Data data;
    float speedDeltatime = 30.0f;

    private PlayerControl playerControl;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("DataOBJ");
        data = gameManager.GetComponent<Data>();

        velocity = new Vector3(0, -0.05f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!data.GetStageMoveFlag())
        {
            Move();
        }
    }
    void Move()
    {
        transform.position += velocity * Time.deltaTime * speedDeltatime;
        if (hitFlag)
        {
            velocity.y = 0.3f;
            Hit(target);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Floor")
        {
            velocity.y = 0;
        }
        if (other.tag == "Player")
        {
            hitFlag = true;
            target = (other.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            hitFlag = true;
            target = (other.gameObject);
            playerControl = other.GetComponent<PlayerControl>();
            playerControl.NetHitTrigger();
        }
    }
    void Hit(GameObject player)
    {
        player.transform.position = transform.position - new Vector3(0, 1f, 0) * Time.deltaTime * speedDeltatime;
    }
    
}
