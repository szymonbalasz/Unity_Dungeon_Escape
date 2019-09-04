using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    bool cooldownInEffect = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.GetComponent<IDamageable>();
        if (hit != null && cooldownInEffect == false)
        {
            hit.Damage();
            cooldownInEffect = true;
        }
    }

    public void ResetCooldown()
    {
        cooldownInEffect = false;
    }
}
