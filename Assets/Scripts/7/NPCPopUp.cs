using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPCPopUp : MonoBehaviour
{
    PopEvent popEvent;
    [SerializeField] BoxCollider2D boxCol2d;
    public LayerMask playerLayer;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] Collider2D[] cols;
    [SerializeField] bool isPopUp = false;

    [SerializeField] Collider2D playerCol;
    private void Start()
    {
        popEvent = FindObjectOfType<PopEvent>();
    }

    private void Update()
    {
        if((Vector2.Distance(transform.position, playerCol.transform.position)) > 7)
        {
            return;
        }
        cols = Physics2D.OverlapBoxAll(boxCol2d.bounds.center, boxCol2d.bounds.size, 0f, playerLayer);

        if(Input.GetKeyDown(KeyCode.R))
        {
            if (cols.Length > 0 && !isPopUp)
            {
                popEvent.npcText.text = text.text;
                popEvent.PopUpTheNPCUI();
                isPopUp = true;
            }
            else if (isPopUp && Input.GetKeyDown(KeyCode.R))
            {
                popEvent.PopDownTheNPCUI();
                isPopUp = false;
            }
        }

        //if(a.Length > 0 && Input.GetKeyDown(KeyCode.R))
        //{
        //}
        //else if(a.Length == 0 && Input.GetKeyDown(KeyCode.R))
        //{
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCol2d.bounds.center, boxCol2d.bounds.size);
    }
}
