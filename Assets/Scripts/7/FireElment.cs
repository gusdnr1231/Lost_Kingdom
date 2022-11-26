using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireElment : MonoBehaviour
{
    public bool onFire = false;
    [SerializeField] GameObject fireObject;
    [SerializeField] float fireTime;
    [SerializeField] BoxCollider2D boxCol2d;
    [SerializeField] LayerMask playerLayer;

    private void Update()
    {
        if (onFire)
        {
            FireCoroutineStart();
        }
    }

    /*public void CheckUseSkill()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(boxCol2d.bounds.center, boxCol2d.bounds.size, 0f, playerLayer);

        try
        {
            if (cols.Length > 0 && Input.GetKeyDown(KeyCode.Alpha3))
            {
                onFire = true;
            }
            else if (cols.Length == 0)
            {
                onFire = false;
            }
        }
        catch(Exception e)
        {
            if (cols.Length > 0 && Input.GetKeyDown(KeyCode.Alpha3))
            {
                onFire = true;
            }
            else if (cols.Length >= 0)
            {
                onFire = false;
            }
        }
    }*/

    public void FireCoroutineStart()
    {
        StartCoroutine(OnFire());
    }

    IEnumerator OnFire()
    {
        fireObject.SetActive(true);

        yield return new WaitForSeconds(fireTime);

        Destroy(gameObject);
    }
}
