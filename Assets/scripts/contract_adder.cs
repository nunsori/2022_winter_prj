using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class contract_adder : MonoBehaviour
{

    //카드 스프라이트 저장(등급 관련된 배경)
    public Sprite[] card_rank_sprite;

    public static contract_adder Instance;


    //뽑기결과 팝업 오브젝트
    public GameObject result_popup;


    //팝업 띄울 오브젝트
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


    //캐릭터 paly data 창에 넣고 저장
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


    //결과 보여주기
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

    //팝업 닫는 버튼
    public void result_off()
    {
        result_popup.SetActive(false);
    }
}
