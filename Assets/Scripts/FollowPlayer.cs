using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

  public Transform playerTransform;
  public Vector3 offset = new Vector3(0f, 2f, -8f);

  void Update() {
    transform.position = playerTransform.position + offset;
  }
}
