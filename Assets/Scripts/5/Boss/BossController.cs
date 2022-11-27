using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class BossController : MonoBehaviour
{
    [SerializeField] int bossHp;
    [SerializeField] BoxCollider2D playerDetectSize;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] BoxCollider2D canAttackSize;
    [SerializeField] List<Collider2D> attack1Size;
    [SerializeField] List<Collider2D> attack2Size;
    [SerializeField] List<Collider2D> attack3Size;
    [SerializeField] float moveSpeed;
    [SerializeField] float attackCooldown;
    private float currentCoolTime;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private Animator animator;
    private Vector2 moveDir;
    public bool canAttack;
    public bool IsAttack;
    public bool death;
    public bool canHit;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (death)
        {
            animator.SetTrigger("Death");
        }
        else
        {
            currentCoolTime += Time.deltaTime;
            DetectPlayer();
            rigid.velocity = moveDir * moveSpeed;
        }
    }
    void DetectPlayer()
    {
        PlayerSkill player = FindObjectOfType<PlayerSkill>();
        Collider2D[] detect = Physics2D.OverlapBoxAll(playerDetectSize.bounds.center, playerDetectSize.size, 0f, playerLayer);
        Collider2D[] canAttack = Physics2D.OverlapBoxAll(canAttackSize.bounds.center, canAttackSize.size, 0f, playerLayer);
        List<Collider2D> attack1 = new List<Collider2D>();
        List<Collider2D> attack3 = new List<Collider2D>();
        List<Collider2D> attack2 = new List<Collider2D>();


        foreach(Collider2D atkRange in attack1Size)
        {
            Collider2D[] tempDetectedEnemies = Physics2D.OverlapBoxAll(atkRange.bounds.center, atkRange.bounds.size, 0f, playerLayer);
            foreach(Collider2D col in tempDetectedEnemies)
            {
                if (!attack1.Contains(col))
                    attack1.Add(col);
            }    
        }
        foreach(Collider2D atkRange in attack3Size)
        {
            Collider2D[] tempDetectedEnemies = Physics2D.OverlapBoxAll(atkRange.bounds.center, atkRange.bounds.size, 0f, playerLayer);
            foreach(Collider2D col in tempDetectedEnemies)
            {
                if (!attack3.Contains(col))
                {
                    attack3.Add(col);
                }
            }
        }
        foreach (Collider2D atkRange in attack2Size)
        {
            Collider2D[] tempDetectedEnemies = Physics2D.OverlapBoxAll(atkRange.bounds.center, atkRange.bounds.size, 0f, playerLayer);
            foreach (Collider2D col in tempDetectedEnemies)
            {
                if (!attack2.Contains(col))
                {
                    attack2.Add(col);
                }
            }
        }
        if (attack1.Count > 0 && currentCoolTime > attackCooldown)
        {
            StartCoroutine(CanHit(0.9f));
            currentCoolTime = 0;
            animator.SetTrigger("Attack1");
            StartCoroutine(Attack(0.6f,player));
        }
        else if (attack2.Count > 0 && currentCoolTime > attackCooldown)
        {
            StartCoroutine(CanHit(0.9f));
            currentCoolTime = 0;
            animator.SetTrigger("Attack2");
            StartCoroutine(Attack(0.6f,player));
        }
        else if (attack3.Count > 0 && currentCoolTime > attackCooldown)
        {
            StartCoroutine(CanHit(1.3f));
            currentCoolTime = 0;
            animator.SetTrigger("Attack3");
            StartCoroutine(Attack(1f,player));
        }
        if (detect.Length > 0)
        {

            if (!IsAttack && canAttack.Length == 0)
            {
                moveDir = detect[0].transform.position - transform.position;
                moveDir.y = 0;
                animator.SetBool("Walk", true);
                if (moveDir.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = Vector3.one;
                }
            
            }
            else
            {
                moveDir = Vector2.zero;
                animator.SetBool("Walk", false);
            }
        }
        else
        {
            moveDir = Vector2.zero;
            animator.SetBool("Walk", false);
        }
    }
    public void TakeHit()
    {
        if (canHit)
        {
            bossHp -= 1;
            animator.SetTrigger("TakeHit");
        }
        if(bossHp == 0)
        {
            death = true;
        }
    }
    IEnumerator CanHit(float time)
    {
        canHit = false;
        yield return new WaitForSeconds(time);
        canHit = true;
    }
    IEnumerator Attack(float time,PlayerSkill player)
    {
        yield return new WaitForSeconds(0.8f);
        player.PlayerGetDamage();
        yield return new WaitForSeconds(time);
        IsAttack = false;
    }

}
