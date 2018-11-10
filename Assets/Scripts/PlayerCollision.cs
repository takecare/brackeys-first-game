using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {

  public PlayerMovement playerMovement;

  void OnCollisionEnter(Collision collision)
  {
    if (collision.collider.tag == "Obstacle") {
      Debug.Log("Collision with obstacle");
      playerMovement.enabled = false;
      endGame();
    }
  }

  void endGame() {
    GameManager gameManager = FindObjectOfType<GameManager>();
    gameManager.GameOver();
  }
}
