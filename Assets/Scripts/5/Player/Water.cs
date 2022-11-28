using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    PlayerDetect playerDetect;
    PlayerElements playerElements;
    [SerializeField] float speed;
    [SerializeField] BoxCollider2D playerDetectBox;
    [SerializeField] LayerMask player;
    void Start()
    {
        playerElements = GameObject.Find("Player").GetComponent<PlayerElements>();
        playerDetect = GameObject.Find("Player").GetComponent<PlayerDetect>();
    }
    void Update()
    {
        float h = Input.GetAxisRaw("Vertical");
        Collider2D[] playerbox = Physics2D.OverlapBoxAll(playerDetectBox.bounds.center, playerDetectBox.bounds.size,0f, player);
        if (playerElements.ElementWater && playerbox.Length > 0)
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
