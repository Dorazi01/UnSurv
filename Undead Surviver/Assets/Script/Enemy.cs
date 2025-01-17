using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Processors;

public class Enemy : MonoBehaviour
{

    public float speed;
    public float health;
    public RuntimeAnimatorController[] animCon;
    public float maxHealth;
    
    public Rigidbody2D target;

    bool isLive;

    Rigidbody2D rigid;
    Animator anim;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
    }


  
    void FixedUpdate()
    {

        if (!isLive)
            return;

        
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;



    }

    void LateUpdate()
    {
        if (!isLive)
            return;



        spriter.flipX = target.position.x < rigid.position.x;



    }
    void OnEnable()
    {
        //프리팹이 활성화 시 타겟을 플레이어로 따라오게끔 적용
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
    }

    public void Init(SpawnData data)
    {
        anim.runtimeAnimatorController = animCon[data.spriteType];
        speed = data.speed;
        maxHealth = data.health;
        health = data.health;
    }

    /// <summary>
    /// 무기와 충돌 할 때만 시작되는 클래스
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Bullet"))
            return;

        health -= collision.GetComponent<Bullet>().damage;

        if(health > 0)
        {
            //Live, Hit Action

        }
        else
        {

            dead();

        }
    }

    void dead()
    {

        gameObject.SetActive(false);

    }
}
