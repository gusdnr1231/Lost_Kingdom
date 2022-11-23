using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGolem : MonoBehaviour
{
    
    void Start()
    {
        StartCoroutine("Destroy");
    }

    
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }
}
