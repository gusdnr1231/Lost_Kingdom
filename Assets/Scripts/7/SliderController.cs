using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] float currentHP;

    [SerializeField] float currentMP;

    public Slider hpSlider;
    public Slider mpslider;

    private void Start()
    {
        
    }

    private void Update()
    {
        hpSlider.value = currentHP;
        mpslider.value = currentMP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
    }

    public void UseMP(int UsedMP)
    {
        currentMP -= UsedMP;
    }
}
