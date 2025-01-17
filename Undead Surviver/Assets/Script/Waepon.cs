using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������� �������ִ� ��ũ��Ʈ
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
                speed = 150;       //�ð�������� ������ ����
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
                bullet = transform.GetChild(index);                         //�ڽĿ�����Ʈ�� ���� ��Ȱ�� 
            }
            else
            {
                bullet = GameManager.instance.pool.Get(prefabId).transform; //�� �Ŀ� ����
                bullet.parent = transform;
            }
   

            

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;         //�ʱ�ȭ 


            Vector3 rotVec = Vector3.forward * 360 * index / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damage, -1);             // -1 is Infinity per
        }
    }


}
