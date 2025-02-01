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




        Vector3 playerPos = GameManager.instance.player.transform.position;
        //Player�� ��ӹ��� �� �ִ� ������ ���ӸŴ����� �̱��������� ����߱� �����̴�.\
        Vector3 myPos = transform.position;
        
        //���ʿ� �ִ� Ÿ�� ���� ��������� �߰��� �� �˱����� ���� ��������

        switch (transform.tag)
        {
            case "Ground":

                float diffX = playerPos.x - myPos.x;
                float diffY = playerPos.y - myPos.y;
                float dirX = diffX < 0 ? -1 : 1;
                float dirY = diffY < 0 ? -1 : 1;
                diffX = Mathf.Abs(diffX);
                diffY = Mathf.Abs(diffY);


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
                    Vector3 dist = playerPos - myPos;
                    Vector3 ran = new Vector3(Random.Range(-3, 3),0);
                    transform.Translate(ran + dist * 2);
                }

                break;
        }




    }



}
