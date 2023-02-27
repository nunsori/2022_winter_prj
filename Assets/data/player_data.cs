using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_data
{
    //gold,gems
    public int basic_chaos_fragments;
    public int basic_chaos_crystal;

    //ingredient
    public item_data[] item_Datas;
    public int item_datas_pivot;

    //characters
    public item_data[] character_Datas;
    public int character_datas_pivot;


    public player_data()
    {
        basic_chaos_fragments = 0;
        basic_chaos_crystal = 0;

        item_datas_pivot = 0;
        character_datas_pivot = 0;
    }

}
