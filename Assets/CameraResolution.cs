using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;
        float scaleheigt=((float)Screen.width/Screen.height)/((float)9/16);
        float scalewidth = 1f / scaleheigt;
        if(scaleheigt<1){
            rect.height = scaleheigt;
            rect.y = (1f-scaleheigt)/2f;
        }
        else{
            rect.width = scalewidth;
            rect.x=(1f-scalewidth)/2f;
        }
        camera.rect=rect;
    }

    void OnPreCull() => GL.Clear(true,true,Color.black);

    // Update is called once per frame
    void Update()
    {
        
    }
}
