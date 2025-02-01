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
    Collider2D coll;
    Animator anim;
    SpriteRenderer spriter;
    WaitForFixedUpdate wait;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();
        spriter = GetComponent<SpriteRenderer>();
        wait = new WaitForFixedUpdate();
    }


  
    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        if (!isLive || anim.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            return;

        
        Vector2 dirVec = target.position - rigid.position;
        Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
        rigid.MovePosition(rigid.position + nextVec);
        rigid.velocity = Vector2.zero;



    }

    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        if (!isLive)
            return;



        spriter.flipX = target.position.x < rigid.position.x;



    }
    void OnEnable()
    {
        //프리팹이 활성화 시 타겟을 플레이어로 따라오게끔 적용
        //재사용시 컴포넌트를 초기화하는 용도
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
        coll.enabled = true;                   //콜라이더는 활성화/비활성화
        rigid.simulated = true;                //리지드바디는 시뮬레이티드 사용
        spriter.sortingOrder = 2;               //오더레이어를 1로 내려 다른 적들을 가리지 않게 함
        anim.SetBool("Dead", false);
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
        if (!collision.CompareTag("Bullet") || !isLive)
            return;

        health -= collision.GetComponent<Bullet>().damage;
        StartCoroutine(KnockBack());

        if(health > 0)
        {
            //Live, Hit Action
            anim.SetTrigger("Hit");

            AudioManager.instance.PlaySfx(AudioManager.Sfx.Hit);


        }
        else
        {
            isLive = false;
            coll.enabled = false;                   //콜라이더는 활성화/비활성화
            rigid.simulated = false;                //리지드바디는 시뮬레이티드 사용
            spriter.sortingOrder = 1;               //오더레이어를 1로 내려 다른 적들을 가리지 않게 함
            anim.SetBool("Dead",true);
            GameManager.instance.kill++;
            GameManager.instance.GetExp();
            if (GameManager.instance.isLive)
            {
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead);
            }



        }
    }

    //Coroutine 코루틴 함수 : 생명주기와 비동기처럼 실행되는 함수
    IEnumerator KnockBack()
    {
        yield return wait; //다음 하나의 물리 프레임을 딜레이 주려고 함
        Vector3 playerpos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerpos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        
    }



    void dead()
    {

        gameObject.SetActive(false);

    }
}
