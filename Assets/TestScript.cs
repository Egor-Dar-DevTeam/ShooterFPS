using BaseInterfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamageble>(out var damageble))
        {
            damageble.ReceiveDamage(1);
        }
    }
}
