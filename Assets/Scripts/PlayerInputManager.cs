using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    [SerializeField] private PauseController _pauseController;
    private void Update()
    {
        if (Input.GetButtonUp("Cancel"))
        {
            _pauseController.UsePauseWindow();
        }
    }
}