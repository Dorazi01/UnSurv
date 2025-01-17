using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //대미지와 관통력 설정
    public float damage;
    public int per;

    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    public void Init(float damage, int per, Vector3 dir)
    {
        this.damage = damage;
        this.per = per;

        if (per > -1)                   //관통력이 -1보다 높은경우 == 근접무기가 아닌 경우
        {
            rigid.velocity = dir * 15 ;
        }
    }

    /// <summary>
    /// 총알이 적에게 닿은 경우
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per == -1)             //근접무기면 적용하지 않음
            return;

        //관통력을 줄임 / 0 이하인경우 rigid.velocity를 초기화 하며 이 게임 오브젝트를 비활성화 함(사라짐)
        per--;
        if (per == -1)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }

    }


}
