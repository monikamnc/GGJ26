using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Picar : MonoBehaviour
{
    public Slider picarSlider;
    public InputActionReference picarAction;

    void OnEnable()
    {
        picarAction.action.performed += OnProgress;
        picarAction.action.Enable();
    }

    void OnDisable()
    {
        picarAction.action.performed -= OnProgress;
        picarAction.action.Disable();
    }

    void OnProgress(InputAction.CallbackContext ctx)
    {
        picarSlider.value += 0.1f;
        //progressBar.value += step;
        //progressBar.value = Mathf.Clamp01(progressBar.value);

        if (picarSlider.value >= 1f)
        {
            Debug.Log("¡Barra completa!");
            GameManager.Instance.ChangeState(GameState.Enfriar);
        }
        //Debug.Log("1");
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
