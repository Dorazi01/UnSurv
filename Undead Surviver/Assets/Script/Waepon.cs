using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 무기들을 관리해주는 스크립트
/// </summary>
public class Waepon : MonoBehaviour
{

    public int id;
    public int prefabId;
    public float damage;
    public int count;
    public float speed;

    void Start()
    {
        Init();
    }
    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);

                break;



            default:
                break;
        }

        //TEST
        if (Input.GetButtonDown("Jump"))
        {
            levelUp(20 , 5);
        }



    }

    public void levelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
            Batch();
    }


    public void Init()
    {
        switch (id)
        {
            case 0:
                speed = 150;       //시계방향으로 돌려면 음수
                Batch();

                break;

            

            default:
                break;
        }
    }


    void Batch()
    {
        for (int index = 0; index < count; index++)
        {
            Transform bullet;
                
                if (index < transform.childCount)
            {
                bullet = transform.GetChild(index);                         //자식오브젝트를 먼저 재활용 
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform; //그 후에 생성
                bullet.parent = transform;
            }
   

            

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;         //초기화 


            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1);             // -1 is Infinity per
        }
    }


}
