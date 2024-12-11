using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerAndHealth : MonoBehaviour
{
    PowerAndHealth PandHp;
    public int MaxHealth;
    public int PowerShot;
    int Score;
    Animator anim;


    public int Hp { get; private set; }



    void Start()

    {
        PandHp = GetComponent<PowerAndHealth>();
        Hp = MaxHealth;
        anim = Manger.Instance.Player.GetComponentInChildren<Animator>();

    }

    public void Health(int value)
    {
        Hp = Mathf.Clamp(Hp + value, 0, MaxHealth);
        Debug.Log(Hp + "/" + MaxHealth);
        if (Hp <= 0) { Die(); }

    }

    // Update is called once per frame
    void Update()
    {


    }

    void Die()
    {
        if (transform.CompareTag("Player"))
        {



            anim.SetTrigger("Die");


        }
        if (transform.CompareTag("Enemy"))
        {
            Destroy(gameObject);

        }

    }

}
