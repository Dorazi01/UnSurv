using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;




//C#��ũ��Ʈ�� ������Ʈ ������Ʈ�� �־�� ������Ʈ�� ������ �� �ִ�. 


public class Player : MonoBehaviour //MonoBehaviour = ���� ���� ������ �ʿ��Ѱ͵��� ���� Ŭ����
{
    //public ���� : �ٸ� ��ũ��Ʈ���� �����Ѵٰ� �����ϴ� Ű����
    public Vector2 inputVec;
    public Scanner scanner;
    public Hand[] hands;

    //���ӿ�����Ʈ�� ������ٵ� 2D�� ������ ���� ����
    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    

    public float speed;






    void Awake()
    {
        //GetComponent<T> = ������Ʈ���� ������Ʈ�� �������� �Լ�
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        scanner = GetComponent<Scanner>();
        hands = GetComponentsInChildren<Hand>(true);
    }






    // Start is called before the first frame update
    void Start()
    {
        
    }

    





    //�������� �����Ӹ��� ȣ��Ǵ� �����ֱ��Լ�
    void FixedUpdate()
    {
        //normalized = ����ȭ, ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ��. �밢�� �̵��� �� �� �� ������ �����̴� ���� �����ϱ� ����.
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //fixedDeltatime = ���� ������ �ϳ��� �Һ��� �ð�
        
        //��ġ �̵�
        rigid.MovePosition (rigid.position + nextVec);
        //MovePosition�� ��ġ �̵��̶� ���� ��ġ�� �����־�� ��.
        //inputVec��  ���� -1,-1 ~ 1,1�̱� ������ ���� ��ġ���� inputVec�� �� ��ŭ ���ؼ� �̵���Ű�� ������.


    }

    void OnMove(InputValue value)
    {
        inputVec = value.Get<Vector2>();

    }


    /// <summary>
    /// Late Update = �������� ����Ǳ� �� ����Ǵ� �����ֱ� �Լ�
    /// </summary>
    void LateUpdate()
    {

        anim.SetFloat("Speed",inputVec.magnitude);
        //magnitude : ������ ������ ũ�� ������ ��ȯ



        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        } //inputVec.X�� ���� 0�� �ƴϰ�, 0���� ������ ��������Ʈ�� ������




    }




}
