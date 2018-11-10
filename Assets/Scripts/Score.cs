using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

  public Transform player;

  private float scoreOffset;
  public Text score;

	void Start() {
    scoreOffset = Mathf.Abs(player.transform.position.z);
    score.text = "0";
  }

	void Update () {
    score.text = (player.position.z + scoreOffset).ToString("0");
  }
}
