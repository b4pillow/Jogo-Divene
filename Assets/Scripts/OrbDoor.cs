using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbDoor : MonoBehaviour
{
    public int orbePrice;
    private bool opened;
    public float animationSpeed;
    void Start()
    {
        opened = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (opened == true)
        {
            return;
        }
        if (collision.gameObject.CompareTag("Player")) 
        {
            OrbeCounter component = collision.gameObject.GetComponent<OrbeCounter>();
            if (component.orbeNumber >= orbePrice)
            {
                component.UpdateOrbeValue(component.orbeNumber - orbePrice);
                opened = true;
                StartCoroutine(OpenGateAndDestroy(1));
            }
        }
    }
    private IEnumerator OpenGateAndDestroy(float animationDuration)
    {
        while(animationDuration > 0)
        {
            animationDuration -= Time.deltaTime;
            transform.position += (animationSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }
        Destroy(gameObject);
    }
}
