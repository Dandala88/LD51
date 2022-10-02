using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsTrigger : MonoBehaviour
{
    [SerializeField]
    private CreditsScreen screen;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Energy"))
        {
            screen.FadeIn();
            Destroy(gameObject);
        }
    }
}
