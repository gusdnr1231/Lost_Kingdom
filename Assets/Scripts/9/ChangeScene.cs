using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string transferScene;
    private Player thePlayer;
    private SplashControl splash;
    

    void Awake()
    {
		
		if (splash == null) splash = FindObjectOfType<SplashControl>();
        if(thePlayer == null) thePlayer = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Player"))
        {
			splash.StartCoroutine("SceneChangeOn");
            thePlayer.currentSceneName = transferScene;
            SceneManager.LoadScene(transferScene);
        }
    }
}
