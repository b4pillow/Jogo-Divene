using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialMensagem : MonoBehaviour
{
    public float radious;
    public GameObject interact;
    public LayerMask playerLayer;
    private Animator anim;

    bool onRadious;
    bool interactActivated;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if(hit != null && !interactActivated)
        {
            interact.SetActive(true);
            onRadious = true;
            interactActivated = true;
            //anim.SetTrigger("FadeIn");
        }
        else if(hit == null)
        {
            onRadious = false;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radious);
    }
}