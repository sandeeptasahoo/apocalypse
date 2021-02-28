using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public float stamina = 50f;
    public Animator anim;
    public void TakeToDamage (float amount)
    {
        stamina -= amount;
        if (stamina <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        anim.Play("Dying");
        Destroy(gameObject,2f);
    }
}
