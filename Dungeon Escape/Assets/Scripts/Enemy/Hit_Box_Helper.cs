using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit_Box_Helper : MonoBehaviour
{
    private Attack attack;

    private void Start()
    {
        attack = GetComponentInChildren<Attack>();
    }
    private void ResetCooldown()
    {
        attack.ResetCooldown();
    }
}
