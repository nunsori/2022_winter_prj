using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class item_data : ScriptableObject
{
    public string item_name;

    public string character_name;

    public int[] character_status;

    public string[] character_script;

    public GameObject character_prefab;

    //static�� �����Ŵ� json�� ���� �ȵ�! ���� ���͵� ���� ������� ���� �����ص� ��
}

