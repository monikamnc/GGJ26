using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public GameObject BlackBackgroundAndText;
    public Text PressAnyKeyText;
    public float TextAlphaHighlightStep = 0.1f;
    float TextAlpha = 0.0f;
    public InputActionReference anyKeyInputAction;

    private void Start()
    {
        BlackBackgroundAndText.SetActive(false);
        PressAnyKeyText.color = new Color(1.0f, 1.0f, 1.0f, TextAlpha);
    }

    void FixedUpdate()
    {
        TextAlpha += TextAlphaHighlightStep;
        PressAnyKeyText.color = new Color(1.0f, 1.0f, 1.0f, TextAlpha);

        if (TextAlpha <= 0.0f || TextAlpha >= 1.0f)
        {
            TextAlphaHighlightStep *= -1;
        }
    }

    void OnPressedKey(InputAction.CallbackContext ctx)
    {
        anyKeyInputAction.action.performed -= OnPressedKey;
        anyKeyInputAction.action.Disable();
        SceneManager.LoadScene("MainScene");
    }

    public void showIntro()
    {
        BlackBackgroundAndText.SetActive(true);
        anyKeyInputAction.action.performed += OnPressedKey;
        anyKeyInputAction.action.Enable();
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
