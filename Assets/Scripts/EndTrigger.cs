using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName; // Имя сцены для перехода
    [SerializeField] private GameObject Bone; // Объект, который нужно уничтожить
    [SerializeField] private GameObject secondTrigger; // Второй триггер для перехода на сцену

    private bool boneDestroyed = false; // Флаг состояния уничтожения кости

    private void Start()
    {
        if (secondTrigger != null)
        {
            secondTrigger.SetActive(false); // Отключаем второй триггер изначально
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Bone != null && !boneDestroyed)
            {
                Destroy(Bone); // Уничтожаем кость
                boneDestroyed = true; // Устанавливаем флаг

                if (secondTrigger != null)
                {
                    secondTrigger.SetActive(true); // Активируем второй триггер
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && boneDestroyed && secondTrigger != null && secondTrigger.activeSelf)
        {
            // Если игрок входит в активный второй триггер и кость уничтожена
            SceneManager.LoadScene(sceneName);
        }
    }
}
