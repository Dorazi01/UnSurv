using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    public float scanRange;
    public LayerMask targetLayer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;

    private void FixedUpdate()
    {
        //CircleCaseAll = 원형의 캐스트를 쏘고 모든 결과를 반환하는 함수
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero ,0,targetLayer);
        nearestTarget = GetNearest();
    }

    /// <summary>
    /// 가장 가까운 적을 탐색하는 클래스
    /// </summary>
    /// <returns></returns>
    Transform GetNearest()
    {
        Transform result = null;
        float diff = 100;

        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curdiff = Vector3.Distance(myPos, targetPos);             //캐릭터와 적의 거리

            if (curdiff < diff)                                             //현재 스캔된 적보다 더 가까운 적이 있는 경우
            {
                diff = curdiff;
                result = target.transform;                                  //가까운 적으로 결과를 업데이트 함
            }

        }


        return result;                                                      //업데이트한 적의 위치를 결과로 출력 <- 16줄로 이동
    }


}
