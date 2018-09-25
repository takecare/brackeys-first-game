using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: when player is changing direction (ex. was turning left and now changed to right),
// then that change should be faster for a short period of time

public class PlayerMovement : MonoBehaviour
{

  public float forwardMovementForce = 4000f;
  public float sidewaysMovementForce = 100f;
  public Rigidbody playerRigidBody;

  private static Vector3 Y_AXIS = new Vector3(0f, 1f, 0f);
  private const float ANGLE_INCREMENT = 18f;

  private float angleIncrement = 0f;

  private bool rightKeyPressed = false;
  private bool leftKeyPressed = false;

  void Start() {
    //
  }

  void Update() {
    if (Input.GetKeyDown("d")) {
      rightKeyPressed = true;
    }
    if (Input.GetKeyDown("a")) {
      leftKeyPressed = true;
    }

    if (Input.GetKeyUp("d")) {
      multiplier = 1f;
      rightKeyPressed = false;
    }
    if (Input.GetKeyUp("a")) {
      multiplier = 1f;
      leftKeyPressed = false;
    }
  }

  float multiplier = 1f;

  void FixedUpdate() {
    playerRigidBody.AddForce(0, 0, forwardMovementForce * Time.deltaTime);

    multiplier += multiplier * Time.deltaTime;

    if (rightKeyPressed) {
      playerRigidBody.AddForce(sidewaysMovementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
      angleIncrement += ANGLE_INCREMENT * Time.deltaTime;
      playerRigidBody.MoveRotation(Quaternion.AngleAxis(angleIncrement, Y_AXIS));
    }
    else if (leftKeyPressed) {
      playerRigidBody.AddForce(-sidewaysMovementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
      angleIncrement -= ANGLE_INCREMENT * Time.deltaTime;
      playerRigidBody.MoveRotation(Quaternion.AngleAxis(angleIncrement, Y_AXIS));
    }
  }
}
