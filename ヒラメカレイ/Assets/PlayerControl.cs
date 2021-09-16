using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 velocity;
    float hp;

    enum Direct
    {
        Flont,Back,
    };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            velocity.x = -0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            velocity.x = 0.1f;
        }
        if(Input.GetKey(KeyCode.UpArrow))
        {
            velocity.y = 0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            velocity.y = -0.1f;
        }
        transform.position += velocity;
    }
    void Damage(float damage)
    {
        hp -= damage;
    }

}
