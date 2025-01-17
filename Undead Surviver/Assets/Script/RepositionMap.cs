using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepositionMap : MonoBehaviour
{

    Collider2D coll;

    void Awake()
    {
        coll = GetComponent<Collider2D>();
    }


    // Start is called before the first frame update
    void OnTriggerExit2D(Collider2D collision)
    {
        //�÷��̾��� Area�±׿� �浹���� ���� ��  = �� ������ �ȳ����ٴ� ��
        if (!collision.CompareTag("Area"))
            return;
        //�ƹ��͵� ����

        //�� �ں��� �浹 ���� �� ���۵Ǵ� �ڵ��




        Vector3 playerPos = GameMananger.instance.player.transform.position;
        //Player�� ��ӹ��� �� �ִ� ������ ���ӸŴ����� �̱��������� ����߱� �����̴�.\
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        //Mathf.abs = ����
        //playerPos = �÷��̾��� ��ġ��, myPos = �� Ÿ���� ��ġ��]
        //diffX,Y = �÷��̾�� Ÿ�ϸ��� ��ġ ��


        Vector3 playerDir = GameMananger.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        //���ʿ� �ִ� Ÿ�� ���� ��������� �߰��� �� �˱����� ���� ��������

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                    //Translate = ������ �� ��ŭ ���� ��ġ���� �̵�
                }
                //X�����θ� �̵� ���� ��
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                    
                }
                //diffX,Y�� �����̱� ������ ���� �̵��ϴ� ũ�� �񱳰� ������

                break;
            case "Enemy":
                if (coll.enabled)
                {
                    transform.Translate(playerDir * 35 + new Vector3(Random.Range(-3f,3f),Random.Range(-3f, 3f), 0f));
                }

                break;
        }




    }



}
