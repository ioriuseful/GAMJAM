using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Vector3 velocity;
    GameObject target;
    public GameObject searchBox;
    EnemySearch search;
    PlayerControl player;
    public GameObject point1;
    public GameObject point2;
    private GameObject gameManager;
    private Data data;
    Vector3 nextPos;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("DataOBJ");
        data = gameManager.GetComponent<Data>();
        nextPos = point1.transform.position;
        search = searchBox.GetComponent<EnemySearch>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!data.GetStageMoveFlag())
        {
            CheckSearch();
            Move();
            Rotate();
        }
    }
    void Move()
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


        if (target != null && player.GetState() == PlayerControl.State.Karei && !player.GetAirFlag())
        {
            transform.position += velocity;
        }
        else if (target != null)
        {
            velocity = (target.transform.position - transform.position).normalized * 0.05f;
        }
        transform.position += velocity;
    }
    void Rotate()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        if (target != null && player.GetState() == PlayerControl.State.Karei && !player.GetAirFlag())
        {
            Vector3 a = (nextPos - transform.position);
            float angle = Mathf.Atan2(a.y, a.x);
            angle = angle / (3.1415f / 180f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            if (angle > 0)
            {
                sp.flipX = true;
                sp.flipY = false;
            }
            else
            {

                sp.flipY = true;
            }
        }
        else if (target != null)
        {
            Vector3 a = (target.transform.position - transform.position);
            float angle = Mathf.Atan2(a.y, a.x);
            angle = angle / (3.1415f / 180f);
            if (angle < 0)
            {
                angle += 360;
            }
            transform.rotation = Quaternion.Euler(0, 0, angle);
            Debug.Log(angle);
            if (angle > 90 && angle < 270)
            {
                sp.flipY = true;
            }
            else
            {
                sp.flipX = true;
                sp.flipY = false;

            }
        }

        if (target == null )
        {

            Vector3 a = (nextPos - transform.position);
            float angle = Mathf.Atan2(a.y, a.x);
            angle = angle / (3.1415f / 180f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
            if (angle > 0)
            {
                sp.flipX = true;
                sp.flipY = false;
            }
            else
            {

                sp.flipY = true;
            }
        }
        else
        {

        }

     
    }
    void CheckSearch()
    {
       if(search.GetSearchFlag())
        {
            target = search.GetTarget();
            player = target.GetComponent<PlayerControl>();
        }
       else
        {
            target = null;
        }
    }

}
