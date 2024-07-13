using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Scene[] scenes;
    private string currentScene;

    void Start()
    {
        currentScene = SceneManager.GetActiveScene().name;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(currentScene);
            Debug.Log(currentScene + " reset!");
        }
    }

    void LoadNextScene()
    {
        Debug.Log(currentScene + " completed!");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex < scenes.Length)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
            currentScene = SceneManager.GetActiveScene().name;
            Debug.Log("Onto next stage!\n" + currentScene + " started!");
        }
        else
        {
            Debug.Log("Victory!");
        }
    }
}
