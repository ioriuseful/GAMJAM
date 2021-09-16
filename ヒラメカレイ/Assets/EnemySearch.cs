using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    bool searchFlag;
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        searchFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    private void OnTriggerStay(Collider other)
    {
        if (other.transform.tag == "Player") 
        {
            searchFlag = true;
            target = other.gameObject;
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
}
