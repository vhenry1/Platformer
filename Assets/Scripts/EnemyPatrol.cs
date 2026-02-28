using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float patrolDistance = 3f;
    
    private Vector3 startPosition;
    private int direction = 1; 
    
    void Start()
    {
        startPosition = transform.position;
    }
    
    void Update()
    {
        transform.position += new Vector3(direction * moveSpeed * Time.deltaTime, 0, 0);
        
        float distanceFromStart = Vector3.Distance(startPosition, transform.position);
        
        if (distanceFromStart > patrolDistance)
        {
            direction *= -1; 
        }
    }
}