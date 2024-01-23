using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameObject _pauseWindow;
    private bool _isPause = false;

    public bool IsPause => _isPause;
    private void Start()
    {
        InitializePauseWindow();
    }
    private void InitializePauseWindow()
    {
        Time.timeScale = 1;
        if (_pauseWindow == null)
        {
            Debug.LogWarning("PauseManagerゲームオブジェクトにポーズ画面のゲームオブジェクトをアタッチしてください。");
        }
        else
        {
            _pauseWindow.SetActive(false);
        }
    }
    public void UsePauseWindow()
    {
        _isPause = !_isPause;
        _pauseWindow.SetActive(_isPause);
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