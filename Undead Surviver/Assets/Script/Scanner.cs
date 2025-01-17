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
        //CircleCaseAll = ������ ĳ��Ʈ�� ��� ��� ����� ��ȯ�ϴ� �Լ�
        targets = Physics2D.CircleCastAll(transform.position, scanRange, Vector2.zero ,0,targetLayer);
        nearestTarget = GetNearest();
    }

    /// <summary>
    /// ���� ����� ���� Ž���ϴ� Ŭ����
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
            float curdiff = Vector3.Distance(myPos, targetPos);             //ĳ���Ϳ� ���� �Ÿ�

            if (curdiff < diff)                                             //���� ��ĵ�� ������ �� ����� ���� �ִ� ���
            {
                diff = curdiff;
                result = target.transform;                                  //����� ������ ����� ������Ʈ ��
            }

        }


        return result;                                                      //������Ʈ�� ���� ��ġ�� ����� ��� <- 16�ٷ� �̵�
    }


}
