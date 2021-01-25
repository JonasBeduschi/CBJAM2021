using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class Score
{
    public static int CurrentScore { get; private set; }

    public static void AddScore(int value)
    {
        CurrentScore += value;
        OnScoreChange?.Invoke(CurrentScore);
    }

    public static Action<int> OnScoreChange;
}