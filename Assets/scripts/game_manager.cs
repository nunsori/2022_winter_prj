using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class game_manager : MonoBehaviour
{
    public static game_manager Instance;

    [Header("data_file")]
    //data_set
    private string data_path;
    [SerializeField]
    private string data_file_name;

    public static player_data play_data; 

    private void Awake()
    {
        //singleton
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        //set data_path
        data_path = Application.dataPath + "/data";
        data_file_name = "player_data.json";
        

        //data loading


        //call json

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void load_data()
    {
        if(File.ReadAllText(data_path + data_file_name) == null)
        {
            //file does not exist
            //create new file

        }
        else
        {
            //data exist
            //get data text

        }
    }
}
