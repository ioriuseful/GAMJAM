using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    bool searchFlag;
    GameObject target;
    float cooltime;
    // Start is called before the first frame update
    void Start()
    {
        cooltime = 3;
        searchFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        cooltime -= Time.deltaTime;
        if (cooltime > 0)
        {
            target = null;
        }
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player" && cooltime < 0)  
        {
            
            searchFlag = true;
            target = other.gameObject;
        }
        if (other.gameObject.tag == "Floor" && target != null) 
        {
            if (Mathf.Abs((transform.position - target.transform.position).magnitude) >
                Mathf.Abs((transform.position - other.transform.position).magnitude)) 
            {
                cooltime = 3;
                
            }
            
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "Player")
        {
            searchFlag = false;
            target = null;
        }
    }
    public bool GetSearchFlag()
    {
        return searchFlag;
    }
    public GameObject GetTarget()
    {
        return target;
    }
    public void SetCoolTime(float time)
    {
        cooltime = time;
    }
}
