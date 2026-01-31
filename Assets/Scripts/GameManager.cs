using UnityEngine;

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
    
    void OnFinishedMinigame (MinigameEndData data)
    {
        // Añadir puntuación
        FinalScores.P1Score += data.P1Score;
        FinalScores.P2Score += data.P2Score;

        // Se acaba el minijuego
        ChangeState(GameState.MinigameEnd);
    }

    void Awake()
    {
        Instance = this;
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
                minigames[currentMinigameId].OnFinishedMinigame += OnFinishedMinigame;
                minigames[currentMinigameId].StartMinigame();
                break;

            case GameState.MinigameEnd:
                Debug.Log("Minigame Ends!");
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
