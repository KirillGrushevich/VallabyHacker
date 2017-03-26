using UnityEngine;
using UnityEngine.SceneManagement;

public class TestEscapeReloadLevel : MonoBehaviour 
{
    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
