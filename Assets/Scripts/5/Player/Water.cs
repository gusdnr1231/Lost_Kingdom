using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    PlayerDetect playerDetect;
    PlayerElements playerElements;
    [SerializeField] float speed;
    void Start()
    {
        playerElements = GameObject.Find("Player").GetComponent<PlayerElements>();
        playerDetect = GameObject.Find("Player").GetComponent<PlayerDetect>();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Vertical");

        if (playerElements.ElementWater)
        {
            if(h > 0 && !playerDetect.detectUp)
            {
                transform.position += new Vector3(0, h * speed * Time.deltaTime, 0);
            }
            else if (h < 0)
            {
                transform.position += new Vector3(0, h * speed * Time.deltaTime, 0);
            }
        }
    }
    
}
