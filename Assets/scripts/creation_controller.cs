using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class creation_controller : MonoBehaviour
{
    public static creation_controller Instance;


    //creation panel 관련 변수

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
    public GameObject item_obj_pref;


    [SerializeField]
    public GameObject popup_obj;


    //private static int[][] combination_table;


    // Start is called before the first frame update
    private void Awake()
    {
        //singleton
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }


        popup_obj.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void create_item_obj()
    {
        creation_inventory_slots = new GameObject[game_manager.play_data.item_Datas.Length];
        Debug.Log(game_manager.play_data.item_Datas.Length);
        GameObject temp;
        for (int i = 0; i < game_manager.play_data.item_Datas.Length; i++)
        {
            creation_inventory_slots[i] = Instantiate(slot_pref, slot_parent.transform);
            if (game_manager.play_data.item_Datas[i] != null)
            {
                //Instantiate(game_manager.play_data.item_Datas[i], creation_inventory_slots[i].transform);
                temp = Instantiate(item_obj_pref, creation_inventory_slots[i].transform);
                //creation_inventory_slots[i].transform.GetChild(0).GetComponent<item_drag>().item_Data = game_manager.play_data.item_Datas[i];
                temp.GetComponent<item_drag>().item_Data = game_manager.play_data.item_Datas[i];
            }
        }
    }


    public void check_creation_btn_interactive()
    {
        creation_start_btn.interactable = true;

        for (int i = 0; i < creation_table_slots.Length; i++)
        {
            //GmeObject temp = (creation_table_slots[i].transform.GetChild(0).gameObject);
            
            if (creation_table_slots[i].transform.childCount == 0)
            {
                Debug.Log("false");
                creation_start_btn.interactable = false;
            }
            else
            {
                //return;
            }
            
        }
    }


    public void create_item()
    {
        Debug.Log("create item");

        int[] temp = {0,0,0};
        bool is_same = false;
        int i_temp = 0;

        for (int i = 0; i < creation_table_slots.Length; i++)
        {
            temp[i] = creation_table_slots[i].transform.GetChild(0).GetComponent<item_drag>().item_Data.code;
        }

        Debug.Log(temp[0]);
        Debug.Log(temp[1]);
        Debug.Log(temp[2]);

        for (int i =0; i<item_data.combination_result_arr.Length; i++)
        {
            for(int j=0; j<temp.Length; j++)
            {
                if (temp[j] == item_data.combination_arr[i, j])
                {
                    is_same = true;
                    continue;
                }
                else
                {
                    //Debug.Log("not same");
                    is_same = false;
                    break;
                }
            }

            if(is_same == true)
            {
                Debug.Log("same true");
                i_temp = i;
                break;
            }
        }

        if (is_same)
        {
            Debug.Log(game_manager.play_data.character_datas_pivot);
            //아이템 생성
            game_manager.play_data.character_Datas[game_manager.play_data.character_datas_pivot++] = new item_data(item_data.combination_result_arr[i_temp], true);
            Debug.Log("item created @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@");

            Destroy(creation_table_slots[0].transform.GetChild(0).gameObject);
            Destroy(creation_table_slots[1].transform.GetChild(0).gameObject);
            Destroy(creation_table_slots[2].transform.GetChild(0).gameObject);

            update_inventory();

            //팝업으로 아이템 생성된거 보여주기
            open_popup(game_manager.play_data.character_Datas[game_manager.play_data.character_datas_pivot - 1]);

            //...here

        }





    }

    public void open_popup(item_data item)
    {
        //popup 기본설정 완료하기
        if(item.code != 0)
        {
            popup_obj.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = item_drag.item_sprites[item.code];
            popup_obj.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = item.item_name;
        }else if(item.char_code != 0)
        {
            popup_obj.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = item_drag.char_sprites[item.char_code];
            popup_obj.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = item.character_name;
        }
        
        //...here


        popup_obj.SetActive(true);
    }

    public void close_popup()
    {
        popup_obj.SetActive(false);
    }

    public void update_inventory()
    {
        for(int i =0; i<creation_inventory_slots.Length; i++)
        {
            if(creation_inventory_slots[i].transform.childCount == 0)
            {
                game_manager.play_data.item_Datas[i] = null;
            }
            else
            {
                game_manager.play_data.item_Datas[i] = creation_inventory_slots[i].transform.GetChild(0).gameObject.GetComponent<item_drag>().item_Data;
            }
        }

        game_manager.Instance.save();
    }
}
