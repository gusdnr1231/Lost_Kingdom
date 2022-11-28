using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMain : MonoBehaviour
{
	[Header("몬스터 변수")]
	public int MaxHealthPoint;
	int CurHealthPoint;
	public float Speed;
	public float RayDistance;
	public int AttackPoint;
	public int AttackDelay, DelayTemp;
	public Vector2 AttackSize;

	[Header("적 컴포넌트")]
	Rigidbody2D EnemyRigidbody;
	Collider2D EnemyCollider;
	SpriteRenderer EnemyRenderer;
	Animator EnemyAnima;

	int lastMove = 1;
	int nextMove;
	float enemyMoving;
	bool isDead = false;

	void Awake()
	{
		EnemyRigidbody = this.GetComponent<Rigidbody2D>();
		EnemyCollider = this.GetComponent<BoxCollider2D>();
		EnemyRenderer = this.GetComponent<SpriteRenderer>();
		EnemyAnima = this.GetComponent<Animator>();
		EnemyAnima.SetFloat("Move", enemyMoving);
		CurHealthPoint = MaxHealthPoint;
		Invoke("Think", 3);
	}

	void Start()
	{
		StartCoroutine("AttackLate");
	}

	void Update()
	{
		SearchPlayer();
		if (AttackDelay == DelayTemp)
		{
			StopAllCoroutines();
			StartCoroutine("AttackLate");
		}
	}

	#region 움직이기
	void Moving(int move)
	{
		EnemyAnima.SetFloat("Move", enemyMoving);
		this.EnemyRigidbody.velocity = new Vector2(move * Speed, EnemyRigidbody.velocity.y);
		Vector2 frontVector = new Vector2(EnemyRigidbody.position.x + move * 0.5f, EnemyRigidbody.position.y);
		RaycastHit2D Ground = Physics2D.Raycast(frontVector, Vector3.down, 5, LayerMask.GetMask("Ground"));
		Debug.DrawRay(frontVector, Vector3.down, Color.red);
		//Debug.Log($"땅 감지 :{(bool)Ground}");
		RaycastHit2D Wall = Physics2D.Raycast(EnemyCollider.bounds.center, new Vector2(nextMove, 0), 2f, LayerMask.GetMask("Ground"));
		//Debug.Log($"벽 감지 :{(bool)Wall}");
		Debug.DrawRay(EnemyCollider.bounds.center, new Vector2(nextMove, 0), Color.blue);
		if (Ground.collider == null || Wall.collider != null)
		{
			Turn();
		}
	}
	void Turn()
	{
		nextMove *= -1;
		EnemyRenderer.flipX = nextMove == -1;
		CancelInvoke();
		Invoke("Think", 2);
	}
	void Think()
	{
		nextMove = Random.Range(-1, 2);
		EnemyAnima.SetFloat("Move", enemyMoving);
		if (nextMove != 0) EnemyRenderer.flipX = nextMove == -1;
		float nextThinkTime = Random.Range(2f, 5f);
		Invoke("Think", nextThinkTime);
	}
	#endregion

	void SearchPlayer()
	{
		Vector2 searchVec = new Vector2(lastMove, 0);
		RaycastHit2D search = Physics2D.Raycast(EnemyCollider.bounds.center, searchVec, RayDistance, LayerMask.GetMask("Player"));
		//Debug.Log($"플레이어 감지 : {(bool)search}");
		if (search.collider != null)
		{
			EnemyRenderer.flipX = lastMove == -1;
			nextMove = lastMove;
			enemyMoving = 0;
			Moving(0);
			Debug.Log("플레이어 감지");
			if (AttackDelay == 0)
			{
				Attack();
				EnemyAnima.SetTrigger("Attack");
				AttackDelay = DelayTemp;
			}
		}
		else if (search.collider == null)
		{
			if (nextMove != 0)
			{
				enemyMoving = 1;
				lastMove = nextMove;
			}
			else if (nextMove == 0) enemyMoving = 0;
			Moving(nextMove);
		}
	}

	IEnumerator AttackLate()
	{
		while (CurHealthPoint > 0 && AttackDelay != 0)
		{
			AttackDelay -= 1;
			yield return new WaitForSeconds(1f);
		}
	}

	#region 공격하기/받기

	void Attack()
	{
		Collider2D[] AttackZone = Physics2D.OverlapBoxAll(EnemyCollider.bounds.center, AttackSize, 0);
		foreach (Collider2D col in AttackZone)
		{
			PlayerSkill player = col.GetComponent<PlayerSkill>();
			if (player)
			{
				player.PlayerGetDamage();
			}
		}
	}

	public void Hit() //데미지 입기
	{
		if (CurHealthPoint > 0)
		{
			CurHealthPoint--;
			EnemyAnima.SetTrigger("Hit");
		}
		if (CurHealthPoint == 0)
		{
			isDead = true;
			EnemyRigidbody.velocity = Vector2.zero;
			EnemyAnima.SetBool("Dead", isDead);
			Destroy(gameObject, EnemyAnima.GetCurrentAnimatorStateInfo(0).length);
		}
	}

	#endregion
}
