using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;

    [SerializeField] private Button loadSceneButton;
    [SerializeField] private Button quitGameButton;

    void Start()
    {
        if (loadSceneButton != null)
        {
            loadSceneButton.onClick.AddListener(LoadScene);
        }

        if (quitGameButton != null)
        {
            quitGameButton.onClick.AddListener(QuitGame);
        }
    }

    public void LoadScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
