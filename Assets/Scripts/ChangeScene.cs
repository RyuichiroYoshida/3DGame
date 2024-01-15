using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private bool _isFadeIn = true;
    [SerializeField] private float _fadeTime = 2;
    private Image _image;
    private int _alpha = 0;
    private void Start()
    {
        if (_isFadeIn)
        {
            CreateFadeImage(0);
            _alpha = 1;
        }
        else
        {
            CreateFadeImage(255);
        }
        _image.gameObject.SetActive(false);
    }
    public void Fade(string loadSceneName)
    {
        _image.gameObject.SetActive(true);
        _image.DOFade(_alpha, _fadeTime)
            .OnComplete(() => SceneManager.LoadScene(loadSceneName));
    }
    
    /// <summary>
    /// フェードを行うときに必要なImageを生成、設置する
    /// </summary>
    /// <param name="alpha">フェードイン = 0 フェードアウト = 1</param>
    private void CreateFadeImage(byte alpha)
    {
        if (_canvas == null)
        {
            Debug.LogWarning("ChangeSceneコンポーネントにCanvasをアタッチしてください");
            return;
        }
        var fadeImage = new GameObject("FadeImage");
        fadeImage.transform.SetParent(_canvas.transform);
        var rectTransform = fadeImage.AddComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(0, 0, 0);
        rectTransform.localScale = new Vector3(10, 10, 10);
        _image = fadeImage.AddComponent<Image>();
        _image.color = new Color32(0, 0, 0, alpha);
    }
}