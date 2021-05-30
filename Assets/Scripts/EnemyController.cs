using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    private Rigidbody2D rb;
    public Enemy enemyObject;
    public enum EnemyState
    {
        idle,
        gunAttacking,
        punchAttacking,
        inQueue,
        active
    }

    public EnemyState currentState;

    public Player playerObject;

    public BattleRegion enemyRegion;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;

    }
    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.idle:
                Idle();
                break;
            case EnemyState.gunAttacking:
                GunAttack();
                break;
            case EnemyState.punchAttacking:
                PunchAttack();
                break;
            case EnemyState.inQueue:
                QueueWait();
                break;
            case EnemyState.active:
                Activated();
                break;
            default:
                break;
        }

        

        
    }
    void FixedUpdate()
    {


    }

    public void Idle()
    {
        if(Vector2.Distance(transform.position, transform.position) < 5 &&
            enemyRegion.locationTrigger.hasTriggered == true)
        {
            currentState = EnemyState.active;
        }
    }
    
    public void GunAttack()
    {

    }

    public void PunchAttack()
    {

    }
    
    public void QueueWait()
    {

    }

    public void Activated()
    {
     
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
    }
}
