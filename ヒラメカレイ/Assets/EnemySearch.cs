using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySearch : MonoBehaviour
{
    bool searchFlag;
    // Start is called before the first frame update
    void Start()
    {
        searchFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            searchFlag = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            searchFlag = false;
        }
    }
}
