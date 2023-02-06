using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_zoom : MonoBehaviour
{
    public SpriteRenderer target_size;
    public set_ratio_obj_size set_Ratio;
    private Vector3 temp_vec = Vector3.zero;

    // Start is called before the first frame update
    //화면비율 맞춰서 확대, 축소 해주는 함수
    void Update()
    {
        //adjust obj size by ratio
        set_Ratio.set_ratio();


        //set camera position
        temp_vec.z = Camera.main.transform.position.z;
        temp_vec.x = set_Ratio.background.position.x;
        temp_vec.y = set_Ratio.background.position.y;
        Camera.main.transform.position = temp_vec;


        //set Camera zoom
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = target_size.bounds.size.x / target_size.bounds.size.y;

        if(screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = target_size.bounds.size.y / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = (target_size.bounds.size.y / 2f) * differenceInSize;
        }
    }

    
}
