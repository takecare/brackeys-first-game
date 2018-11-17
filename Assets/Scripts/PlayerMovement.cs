using System;
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

  private GameManager gameManager;
  private GameObject ground;

  private float playerHalfWidth;
  private float groundPosX;
  private float groundHalfWidth;

  void Start() {
    ground = GameObject.FindWithTag("Ground");
    gameManager = FindObjectOfType<GameManager>();

    playerHalfWidth = this.transform.GetComponent<Collider>().bounds.size.x / 2;

    Collider groundCollider = ground.GetComponent<Collider>();
    groundPosX = ground.transform.position.x;
    groundHalfWidth = groundCollider.bounds.size.x / 2f;
    // Debug.Log(playerHalfWidth);
  }

  void Update() {
    if (Input.GetKeyDown("d")) {
      rightKeyPressed = true;
    } else if (Input.GetKeyUp("d")) {
      rightKeyPressed = false;
    }

    if (Input.GetKeyDown("a")) {
      leftKeyPressed = true;
    } else if (Input.GetKeyUp("a")) {
      leftKeyPressed = false;
    }

    if (Input.GetKeyDown("w")) {
      playerRigidBody.transform.position = new Vector3(0, 0, 710);
    }
  }

  void FixedUpdate() {
    endGameIfFallenOff();

    if (gameManager.isGameOver()) {
      return;
    }

    playerRigidBody.AddForce(0, 0, forwardMovementForce * Time.deltaTime);

    if (rightKeyPressed) {
      playerRigidBody.AddForce(sidewaysMovementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
      angleIncrement += ANGLE_INCREMENT * Time.deltaTime;
      playerRigidBody.MoveRotation(Quaternion.AngleAxis(angleIncrement, Y_AXIS));
    } else if (leftKeyPressed) {
      playerRigidBody.AddForce(-sidewaysMovementForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
      angleIncrement -= ANGLE_INCREMENT * Time.deltaTime;
      playerRigidBody.MoveRotation(Quaternion.AngleAxis(angleIncrement, Y_AXIS));
    }
  }

  private void endGameIfFallenOff() {
    // Debug.Log(ground.transform.position.x + " " + playerRigidBody.position.x + " | " + collider.bounds.size.x);
    if (playerRigidBody.position.y < GameManager.FALL_OFF_THRESHOLD
    || playerRigidBody.position.x + playerHalfWidth < (groundPosX - groundHalfWidth)
    || playerRigidBody.position.x - playerHalfWidth > (groundPosX + groundHalfWidth)) {
      gameManager.GameOver();
      // Debug.Log(playerRigidBody.velocity);
      playerRigidBody.velocity = new Vector3(
        playerRigidBody.velocity.x / 2f,
        playerRigidBody.velocity.y / 2f,
        playerRigidBody.velocity.z / 2f
      );
      // playerRigidBody.angularVelocity
      // Debug.Log(playerRigidBody.velocity);
    }
  }

  public void stop() {
    playerRigidBody.velocity = new Vector3(0, 0, 0);
    // playerRigidBody.
  }
}
