using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeInOut : MonoBehaviour
{
    [SerializeField] Image image;
    void Start()
    {
        StartCoroutine("Fade");
    }

    void Update()
    {
        
    }
    IEnumerator Fade()
    {
        float fadecount = 0;
        while(fadecount <= 1)
        {
            fadecount += 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadecount);
        }
        yield return new WaitForSeconds(1f);
        while(fadecount >= 0)
        {
            fadecount -= 0.01f;
            yield return new WaitForSeconds(0.01f);
            image.color = new Color(0, 0, 0, fadecount);
        }
    }
}
