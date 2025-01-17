using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // �������� ������ ���� 
    public GameObject[] prefabs;




    // Ǯ ����� �ϴ� ����Ʈ �ʿ�
    List<GameObject>[] pools;


    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        //�ʱ�ȭ ����


        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
            //����Ʈ�� Ǯ�� �ʱ�ȭ�ؾ���

        }

       
    }

    public GameObject Get(int index)
    {
        GameObject select = null;       
        // ������ Ǯ�� ��Ȱ��ȭ�� ���ӿ�����Ʈ ����
           
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                //�߽߰� select������ �Ҵ�
                select = item;
                select.SetActive(true);
                break;
            }

        }

        if (!select)
        {
            //��ã���� ���Ӱ� �����ؼ� select ������ �Ҵ�
            select = Instantiate(prefabs[index], transform);
                //instantiate ���� ������Ʈ�� �����ؼ� ��鿡 �����ϴ� �Լ�
                pools[index].Add(select);
        }
        return select;

    }



}
