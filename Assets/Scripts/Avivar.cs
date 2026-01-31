using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Avivar : Minigame
{
    public Slider avivarSliderP1;
    public Slider avivarSliderP2;
    public InputActionReference avivarActionP1;
    public InputActionReference avivarActionP2;

    public override void StartMinigame()
    {
        base.StartMinigame();
    }

    void OnEnable()
    {
        //avivarActionP1.action.performed += OnProgressP1;
        //avivarActionP2.action.performed += OnProgressP2;

        //avivarActionP1.action.Enable();
        //avivarActionP2.action.Enable();
    }

    void OnDisable()
    {
        //avivarActionP1.action.performed -= OnProgressP1;
        //avivarActionP2.action.performed -= OnProgressP2;

        //avivarActionP1.action.Disable();
        //avivarActionP2.action.Disable();
    }

    void OnProgressP1(InputAction.CallbackContext ctx)
    {
        //picarSliderP1.value += 0.1f;


        //if (picarSliderP1.value >= 1f)
        //{
        //    Debug.Log("¡Barra completa!");
            

        //    FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        //}

    }

    void OnProgressP2(InputAction.CallbackContext ctx)
    {
        //picarSliderP2.value += 0.1f;

        //if (picarSliderP2.value >= 1f)
        //{
        //    Debug.Log("¡Barra completa!");

        //    FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        //}
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
