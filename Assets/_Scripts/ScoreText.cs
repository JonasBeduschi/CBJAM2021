using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    private Text text;
    [SerializeField] private bool random;
    private void Awake()
    {
        text = GetComponent<Text>();
        Score.OnScoreChange += ScoreChanged;
    }

    private void ScoreChanged(int value)
    {
        if (random)
            text.text = $"SCORE: {Random.Range(int.MinValue, int.MaxValue)}";
        else
            text.text = $"STARS: {value}";
    }

    private void OnDestroy()
    {
        Score.OnScoreChange -= ScoreChanged;
    }
}