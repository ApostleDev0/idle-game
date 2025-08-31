using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;// bien luu Prefab dan
    public float fireRate = 0.5f; // bien luu toc do ban 1 vien
    public float aimingTime = 1f; // bien luu toc do ngam

    private float fireTimer = 0f; // bien dem time 
    private bool isShooting = false; // state to shoot = false
    private GameObject targetEnemy; // bien luu muc tieu


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) // check input if = space
        {
            isShooting = !isShooting; // turn on state shooting
            Debug.Log("Shooting State changed to " + isShooting); // thong bao state shooting
        }

        if (isShooting)
        {
            fireTimer = fireTimer + Time.deltaTime; // so dem ++

            // check time ban
            if (fireTimer >= aimingTime) // aimingTime controll shooting time
            {
                targetEnemy = FindNearestEnemy(); // ham tim muc tieu gan nhat

                if (targetEnemy != null)
                {
                    Shooting();
                }
                fireTimer = 0f; // reset time dem = 0
            }
        }

    }

    void Shooting()
    {
        // vi tri dan cach player 1 don vi
        Vector3 spawnPoint = transform.position + new Vector3(1f, 0, 0);

        // copy Prefab projectile and generate
        GameObject projectileInstance = Instantiate(projectilePrefab, spawnPoint, Quaternion.Euler(1f, 0, 0));

        // truyen vi tri cho vien dan
        ProjectileController projectileScript = projectileInstance.GetComponent<ProjectileController>();
        if (projectileScript != null && targetEnemy != null)
        {
            // truyen toan bo gameobject muc tieu
            projectileScript.SetTarget(targetEnemy);
        }
    }

    // ham tim enemy nearest
    GameObject FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject nearest = null;
        float minDistance = Mathf.Infinity;

        if (enemies.Length > 0)
        {
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearest = enemy;
                }
            }
        }
        return nearest;
    }
}
