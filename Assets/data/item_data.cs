using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class item_data : ScriptableObject
{
    public int code;

    public string item_name;

    public string character_name;

    public int[] character_status;

    public string[] character_script;

    public GameObject _prefab;

    //static이 붙은거는 json에 저장 안됨! 따라서 스터디 때와 같은방식 으로 구현해도 됨

    public static string[] item_name_set = { "1", "2", "3" };
    public static string[] character_name_set = { "c1", "c2", "c3" };
    
    public item_data(int code, bool is_character)
    {
        if (is_character)
        {
            //character의 경우
            this.item_name = item_name_set[code];
        }
        else
        {
            //item의 경우
            this.character_name = character_name_set[code];
        }
        
        
    }
}

