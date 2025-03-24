using LMNT;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechRunner : MonoBehaviour
{ 
    private LMNTSpeech speech;
    private AudioSource aud;
    bool check = false;

    void Start()
    {
        // ... your code here ...
        speech = GetComponent<LMNTSpeech>();
        speech.dialogue = "Hello World";
        aud = GetComponent<AudioSource>();
    }
    public void speak()
    {
        if(check)
        {
            check = false;
            GetComponent<Animator>().Play("IdleFloat");
        }
        else
        {
            StartCoroutine(speech.Talk());
            Debug.Log("hello");
            aud.Play();
            GetComponent<CharacterAnimationController>().playTalk();
            check = true;
        }
        

    }



}

