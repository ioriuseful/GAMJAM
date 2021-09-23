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
    float speedDeltatime = 50.0f;
    private PlayerControl playerControl;
    // public AudioClip eat;
    AudioSource sound;
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
            PlayerControl player = other.GetComponent<PlayerControl>();
            if(player.GetState()==PlayerControl.State.Hirame)
            {
                deadFlag = true;
                playerControl.UPScore();
                Destroy(this.gameObject);
            }
            else
            {

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerControl = other.GetComponent<PlayerControl>();
            if (playerControl.GetState() == PlayerControl.State.Hirame) 
            {
                //playerControl.UPScore();
                //Destroy(this.gameObject);
            }
      
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!data.GetStageMoveFlag())
        {
            Move();
            CheckDead();
            Rotate();
        }
    }
    private void Move()
    {
        float speed = 0.05f;
        velocity = (nextPos - transform.position).normalized * speed;

        if ((transform.position - point1.transform.position).magnitude <= speed)
        {
            nextPos = point2.transform.position;
        }
        if ((transform.position - point2.transform.position).magnitude <= speed)
        {
            nextPos = point1.transform.position;
        }
        transform.position += velocity * Time.deltaTime * speedDeltatime;
    }
    void CheckDead()
    {
        if(deadFlag)
        {
            Destroy(gameObject);
        }
    }
    void Rotate()
    {
        Vector3 a = (nextPos - transform.position);
        float angle = Mathf.Atan2(a.y, a.x);
        angle = angle / (3.1415f / 180f);
        if (angle < 0)
        {
            angle += 360;
        }
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (angle > 90 && angle < 270)
        {
            sp.flipY = true;
        }
        else
        {
            sp.flipX = true;
            sp.flipY = false;

        }
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
    
}
