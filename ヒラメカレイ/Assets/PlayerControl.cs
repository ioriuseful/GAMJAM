using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //シーン遷移

public class PlayerControl : MonoBehaviour
{
    Vector3 velocity;
    float hp;
    bool deadFlag;
    bool clearFlag;
    bool air;
    bool upstop;
    int score;
    private GameObject gameManager;
    private Data data;

    public AudioClip jump = null;
    public AudioClip netHit = null;
    public AudioClip dead = null;
    public AudioClip eat = null;
    AudioSource sound;
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
        clearFlag = false;
        air = true;upstop = false;
        state = State.Hirame;
        gameManager = GameObject.Find("DataOBJ");
        data = gameManager.GetComponent<Data>();
        sound = GetComponent<AudioSource>();
        sound.volume = 0.5f;
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
        if (other.transform.tag == "Goal")
        {
            clearFlag = true;
        }
        if(other.transform.tag=="kozakana")
        {
            if (eat != null)
            {
                sound.PlayOneShot(eat);
            }
        }
        if (other.transform.tag == "Net")
        {
            Damage(10);
            if (netHit != null)
            {
                sound.PlayOneShot(netHit);
            }
        }
        if (other.transform.tag == "Floor")
        {
            Vector3 vec = transform.position - other.transform.position;
            //BoxCollider co = GetComponent<BoxCollider>();
            //BoxCollider co2 = other.GetComponent<BoxCollider>();
            if ((transform.position.y - transform.localScale.y / 2 + 0.1f) >= other.transform.position.y + other.transform.localScale.y / 2)
            {
                
                
                air = false;
                velocity.y = 0;
               // transform.position += vec.normalized / 10;
            }
            else if (((transform.position.y - transform.localScale.y / 2 + 0.1f) <= other.transform.position.y + other.transform.localScale.y / 2))
            {
                air = true;
                vec.y = 0;
                transform.position += vec.normalized / 10;
            }

            else
            {
                air = true;
                transform.position += vec.normalized / 10;
            }
        

        }
        if (other.transform.tag == "UpStop")
        {
            Debug.Log("UpStop");
            upstop = true;
            velocity.y = 0;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        
        if (collision.transform.tag == "Floor")
        {
            air = true;
        }
      
        if(collision.transform.tag=="UpStop")
        {
            upstop = false;
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
    
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
        if (Input.GetKey(KeyCode.LeftArrow)&&state==State.Hirame)
        {
            velocity.x = -0.1f;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && state == State.Karei)
        {
            velocity.x = 0.1f;
        }
        if (Input.GetKey(KeyCode.RightArrow) && state == State.Hirame)
        {
            velocity.x = 0.1f;
        }
        else if (Input.GetKey(KeyCode.RightArrow) && state == State.Karei) 
        {
            velocity.x = -0.1f;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(upstop)
            { return; }
            velocity.y = 0.1f;
        }
        if (Input.GetKey(KeyCode.DownArrow) && air) 
        {
            velocity.y = -0.1f;
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (upstop)
            { return; }
            velocity.y = 0.15f;
            if(jump!=null)
            {
                sound.PlayOneShot(jump);
            }
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
            if(dead!=null)
            {
                sound.PlayOneShot(dead);
            }
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

    public bool GetClearFlag()
    {
        return clearFlag;
    }
    public float GetHp()
    {
        return hp;
    }
    public State GetState()
    {
        return state;
    }
    public bool GetAirFlag()
    {
        return air;
    }
    public int GetScore()
    {
        return score;
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
