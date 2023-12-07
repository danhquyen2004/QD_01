using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange;
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] bool isAtking = false;
    [SerializeField] protected float atkRate = 2;
    [SerializeField] protected float countAtkTime = 0;

    [SerializeField] private int damage;
    private void Update()
    {
        Attacking();
    }
    private void Attacking()
    {
        if (isAtking)
        {
            countAtkTime += Time.deltaTime;
            if(countAtkTime > atkRate)
            {
                isAtking = false;
                countAtkTime = 0;
            }
            return;
        }
        if (!InputManager.Instance.NormalAtk) return;
        
        PlayerController.Instance.animator.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if(hitEnemies.Length > 0) isAtking = true;
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<Enemy>().hp -= damage;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
