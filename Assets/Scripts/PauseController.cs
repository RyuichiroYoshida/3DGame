using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseCanvas;
    [SerializeField] private GameObject _otherCanvas;
    [SerializeField] private GameTextManager _gameTextManager;
    private bool _isPause;
    private void Start()
    {
        InitializePauseWindow();
    }
    private void InitializePauseWindow()
    {
        Time.timeScale = 1;
        if (_pauseCanvas == null)
        {
            Debug.LogWarning("PauseManagerゲームオブジェクトにポーズ画面のゲームオブジェクトをアタッチしてください。");
        }
        else
        {
            _pauseCanvas.SetActive(false);
            _otherCanvas.SetActive(true);
        }
    }
    public void UsePauseWindow()
    {
        var chanceAudio = AudioManager.Instance.ChanceAudio;
        if (chanceAudio.isPlaying)
        {
            chanceAudio.Stop();
        }
        
        _gameTextManager.EditText();
        _isPause = !_isPause;
        _pauseCanvas.SetActive(_isPause);
        _otherCanvas.SetActive(!_isPause);
        if (_isPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}