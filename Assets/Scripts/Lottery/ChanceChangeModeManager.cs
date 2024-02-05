using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Lottery
{
    public class ChanceChangeModeManager : MonoBehaviour
    {
        [SerializeField] private Image _chanceImage;
        [SerializeField] private LotteryChanceChangeModeTable _chanceChangeTable;
        [Header("デバッグ用SerializeField")]
        [SerializeField] private int _nowChanceModeCount;
        [SerializeField] private int _chanceGameModeIndex;
        [SerializeField] private int _viewStaticCount;
        /// <summary>前回のフィーバーからのゲーム数 フィーバー終了時にリセット</summary>
        public static int ChanceGameCount;

        private Color _defaultColor;

        private void Awake()
        {
            _chanceChangeTable = new LotteryChanceChangeModeTable(_chanceChangeTable);
        }

        private void Start()
        {
            _chanceGameModeIndex = _chanceChangeTable.ChanceModeGameCount.Length;
            _defaultColor = _chanceImage.color;
            _chanceImage.gameObject.SetActive(false);
        }

        public bool CheckGameCount()
        {
            if (ChanceGameCount == 0)
            {
                _nowChanceModeCount = 0;
            }
            ChanceGameCount++;
            _viewStaticCount = ChanceGameCount;
            if (_chanceGameModeIndex <= _nowChanceModeCount)
            {
                return false;
            }
            ShowChanceText();
            if (_chanceChangeTable.ChanceModeGameCount[_nowChanceModeCount] < ChanceGameCount)
            {
                _nowChanceModeCount++;
                return true;
            }

            return false;
        }

        public bool CheckMaxGameCount()
        {
            return ChanceGameCount > _chanceChangeTable.MaxChanceModeCount;
        }

        private void ShowChanceText()
        {
            if (_chanceChangeTable.ChanceModeGameCount[_nowChanceModeCount] - 5 < ChanceGameCount)
            {
                if (Random.Range(0, 2) == 0)
                {
                    _chanceImage.gameObject.SetActive(true);
                    _chanceImage.color = _defaultColor;
                    DOVirtual.DelayedCall(2.5f, () => _chanceImage.DOFade(0f, 2)
                            .OnComplete(() => _chanceImage.gameObject.SetActive(false)), false);
                }
            }
        }
    }
}