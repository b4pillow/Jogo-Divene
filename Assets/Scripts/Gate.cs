using System.Collections;
using UnityEngine;

public class Gate : MonoBehaviour
{
    [SerializeField] private float health;
    [SerializeField] private float animationSpeed = 10f;
    private bool canHit;

    private AudioSource sound;

    public int Damage = 10;

    private void Awake()
    {
        canHit = true;
        sound = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (canHit)
        {
            if (health <= 0)
            {
                sound.Play();
                StartCoroutine(OpenGateAndDestroy(1)); // Chama a corrotina
                Destroy(gameObject, 0.8f);
            }    
        }
    }

    public void EnemyHit(float damageDone)
    {
        if (!canHit) return;
        health -= damageDone;
    }

    private IEnumerator OpenGateAndDestroy(float animationDuration)
    {
        canHit = false;
        while(animationDuration > 0)
        {
            animationDuration -= Time.deltaTime;
            transform.position += (animationSpeed * Time.deltaTime * Vector3.up);
            yield return null;
        }
        Destroy(gameObject); // Destroi o portão após a animação
    }
    
    
}