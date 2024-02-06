using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PauseController _pauseController;
    [SerializeField] private MedalShooter _medalShooter;
    [SerializeField] private MedalShooterMove _shooterMove;
    [SerializeField] private float _shootCoolTime;
    private float _time;

    private void Update()
    {
        _time += Time.deltaTime;
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
        else if (Input.GetButton("Jump"))
        {
            if (_shootCoolTime >= _time)
            {
                return;
            }

            _time = 0;
            if (ScoreCounter.Score < StageManager.Instance.StageBetCount)
            {
                return;
            }

            ScoreCounter.Instance.SubScore(StageManager.Instance.StageBetCount);
            _medalShooter.ShootMedal();
        }
    }
}