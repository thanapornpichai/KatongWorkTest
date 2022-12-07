using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountKatong : MonoBehaviour
{
    private int katongPassNo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "katong")
        {
            if(katongPassNo==10)
            {
                katongPassNo = 0;
            }
            else
            {
                katongPassNo++;
            }
        }
    }

    public int GetKatongPass()
    {
        return katongPassNo;
    }
}
