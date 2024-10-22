using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OnButtonPress(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
