using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePad : MonoBehaviour
{
    /*
    public 선언 : 다른 스크립트에게 공개한다고 선언하는 키워드
    public Vector2 inputVec;
    //변수 선언 : 데이터타입   데이터이름;

    //게임오브젝트의 리지드바디 2D를 저장할 변수 선언
    Rigidbody2D rigid;






    void Awake()
    {
        //GetComponent<T> = 오브젝트에서 컴포넌트를 가져오는 함수
        rigid = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input = 유니티에서 받는 모든 입력을 관리하는 클래스
        //GetAxis = Horizontal의 값을 반환함
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        //GetAxisRaw = 더욱 명확한 컨트롤이 구현됨
    }





    //물리연산 프레임마다 호출되는 생명주기함수
    
        //normalized = 정규화, 벡터 값의 크기가 1이 되도록 좌표가 수정된 값. 대각선 이동을 할 때 더 빠르게 움직이는 것을 방지하기 위함.
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //fixedDeltatime = 물리 프레임 하나가 소비한 시간



        //물리 이동 방식 세가지

        //1. 힘을 준다
        //rigid.AddForce (inputVec);
        //AddForce의 경우 가속도에 해당돼 연속해서 가하면 자동차의 페달처럼 가속함.
        //순간적으로 튀어오르고 점차 속도가 줄어드는 점프의 개념에 적합하다


        //2. 속도 제어
        //rigid.velocity = inputVec;
        //velocity의 힘을 가해도 동일한 속도로 달릴 수 있도록 물리엔진이 자동으로 계산 해줌.

        //3. 위치 이동
        rigid.MovePosition(rigid.position + nextVec);
        //MovePosition은 위치 이동이라 현재 위치도 더해주어야 함.
        //inputVec의  값은 -1,-1 ~ 1,1이기 때문에 현재 위치에서 inputVec의 값 만큼 더해서 이동시키기 위함임.



    IEnumerator = Coroutine 코루틴 함수 : 생명주기와 비동기처럼 실행되는 함수

    ex) yield return null; //1프레임을 쉼

        yield return new WaitForSeconds(2f); //2초 쉬기















































    */



}
