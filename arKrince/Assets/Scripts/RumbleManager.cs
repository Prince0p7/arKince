using UnityEngine;
using UnityEngine.InputSystem;

public class RumbleManager : MonoBehaviour
{
    public Gamepad gamepad;
    public void RumblePusle(float lowFreq, float highFreq, float duration)
    {
        gamepad = Gamepad.current;

        if(gamepad != null)
        {
            gamepad.SetMotorSpeeds(lowFreq, highFreq);
            Invoke(nameof(StopRumble), duration);
        }
    }
    private void StopRumble()
    {
        if(gamepad != null)
        {
            gamepad.SetMotorSpeeds(0, 0);
        }
    }
}