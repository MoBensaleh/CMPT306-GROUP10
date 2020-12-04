using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public float thrust;
    public float knockTime;
    Rigidbody2D enemy;
    Enemy enemyState;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (enemyState != null && enemyState.onTerminus()) StopCoroutine(KnockCo(enemy));
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy = other.GetComponent<Rigidbody2D>();
            enemyState = other.GetComponent<Enemy>();
            if(enemy != null)
            {
                
                Vector2 difference = enemy.transform.position - transform.position;
                difference = difference.normalized * thrust;
                enemy.AddForce(difference, ForceMode2D.Impulse);
                
                StartCoroutine(KnockCo(enemy));
                
            }
        }
        
    }
    private IEnumerator KnockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
         

        }
    }
}
