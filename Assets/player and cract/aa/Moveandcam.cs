using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Moveandcam : MonoBehaviour
{
    public float speed;
    public float gravety = 110;
    public float jumpp = 0;
    public float powerJump;
    Transform cam;
    Animator anim;
    float PositiveMove;
    //run
    bool isrun = false;
    float backspeed;
    //ex run
   public GameObject shild;
    bool compo = false;
    int clickcombo;


    CharacterController controlar;
    // Start is called before the first frame update
    void Start()
    {
        controlar = GetComponent<CharacterController>();
        jumpp = 0;
        cam = Camera.main.transform;
        anim = GetComponent<Animator>();
        backspeed = speed;
       

    }

    // Update is called once per frame
    void Update()
    {
        float hori = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");
        float jump = Input.GetAxis("Jump");
        Vector3 moves = new Vector3(hori, 0, ver);
        if (moves.magnitude > 0.01)
        {
            float angcam = Mathf.Atan2(moves.x, moves.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            transform.rotation = Quaternion.Euler(0, angcam, 0);
        }

        moves = cam.TransformDirection(moves);
        if (jump > 0 && controlar.isGrounded)
        {
            jumpp = powerJump;

            
            anim.SetTrigger("Jump");
        }
        else
        {


            jumpp -= gravety * Time.deltaTime;
            ;
        }

        controlar.Move(new Vector3(moves.x * speed, jumpp, moves.z * speed));
        if (jumpp < -100) { jumpp = -1; }

        PositiveMove = new Vector2(hori, ver).magnitude;

        Debug.Log(clickcombo);
        anim.SetFloat("wolk",Mathf.Clamp( PositiveMove,0,0.5f) + (isrun?0.5f:0));
        
        // ÇÓßÑÈÊ ÇáÌÑí
       float runun(float spee)
        {
            spee = backspeed * 2;
            return spee;
        }
      if  ( Input.GetKey(KeyCode.LeftShift))
        { isrun = true;
            shild.SetActive(false);
        
        }
      else
        { isrun = false;
            shild.SetActive(true);


        }
        if (isrun)
            speed = runun(speed); 
        else
        {
            speed = backspeed;
        }
        // äåÇíÉ ÇÓßÑÈÊ ÇáÌÑí
        if (Input.GetMouseButtonDown(0) && !isrun  )
        {
            clickcombo++;

            
            

                StartCoroutine(doplclick());
            
            // anim.SetTrigger("attack11");
            
        }


        if (Input.GetMouseButtonDown(0) && isrun  )
        {
            anim.SetTrigger("attack2");
            

        }
        

        

    }
    
    IEnumerator doplclick()
    {
        if (!compo)
        { 
                
            anim.SetTrigger("attack11");

            compo = true;
        }
       

        if (clickcombo > 1 && !isrun)
        {
            anim.SetBool("attack22",true);
            
        }
        
        else
        {
            anim.SetBool("attack22", false);
        }
        
        yield return new WaitForSeconds(1.25f);
        
        clickcombo = 0;
        compo = false;
    }
    
}
