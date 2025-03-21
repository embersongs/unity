using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Проверяем, что объект, вошедший в триггер, имеет тег "Player"
        if (other.CompareTag("Player"))
        {
            // Перезагружаем текущую сцену
            RestartLevel();
        }
    }

    // Метод для перезагрузки уровня
    private void RestartLevel()
    {
        // Получаем индекс текущей сцены
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        // Перезагружаем сцену по её индексу
        SceneManager.LoadScene(currentSceneIndex);
    }
}
