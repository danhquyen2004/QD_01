using UnityEngine;

public class BossHpBar : MonoBehaviour
{
    public GameObject hpBar;
    private void FixedUpdate()
    {
        if(gameObject.activeInHierarchy)
        {
            hpBar.SetActive(true);
        }
    }

}
