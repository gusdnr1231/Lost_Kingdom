using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPopUp : MonoBehaviour
{
    PopEvent popEvent;
    public bool isPopUpTheNPCUI = false;
    public bool isPlayerHere = false;

    public LayerMask layerMask;

    private void Start()
    {
        popEvent = FindObjectOfType<PopEvent>();
    }

    private void Update()
    {
        if (!isPlayerHere && Input.GetKeyDown(KeyCode.R))
        {
            popEvent.PopUpTheNPCUI();
            isPlayerHere = true;
        }
        else if(isPlayerHere && Input.GetKeyDown(KeyCode.R))
        {
            popEvent.PopDownTheNPCUI();
            isPlayerHere = false;
        }
    }
}
