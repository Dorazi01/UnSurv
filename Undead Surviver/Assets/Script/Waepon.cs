using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
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

    float timer;

    Player player;

    private void Awake()
    {
        player = GameManager.instance.player;
    }


    // Update is called once per frame
    void Update()
    {
        switch (id)
        {
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);

                break;

            case 1:
                timer += Time.deltaTime;
                
                if (timer > speed)
                {
                    timer = 0f;
                    Fire();
                }
                break;
        }

        //test
        if (Input.GetButtonDown("Jump"))
        {
            levelUp(10, 1);
        }


    }

    public void levelUp(float damage, int count)
    {
        this.damage = damage;
        this.count += count;

        if (id == 0)
            Batch();

        player.BroadcastMessage("ApplyGear",SendMessageOptions.DontRequireReceiver);
    }


    public void Init(ItemData data)
    {

        //기본 세팅
        name = "Waepon" + data.itemId;
        transform.parent = player.transform;
        transform.localPosition = Vector3.zero;



        //프로퍼티 세팅
        id = data.itemId;
        damage = data.baseDamage;
        count = data.baseCount;

        for (int index  = 0; index < GameManager.instance.pool.prefabs.Length; index++)
        {
            if(data.projectile == GameManager.instance.pool.prefabs[index])
            {
                prefabId = index;
                break;
            }
        }


        switch (id)
        {
            case 0:
                speed = 150;       //시계방향으로 돌려면 음수
                Batch();

                break;
            

            default:
                speed = 0.4f;
                break;
        }

        //Hand set

        Hand hand = player.hands[(int)data.itemType];
        hand.spriter.sprite = data.hand;
        hand.gameObject.SetActive(true);

        player.BroadcastMessage("ApplyGear", SendMessageOptions.DontRequireReceiver);
    }

    /// <summary>
    /// 근접무기 배치
    /// </summary>
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
            bullet.GetComponent<Bullet>().Init(damage, -1, Vector3.zero);             // -1 is Infinity per
        }
    }




    /// <summary>
    /// 총알 발사
    /// </summary>
    void Fire()
    {
        if (!player.scanner.nearestTarget)
            return;
        

        Vector3 targetPos = player.scanner.nearestTarget.position;
        Vector3 dir = targetPos - transform.position;
        dir = dir.normalized;



        Transform bullet = GameManager.instance.pool.Get(prefabId).transform;
        bullet.position = transform.position;
        bullet.rotation = Quaternion.FromToRotation(Vector3.up, dir);
        //FromToRotation = 지정된 축을 중심으로 목표를 향해 회전하는 함수
        bullet.GetComponent<Bullet>().Init(damage, count, dir);    

    }
}
