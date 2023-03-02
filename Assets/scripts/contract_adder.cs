using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contract_adder : MonoBehaviour
{

    //ī�� ��������Ʈ ����(��� ���õ� ���)
    public Sprite[] card_rank_sprite;

    public static contract_adder Instance;


    //�̱��� �˾� ������Ʈ
    public GameObject result_popup;


    //�˾� ��� ������Ʈ
    public GameObject[] item_obj;
    

    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }


        result_popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //ĳ���� paly data â�� �ְ� ����
    public void insert_chararcter(int num)
    {
        if (num != 1)
        {
            for(int i =0; i<num; i++)
            {
                game_manager.play_data.character_Datas[game_manager.play_data.character_datas_pivot++] = 
                    new item_data(contract_controller.Instance.sample[i],true);
                
            }
        }
        else
        {
            game_manager.play_data.character_Datas[game_manager.play_data.character_datas_pivot++] =
                    new item_data(contract_controller.Instance.sample[0], true);
        }

        game_manager.Instance.save();
        
    }


    //��� �����ֱ�
    public void result_on(int num)
    {
        result_popup.SetActive(true);

        for(int i =0; i < contract_controller.Instance.sample.Length; i++)
        {
            item_obj[i].GetComponent<Image>().sprite = card_rank_sprite[contract_controller.Instance.sample[i]];
        }


        for(int i =0; i<item_obj.Length; i++)
        {
            item_obj[i].SetActive((num == 1) ? i == 1 : true);
        }

        insert_chararcter(num);

    }

    //�˾� �ݴ� ��ư
    public void result_off()
    {
        result_popup.SetActive(false);
    }
}
