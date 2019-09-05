using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider_Animation_Helper : MonoBehaviour
{
    private Spider spider;

    private void Start()
    {
        spider = GetComponentInParent<Spider>();
    }

    public void Fire()
    {
        spider.Attack();
    }
}
