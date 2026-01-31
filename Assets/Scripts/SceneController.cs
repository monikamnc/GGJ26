using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void goToGame()
    {
        SceneManager.LoadScene("MainScene");
    }
}
