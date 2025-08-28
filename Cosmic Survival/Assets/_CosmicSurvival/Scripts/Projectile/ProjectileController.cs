using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    // bien toc do di chuyen cua dan
    public float speed = 10f;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        // transform.Translate la ham cua Unity
        // di chuyen doi tuong theo 1 vector va toc do dc cung cap
        // Vector2.up la vector luon huong len tren
        // speed * Time.deltaTime = quang duong di duoc trong 1 khung hinh
        transform.Translate(Vector2.up *  speed * Time.deltaTime);

        // ham tu huy khi ra khoi map
        if(transform.position.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    // ham va cham voi enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // kiem tra xem doi tuong va cham co phai Enemy ko
        if(collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);// huy enemy
            Destroy(gameObject);// huy vien dan
        }
    }
}
