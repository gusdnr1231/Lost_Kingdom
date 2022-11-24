using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : MonoBehaviour
{
    public Transform parentPos;
    private Queue<Vector3> delayPos = new Queue<Vector3>();
    private Vector3 followPos;
    private SpriteRenderer spriteRendere;
    void Start()
    {
        spriteRendere = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        delayPos.Enqueue(parentPos.position);
        
        if(delayPos.Count > 15)
        {
            followPos = delayPos.Dequeue();
            
        }
        if(followPos.x - transform.position.x < 0)
        {
            spriteRendere.flipX = true;
        }
        else if (followPos.x - transform.position.x > 0)
        {
            spriteRendere.flipX = false;
        }
        transform.position = new Vector3(followPos.x,followPos.y);
    }
}
