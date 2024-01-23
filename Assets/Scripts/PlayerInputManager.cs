using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PauseController _pauseController;
    [SerializeField] private SpawnMedal _spawnMedal;
    private void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            _pauseController.UsePauseWindow();
        }
        else if (Input.GetButtonDown("Jump"))
        {
            if (ScoreCounter.Instance.Score < StageManager.Instance.StageBetCount)
            {
                return;
            }
            ScoreCounter.Instance.SubScore(StageManager.Instance.StageBetCount);
            _spawnMedal.MedalSpawn(MedalObjectPool.Instance.Pool);
        }
    }
}