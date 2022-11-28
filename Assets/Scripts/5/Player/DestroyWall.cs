using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWall : MonoBehaviour
{
    [SerializeField] ParticleSystem destroyGroundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine("DestroyObject");
    }
    IEnumerator DestroyObject()
    {
        yield return new WaitForSeconds(1f);
        destroyGroundEffect.Play();
        Destroy(gameObject);
    }
}
