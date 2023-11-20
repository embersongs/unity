using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class generateWorld : MonoBehaviour
{
    //������ �� ������-�����, ��� ������� ��������� �� ���� ��������
    public GameObject ground;

    //�������� ������ �����, ��� ����� ������� �������� �� � ������������ �����
    public int nextPosGround = 50;

    //������� ��������� ������ �� �, �� ���������� nextPosGround ����������
    private float playerPosition;

    //���������� ��������� �����
    public Vector2 startGroundPos;

    //������� ��������� ����� ����� ������� � ������ ������, ��� ���������� 50 ����� � �����
    private float dX;

    //���������� ������� ������
    private float prevPos;

    void Start()
    {
        //��� ������ ���������� ��������� �����, ����� ������������ �� ������ �� nextPosGround
        startGroundPos = ground.transform.position;

        //�������������� ���������� ������� ������
        prevPos = 0; 
    }

    
    void Update()
    {

        //��������� ������������� �������� ������, ��� ����� ������ �������� �� 0 �� nextPosGround ������������
        playerPosition = transform.position.x % nextPosGround;

        //��������� �������� ������, ����� � ����� ��� �������� � 49.9 � 0.01 (0.01 - 49.9) ��������
        //� ������� �������� ����� � �����, �������� (1.21 - 0.9)
        dX = playerPosition - prevPos;

        //��� ������ ����� �������� � ����� ���������� ����� �����
        if (dX < 0)
        {
           //��������� ����� ��������� �����
           startGroundPos.x = startGroundPos.x + nextPosGround;

            //���������� ����� � ����� ������� � ��������� 0
           Instantiate(ground, startGroundPos, Quaternion.Euler(0,0,0));
      
        }

        //���������� ������� ������������� ������� ������ ��� ����������
        prevPos = transform.position.x % nextPosGround;
    }
}
