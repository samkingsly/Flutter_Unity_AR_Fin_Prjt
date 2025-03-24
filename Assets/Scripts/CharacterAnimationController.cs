using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationController : MonoBehaviour
{
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void playIdle()
    {
        anim.Play("IdleFloat");
    }
    public void playHi()
    {
        anim.Play("Hi");
    }
    public void playQT()
    {
        anim.Play("QT");
    }
    public void playDancePose()
    {
        anim.Play("DancePose");
    }
    public void playTalk()
    {
        anim.Play("Talk");
    }
}
