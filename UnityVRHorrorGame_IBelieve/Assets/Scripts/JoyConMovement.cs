using UnityEngine;
using UnityEngine.InputSystem;

public class JoyConMovement : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector2 moveInput;
    private bool hasShownWarning = false;

    void Update()
    {
        // Check if a gamepad is connected
        if (Gamepad.current != null)
        {
            // Reset the warning flag if a gamepad is connected
            hasShownWarning = false;

            // Get the Joy-Con input
            moveInput = Gamepad.current.leftStick.ReadValue();

            // Calculate movement direction relative to the player's forward direction
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y);
            moveDirection = Camera.main.transform.TransformDirection(moveDirection);
            moveDirection.y = 0; // Keep movement horizontal

            // Move the player
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
        else
        {
            // Show the warning only once
            if (!hasShownWarning)
            {
                Debug.LogWarning("No gamepad connected.");
                hasShownWarning = true;
            }
        }
    }
}
