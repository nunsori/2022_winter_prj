using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class item_data
{
    public int code;

    public string item_name;

    public string character_name;

    public int[] character_status;

    public string[] character_script;

    public GameObject _prefab;

    //static이 붙은거는 json에 저장 안됨! 따라서 스터디 때와 같은방식 으로 구현해도 됨

    public static string[] item_name_set =
        {"temp" ,"혼돈의 권능", "짐승", "죽음의 축복","불사의 축복","지옥초","다크 다이아몬드"
            ,"생명의 축복","꺼지지 않는 불","장염한 대지의 토양","솟구치는 영원수"};
    public static string[] character_name_set = { "c1", "c2", "c3" };



    private static int[,] combination_arr = new int[,] 
    { {1,2,3 },{1,2,4 },{1,2,5 }
     ,{4,8,7 },{4,10,7 },{4,9,6 } };


    public item_data(int code2, bool is_character)
    {
        if (is_character)
        {
            //character의 경우
            this.character_name = character_name_set[code2];
        }
        else
        {
            //item의 경우
            
            this.item_name = item_name_set[code2];
        }

        this.code = code2;
        
        
    }
}

