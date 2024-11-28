using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbeCounter : MonoBehaviour
{
    public int orbeNumber;
    public TMPro.TextMeshProUGUI ScoreText;
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
            UpdateOrbeValue(orbeNumber + 1);
            Destroy(collision.gameObject);
        }
    }

    public void UpdateOrbeValue(int newvalue)
    {
        orbeNumber = newvalue;
        ScoreText.text = $"x {orbeNumber}";
    }
}
