using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PauseController _pauseController;
    [SerializeField] private SpawnMedal _spawnMedal;
    [SerializeField] private MedalShooterMove _shooterMove;
    
    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        var vertical = Input.GetAxisRaw("Vertical");
        if (horizontal != 0)
        {
            _shooterMove.MoveShooterHorizontal(horizontal);
        }
        else if (vertical != 0)
        {
            _shooterMove.MoveShooterVertical(vertical);
        }
        if (Input.GetButtonUp("Cancel"))
        {
            _pauseController.UsePauseWindow();
        }
        else if (Input.GetButton("Jump"))
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