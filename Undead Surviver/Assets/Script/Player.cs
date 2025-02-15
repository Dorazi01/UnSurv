using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;




//C#스크립트를 오브젝트 컴포넌트에 넣어야 오브젝트가 움직일 수 있다. 


public class Player : MonoBehaviour //MonoBehaviour = 게임 로직 구정에 필요한것들을 가진 클래스
{
    //public 선언 : 다른 스크립트에게 공개한다고 선언하는 키워드
    public Vector2 inputVec;
    public Scanner scanner;
    public Hand[] hands;
    public RuntimeAnimatorController[] animCon;

    //게임오브젝트의 리지드바디 2D를 저장할 변수 선언
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    

    public float speed;






    void Awake()
    {
        //GetComponent<T> = 오브젝트에서 컴포넌트를 가져오는 함수
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }


    private void OnEnable()
    {
        speed *= Character.Speed;
        anim.runtimeAnimatorController = animCon[GameManager.instance.playerId];
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void Update()
    {
        if (!GameManager.instance.isLive)
            return;

    }


    //물리연산 프레임마다 호출되는 생명주기함수
    void FixedUpdate()
    {
        if (!GameManager.instance.isLive)
            return;
        //normalized = 정규화, 벡터 값의 크기가 1이 되도록 좌표가 수정된 값. 대각선 이동을 할 때 더 빠르게 움직이는 것을 방지하기 위함.
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //fixedDeltatime = 물리 프레임 하나가 소비한 시간
        
        //위치 이동
        rigid.MovePosition (rigid.position + nextVec);
        //MovePosition은 위치 이동이라 현재 위치도 더해주어야 함.
        //inputVec의  값은 -1,-1 ~ 1,1이기 때문에 현재 위치에서 inputVec의 값 만큼 더해서 이동시키기 위함임.


    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();

    }


    /// <summary>
    /// Late Update = 프레임이 종료되기 전 실행되는 생명주기 함수
    /// </summary>
    void LateUpdate()
    {
        if (!GameManager.instance.isLive)
            return;

        anim.SetFloat("Speed",inputVec.magnitude);
        //magnitude : 벡터의 순수한 크기 값으로 변환



        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        } //inputVec.X의 값이 0도 아니고, 0보다 작을시 스프라이트를 뒤집음




    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (!GameManager.instance.isLive) return;


        GameManager.instance.health -= Time.deltaTime * 10;

        if (GameManager.instance.health < 0)
        {
            for (int index = 2; index < transform.childCount; index++)
            {
                transform.GetChild(index).gameObject.SetActive(false);

            }
            anim.SetTrigger("Dead");
            GameManager.instance.GameOver();

        }

    }

}
