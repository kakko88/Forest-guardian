using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyAnimation : MonoBehaviour
{
  public void Flappy()
    {
        GetComponent<Animation>().Play();
        print("flap");
    }
}
