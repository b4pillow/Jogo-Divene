using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cura : MonoBehaviour
{
    [SerializeField] private LifeSystemPlayer vidaPlayer;
    [SerializeField] private LifeUI vidaCura;
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            if (vidaPlayer.health < 12)
            {
                sound.Play();
                vidaPlayer.health++;
                vidaCura.ChangeBar(vidaPlayer.health, vidaPlayer.maxHealth);
                Destroy(gameObject, 0.6f);
            }
        }
    }
}