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

    //static�� �����Ŵ� json�� ���� �ȵ�! ���� ���͵� ���� ������� ���� �����ص� ��

    public static string[] item_name_set = { "1", "2", "3" };
    public static string[] character_name_set = { "c1", "c2", "c3" };
    
    public item_data(int code)
    {
        this.item_name = item_name_set[code];
        this.character_name = character_name_set[code];
    }
}

