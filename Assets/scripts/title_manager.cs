using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class title_manager : MonoBehaviour
{

    [Header("title_btns")]
    [SerializeField]
    private GameObject[] btn_list;
    [SerializeField]
    private string[] btn_fadeout_motion_name;

    Animator[] btn_animator_list;


    public static title_manager instance;

    private void Awake()
    {
        //singleton
        if (instance == null)
        {
            instance = this;

            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        btn_animator_list = new Animator[btn_list.Length];
        for (int i = 0; i < btn_list.Length; i++)
        {
            btn_animator_list[i] = btn_list[i].GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void start_click()
    {
        //fade out effect start
        
        for(int i =0; i<btn_animator_list.Length; i++)
        {
            change_animation_state(btn_animator_list[i], btn_fadeout_motion_name[i]);
        }


        //wait time

        //wait_time(1f);
        Invoke("wait_time",1f);

        //generate loading scene

        
    }

    public void change_animation_state(Animator animator, string state_name)
    {
        // stop from interrupting by same animation
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(state_name)) return;

        //animation play
        animator.Play(state_name);

    }

    private void wait_time()
    {
        /*
        float temp = 0f;
        while (true)
        {
            temp += Time.deltaTime;
            if (temp >= time)
            {
                break;
            }
        }*/
        loading_scene_controller.Instance.load_new_scene("main_scene");
    }
}
