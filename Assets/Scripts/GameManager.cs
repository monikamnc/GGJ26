using UnityEngine;

public enum GameState
{
    Start,
    Avivar,
    Rotar,
    Picar,
    Enfriar,
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

    Minigame[] minigames;

    MinigameEndData FinalScores;
    
    void OnFinishedMinigame (MinigameEndData data)
    {
        // Añadir puntuación
        FinalScores.P1Score += data.P1Score;
        FinalScores.P2Score += data.P2Score;

        // minigames[0].OnFinishedMinigame -= OnFinishedMinigame;
        // Cambiar al siguente minijuego
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
                ChangeState(GameState.Picar);
                break;

            case GameState.Picar:
                Debug.Log("Entrando Picar");
                minigames[0].StartMinigame();
                minigames[0].OnFinishedMinigame += OnFinishedMinigame;
                break;

            //case GameState.MiniJuegoB:
            //    Debug.Log("Entrando Minijuego B");
            //    break;
        }
    }

    void ExitState(GameState state)
    {
        switch (state)
        {
            case GameState.Picar:
                Debug.Log("Saliendo Minijuego A");
                break;

            //case GameState.MiniJuegoB:
            //    Debug.Log("Saliendo Minijuego B");
            //    break;
        }
    }

}
