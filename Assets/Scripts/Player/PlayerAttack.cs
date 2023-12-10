using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] protected Transform attackPoint;
    [SerializeField] protected float attackRange;
    [SerializeField] protected LayerMask enemyLayers;

    [SerializeField] public bool isAtking = false;
    [SerializeField] protected float atkRate = 2;
    [SerializeField] protected float countAtkTime = 0;


    [SerializeField] protected int damage;
    private void Update()
    {   
        Attacking();
    }
    protected virtual void Attacking()
    {

        if (isAtking)
        {
            countAtkTime += Time.deltaTime;
            if (countAtkTime > atkRate)
            {
                isAtking = false;
                countAtkTime = 0;
            }
            return;
        }
        if (!InputManager.Instance.NormalAtk) return;
        PlayerController.Instance.animator.SetTrigger("Attack");
        PlayerController.Instance.animator.SetFloat("AttackState", 0f);
        PlayerController.Instance.animator.SetFloat("SkillState",0f);
        

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if(hitEnemies.Length > 0) isAtking = true;
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.gameObject.GetComponent<Health>().TakeDamage(damage);
        }

    }
    protected void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
