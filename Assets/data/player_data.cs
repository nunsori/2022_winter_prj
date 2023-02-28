using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_stat
{
    // �༺ ��� ���޷� (��ġ��)
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
    // ������ ����� ����
    public string closeDate;

    // �༺ ���� ����

    public bool[] isConquered_planets;

    //gold,gems
    public int basic_chaos_fragments;
    public int basic_chaos_crystal;

    //ingredient


    //characters
    public item_data[] item_Datas;

    public player_data()
    {
        isConquered_planets = new bool[data_pool.planetNum];
    }
}
