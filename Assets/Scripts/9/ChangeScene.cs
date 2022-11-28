using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    private Player thePlayer;
    private SplashControl splash;
    [SerializeField] Transform ChangeTrans;

    void Awake()
    {
		if (splash == null) splash = FindObjectOfType<SplashControl>();
        if(thePlayer == null) thePlayer = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
            thePlayer.transform.position = ChangeTrans.position;
        }
    }
}
