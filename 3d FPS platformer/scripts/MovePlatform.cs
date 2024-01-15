using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovePlatform : MonoBehaviour
{
    public GameObject Player;

    // ��� ������ �� ��������� ��������� Player, ������ ��� �������� ���������
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    //��� ��������� ��������� ��������� �����
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            other.gameObject.transform.SetParent(null);
        }
    }


    void FixedUpdate()
    {
        //������� ���, ����� ��� ������ ����� Fixed, ����� ����� ����� ��������� �� ���������
        var step = 2 * Time.deltaTime; //2 �������� �������� ���������
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(-1.0f, 0.3f, 110.0f), step);
    }
}
