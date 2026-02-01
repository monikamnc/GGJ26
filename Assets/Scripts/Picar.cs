using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Picar : Minigame
{
    public Slider picarSliderP1;
    public Slider picarSliderP2;
    public InputActionReference picarActionP1;
    public InputActionReference picarActionP2;

    Vector3 P1SliderInitialRecPos;
    Vector3 P2SliderInitialRecPos;

    public RectTransform martilloP1;
    public RectTransform martilloP2;

    public RectTransform lingoteP1;
    public RectTransform lingoteP2;

    public float stepValue;

    void OnEnable()
    {
        picarActionP1.action.performed += OnKeyPressedP1;
        picarActionP1.action.canceled += OnKeyReleasedP1;
        picarActionP1.action.Enable();

        picarActionP2.action.performed += OnKeyPressedP2;
        picarActionP2.action.canceled += OnKeyReleasedP2;
        picarActionP2.action.Enable();

        martilloP1.DOLocalMove(new Vector3(-398.0f, -132.0f, 0.0f), 0.0f);
        martilloP1.DOLocalRotate(new Vector3(0.0f, 180.0f, 60.0f), 0.0f);
    }

    void OnDisable()
    {
        picarActionP1.action.performed -= OnKeyPressedP1;
        picarActionP1.action.canceled -= OnKeyReleasedP1;
        picarActionP1.action.Disable();

        picarActionP2.action.performed -= OnKeyPressedP2;
        picarActionP2.action.canceled -= OnKeyReleasedP2;
        picarActionP2.action.Disable();
    }

    void OnKeyPressedP1(InputAction.CallbackContext ctx)
    {
        picarSliderP1.value += stepValue;

        picarSliderP1.GetComponent<RectTransform>().DOShakePosition(0.5f, 20);
        lingoteP1.GetComponent<RectTransform>().DOShakePosition(0.5f, 5, 10, 10);
        martilloP1.DOLocalMove(new Vector3(-576.0f, -237.0f, 0.0f), 0.0f);
        martilloP1.DOLocalRotate(new Vector3(0.0f, 180.0f, 0.0f), 0.0f);

        if (picarSliderP1.value >= 1f)
        {
            Debug.Log("¡Barra completa!");

            FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        }
    }

    void OnKeyReleasedP1(InputAction.CallbackContext ctx)
    {
        martilloP1.DOLocalMove(new Vector3(-398.0f, -132.0f, 0.0f), 0.0f);
        martilloP1.DOLocalRotate(new Vector3(0.0f, 180.0f, 60.0f), 0.0f);
    }

    void OnKeyPressedP2(InputAction.CallbackContext ctx)
    {
        picarSliderP2.value += stepValue;

        picarSliderP2.GetComponent<RectTransform>().DOShakePosition(0.5f, 20);
        lingoteP2.GetComponent<RectTransform>().DOShakePosition(0.5f, 5, 10, 10);
        martilloP2.DOLocalMove(new Vector3(520.0f, -216.0f, 0.0f), 0.0f);
        martilloP2.DOLocalRotate(new Vector3(0.0f, 0.0f, 0.0f), 0.0f);

        if (picarSliderP2.value >= 1f)
        {
            Debug.Log("¡Barra completa!");

            FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        }
    }

    void OnKeyReleasedP2(InputAction.CallbackContext ctx)
    {
        martilloP2.DOLocalMove(new Vector3(321.0f, -132.0f, 0.0f), 0.0f);
        martilloP2.DOLocalRotate(new Vector3(0.0f, 0.0f, 60.0f), 0.0f);
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
