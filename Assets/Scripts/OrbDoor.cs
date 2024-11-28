using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDoor : MonoBehaviour
{
    public int orbePrice;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OrbeCounter component = collision.gameObject.GetComponent<OrbeCounter>();
            if (component.orbeNumber >= orbePrice)
            {
                component.orbeNumber -= orbePrice;
                GameController.Instace.UpdateScore(component.orbeNumber);
                Destroy(gameObject);
            }
        }
    }
}
