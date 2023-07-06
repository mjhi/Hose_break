using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monster : MonoBehaviour
{
    BtnScript btnscript;
    playerstats Playerstat;
    public bool hit;
    Rigidbody2D rigid;
    public float fullhp=18;
    public int hp;
    UIscript uisc;
    // Start is called before the first frame update
    void Start()
    {
        hit=false;
        rigid = GetComponent<Rigidbody2D>();
       btnscript =  GameObject.Find("Player").GetComponent<BtnScript>();
       Playerstat =  GameObject.Find("Player").GetComponent<playerstats>();
       uisc = GameObject.Find("UIManager").GetComponent<UIscript>();
       hp=(int)fullhp;
    }

    // Update is called once per frame
    void Update()
    {
        if(hp==0){
            uisc.hithp.SetActive(false);
            // Destroy(gameObject);
        }
        if(hit&&btnscript.Shiledbool&&btnscript.standfloor){
            
            rigid.AddForce(Vector2.up* 0.3f , ForceMode2D.Impulse);
            //hit=false;
        }
        else if(hit&&btnscript.attackbool){
            hp-=Playerstat.power;
            uisc.hithp.SetActive(true);
            uisc.hpslider.value = (float)hp / fullhp;
            btnscript.attackbool=false;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.name=="Player"){
            hit=true;
            
        }
        if(col.gameObject.name=="Floor"){
            Playerstat.HP-=1;
            HpBye();
        }
        
        

        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name=="Player"){
            hit=true;
            
        }
        if(col.gameObject.name=="Floor"){
            Playerstat.HP-=1;
            HpBye();
        }
        
        

        
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.name=="Player"){
            hit=false;
            
        }
    }
    void HpBye(){
        if(Playerstat.HP==2){
            Playerstat.hp[2].SetActive(false);
        }
        else if(Playerstat.HP==1){
            Playerstat.hp[1].SetActive(false);
        }
        else if(Playerstat.HP==0){
            Playerstat.hp[0].SetActive(false);
        }
    }
}
