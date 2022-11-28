using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SplashControl : MonoBehaviour
{
    GameObject SplashObject;
    Image image;

    private bool checkbool = false;

    void Awake()
    {
        SplashObject = this.gameObject;
        image = SplashObject.GetComponent<Image>();
    }

    void Update()
    {
        if (checkbool)
        {
            Destroy(this.gameObject);
        }
    }
}
