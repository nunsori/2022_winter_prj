using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class data_pool : MonoBehaviour
{
    private static data_pool Instance;
    public static data_pool instance
    {
        set
        {
            if (Instance == null)
            {
                Instance = value;
            }
        }
        get
        {
            return Instance;
        }
    }

    public static short planetNum = 13;

    public static List<planet_data> planet_Datas = new List<planet_data>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);

            for (int i = 0; i < planetNum; i++)
                planet_Datas.Add(new planet_data(i));
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
