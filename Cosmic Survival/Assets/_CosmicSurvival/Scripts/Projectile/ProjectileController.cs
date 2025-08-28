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
        // goi toi Rigidbody2D cua dan roi gan van toc cho no
        // transform.up la 1 vector chi huong len tren (0,1)
        GetComponent<Rigidbody2D>().velocity = transform.up * speed;

        // vien dan se bi huy sau khoang thoi gian
        Destroy(gameObject, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
