using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Picar : Minigame
{
    public Slider picarSliderP1;
    public Slider picarSliderP2;
    public InputActionReference picarActionP1;
    public InputActionReference picarActionP2;

    void OnEnable()
    {
        picarActionP1.action.performed += OnProgressP1;
        picarActionP2.action.performed += OnProgressP2;

        picarActionP1.action.Enable();
        picarActionP2.action.Enable();
    }

    void OnDisable()
    {
        picarActionP1.action.performed -= OnProgressP1;
        picarActionP2.action.performed -= OnProgressP2;

        picarActionP1.action.Disable();
        picarActionP2.action.Disable();
    }

    void OnProgressP1(InputAction.CallbackContext ctx)
    {
        picarSliderP1.value += 0.1f;
        //progressBar.value = Mathf.Clamp01(progressBar.value);

        if (picarSliderP1.value >= 1f)
        {
            Debug.Log("¡Barra completa!");
            //GameManager.Instance.ChangeState(GameState.Enfriar);

            FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        }
        //Debug.Log("1");
    }

    void OnProgressP2(InputAction.CallbackContext ctx)
    {
        picarSliderP2.value += 0.1f;

        if (picarSliderP2.value >= 1f)
        {
            Debug.Log("¡Barra completa!");
            //GameManager.Instance.ChangeState(GameState.Enfriar);

            FinishMinigame(picarSliderP1.value, picarSliderP2.value);
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
