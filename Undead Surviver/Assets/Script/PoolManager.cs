using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    // 프리팹을 보관할 변수 
    public GameObject[] prefabs;




    // 풀 담당을 하는 리스트 필요
    List<GameObject>[] pools;


    void Awake()
    {
        pools = new List<GameObject>[prefabs.Length];
        //초기화 과정


        for (int index = 0; index < pools.Length; index++)
        {
            pools[index] = new List<GameObject>();
            //리스트의 풀도 초기화해야함

        }

       
    }

    public GameObject Get(int index)
    {
        GameObject select = null;       
        // 선택한 풀의 비활성화된 게임오브젝트 접근
           
        foreach (GameObject item in pools[index])
        {
            if (!item.activeSelf)
            {
                //발견시 select변수에 할당
                select = item;
                select.SetActive(true);
                break;
            }

        }

        if (!select)
        {
            //못찾으면 새롭게 생성해서 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
                //instantiate 원본 오브젝트를 복제해서 장면에 생성하는 함수
                pools[index].Add(select);
        }
        return select;

    }



}
