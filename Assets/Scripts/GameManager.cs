using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum GameState
{
    Start,
    MinigameStart,
    MinigameEnd,
    Resultados
}

public struct MinigameEndData
{
    public float P1Score;
    public float P2Score;
}

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

    public Minigame[] minigames;

    MinigameEndData FinalScores;

    int currentMinigameId;

    Text countdownText;
    public Text instructionsTextP1;
    public Text instructionsTextP2;

    void OnFinishedMinigame (MinigameEndData data)
    {
        // Añadir puntuación
        FinalScores.P1Score += data.P1Score;
        FinalScores.P2Score += data.P2Score;

        // Se acaba el minijuego
        ChangeState(GameState.MinigameEnd);
    }

    public IEnumerator StartCountdown()
    {
        countdownText.gameObject.SetActive(true);

        for (int i = 3; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }

        countdownText.text = "GO!";
        Debug.Log("GO!");
        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        instructionsTextP1.text = minigames[currentMinigameId].instructionsTextP1;
        instructionsTextP2.text = minigames[currentMinigameId].instructionsTextP2;
        instructionsTextP1.gameObject.SetActive(true);
        instructionsTextP2.gameObject.SetActive(true);
        minigames[currentMinigameId].StartMinigame();

    }

    void Awake()
    {
        Instance = this;
        countdownText = GameObject.Find("CountdownText").GetComponent<Text>();
    }

    void Start()
    {
        ChangeState(GameState.Start);
    }

    public void ChangeState(GameState newState)
    {
        ExitState(currentState);
        currentState = newState;
        EnterState(currentState);
    }

    void EnterState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                Debug.Log("Entrando al juego");
                ChangeState(GameState.MinigameStart);
                break;

            case GameState.MinigameStart:
                Debug.Log("Minigame Start!");
                StartCoroutine(StartCountdown());
                minigames[currentMinigameId].OnFinishedMinigame += OnFinishedMinigame;
                break;

            case GameState.MinigameEnd:
                Debug.Log("Minigame Ends!");
                instructionsTextP1.gameObject.SetActive(false);
                instructionsTextP2.gameObject.SetActive(false);
                currentMinigameId++;

                if (currentMinigameId >= minigames.Length)
                {
                    ChangeState(GameState.Resultados);
                    break;
                }

                ChangeState(GameState.MinigameStart);

                break;

            case GameState.Resultados:
                Debug.Log("Entrando Resultados");
                break;
        }
    }

    void ExitState(GameState state)
    {
        switch (state)
        {
            case GameState.MinigameStart:
                Debug.Log("Saliendo Minigame Start");
                minigames[currentMinigameId].OnFinishedMinigame -= OnFinishedMinigame;
                break;

            case GameState.Resultados:
                Debug.Log("Saliendo Resultados");
                break;
        }
    }
}
