using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;// Bien luu tru Prefab dan
    public float fireRate = 0.5f; // Bien toc do ban (firerate): 1 vien / 0.5 giay
    private float fireTimer = 0f;// Bien dem thoi gian vien dan sau khi dc ban ra
    private bool isShooting = false;// trang thai ban la false


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) // ktra nut ban la space
        {
            isShooting = !isShooting; // trang thai ban la true
            Debug.Log("Shooting State changed to: " + isShooting);
        }
        if(isShooting)
        {
            fireTimer = fireTimer + Time.deltaTime; // cong don so dem

            // kiem tra du thoi gian de ban chua
            if(fireTimer > fireRate)
            {
                Shoot(); // goi ham ban
                fireTimer = 0f; // reset dem time = 0
            }
        }
        
    }

    void Shoot()
    {
        Vector3 spawnPosition = transform.position + new Vector3(0, 1f, 0);
        Instantiate(projectilePrefab,spawnPosition,Quaternion.identity);
    }
}
