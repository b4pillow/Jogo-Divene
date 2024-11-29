using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botão : MonoBehaviour
{
    public bool pressionado;
    private Animator anim;
    private AudioSource Sound;

    void Start()
    {
        anim = GetComponent<Animator>();
        Sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Verifique a lógica para a animação do botão aqui, caso precise de outra forma de interação
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BlocoDePedra"))
        { 
            Sound.Play();
            anim.SetBool("Botão", true);
           pressionado = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("BlocoDePedra"))
        {
            anim.SetBool("Botão", false);
            pressionado = false;
        }
    }
}