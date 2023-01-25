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

    //static이 붙은거는 json에 저장 안됨! 따라서 스터디 때와 같은방식 으로 구현해도 됨
}

