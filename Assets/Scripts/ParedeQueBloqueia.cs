using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeQueBloqueia : MonoBehaviour
{
    public Transform[] posicoes;
    public float speed;
    public Botão botao;

    void Update()
    {
        if (botao.pressionado == true || transform.position.y <= posicoes[1].position.y)
        {
            transform.Translate(Vector2.up * Time.deltaTime * speed); // Move para cima
        }
        if (botao.pressionado == false || transform.position.y >= posicoes[0].position.y)
        {
            transform.Translate(Vector2.down * Time.deltaTime * speed); // Move para baixo
        }
    }
}