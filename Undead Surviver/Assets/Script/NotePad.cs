using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotePad : MonoBehaviour
{
    /*
    public ���� : �ٸ� ��ũ��Ʈ���� �����Ѵٰ� �����ϴ� Ű����
    public Vector2 inputVec;
    //���� ���� : ������Ÿ��   �������̸�;

    //���ӿ�����Ʈ�� ������ٵ� 2D�� ������ ���� ����
    Rigidbody2D rigid;






    void Awake()
    {
        //GetComponent<T> = ������Ʈ���� ������Ʈ�� �������� �Լ�
        rigid = GetComponent<Rigidbody2D>();
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Input = ����Ƽ���� �޴� ��� �Է��� �����ϴ� Ŭ����
        //GetAxis = Horizontal�� ���� ��ȯ��
        inputVec.x = Input.GetAxisRaw("Horizontal");
        inputVec.y = Input.GetAxisRaw("Vertical");
        //GetAxisRaw = ���� ��Ȯ�� ��Ʈ���� ������
    }





    //�������� �����Ӹ��� ȣ��Ǵ� �����ֱ��Լ�
    
        //normalized = ����ȭ, ���� ���� ũ�Ⱑ 1�� �ǵ��� ��ǥ�� ������ ��. �밢�� �̵��� �� �� �� ������ �����̴� ���� �����ϱ� ����.
        Vector2 nextVec = inputVec * speed * Time.fixedDeltaTime;
        //fixedDeltatime = ���� ������ �ϳ��� �Һ��� �ð�



        //���� �̵� ��� ������

        //1. ���� �ش�
        //rigid.AddForce (inputVec);
        //AddForce�� ��� ���ӵ��� �ش�� �����ؼ� ���ϸ� �ڵ����� ���ó�� ������.
        //���������� Ƣ������� ���� �ӵ��� �پ��� ������ ���信 �����ϴ�


        //2. �ӵ� ����
        //rigid.velocity = inputVec;
        //velocity�� ���� ���ص� ������ �ӵ��� �޸� �� �ֵ��� ���������� �ڵ����� ��� ����.

        //3. ��ġ �̵�
        rigid.MovePosition(rigid.position + nextVec);
        //MovePosition�� ��ġ �̵��̶� ���� ��ġ�� �����־�� ��.
        //inputVec��  ���� -1,-1 ~ 1,1�̱� ������ ���� ��ġ���� inputVec�� �� ��ŭ ���ؼ� �̵���Ű�� ������.



    IEnumerator = Coroutine �ڷ�ƾ �Լ� : �����ֱ�� �񵿱�ó�� ����Ǵ� �Լ�

    ex) yield return null; //1�������� ��

        yield return new WaitForSeconds(2f); //2�� ����















































    */



}
