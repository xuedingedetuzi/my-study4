using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum zombieState
{
    Move,Eat,Die,Pause
}
public class Zombie : MonoBehaviour
{
    // Start is called before the first frame update
    zombieState zombieState=zombieState.Move; 
    private Rigidbody2D rgd;
    public float moveSpeed = 1.5f;
    private Animator anim;

    public int atkValue=30;
    public float atkDuration = 2;
    private float atkTimer = 0;

    public int HP = 100;
    private int currentHP;

    private Plant currentEatPlant;
    public GameObject zombieHeadPrefab;

    private bool haveHead=true;
    void Start()
    {
        rgd=GetComponent<Rigidbody2D>();
        anim=GetComponent<Animator>();
        currentHP=HP;
        anim.SetFloat("HPPercent", 1f);
    }

    // Update is called once per frame
    void Update()
    {   
        switch (zombieState)
        {
            case zombieState.Move:
                MoverUpdate();
                break;
            case zombieState.Eat:
                EatUpdate();
                break;
            case zombieState.Die:
                break;
            case zombieState.Pause:
                break;
        }
    }
    void MoverUpdate()
    {
        rgd.MovePosition(rgd.position+Vector2.left*moveSpeed*Time.deltaTime);
    }
    void EatUpdate()
    {
        atkTimer+= Time.deltaTime;
        if (atkTimer > atkDuration&&currentEatPlant!=null)
        {
            Aduiomanager.Instance.PlayClip(Config.eat);
            currentEatPlant.TakeDamage(atkValue);
            atkTimer=0;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking",true);
            TransitionToEat();
            currentEatPlant =collision.GetComponent<Plant>();
        }else if (collision.tag == "House")
        {
            GameManager.Instance.GameEndFall();
        }
    } 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Plant")
        {
            anim.SetBool("IsAttacking", false);
            zombieState = zombieState.Move;
            currentEatPlant=null;
        }
    }
    void TransitionToEat()
    {
        zombieState= zombieState.Eat;
        atkTimer = 0;
    }
    public void TransitionToPause()
    {
        zombieState=zombieState.Pause;
        anim.enabled = false;
        
    }
    public void TackDamage(int damage)
    {
        if (currentHP <= 0) return;

        this.currentHP-= damage;
        if (currentHP <= 0) 
        {
            currentHP = -1;
            Dead();
        }
        float hpPercent =(float) currentHP  / HP;
        anim.SetFloat("HPPercent",hpPercent);
        if (hpPercent < 0.5f&&haveHead)
        {   
            haveHead=false;
            GameObject go=GameObject.Instantiate(zombieHeadPrefab, transform.position, Quaternion.identity);
            Destroy(go,2);
        }
    }
    private void Dead()
    {
        if (zombieState == zombieState.Die) return;

        zombieState = zombieState.Die;
        GetComponent<Collider2D>().enabled = false;
        ZombieManager.Instance.RemoveZombie(this);

        Destroy(this.gameObject,2);
    }
}
