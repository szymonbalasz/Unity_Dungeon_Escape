﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour    
{
    private Animator swordAnim;
    private Attack attack;

    // Start is called before the first frame update
    void Start()
    {
        swordAnim = transform.parent.transform.Find("Sword_Arc").GetComponent<Animator>();
        attack = GetComponentInChildren<Attack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Swing()
    {
        swordAnim.SetTrigger("SwordAnimation");
    }

    private void ResetCooldown()
    {
        attack.ResetCooldown();
    }
}
