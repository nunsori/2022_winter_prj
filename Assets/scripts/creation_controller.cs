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
    }

    public void open_popup(item_data item)
    {
        //popup 기본설정 완료하기
        popup_obj.transform.GetChild(0).GetChild(1).GetComponent<Image>().sprite = item_drag.item_sprites[item.code];
        popup_obj.transform.GetChild(0).GetChild(2).GetComponent<TextMeshProUGUI>().text = item.item_name;
        //...here


        popup_obj.SetActive(true);
    }

    public void close_popup()
    {
        popup_obj.SetActive(false);
    }
}
