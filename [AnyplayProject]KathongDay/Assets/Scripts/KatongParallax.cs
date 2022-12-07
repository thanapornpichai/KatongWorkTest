using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatongParallax : MonoBehaviour
{
    [SerializeField]
    private Transform[] katongPos;
    [SerializeField]
    private float endPos,posY1,posY2,posY3;
    [SerializeField]
    private int katongNo,randomY;
    // Start is called before the first frame update
    void Start()
    {
        randomY =Random.Range(0, 3);
        switch(randomY)
        {
            case 0:
                transform.position = new Vector3(transform.position.x, posY1);
                break;
            case 1:
                transform.position = new Vector3(transform.position.x, posY2);
                break;
            case 2:
                transform.position = new Vector3(transform.position.x, posY3);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1 * Time.deltaTime, 0);
        if (transform.position.x > endPos)
        {
            if(katongNo==0)
            {
                transform.position = new Vector3(katongPos[katongNo + 9].transform.position.x -8, transform.position.y);
            }
            else 
            {
                transform.position = new Vector3(katongPos[katongNo - 1].transform.position.x -8, transform.position.y);
            }
        }
    }
}
