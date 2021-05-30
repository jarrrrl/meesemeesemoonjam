using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private bool canFire = true;
    public Gun enemyGun;
    //public Fist enemyFist;

    public Sprite idleSprite;
    public Sprite gunSprite;

    private Rigidbody2D rb;
    public Enemy enemyObject;

    public enum EnemyState
    {
        idle,
        active
    }

    public EnemyState currentState;

    public Player playerObject;

    public BattleRegion enemyRegion;

    private Vector2 movement;
    public Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {
        currentState = EnemyState.idle;
        rb = enemyObject.GetComponent<Rigidbody2D>();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        switch (currentState)
        {
            case EnemyState.idle:
                Idle();
                break;
            case EnemyState.active:
                Activated();
                break;
            default:
                break;
        }

        direction = playerObject.transform.position -
            enemyObject.transform.position;
        direction.Normalize();
        Rotate(direction);
        
        if (Vector2.Distance(playerObject.transform.position, transform.position) > 5f){
            movement = direction;
        }

    }
    void MoveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)enemyObject.transform.position +
          (direction * enemyObject.moveSpeed * Time.deltaTime));
    }

    public void Idle()
    {
        if(Vector2.Distance(playerObject.transform.position, transform.position) < 20f &&
            enemyRegion.locationTrigger.hasTriggered == true)
        {
            currentState = EnemyState.active;
        }
    }
    
    public void GunAttack()
    {
        if (direction.y <= 0.2f && direction.y >= -0.2f && canFire
            && (Vector2.Distance(playerObject.transform.position, transform.position) > 15f))
        {
            enemyObject.moveSpeed -= 2f;
            enemyObject.GetComponent<SpriteRenderer>().sprite = gunSprite;
            //enemyFist.transform.gameObject.SetActive(false);

            enemyGun.ShootGun();
            StartCoroutine(FireSpeedTimer());
        }
    }

    public void PunchAttack()
    {
        if (Mathf.Abs(playerObject.transform.position.x - transform.position.x) < 5f
            && Mathf.Abs(playerObject.transform.position.y - transform.position.y) < 5f)
        {
            enemyObject.moveSpeed = 0f;
            enemyObject.GetComponent<SpriteRenderer>().sprite = gunSprite;
            //enemyFist.transform.gameObject.SetActive(false);

            enemyGun.ShootGun();
            StartCoroutine(FireSpeedTimer());
        }
    }
    

    public void Activated()
    {
        MoveCharacter(movement);
        GunAttack();
    }
    private void Rotate(Vector2 direction)
    {
        if (direction.x > 0)
        {
            enemyObject.transform.eulerAngles = Vector3.up * 180;
        }
        else if (direction.x < 0)
        {
            enemyObject.transform.eulerAngles = Vector3.up;
        }
    }
    private IEnumerator FireSpeedTimer()
    {
        canFire = false;
        yield return new WaitForSeconds(enemyGun.fireSpeed);
        enemyObject.GetComponent<SpriteRenderer>().sprite = idleSprite;


        canFire = true;
        enemyObject.moveSpeed += 2f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Physics2D.IgnoreCollision(collision.collider,
            GetComponent<Collider2D>());


            // ignore
        }
    }
}
