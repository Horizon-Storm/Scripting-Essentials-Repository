using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KnockBackBehavior : MonoBehaviour
{
    public Rigidbody2D rb;

    public float knockbackForce = 10f;



    void OnCollisionEnter2D(Collision2D collision)

    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            //Calculate knockbackdirection based on collision normal (or other logic)
            Vector3 knockbackDirection = collision.contacts[0].normal;

            //ApplyForce
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

        }
    }
}
