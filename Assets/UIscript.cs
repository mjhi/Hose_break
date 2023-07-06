using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIscript : MonoBehaviour
{
    public GameObject GameOver;
    public Slider hpslider;
    public GameObject hithp;
    playerstats Playerstat;
    // Start is called before the first frame update
    void Start()
    {
        Playerstat =  GameObject.Find("Player").GetComponent<playerstats>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Playerstat.HP==0){
            GameOver.SetActive(true);
        }
    }

    public void GoMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}
