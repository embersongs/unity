using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //��������� ���������� ��� �������� �������

public class FinishLevel : MonoBehaviour
{
    //��� ����� �� ��������� �������
    public string nextLevelName = "Level2";

    //��� ������ ����������� � ������ �����������
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //�������� ��� �����
        if (collision.CompareTag("Player"))
        {
            //���� ��, �� �������� ��������� ������� �� ����� �� nextLevelName
            SceneManager.LoadScene(nextLevelName);
        }
    }

}
