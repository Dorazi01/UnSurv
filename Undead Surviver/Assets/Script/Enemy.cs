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
        //�������� Ȱ��ȭ �� Ÿ���� �÷��̾�� ������Բ� ����
        //����� ������Ʈ�� �ʱ�ȭ�ϴ� �뵵
        target = GameManager.instance.player.GetComponent<Rigidbody2D>();
        isLive = true;
        health = maxHealth;
        coll.enabled = true;                   //�ݶ��̴��� Ȱ��ȭ/��Ȱ��ȭ
        rigid.simulated = true;                //������ٵ�� �ùķ���Ƽ�� ���
        spriter.sortingOrder = 2;               //�������̾ 1�� ���� �ٸ� ������ ������ �ʰ� ��
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
    /// ����� �浹 �� ���� ���۵Ǵ� Ŭ����
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
            coll.enabled = false;                   //�ݶ��̴��� Ȱ��ȭ/��Ȱ��ȭ
            rigid.simulated = false;                //������ٵ�� �ùķ���Ƽ�� ���
            spriter.sortingOrder = 1;               //�������̾ 1�� ���� �ٸ� ������ ������ �ʰ� ��
            anim.SetBool("Dead",true);
            GameManager.instance.kill++;
            GameManager.instance.GetExp();
            if (GameManager.instance.isLive)
            {
                AudioManager.instance.PlaySfx(AudioManager.Sfx.Dead);
            }



        }
    }

    //Coroutine �ڷ�ƾ �Լ� : �����ֱ�� �񵿱�ó�� ����Ǵ� �Լ�
    IEnumerator KnockBack()
    {
        yield return wait; //���� �ϳ��� ���� �������� ������ �ַ��� ��
        Vector3 playerpos = GameManager.instance.player.transform.position;
        Vector3 dirVec = transform.position - playerpos;
        rigid.AddForce(dirVec.normalized * 3, ForceMode2D.Impulse);
        
    }



    void dead()
    {

        gameObject.SetActive(false);

    }
}
