using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour {

  void LoadNextLevel() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
  }
}
