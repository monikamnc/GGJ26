using System;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public event Action<MinigameEndData> OnFinishedMinigame;

    public virtual void StartMinigame()
    { }

    public virtual void FinishMinigame(MinigameEndData data)
    {
        OnFinishedMinigame.Invoke(data);
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
