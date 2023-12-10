using UnityEngine;

public class SpamPoint : MonoBehaviour
{
    [SerializeField] private bool enemyIsActive;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Health health;
    [SerializeField] private float timeSpawn;
    [SerializeField] private float countTimeSpawn = 0;

    [SerializeField] private GameObject spawnEffect;

    private void Start()
    {
        health = enemy.GetComponent<Health>();
    }
    private void Update()
    {
        Spawn();
    }

    protected void Spawn()
    {
        if (enemyIsActive) return;
        countTimeSpawn += Time.deltaTime;
        if(countTimeSpawn > timeSpawn)
        {
            GameObject ef = Instantiate(spawnEffect,transform.position,Quaternion.identity);
            ef.SetActive(true);
            Destroy(ef, 0.4f);

            enemyIsActive = true;
            enemy.transform.position = transform.position;
            enemy.SetActive(true);
            health.InitEnemy();
            if(!enemyIsActive)
            {
                countTimeSpawn = 0;
            }
        }
        

    }
}
