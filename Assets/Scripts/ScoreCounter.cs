using UnityEngine;

public class ScoreCounter : Singleton<ScoreCounter>
{
    [SerializeField] int _score;
    public int Score => _score;
    public void AddScore(int value)
    {
        _score += value;
        Debug.Log($"NowScore : {_score}");
    }
}