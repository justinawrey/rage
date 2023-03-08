using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  private Vector2 input;

  [SerializeField]
  private Rigidbody2D rb;

  [SerializeField]
  private float maxVelocity, acceleration, deceleration;

  private void Update()
  {
    input.x = Input.GetAxisRaw("Horizontal");
    input.y = Input.GetAxisRaw("Vertical");
  }

  private void FixedUpdate()
  {
    float forceX = GetMovementForce("Horizontal");
    float forceY = GetMovementForce("Vertical");

    // TODO: Too much diagonal force is being applied
    rb.AddForce(new Vector2(forceX, forceY));
  }

  private float GetMovementForce(string axis)
  {
    bool isHorizontalMovement = axis == "Horizontal";

    // Calculate the direction we want to move in and our desired velocity
    float targetVelocity = (isHorizontalMovement ? input.x : input.y) * maxVelocity;

    // Calculate acceleration based on if we're moving or not
    float accel = (Mathf.Abs(targetVelocity) > 0.01f) ? acceleration : deceleration;

    // Calculate difference between current velocity and desired velocity
    float velocityDiff = targetVelocity - (isHorizontalMovement ? rb.velocity.x : rb.velocity.y);

    // Calculate force along x-axis to apply to the player
    return velocityDiff * accel;
  }
}
