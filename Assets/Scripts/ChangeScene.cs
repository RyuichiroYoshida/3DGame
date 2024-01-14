using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class ChangeScene : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private bool _isFadeIn = true;
    private Image _image;
    private void Start()
    {
        if (_isFadeIn)
        {
            CreateFadeImage(0);
        }
        else
        {
            CreateFadeImage(255);
        }
    }

    private void Fade()
    {
        
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