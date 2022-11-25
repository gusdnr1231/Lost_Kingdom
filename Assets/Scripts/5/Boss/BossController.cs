using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] BoxCollider2D playerDetectSize;
    [SerializeField] BoxCollider2D canAttackSize;
    [SerializeField] BoxCollider2D dashAttackSize;
    [SerializeField] LayerMask playerLayer;
    [SerializeField] List<Collider2D> attack1Size;
    [SerializeField] BoxCollider2D attack2Size;
    [SerializeField] List<Collider2D> attack3Size;
    [SerializeField] float moveSpeed;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigid;
    private Animator animator;
    private Vector2 moveDir;
    [SerializeField] float attackCoolTime;
    private float currentAttackTime;
    public bool IsAttack;
    public bool canDashAttack;
    public bool canAttack;
    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        currentAttackTime += Time.deltaTime;
        DetectPlayer();
        if (rigid.velocity.x != 0)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }
        if (moveDir.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveDir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
    void DetectPlayer()
    {
        Collider2D[] detect = Physics2D.OverlapBoxAll(playerDetectSize.bounds.center, playerDetectSize.size, 0f, playerLayer);
        Collider2D[] canAttackBox = Physics2D.OverlapBoxAll(playerDetectSize.bounds.center, canAttackSize.size, 0f, playerLayer);
        Collider2D[] attack2 = Physics2D.OverlapBoxAll(playerDetectSize.bounds.center, attack2Size.size, 0f, playerLayer);
        Collider2D[] dashAttack = Physics2D.OverlapBoxAll(playerDetectSize.bounds.center, dashAttackSize.size, 0f, playerLayer);
        List<Collider2D> attack1 = new List<Collider2D>();
        List<Collider2D> attack3 = new List<Collider2D>();

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
        if(detect.Length > 0)
        {
            if (canAttack)
            {
                if(dashAttack.Length > 0)
                {

                }
                rigid.velocity = new Vector2(0, 0);
            }
            else 
            {
                moveDir = detect[0].transform.position - transform.position;
                moveDir.y = 0;
                rigid.velocity = moveDir * moveSpeed;
            }
        }
        else
        {
            moveDir = Vector2.zero;
        }
    }
    IEnumerator DashAttack()
    {
        yield return null;
    }
}
