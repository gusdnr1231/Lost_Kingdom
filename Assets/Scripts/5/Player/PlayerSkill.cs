using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] GameObject golemAttackPrefab;
    [SerializeField] GameObject windEffectPrefab;
    [SerializeField] Transform windEffectTransform;
    [SerializeField] Transform golemAttackTransform;
    private PlayerDetect playerDetect;
    private PlayerElements playerElements;
    private SpriteRenderer playerSP;
    private PlayerMove playerMove;
    private Animator playerAnimator;
    private bool canRolling = true;
    private bool isRolling;
    private bool isAttack = false;
    private bool attack1 = false;
    private bool attack2 = false;
    private bool attack3 = false;
    private bool attack4 = false;
    private bool canNextAttack = false;
    public bool canWindJump = false;
    public bool GetWind = false;
    public bool GetFire = false;
    public bool GetWater = false;
    public bool GetGround = false;
    void Start()
    {
        playerElements = GetComponentInChildren<PlayerElements>();
        playerDetect = GetComponent<PlayerDetect>();
        playerSP = GetComponent<SpriteRenderer>();
        playerMove = GetComponent<PlayerMove>();
        playerAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerGolemAttack();    
        PlayerAirAnimation();
        PlayerWindJump();
        PlayerAttack();
        PlayerRolling();
        if (playerDetect.IsAir)
        {
            playerAnimator.SetBool("Run", false);
        }
        else
        {
            playerAnimator.SetBool("Jump", false);
            if (playerMove.DirX == 1 || playerMove.DirX == -1)
            {
                playerAnimator.SetBool("Run", true);
            }

        }
        if (playerMove.DirX == 1 && !playerMove.isWallJumping)
        {
            playerSP.flipX = false;
        }
        else if (playerMove.DirX == -1 && !playerMove.isWallJumping)
        {
            playerSP.flipX = true;
        }
        else
        {
            playerAnimator.SetBool("Run", false);
        }
    }


    public void PlayerGetDamage()
    {
        Debug.Log("아야");
        StartCoroutine("GetDamage");
    }
    private void PlayerAirAnimation()
    {
        if (playerDetect.IsWall)
        {
            playerAnimator.SetBool("IsWall", false);
        }
        if (playerDetect.IsGround)
        {
            playerAnimator.SetBool("Air", false);
            playerAnimator.SetBool("IsWall", false);
        }
        if (playerMove.playerRigid.velocity.y > 0)
        {
            playerAnimator.SetBool("Jump", true);
        }
        else if (playerMove.playerRigid.velocity.y < 0)
        {
            playerAnimator.SetBool("Jump", false);
            if (playerDetect.IsWall)
            {
                playerAnimator.SetBool("IsWall", true);
                playerAnimator.SetBool("Air", false);
            }
            else
            {
                playerAnimator.SetBool("IsWall", false);
                playerAnimator.SetBool("Air", true);
            }
        }
    }
    private void PlayerGolemAttack()
    {
        if(Input.GetKeyDown(KeyCode.Mouse1) && playerElements.ElementGround)
        {
            if (playerSP.flipX)
            {
                Instantiate(golemAttackPrefab, golemAttackTransform.position ,Quaternion.Euler(0f,180f,0));
            }
            else
            {
                Instantiate(golemAttackPrefab, golemAttackTransform.position, Quaternion.identity);
            }
        }
    }
    private void PlayerWindJump()
    {

        if (Input.GetKeyDown(KeyCode.Mouse1) && playerDetect.IsAir && playerElements.ElementWind && canWindJump && !playerDetect.IsGroundWall)
        {
            playerMove.WindJump();
            Instantiate(windEffectPrefab,windEffectTransform);
        }
    }
    private void PlayerRolling()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && canRolling && !isAttack && playerDetect.IsGround)
        {
            StartCoroutine("Rolling");
            playerAnimator.SetTrigger("Rolling");
        }
    }
    private void PlayerAttack()
    {
        if (!playerDetect.IsWall)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0) && !attack1)
            {
                attack1 = true;
                StartCoroutine("AttackCooldown");
                playerAnimator.SetTrigger("Attack1");
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && !attack2 && attack1 && canNextAttack)
            {
                StopCoroutine("AttackCooldown");
                StartCoroutine("AttackCooldown");
                attack2 = true;
                playerAnimator.SetTrigger("Attack2");
                Debug.Log("2");
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && attack2 && !attack3 && canNextAttack)
            {
                StopCoroutine("AttackCooldown");
                StartCoroutine("AttackCooldown");
                attack3 = true;
                playerAnimator.SetTrigger("Attack3");
                Debug.Log("3");
            }
            else if (Input.GetKeyDown(KeyCode.Mouse0) && attack3 && !attack4 && canNextAttack)
            {
                StopCoroutine("AttackCooldown");
                StartCoroutine("AttackCooldown"); // 이거 바꾸면 공격속도 조절가능
                attack4 = true;
                playerAnimator.SetTrigger("Attack4");
                Debug.Log("4");
            }
        }
    }
    private void AttackController()
    {
        canNextAttack = false;
        attack1 = false;
        attack2 = false;
        attack3 = false;
        attack4 = false;
    }
    IEnumerator AttackCooldown()
    {
        isAttack = true;
        playerAnimator.SetBool("IsAttack", true);
        canNextAttack = false;
        yield return new WaitForSeconds(0.5f);
        canNextAttack = true;
        isAttack = false;
        playerAnimator.SetBool("IsAttack", false);
        yield return new WaitForSeconds(1.5f);
        AttackController();
        Debug.Log(2 + "기달림");
        yield break;
    }
    IEnumerator Rolling()
    {
        canRolling = false;
        isRolling = true;
        yield return new WaitForSeconds(0.7f);
        isRolling = false;
        yield return new WaitForSeconds(1f);
        canRolling = true;
        yield break;
    }
    IEnumerator GetDamage()
    {
        playerSP.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.2f);
        playerSP.color = new Color(1, 1, 1, 1);
    }
}
