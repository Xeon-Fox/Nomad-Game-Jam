using UnityEngine;
using UnityEngine.SceneManagement;

public class SkipVid : MonoBehaviour
{
    [SerializeField] private string sceneName;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) 
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}