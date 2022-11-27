using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerHp : MonoBehaviour
{
    [SerializeField] Slider Hp;
    [SerializeField] Slider Mp;
    PlayerSkill player;
    void Start()
    {
        player = GetComponent<PlayerSkill>();
        Hp = GetComponent<Slider>();
        Mp = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        Hp.value = player.CurrentHp / player.MaxHp;
        Mp.value = player.CurrentMp / player.MaxMp;
    }
}
