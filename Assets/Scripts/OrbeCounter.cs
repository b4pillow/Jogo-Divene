using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbeCounter : MonoBehaviour
{
    public int orbeNumber;
    // Start is called before the first frame update
    void Start()
    {
        orbeNumber = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Orb"))
        {
            Destroy(collision.gameObject);
            orbeNumber++;
            GameController.Instace.UpdateScore(orbeNumber);
        }
    }
}
