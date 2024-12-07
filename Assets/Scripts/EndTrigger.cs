using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName; // ��� ����� ��� ��������
    [SerializeField] private GameObject Bone; // ������, ������� ����� ����������
    [SerializeField] private GameObject secondTrigger; // ������ ������� ��� �������� �� �����

    private bool boneDestroyed = false; // ���� ��������� ����������� �����

    private void Start()
    {
        if (secondTrigger != null)
        {
            secondTrigger.SetActive(false); // ��������� ������ ������� ����������
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Bone != null && !boneDestroyed)
            {
                Destroy(Bone); // ���������� �����
                boneDestroyed = true; // ������������� ����

                if (secondTrigger != null)
                {
                    secondTrigger.SetActive(true); // ���������� ������ �������
                }
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && boneDestroyed && secondTrigger != null && secondTrigger.activeSelf)
        {
            // ���� ����� ������ � �������� ������ ������� � ����� ����������
            SceneManager.LoadScene(sceneName);
        }
    }
}
