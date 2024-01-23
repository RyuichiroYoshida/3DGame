using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : Singleton<ScoreCounter>
{
    [SerializeField] private int _score;
    private Text _text;
    public int Score => _score;
    private void Start()
    {
        _text = GetComponent<Text>();
        AddScore(StageManager.Instance.StartCredit);
    }
    public void AddScore(int value)
    {
        _score += value;
        _text.text = $"Credit : {_score:000000}";
    }

    public void SubScore(int value)
    {
        _score -= value;
        _text.text = $"Credit : {_score:000000}";
    }
}