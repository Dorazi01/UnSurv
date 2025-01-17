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
        //플레이어의 Area태그에 충돌하지 않을 때  = 맵 밖으로 안나갔다는 뜻
        if (!collision.CompareTag("Area"))
            return;
        //아무것도 안함

        //이 뒤부턴 충돌 했을 때 시작되는 코드들




        Vector3 playerPos = GameMananger.instance.player.transform.position;
        //Player을 상속받을 수 있는 이유는 게임매니저에 싱글톤패턴을 사용했기 때문이다.\
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(playerPos.x - myPos.x);
        float diffY = Mathf.Abs(playerPos.y - myPos.y);
        //Mathf.abs = 절댓값
        //playerPos = 플레이어의 위치값, myPos = 맵 타일의 위치값]
        //diffX,Y = 플레이어와 타일맵의 위치 비교


        Vector3 playerDir = GameMananger.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;
        //뒤쪽에 있는 타일 맵을 어느쪽으로 추가할 지 알기위해 만든 변수같음

        switch (transform.tag)
        {
            case "Ground":
                if (diffX > diffY)
                {
                    transform.Translate(Vector3.right * dirX * 40);
                    //Translate = 지정된 값 만큼 현재 위치에서 이동
                }
                //X축으로만 이동 했을 때
                else if (diffX < diffY)
                {
                    transform.Translate(Vector3.up * dirY * 40);
                    
                }
                //diffX,Y가 절댓값이기 때문에 어디로 이동하던 크기 비교가 가능함

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
