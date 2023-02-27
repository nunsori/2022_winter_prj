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

    //static�� �����Ŵ� json�� ���� �ȵ�! ���� ���͵� ���� ������� ���� �����ص� ��

    public static string[] item_name_set =
        {"temp" ,"ȥ���� �Ǵ�", "����", "������ �ູ","�һ��� �ູ","������","��ũ ���̾Ƹ��"
            ,"������ �ູ","������ �ʴ� ��","�忰�� ������ ���","�ڱ�ġ�� ������"};
    public static string[] character_name_set = { "c1", "c2", "c3" };



    private static int[,] combination_arr = new int[,] 
    { {1,2,3 },{1,2,4 },{1,2,5 }
     ,{4,8,7 },{4,10,7 },{4,9,6 } };


    public item_data(int code2, bool is_character)
    {
        if (is_character)
        {
            //character�� ���
            this.character_name = character_name_set[code2];
        }
        else
        {
            //item�� ���
            
            this.item_name = item_name_set[code2];
        }

        this.code = code2;
        
        
    }
}

