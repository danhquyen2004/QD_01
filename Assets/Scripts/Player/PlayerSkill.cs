using TMPro;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    public GameObject skill;
    private bool isCoolDown = false;
    [SerializeField] private float coolDown;
    [SerializeField] private float countCoolDown;

    [SerializeField] private TMP_Text text;
    [SerializeField] private GameObject image;

    private void Start()
    {
        countCoolDown = coolDown;
    }
    private void Update()
    {
        if (isCoolDown)
        {
            countCoolDown -= Time.deltaTime;
            if (countCoolDown < 0)
            {
                countCoolDown = coolDown;
                isCoolDown = false;
            }
        }
        if (!InputManager.Instance.SkillAtk) return;
        if (isCoolDown) return;
        isCoolDown = true;
        AnimSkill();
        Invoke("ActiveSkill", 0.4f);
    }
    private void FixedUpdate()
    {
        if(isCoolDown)
        {
            image.SetActive(true);
            text.text = countCoolDown.ToString("F1");
        }
        else
        {
            image.SetActive(false);
        }

    }
    private void AnimSkill()
    {
        PlayerController.Instance.animator.SetFloat("RunState", 0f);
        PlayerController.Instance.animator.SetTrigger("Attack");
        PlayerController.Instance.animator.SetFloat("AttackState", 1f);
        PlayerController.Instance.animator.SetFloat("SkillState", 1f);
    }

    private void ActiveSkill()
    {
        GameObject skill = Instantiate(this.skill, transform.position, Quaternion.identity);
        Vector3 direction = new Vector3(-transform.parent.localScale.x, 0, 0);
        if(transform.parent.localScale.x>0)
        {
            skill.GetComponent<SpriteRenderer>().flipX = true;
        }
        if(transform.parent.localScale.x < 0)
        {
            skill.GetComponent<SpriteRenderer>().flipX = false;
        }
        Bullet skillMovement = skill.GetComponent<Bullet>();
        if (skillMovement != null)
        {
            skillMovement.SetTarget(direction);
        }
        skill.SetActive(true);
    }





}
