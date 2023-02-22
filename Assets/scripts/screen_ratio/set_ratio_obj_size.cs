using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class set_ratio_obj_size : MonoBehaviour
{
    float screen_ratio;
    [SerializeField]
    private SpriteRenderer player_sprite_renderer;
    private SpriteRenderer obj_renderer;

    private Vector3 temp_vector = Vector3.zero;

    [SerializeField]
    private float magnification;
    [SerializeField]
    public Transform background;


    // Start is called before the first frame update
    void Start()
    {
        //add obj renderer
        obj_renderer = gameObject.GetComponent<SpriteRenderer>();

        //trans to background
        gameObject.transform.position = background.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        set_ratio();
    }


    public void set_ratio()
    {
        //caculate the ratio of screen 
        screen_ratio = (float)Screen.width / (float)Screen.height;

        //set the vector3
        temp_vector.x = magnification * player_sprite_renderer.bounds.size.x;
        temp_vector.y = temp_vector.x / screen_ratio;
        temp_vector.z = 1;

        //adjust ratio of this obj
        //gameObject.transform.localScale = temp_vector;


        //adjust background scale
        //background.transform.localScale = gameObject.transform.localScale;
    }
}
