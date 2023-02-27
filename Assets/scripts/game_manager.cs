using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class game_manager : MonoBehaviour
{
    public static game_manager Instance;

    [Header("data_file")]
    //data_set
    private string data_path;
    [SerializeField]
    private string data_file_name;

    //to json 함수에 넣을 데이터 이 데이터가 json으로 된다.
    public static player_data play_data;


    //data string temp 데이터 저장 전, to json으로 나오는거 받는 용도
    private string data_string_temp;


    [Header("ui_set")]
    [SerializeField]
    private GameObject down_buttion_set;
    [SerializeField]
    private Animator[] ui_animation_arr;
    //[SerializeField]
    private string[] ui_animation_name = 
        {"main_panel_init","main_panel_in",
         "creation_panel_init","creation_panel_in",
         "contract_panel_init","contract_panel_in",
         "conquer_panel_init","conquer_panel_in"};
    [SerializeField]
    private AnimationClip[] ui_animation_clips;

    //private string[]
    //ui panel들
    /*
     * 0 - main
     * 1 - creation
     * 2 - contract
     * 3 - conquer
     */
    [SerializeField]
    private GameObject[] ui_obj;




    //creation panel 관련 변수

    /*
    [SerializeField]
    public Button creation_start_btn;
    [SerializeField]
    public GameObject[] creation_table_slots;


    [SerializeField]
    private GameObject slot_parent;
    private GameObject[] creation_inventory_slots;

    [SerializeField]
    public GameObject slot_pref;
    [SerializeField]
    public GameObject item_obj_pref;*/




    private void Awake()
    {
        //singleton
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //set data_path
        data_path = Application.persistentDataPath + "/data/";
        data_file_name = "player_data.json";


        //data loading
        load_data();

        //create slot and item obj

        creation_controller.Instance.create_item_obj();
        /*
        for(int i =0; i<play_data.item_Datas.Length; i++)
        {
            creation_inventory_slots[i] = Instantiate(slot_pref, slot_parent.transform);
            if (play_data.item_Datas[i] != null)
            {
                Instantiate(play_data.item_Datas[i], creation_inventory_slots[i].transform);
            }
        }*/



    }


    // Start is called before the first frame update
    void Start()
    {
        //get_animation component
        //ui_animation_arr[0] = down
        only_one_arr_actvie(0, ui_obj);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save()
    {
        data_string_temp = JsonUtility.ToJson(play_data,true);
        Debug.Log(data_string_temp);
        /*
        using(var stream = new FileStream(data_path+data_file_name,FileMode.CreateNew, FileAccess.Write, FileShare.Write))
        using(var writer = new StreamWriter(stream))
        {
            File.WriteAllText(data_path + data_file_name, data_string_temp);
        }*/
        File.WriteAllText(data_path + data_file_name, data_string_temp);
    }


    void load_data()
    {
        //if file does not exist
        if (!File.Exists(data_path))
        {
            //make file
            //File.Create(data_path);
            Directory.CreateDirectory(data_path);
            Debug.Log("data file created");
        }


        //data file does not exist
        if (!File.Exists(data_path + data_file_name))
        {
            //make data file
            FileStream temp = File.Create(data_path + data_file_name);

            Debug.Log("data_json created");

            play_data = new player_data();

            temp.Close();

            save();
        }
        else //else data file exist
        {
            
            data_string_temp = File.ReadAllText(data_path + data_file_name);
            play_data = JsonUtility.FromJson<player_data>(data_string_temp);
        }

    }

    //ui활성화 함수

    public void main_menu_button_clicked(string btn_type)
    {
        switch (btn_type) {

            case ("create_btn"):
                //ui_animation_arr[]
                StartCoroutine(set_active_delay(ui_obj[0], ui_animation_clips[0 * 2].length, false, 0));
                //ui set active 와 기본 설정
                


                //ui animation 재생
                ui_animation_arr[1].Play("creation_panel_in");

                StartCoroutine(set_active_delay(ui_obj[1], ui_animation_clips[1 * 2 + 1].length, true, 1));


                //ui 기본 세팅 실행
                creation_controller.Instance.check_creation_btn_interactive();


                break;

            case ("contract_btn"):

                //ui set active 와 기본 설정


                //ui animation 재생

                break;

            case ("dictionary_btn"):

                //ui set active 와 기본 설정


                //ui animation 재생

                break;

            case ("conquer"):

                //ui set active 와 기본 설정


                //ui animation 재생

                break;

            case ("back_btn"):

                //지금 활성화 되있는 ui찾기
                for (int i = 1; i < ui_obj.Length; i++)
                {
                    if (ui_obj[i] != null &&ui_obj[i].activeSelf == true)
                    {
                        //해당 패널 퇴장 애니메이션 재생
                        //끝날때까지 대기할 방법 구성
                        //ui_animation_arr[i].SetFloat("speed", -1);
                        //ui_animation_arr[i].Play(ui_animation_name[i * 2 + 1]);

                        
                        
                        //ui 비활성화
                        
                        
                        //ui_obj[i].SetActive(false);
                        StartCoroutine(set_active_delay(ui_obj[i], ui_animation_clips[i * 2 + 1].length * 2f , false,i));
                        //main 활성화
                        //ui_obj[0].SetActive(true);

                        StartCoroutine(set_active_delay(ui_obj[0], ui_animation_clips[i * 2 + 1].length * 2f , true, 0));

                    }
                }


                

                //main anim재생
                //ui_animation_arr[0].SetFloat("speed", 1f);
                //ui_animation_arr[0].Play(ui_animation_name[1]);


                break;

            default:
                break;
        
        }

    }

    private void only_one_arr_actvie(int index, GameObject[] arr)
    {
        for(int i =0; i<arr.Length; i++)
        {
            if (arr[i] != null)
            {
                arr[i].SetActive(i==index);
            }
        }
    }

    private void translate_panel(int n)
    {
        //??
        ui_animation_arr[n].Play(ui_animation_name[n]);
    }


    /*
    public void check_creation_btn_interactive()
    {
        creation_start_btn.interactable = true;

        for(int i =0; i<creation_table_slots.Length; i++)
        {
            if (creation_table_slots[i].transform.GetChild(0) == null)
            {
                creation_start_btn.interactable = false;
            }
        }
    }*/


    public IEnumerator set_active_delay(GameObject obj, float delay, bool is_true, int index)
    {
        Debug.Log("delay on");
        Debug.Log(delay);

        if (!is_true)
        {
            Debug.Log("out");
            obj.GetComponent<Animator>().SetFloat("speed", -1f);
            
            
            obj.GetComponent<Animator>().Play(ui_animation_name[index * 2]);
        }

        yield return new WaitForSeconds(delay);

        obj.SetActive(is_true);

        if (is_true)
        {
            Debug.Log("in");
            obj.GetComponent<Animator>().SetFloat("speed", 1f);
            obj.GetComponent<Animator>().Play(ui_animation_name[index * 2 + 1]);
        }
    }
}
