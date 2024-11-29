using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int ID;
    public Transform player;
    private Animator anim;

    public AudioSource Audio;
    public AudioClip[] sound;
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Audio.clip = sound[0];
            Audio.Play();
            anim.SetBool("Checkpoint", true);
            GameManager.Instance.savePointID = ID;
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        if (GameManager.Instance.savePointID == ID)
        {
            player.position = transform.position;
        }

        Audio = GetComponent<AudioSource>();

    }
}