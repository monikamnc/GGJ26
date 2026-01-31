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
        ChangeState(GameState.Resultados);
    }

    void Awake()
    {
        Instance = this;
        minigames = new Minigame[4];
        minigames[0] = GameObject.Find("Picar").GetComponent<Picar>();
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

            case GameState.Resultados:
                Debug.Log("Entrando Resultados");
                break;
        }
    }

    void ExitState(GameState state)
    {
        switch (state)
        {
            case GameState.Picar:
                Debug.Log("Saliendo Picar");
                break;

            case GameState.Resultados:
                Debug.Log("Saliendo Resultados");
                break;
        }
    }

}
