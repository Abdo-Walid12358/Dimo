using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Enimy1 : MonoBehaviour
{
   // PowerAndHealth PandHp;
    GameObject Player;
    public float dis;
    NavMeshAgent agent;
    Animator anim;
    bool canShot;
    float distance;
    // Start is called before the first frame update
    void Start()
    {
        Player = Manger.Instance.Player;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        canShot = true;
       // PandHp = GetComponent<PowerAndHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Player.transform.position);

        if (distance <= agent.stoppingDistance)
        { canShot = true; }
        else { canShot = false; }
        if (canShot && distance <= agent.stoppingDistance)
        {
            anim.SetTrigger("Attack1");


            StartCoroutine(TimeShotDown());

        }
        else { canShot = false; }
        if (Vector3.Distance(transform.position, Player.transform.position) < dis)
        {
            anim.SetFloat("Move", agent.velocity.magnitude);
            agent.SetDestination(Player.transform.position);

        }
        else
        {
            anim.SetFloat("Move", 0);
        }
        


    }
    private void OnTriggerEnter(Collider other)
    {
      /*  if (other.CompareTag("Sword"))
        {
            PandHp.Health(-other.GetComponent<PowerAndHealth>().PowerShot);
        }
      */
    }
    IEnumerator TimeShotDown()
    {
        yield return new WaitForSeconds(2f);
        canShot = true;

    }
}
