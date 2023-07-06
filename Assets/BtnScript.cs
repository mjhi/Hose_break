using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    public bool Shiledbool=false;
    private Animator animator;
    public float jumpPower;
    Rigidbody2D rigid;
    public bool standfloor;
    public GameObject nowmonster;
    public bool jumpbool;
    public bool attackbool;
    // Start is called before the first frame update
    void Start()
    {
        jumpbool=true;
        rigid = GetComponent<Rigidbody2D>();
        nowmonster=null;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Shiledbool){
            if(nowmonster!=null){
                
                nowmonster.GetComponent<Rigidbody2D>().AddForce(Vector2.up* 8f , ForceMode2D.Impulse);
                nowmonster=null;
                Shiledbool=false;
            }
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name=="Floor"){
            if(!standfloor){
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
                rigid.constraints = RigidbodyConstraints2D.FreezeRotation|RigidbodyConstraints2D.FreezePositionY;
                standfloor=true;
                gameObject.transform.position =new  Vector3(0.02f,-3.3692f,0);
                animator.SetBool("jump",false);
            }
            
        }
        if(col.gameObject.name=="monster"){
            if(standfloor){
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
                jumpbool=false;
            }
            
        }
        

        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(standfloor){
            if(col.gameObject.tag=="monster"){
                jumpbool=false;
            }
        }
        if(col.gameObject.name=="Floor"){
            if(!standfloor){
                gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
                rigid.constraints = RigidbodyConstraints2D.FreezeRotation|RigidbodyConstraints2D.FreezePositionY;
                standfloor=true;
                gameObject.transform.position =new  Vector3(0.02f,-3.3692f,0);
                animator.SetBool("jump",false);
            }
            
        }
        

        
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if(standfloor){
            if(col.gameObject.tag=="monster"){
                jumpbool=true;
            }
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(standfloor){
            if(col.gameObject.tag=="monster"){
                jumpbool=true;
            }
        }
    }

    
    public void Shiled(){
        Shiledbool = true;
        
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
        
        if(standfloor){
            animator.SetTrigger("shiled");
        }
        else{
            animator.SetTrigger("jumpshiled");
        }
        Invoke("noneshiled",0.3f);
        
        
    }
    void noneshiled()
    {
        gameObject.GetComponent<PolygonCollider2D>().isTrigger = true;
        Shiledbool=false;
    }
    void noneattack()
    {
        
        attackbool=false;
    }
    public void Attack(){
        if(!attackbool){
            Debug.Log("АјАн");
            attackbool=true;
        if(standfloor){
            animator.SetTrigger("attack");
        }
        else{
            animator.SetTrigger("Jumpattack");
        }
        Invoke("noneattack",0.5f);
        }
        
        
    }

    public void Jump()
    {
        if(standfloor&&jumpbool){
            gameObject.GetComponent<PolygonCollider2D>().isTrigger = false;
            rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
            animator.SetBool("jump",true);
            standfloor=false;
            rigid.AddForce(Vector2.up* jumpPower , ForceMode2D.Impulse);
        }
            
        
    }
}
