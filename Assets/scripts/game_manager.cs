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

    //to json 함수에 넣을 데이터 이 데이터가 json으로 된다.
    public static player_data play_data;


    //data string temp 데이터 저장 전, to json으로 나오는거 받는 용도
    private string data_string_temp;

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
        data_path = Application.persistentDataPath + "/data";
        data_file_name = "player_data.json";


        //data loading
        load_data();

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

    public void save()
    {
        data_string_temp = JsonUtility.ToJson(play_data);
        File.WriteAllText(data_path + '/' + data_file_name, data_string_temp);
    }


    void load_data()
    {
        //if file does not exist
        if (!File.Exists(data_path))
        {
            //make file
            File.Create(data_path);
        }


        //data file does not exist
        if (!File.Exists(data_path + '/' + data_file_name))
        {
            //make data file
            File.Create(data_path + '/' + data_file_name);
        }
        else //else data file exist
        {
            
            data_string_temp = File.ReadAllText(data_path + '/' + data_file_name);
            play_data = JsonUtility.FromJson<player_data>(data_string_temp);
        }




        //삭제 예정 코드
        /*
        if(File.ReadAllText(data_path + data_file_name) == null)
        {
            //file does not exist
            //create new file

        }
        else
        {
            //data exist
            //get data text

        }*/
    }
}
