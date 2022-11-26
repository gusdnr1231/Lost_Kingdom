using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetElement : MonoBehaviour
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

        if (cols.Length > 0)
        {
            popEvent.elementText.text = text.text;
            popEvent.PopUpTheElementUI();
        }
        else if (cols.Length == 0)
        {
            popEvent.PopDownTheElementUI();
        }
    }
}
