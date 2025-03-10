using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;


public class data_
{

    /**
     *  다른 스크립트, 함수에서 요 밑에 변수들 가져오는 법
     * 
     *  ex) temp 변수 가져오는 법 
     *      save_load_Data.play_data.temp
     *      을 이용해서 temp 변수에 접근가능
     * 
     */
    public int temp = 0;

    //생성자 함수
    public data_()
    {

    }



}


public class save_load_Data : MonoBehaviour
{

    public static save_load_Data Instance;

    [Header("data_path_name")]
    [SerializeField]
    private string data_file_name = "";
    //[SerializeField]
    //private string json_file_name = "";

    private string data_path;

    private string data_string_temp;

    public static data_ play_data;


    private void Awake()
    {
        //데이터 파일 저장 경로 설정
        //data_file_name = "/" + data_file_name + "/" ;
        data_file_name = data_file_name + ".json";
        data_path = Application.persistentDataPath + "/data/";

        //플레이 데이터 설정
        play_data = new data_();

        //singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }


        load();


    }


    //저장 함수
    public void save()
    {
        data_string_temp = JsonUtility.ToJson(play_data, true);
        //Debug.Log(data_string_temp);
        
        File.WriteAllText(data_path + data_file_name, data_string_temp);
    }

    //로드 함수
    public void load()
    {
        //if file does not exist
        if (!File.Exists(data_path))
        {
            //make file
            //File.Create(data_path);
            Directory.CreateDirectory(data_path);
            Debug.Log("data file created");
        }


        //data file does not exist
        if (!File.Exists(data_path + data_file_name))
        {
            //make data file

            FileStream temp = File.Create(data_path + data_file_name);

            Debug.Log("data_json created");

            play_data = new data_();

            temp.Close();

            save();
        }
        else //else data file exist
        {

            data_string_temp = File.ReadAllText(data_path + data_file_name);
            play_data = JsonUtility.FromJson<data_>(data_string_temp);
        }
    }


    //게임종료시 자동으로 저장하기
    private void OnApplicationQuit()
    {

        save();
    }


}



