using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Llimar : Minigame
{
    public Slider picarSliderP1;
    public Slider picarSliderP2;

    public InputActionReference llimarActionLeftP1;
    public InputActionReference llimarActionRightP1;

    public InputActionReference llimarActionLeftP2;
    public InputActionReference llimarActionRightP2;

    public RectTransform mascaraP1;
    public RectTransform mascaraP2;

    public float stepValue;

    bool LastPressedPlayer1Left;
    bool LastPressedPlayer2Left;

    void OnEnable()
    {
        llimarActionLeftP1.action.performed += OnLeftKeyPressedP1;
        llimarActionRightP1.action.performed += OnRightKeyPressedP1;
        llimarActionLeftP1.action.Enable();
        llimarActionRightP1.action.Enable();

        llimarActionLeftP2.action.performed += OnLeftKeyPressedP2;
        llimarActionRightP2.action.performed += OnRightKeyPressedP2;
        llimarActionLeftP2.action.Enable();
        llimarActionRightP2.action.Enable();

        mascaraP1.DOLocalMove(new Vector3(-740.0f, -30.0f, 0.0f), 0.0f);
        mascaraP2.DOLocalMove(new Vector3(740.0f, -132.0f, 0.0f), 0.0f);
    }

    void OnDisable()
    {
        llimarActionLeftP1.action.performed -= OnLeftKeyPressedP1;
        llimarActionRightP1.action.performed -= OnRightKeyPressedP1;
        llimarActionLeftP1.action.Disable();
        llimarActionRightP1.action.Disable();

        llimarActionLeftP2.action.performed -= OnLeftKeyPressedP2;
        llimarActionRightP2.action.performed -= OnRightKeyPressedP2;
        llimarActionLeftP2.action.Disable();
        llimarActionRightP2.action.Disable();
    }

    void OnLeftKeyPressedP1(InputAction.CallbackContext ctx)
    {
        if (LastPressedPlayer1Left)
            return;

        picarSliderP1.value += stepValue;

        picarSliderP1.GetComponent<RectTransform>().DOShakePosition(0.5f, 20);
        mascaraP1.DOLocalMove(new Vector3(-740.0f, -30.0f, 0.0f), 0.0f);

        if (picarSliderP1.value >= 1f)
        {
            Debug.Log("¡Barra completa!");

            FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        }

        LastPressedPlayer1Left = true;
    }

    void OnRightKeyPressedP1(InputAction.CallbackContext ctx)
    {
        if (!LastPressedPlayer1Left)
            return;

        picarSliderP1.value += stepValue;

        picarSliderP1.GetComponent<RectTransform>().DOShakePosition(0.5f, 20);
        mascaraP1.DOLocalMove(new Vector3(-740.0f, -237.0f, 0.0f), 0.0f);

        if (picarSliderP1.value >= 1f)
        {
            Debug.Log("¡Barra completa!");

            FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        }

        LastPressedPlayer1Left = false;
    }

    void OnLeftKeyPressedP2(InputAction.CallbackContext ctx)
    {
        if (LastPressedPlayer2Left)
            return;

        picarSliderP2.value += stepValue;

        picarSliderP2.GetComponent<RectTransform>().DOShakePosition(0.5f, 20);
        mascaraP2.DOLocalMove(new Vector3(740.0f, -30.0f, 0.0f), 0.0f);

        if (picarSliderP2.value >= 1f)
        {
            Debug.Log("¡Barra completa!");

            FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        }

        LastPressedPlayer2Left = true;
    }

    void OnRightKeyPressedP2(InputAction.CallbackContext ctx)
    {
        if (!LastPressedPlayer2Left)
            return;

        picarSliderP2.value += stepValue;

        picarSliderP2.GetComponent<RectTransform>().DOShakePosition(0.5f, 20);
        mascaraP2.DOLocalMove(new Vector3(740.0f, -237.0f, 0.0f), 0.0f);

        if (picarSliderP2.value >= 1f)
        {
            Debug.Log("¡Barra completa!");

            FinishMinigame(picarSliderP1.value, picarSliderP2.value);
        }

        LastPressedPlayer2Left = false;
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
