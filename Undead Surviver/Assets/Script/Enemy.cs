using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;
    public Rigidbody2D target;

    bool isLive = true;

    Rigidbody2D rigid;
    SpriteRenderer spriter;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
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
        target = GameMananger.instance.player.GetComponent<Rigidbody2D>();

    }


}
