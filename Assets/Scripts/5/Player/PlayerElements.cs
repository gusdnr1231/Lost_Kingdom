using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerElements : MonoBehaviour
{
    [SerializeField] SpriteRenderer groundPet;
    [SerializeField] SpriteRenderer waterPet;
    [SerializeField] SpriteRenderer windPet;
    [SerializeField] SpriteRenderer firePet;
    public bool ElementWind { get; set; }
    public bool ElementFire { get; set; }
    public bool ElementGround { get; set; }
    public bool ElementWater { get; set; }
    private PlayerSkill playerSkill;
    private int elementsCount = 0;
    private void Start()
    {
        playerSkill = GetComponentInParent<PlayerSkill>();
        waterPet.color = new Color(1, 1, 1, 0);
        firePet.color = new Color(1, 1, 1, 0);
        groundPet.color = new Color(1, 1, 1, 0);
        windPet.color = new Color(1, 1, 1, 0);
    }
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if(elementsCount != 4)
            elementsCount++;
            else
            {
                elementsCount = 1;
            }
        }
        switch (elementsCount)
        {
            case 1:
                if (playerSkill.GetWind)
                {
                    waterPet.color = new Color(1, 1, 1, 0);
                    firePet.color = new Color(1, 1, 1, 0);
                    groundPet.color = new Color(1, 1, 1, 0);
                    windPet.color = new Color(1, 1, 1, 1);
                    ElementFire = false;
                    ElementGround = false;
                    ElementWater = false;
                    ElementWind = true;
                }
                break;
            case 2:
                if (playerSkill.GetFire)
                {
                    windPet.color = new Color(1, 1, 1, 0);
                    groundPet.color = new Color(1, 1, 1, 0);
                    waterPet.color = new Color(1, 1, 1, 0);
                    firePet.color = new Color(1, 1, 1, 1);
                    ElementWind = false;
                    ElementGround = false;
                    ElementWater = false;
                    ElementFire = true;
                }
                break;
            case 3:
                if (playerSkill.GetGround)
                {
                    firePet.color = new Color(1, 1, 1, 0);
                    waterPet.color = new Color(1, 1, 1, 0);
                    windPet.color = new Color(1, 1, 1, 0);
                    groundPet.color = new Color(1, 1, 1, 1);
                    ElementFire = false;
                    ElementWater = false;
                    ElementWind = false;
                    ElementGround = true;
                }
                break;
            case 4:
                if (playerSkill.GetWater)
                {
                    groundPet.color = new Color(1, 1, 1, 0);
                    firePet.color = new Color(1, 1, 1, 0);
                    windPet.color = new Color(1, 1, 1, 0);
                    waterPet.color = new Color(1, 1, 1, 1);
                    ElementWind = false;
                    ElementGround = false;
                    ElementFire = false;
                    ElementWater = true;
                }
                break;
            
        }
    }
}
