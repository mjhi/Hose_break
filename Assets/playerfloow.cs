using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerfloow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = player.transform.position+new Vector3(0,4,-10);
        

    }
    void FixedUpdate(){
        transform.position = Vector3.Lerp(transform.position,player.transform.position+new Vector3(0,2.5f,0),Time.deltaTime*30.0f);
        transform.position = new Vector3(transform.position.x,transform.position.y,-10);
    }
}
