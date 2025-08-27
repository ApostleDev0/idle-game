using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    // tao bien luu tru Prefab dan
    public GameObject projectilePrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // khi start, doan code se dc chay lien tuc moi frame
        // nhan phim r de ban
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Debug.Log("Player is shooting!");
            // su dung ham Instantiate() de tao ra dan
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        }
    }
}
