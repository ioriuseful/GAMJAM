using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    Vector3 velocity;
    float hp;
    bool deadFlag;
    bool air;

    private GameObject gameManager;
    private Data data;

    public enum State
    {
      Hirame,Karei
    };
    State state;

    // Start is called before the first frame update
    void Start()
    {
        hp = 10;
        deadFlag = false;
        air = true;
        state = State.Hirame;
        gameManager = GameObject.Find("DataOBJ");
        data = gameManager.GetComponent<Data>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!data.GetStageMoveFlag())
        {
            Move();
            CheckDead();
            CheckState();
        }
     
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Net")
        {
            Damage(10);
        }
        if (other.transform.tag == "Floor")
        {
            air = false;
            velocity.y = 0;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.transform.tag == "Floor")
        {
            air = true;
        }
    }
    void Move()
    {
        velocity.x = 0;
        if (air)
        {
            velocity.y -= 0.005f;
            if (velocity.y < -0.05f)
            {
                velocity.y = -0.05f;
            }
        }
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
        if (Input.GetKey(KeyCode.DownArrow) && air) 
        {
            velocity.y = -0.1f;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = 0.15f;
        }
        transform.position += velocity;
  
    }
    void Damage(float damage)
    {
        hp -= damage;
    }
    void CheckDead()
    {
        if (hp >= 0)
        { 
            deadFlag = true;
        }
        else
        {
            deadFlag = false;
        }
    }
    public bool GetDeadFlag()
    {
        return deadFlag;
    }
    public float GetHp()
    {
        return hp;
    }
    public State GetState()
    {
        return state;
    }
    void CheckState()
    {
        bool flag = data.GetStageChange();//取得falseが表カレイ.trueがヒラメ
        Debug.Log(flag);

        if(!flag)
        {
            state = State.Hirame;
        }
        else
        {
            state = State.Karei;
        }
    }
}
