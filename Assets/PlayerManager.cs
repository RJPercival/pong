using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;

public class PlayerManager : MonoBehaviour
{
    private void OnPlayerJoined(PlayerInput input) {
        //InputUser.PerformPairingWithDevice(Keyboard.current, input.user);
    }
}
