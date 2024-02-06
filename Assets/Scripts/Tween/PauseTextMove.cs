using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Tween
{
    public class PauseTextMove : MonoBehaviour
    {
        [SerializeField] private Text _text;

        private void Start()
        {
            _text.DOFade(0.3f, 10f)
                .SetLoops(-1, LoopType.Yoyo)
                .SetLink(gameObject)
                .SetUpdate(UpdateType.Normal, true);
        }
    }
}