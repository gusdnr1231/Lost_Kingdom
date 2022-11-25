using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPopUp : MonoBehaviour
{
    [SerializeField] BoxCollider2D boxCol2d;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

        }
    }
}
