using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectWork : MonoBehaviour
{
    Animator EffectAnime;
    void Start()
    {
        EffectAnime = GetComponent<Animator>();
        Destroy(gameObject, EffectAnime.GetCurrentAnimatorStateInfo(0).length);
    }
}
