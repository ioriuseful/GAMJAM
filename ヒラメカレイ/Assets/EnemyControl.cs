using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    Vector3 velocity;
    GameObject target;
    public GameObject searchBox;
    EnemySearch search;
    // Start is called before the first frame update
    void Start()
    {
        search = searchBox.GetComponent<EnemySearch>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckSearch();
        Move();
        Rotate();
    }
    void Move()
    {
        velocity = Vector3.zero;
        if (target != null)
        {
            velocity = (target.transform.position - transform.position).normalized * 0.05f;
        }
        else
        {

        }
        transform.position += velocity;
    }
    void Rotate()
    {
        if (target != null)
        {
            Vector3 a = (target.transform.position - transform.position);
            float angle = Mathf.Atan2(a.y, a.x);
            angle = angle / (3.1415f / 180f);
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    void CheckSearch()
    {
       if(search.GetSearchFlag())
        {
            target = search.GetTarget();
        }
       else
        {
            target = null;
        }
    }

}
