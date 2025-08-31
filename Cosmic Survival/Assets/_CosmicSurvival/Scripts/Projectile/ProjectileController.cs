using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed = 10f;              // toc do projectile
    public GameObject hitEffectPrefab;     // hieu ung khi hit

    private GameObject target;             // muc tieu hien tai
    private Vector3 direction;             // huong ban

    public void SetTarget(GameObject enemy)
    {
        target = enemy;

        if (target != null)
        {
            // tinh toan huong di tu player -> enemy
            direction = (target.transform.position - transform.position).normalized;

            // xoay dau dan theo huong nao
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }

    void Update()
    {
        // dan di chuyen theo huong
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // tao hieu ung no
            if (hitEffectPrefab != null)
            {
                GameObject effect = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                Destroy(effect, 1f);
            }
            Destroy(collision.gameObject);// xoa enemy khi hit
            Destroy(gameObject);// xoa projectile
        }
    }
}
