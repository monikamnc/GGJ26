using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using System.Collections;

public class Avivar : Minigame
{
    public Slider avivarSliderP1;
    public Slider avivarSliderP2;

    public Image BufadorP1;
    public Image BufadorP2;

    public Sprite BufadorSpriteObert;
    public Sprite BufadorSpriteTancat;

    public InputActionReference avivarActionP1;
    public InputActionReference avivarActionP2;

    public float markerVelocityMin;
    public float markerVelocityMax;
    float[] markerVelocityStep;

    int markerDirectionP1;
    int markerDirectionP2;

    int roundP1;
    int roundP2;
    public int maxRounds;

    float[] P1Score;
    float[] P2Score;

    bool player1Finished;
    bool player2Finished;

    Coroutine bufadorP1Routine;
    Coroutine bufadorP2Routine;

    public override void StartMinigame()
    {
        base.StartMinigame();

        roundP1 = roundP2 = 0;
        markerVelocityStep = new float[maxRounds];

        for (int i = 0; i < maxRounds; i++)
        {
            markerVelocityStep[i] = Random.Range(markerVelocityMin, markerVelocityMax);
        }

        P1Score = new float[maxRounds];
        P2Score = new float[maxRounds];

        markerDirectionP1 = 1;
        markerDirectionP2 = 1;
    }

    void OnEnable()
    {
        avivarActionP1.action.performed += OnKeyPressedP1;
        avivarActionP1.action.Enable();

        avivarActionP2.action.performed += OnKeyPressedP2;
        avivarActionP2.action.Enable();
    }

    void OnDisable()
    {
    }

    void CheckNewMarkerPositionP1()
    {
        avivarSliderP1.value += (markerVelocityStep[roundP1] * markerDirectionP1);

        if (avivarSliderP1.value <= avivarSliderP1.minValue || avivarSliderP1.value >= avivarSliderP1.maxValue)
        {
            markerDirectionP1 *= -1;
        }
    }

    void CheckNewMarkerPositionP2()
    {
        avivarSliderP2.value += (markerVelocityStep[roundP2] * markerDirectionP2);

        if (avivarSliderP2.value <= avivarSliderP2.minValue || avivarSliderP2.value >= avivarSliderP2.maxValue)
        {
            markerDirectionP2 *= -1;
        }
    }

    float CalculatePlayerScore(float[] playerScore)
    {
        return 0.0f;
    }

    void CheckIfMinigameIsFinished()
    {
        if (!player1Finished || !player2Finished)
            return;

        FinishMinigame(CalculatePlayerScore(P1Score), CalculatePlayerScore(P2Score));
    }

    void OnKeyPressedP1(InputAction.CallbackContext ctx)
    {
        if (bufadorP1Routine != null)
            StopCoroutine(bufadorP1Routine);

        bufadorP1Routine = StartCoroutine(
            CambiarBufadorTemporal(BufadorP1, 0.2f)
        );

        P1Score[roundP1] = avivarSliderP1.value;
        avivarSliderP1.value = 0;

        roundP1++;

        if (roundP1 >= maxRounds)
        {
            player1Finished = true;
            avivarActionP1.action.performed -= OnKeyPressedP1;
            avivarActionP1.action.Disable();
            CheckIfMinigameIsFinished();
            return;
        }
    }

    void OnKeyPressedP2(InputAction.CallbackContext ctx)
    {
        if (bufadorP2Routine != null)
            StopCoroutine(bufadorP2Routine);

        bufadorP2Routine = StartCoroutine(
            CambiarBufadorTemporal(BufadorP2, 0.2f)
        );

        P2Score[roundP2] = avivarSliderP2.value;
        avivarSliderP2.value = 0;

        roundP2++;

        if (roundP2 >= maxRounds)
        {
            player2Finished = true;
            avivarActionP2.action.performed -= OnKeyPressedP2;
            avivarActionP2.action.Disable();
            CheckIfMinigameIsFinished();
            return;
        }
    }

    IEnumerator CambiarBufadorTemporal(Image bufador, float tiempo)
    {
        bufador.sprite = BufadorSpriteTancat;
        bufador.transform.localScale = Vector3.one * 1.1f;
        yield return new WaitForSeconds(tiempo);
        bufador.sprite = BufadorSpriteObert;
        bufador.transform.localScale = Vector3.one;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        avivarSliderP1.value = 0;
        avivarSliderP2.value = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!player1Finished)
            CheckNewMarkerPositionP1();
        
        if (!player2Finished)
            CheckNewMarkerPositionP2();
    }
}
