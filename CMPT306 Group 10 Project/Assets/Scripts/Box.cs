using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Cross" || other.gameObject.tag == "Awakening" || other.gameObject.tag == "Blessing"
            || other.gameObject.tag == "Candle" || other.gameObject.tag == "Key" || other.gameObject.tag == "Boost" ||
            other.gameObject.tag == "Statue")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        }

    }

}
