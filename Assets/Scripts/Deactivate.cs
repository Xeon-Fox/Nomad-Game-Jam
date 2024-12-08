using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject targetObject;
    public GameObject particleObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(false);
                particleObject.SetActive(true);
            }
        }
    }
}
