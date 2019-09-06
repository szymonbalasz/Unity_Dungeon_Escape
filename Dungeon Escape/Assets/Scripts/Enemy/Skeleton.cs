using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy
{
    public override IEnumerator Death()
    {
        dead = true;
        anim.SetTrigger(ANIMATION_DEATH);
        GetComponent<BoxCollider2D>().enabled = false;
        dropLocation = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        GameObject diamond = Instantiate(gemPrefab, dropLocation, Quaternion.identity) as GameObject;
        diamond.GetComponent<Diamond>().SetGemValue(gems);
        yield return new WaitForSeconds(5);
        Destroy(this.gameObject);
    }
}
