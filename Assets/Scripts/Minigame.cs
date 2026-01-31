using System;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public event Action<MinigameEndData> OnFinishedMinigame;

    public virtual void StartMinigame()
    { }

    public virtual void FinishMinigame(float Player1Score, float Player2Score)
    {
        MinigameEndData data = new MinigameEndData
        {
            P1Score = Player1Score,
            P2Score = Player2Score
        };

        OnFinishedMinigame?.Invoke(data);

        gameObject.SetActive(false);

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
