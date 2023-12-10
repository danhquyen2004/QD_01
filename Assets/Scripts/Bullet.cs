using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float arrowSpeed = 5f;
    private Vector3 direction;
    [SerializeField] private int damage;
    [SerializeField] private bool isEnemy;
    [SerializeField] private bool isPlayer;


    public void SetTarget(Vector3 direction)
    {
        this.direction = direction;
    }
    private void Update()
    {
        BulletMove();
        Destroy(gameObject, 7f);
    }

    protected void BulletMove()
    {
        transform.position += direction * arrowSpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isPlayer)
        {
            if (collision.CompareTag("Enemy"))
            {
                collision.gameObject.GetComponent<Health>().TakeDamage(damage);
                PlayerController.Instance.health.currentHealth += damage / 2;
            }
                
            Destroy(gameObject);
        }
        if(isEnemy)
        {
            if (collision.CompareTag("Player"))
                PlayerController.Instance.health.TakeDamage(damage);
            if (collision.CompareTag("Enemy")) return;
            Destroy(gameObject);
        }
    }

}
