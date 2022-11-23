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
	IEnumerator SceneChangeOn()
	{
		Color color = image.color;
		for (int i = 100; i >= 0; i--)
		{
			color.a += Time.deltaTime * 0.01f;
			image.color = color;
			if (image.color.a >= 255)
			{
				checkbool = true;
			}
		}
		yield return null;
	}
}
