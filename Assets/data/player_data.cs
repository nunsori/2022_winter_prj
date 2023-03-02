using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stat
{
    // 행성 골드 수급력 (방치형)
    public int planet_force;

    public void SetData()
    {
        int force = 0;

        for (int i = 0; i < data_pool.planetNum; i++)
            if (game_manager.play_data.isConquered_planets[i])
                force += data_pool.planet_Datas[i].gold;
        planet_force = force;
    }
}

public class player_data
{
    // 게임이 종료된 시점
    public string closeDate;

    // 행성 정복 유무

    public bool[] isConquered_planets;

    //gold,gems
    public int basic_chaos_fragments;
    public int basic_chaos_crystal;

    //ingredient
    public item_data[] item_Datas;
    public int item_datas_pivot;

    //characters
    public item_data[] character_Datas;
    public int character_datas_pivot;


    //max slots
    public static int max_slot = 40;


    public player_data()
    {
        isConquered_planets = new bool[data_pool.planetNum];

        basic_chaos_fragments = 1000;
        basic_chaos_crystal = 1000;

        item_Datas = new item_data[max_slot];
        character_Datas = new item_data[max_slot];

        item_datas_pivot = 0;
        character_datas_pivot = 0;

        item_Datas[item_datas_pivot++] = new item_data(1, false);
        item_Datas[item_datas_pivot++] = new item_data(2, false);
        item_Datas[item_datas_pivot++] = new item_data(3, false);
        item_Datas[item_datas_pivot++] = new item_data(4, false);

        item_datas_pivot = 0;
        character_datas_pivot = 0;
    }
}
