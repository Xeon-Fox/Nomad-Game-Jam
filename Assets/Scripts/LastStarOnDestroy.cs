using UnityEngine;

public class LastStarOnDestroy : MonoBehaviour 
{
    public GameObject objectToActivate;

    void OnDestroy()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
