using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  public static float FALL_OFF_THRESHOLD = -0.5f;
  public static float RESTART_DELAY_SEC = 6f;//2f;

  public GameObject completeLevelUi;
  private bool _isGameOver = false;

  public bool isGameOver() {
    return _isGameOver;
  }

  public void GameOver() {
    if (_isGameOver) {
      return;
    }
    Invoke("Restart", RESTART_DELAY_SEC);
    _isGameOver = true;
    // TODO slow down movement (slowmo effect)
  }

	public void Restart() {
    // TODO restart UI: counter?
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  public void EndTriggerEntered() {
    completeLevelUi.SetActive(true);
    FindObjectOfType<PlayerMovement>().stop();
    // TODO ui to go to next level
  }
}
