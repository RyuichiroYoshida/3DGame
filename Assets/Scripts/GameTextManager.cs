using System;
using UnityEngine;
using UnityEngine.UI;

public class GameTextManager : MonoBehaviour
{
    [SerializeField] private Text _gameCount;
    [SerializeField] private Text _medalGetCount;
    public Action EditText;

    private void Start()
    {
        EditText += EditMedalGetCount;
        EditText += EditGameCountText;
    }

    private void EditGameCountText()
    {
        _gameCount.text = StageManager.GameCount.ToString("000000");
    }

    private void EditMedalGetCount()
    {
        _medalGetCount.text = StageManager.MedalGetCount.ToString("000000");
    }
}