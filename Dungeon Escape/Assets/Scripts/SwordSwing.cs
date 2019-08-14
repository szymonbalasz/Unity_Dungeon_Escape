using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordSwing : MonoBehaviour    
{
    private Animator swordAnim;

    // Start is called before the first frame update
    void Start()
    {
        swordAnim = transform.parent.transform.Find("Sword_Arc").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Swing()
    {
        swordAnim.SetTrigger("SwordAnimation");
    }
}
