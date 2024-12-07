using UnityEngine;

public class Deactivate : MonoBehaviour
{
    public GameObject targetObject;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (targetObject != null)
            {
                targetObject.SetActive(false);
            }
        }
    }
}
