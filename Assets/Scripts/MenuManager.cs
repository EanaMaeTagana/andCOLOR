using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // load scene by name
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName); // locates the scene with the specified scene name
    }
}