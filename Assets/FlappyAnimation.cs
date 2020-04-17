using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlappyAnimation : MonoBehaviour
{

    public Animation anim;

    public float animSpeed;
    public string nameOfAnimation;

    private void Start()
    {
        anim = GetComponent<Animation>();

    }

    private void Update()
    {
        anim[nameOfAnimation].speed = animSpeed;
    }
}