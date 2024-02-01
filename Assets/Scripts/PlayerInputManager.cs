using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PauseController _pauseController;
    [SerializeField] private MedalShooter _medalShooter;
    [SerializeField] private MedalShooterMove _shooterMove;
    
    private void Update()
    {
        var horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal != 0)
        {
            _shooterMove.MoveShooterHorizontal(horizontal);
        }
        else
        {
            _shooterMove.ResetVelocity();
        }
        
        if (Input.GetButtonUp("Cancel"))
        {
            _pauseController.UsePauseWindow();
        }
        else if (Input.GetButtonDown("Jump"))
        {
            if (ScoreCounter.Score < StageManager.Instance.StageBetCount)
            {
                return;
            }
            ScoreCounter.Instance.SubScore(StageManager.Instance.StageBetCount);
            _medalShooter.ShootMedal();
        }
    }
}