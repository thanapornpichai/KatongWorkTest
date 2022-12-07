using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveParallax : MonoBehaviour
{
    [SerializeField]
    private float endPos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(1 * Time.deltaTime, 0);
        if(transform.position.x>endPos)
        {
            transform.position = new Vector3(-endPos,transform.position.y); 
        }
    }
}
