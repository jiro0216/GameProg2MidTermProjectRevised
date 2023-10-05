using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public Transform BulletDirectionPlayer;
    public Transform SpawnPointPosition;
    public float spawnMin;
    public float spawnMax;
    public float BulletSpeed;
    public float rotSpeed;
    public float shootingRadius;
    private bool isEnemyInRange = false;
    public GameManager gameManager;
    [SerializeField] private float SpawnTimer;
    public GameObject PlayerBullet;




    // Start is called before the first frame update
    void Start()
    {
        SpawnTimer = Random.Range(spawnMin, spawnMax);

    }
    // Update is called once per frame
    void Update()
    {

        if (BulletDirectionPlayer != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, BulletDirectionPlayer.position);

            // Check if the player is within the shooting range
            if (distanceToPlayer <= shootingRadius)
            {
                isEnemyInRange = true;
                RotatesTowardsEnemy();
            }
            else
            {
                isEnemyInRange = false;
            }

            if (isEnemyInRange)
            {
                PlayerAutoShoot();
            }
        }

        // Check if the player is within the shooting range
       
    }

    void PlayerAutoShoot()
    {
        SpawnTimer -= Time.deltaTime;

        if (SpawnTimer <= 0)
        {
            Vector3 BulletDirection = (BulletDirectionPlayer.position - SpawnPointPosition.position).normalized;
            GameObject PlayerBullet1 = Instantiate(PlayerBullet, SpawnPointPosition.position, Quaternion.identity);
            Rigidbody BulletRB = PlayerBullet1.GetComponent<Rigidbody>();
            if (BulletRB != null)
            {
                BulletRB.velocity = BulletDirection * BulletSpeed;
            }
            
            Destroy(PlayerBullet1, 5f);

            SpawnTimer = Random.Range(spawnMin, spawnMax);
        }


    }

    void RotatesTowardsEnemy()
    {
        Vector3 relativePos = BulletDirectionPlayer.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(relativePos, Vector3.up);
        float step = rotSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, step);
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, shootingRadius);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Game over condition: When the turret collides with an enemy.
            gameManager.GameOver();

        }

    }// SA PLAYER ITO
}

    
