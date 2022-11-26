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

    private void Start()
    {
        popEvent = FindObjectOfType<PopEvent>();
    }

    private void Update()
    {
        Collider2D[] cols = Physics2D.OverlapBoxAll(boxCol2d.bounds.center, boxCol2d.bounds.size, 0f, playerLayer);

        if(cols.Length > 0 && Input.GetKeyDown(KeyCode.R))
        {
            popEvent.npcText.text = text.text;
            popEvent.PopUpTheNPCUI();
        }
        else if(cols.Length == 0)
        {
            popEvent.PopDownTheNPCUI();
        }
    }
}
