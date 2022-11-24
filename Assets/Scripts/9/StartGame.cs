using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]GameObject camera;
    Transform cameraTransform;

    void Awake()
    {
        if(cameraTransform == null) cameraTransform = camera.GetComponent<Transform>();
    }

    public void GameStart()
    {
        Debug.Log("¿€µø");
       StartCoroutine(CameraMove());
    }

    IEnumerator CameraMove()
    {
        while(camera.transform.position.x <= 0)
        {
            cameraTransform.position += new Vector3(0.01f,0);
            yield return null;
        }
    }
}
