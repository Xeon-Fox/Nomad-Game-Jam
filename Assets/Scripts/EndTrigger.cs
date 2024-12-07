using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour
{
    [SerializeField] private string sceneName;
    [SerializeField] private GameObject Bone;
    [SerializeField] private GameObject secondTrigger;

    private bool boneDestroyed = false;
    private bool reachedSecondTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.gameObject == secondTrigger)
            {
                reachedSecondTrigger = true;
            }
            if (other.gameObject == Bone)
            {
                Destroy(Bone);
                boneDestroyed = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && boneDestroyed && reachedSecondTrigger)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}