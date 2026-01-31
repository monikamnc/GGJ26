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

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState currentState;

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
