using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] protected int defaultHealth;
    [SerializeField] public int currentHealth;
    [SerializeField] protected Animator animator;

    public bool isStun;
    public bool isDie = false;
    public float timeStun;
    private float countTimeStun;
    protected virtual void Start()
    {
        InitEnemy();
    }
    protected virtual void Update()
    {
        if(isStun)
        {
            countTimeStun += Time.deltaTime;
            if(countTimeStun > timeStun) 
            {
                countTimeStun = 0;
                isStun = false;
                AnimIdle();
            }
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        isStun = true;
        animator.SetFloat("RunState", 1f);
        if (currentHealth <= 0)
            Die();
    }
    protected virtual void Die()
    {
        isDie = true;
        animator.SetTrigger("Die");

        if(gameObject.tag == "Enemy")
            StartCoroutine(AnimDie(2.0f));
    }
    protected IEnumerator AnimDie(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        gameObject.SetActive(false);
    }
    protected void AnimIdle()
    {
        animator.SetFloat("RunState", 0f);
    }
    public void InitEnemy()
    {
        isDie = false;
        isStun = false;
        currentHealth = defaultHealth;
    }
}

