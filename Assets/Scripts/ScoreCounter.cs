using UnityEngine.UI;

public class ScoreCounter : Singleton<ScoreCounter>
{
    private Text _text;
    private static bool _isInitialized;
    public static int Score { get; private set; }

    private void Start()
    {
        _text = GetComponent<Text>();
        _text.text = $"Credit {Score:000000}";
        if (_isInitialized == false)
        {
            AddScore(StageManager.Instance.StartCredit);
            _isInitialized = true;
        }
    }
    public void AddScore(int value)
    {
        Score += value;
        _text.text = $"Credit {Score:000000}";
    }

    public void SubScore(int value)
    {
        Score -= value;
        _text.text = $"Credit {Score:000000}";
    }
}