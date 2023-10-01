using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour

{
    public Transform EnemyMovementA;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WalkTowardsPlayer();
    }

    void WalkTowardsPlayer() 
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime); // game object movement  
        transform.position = Vector3.MoveTowards(transform.position, EnemyMovementA.position, speed * Time.deltaTime); // makes the game object moves towards a specific position
    }


}
