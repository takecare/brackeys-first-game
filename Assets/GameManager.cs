using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  public static int FALL_OFF_THRESHOLD = -5;
  public static float restartDelay = 2f;

  public GameObject completeLevelUi;
  private bool isGameOver = false;

  public void GameOver() {
    if (isGameOver) {
      return;
    }
    Invoke("Restart", restartDelay);
    isGameOver = true;
    // TODO slow down movement (slowmo effect)
  }

	public void Restart() {
    // TODO restart UI
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void EndTriggerEntered() {
    completeLevelUi.SetActive(true);
    FindObjectOfType<PlayerMovement>().stop();
    // TODO ui to go to next level
  }
}
