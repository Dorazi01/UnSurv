using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //������� ����� ����
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

        if (per > -1)                   //������� -1���� ������� == �������Ⱑ �ƴ� ���
        {
            rigid.velocity = dir * 15 ;
        }
    }

    /// <summary>
    /// �Ѿ��� ������ ���� ���
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Enemy") || per == -1)             //��������� �������� ����
            return;

        //������� ���� / 0 �����ΰ�� rigid.velocity�� �ʱ�ȭ �ϸ� �� ���� ������Ʈ�� ��Ȱ��ȭ ��(�����)
        per--;
        if (per == -1)
        {
            rigid.velocity = Vector2.zero;
            gameObject.SetActive(false);
        }

    }


}
