using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contract_controller : MonoBehaviour
{
    public static contract_controller Instance;

    [Header("percentage_setting")]
    [SerializeField]
    private float[] percentage_table;
    [SerializeField]
    private int amount_per_generate;
    [SerializeField]
    private int generate_count = 0;
    [SerializeField]
    private int percentage_correction;

    private float sample_val = 0f;
    public int[] sample;


    [Header("item_exchange_setting")]
    [SerializeField]
    private GameObject character_data;




    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            //Destroy(this.gameObject);
        }

        sample = new int[amount_per_generate];
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void generate()
    {
        if(game_manager.play_data.character_datas_pivot >= player_data.max_slot - 10 || game_manager.play_data.basic_chaos_crystal <500)
        {
            return;
        }
        //int[] sample = new int[amount_per_generate]; // �̰� ���߿� �������� ���� (new ȣ���� �������� �ʹ� �Ǽ� ���ɸ鿡�� �����ϵ�)

        //string debuging_text = "";

        game_manager.play_data.basic_chaos_crystal -= 500;

        for (int j = 0; j < amount_per_generate; j++)
        {
            sample_val = 0f;
            sample_val = Random.value;
            //Debug.Log(sample_val);
            //Debug.Log(percentage_table.Length);
            for (int i = 0; i < percentage_table.Length; i++)
            {
                if (sample_val <= percentage_table[i] && generate_count < percentage_correction)
                {
                    //got it
                    sample[j] = i;
                    generate_count++;
                    break;
                }
                else if (generate_count >= percentage_correction)
                {
                    //õ��
                    sample[j] = 0;
                    generate_count = 0;
                    break;
                }
                else
                {
                    //generate_count++;
                    continue;
                }
            }

            
            Debug.Log(sample[j]);

            //�ؽ�Ʈ ������Ʈ ������Ʈ
            game_manager.Instance.update_src();
        }

        //contract_adder.Instance.insert_chararcter(amount_per_generate);
        contract_adder.Instance.result_on(amount_per_generate);
        /*
        for(int i2 =0; i2<amount_per_generate; i2++)
        {
            debuging_text += sample[i2].ToString() + " " ;
        }*/

        //Debug.Log(debuging_text);
        //return sample;

        //0�� ���� ��� 1,2,3 ... ���� �� ���� ���� ��͵� ���������� ���
    }


    public void generate_one()
    {
        if (game_manager.play_data.character_datas_pivot >= player_data.max_slot - 1 || game_manager.play_data.basic_chaos_crystal < 50)
        {
            return;
        }

        game_manager.play_data.basic_chaos_crystal -= 50;


        sample_val = 0f;
        sample_val = Random.value;
        //Debug.Log(sample_val);
        //Debug.Log(percentage_table.Length);
        for (int i = 0; i < percentage_table.Length; i++)
        {
            if (sample_val <= percentage_table[i] && generate_count < percentage_correction)
            {
                //got it
                sample[0] = i;
                generate_count++;
                break;
            }
            else if (generate_count >= percentage_correction)
            {
                //õ��
                sample[0] = 0;
                generate_count = 0;
                break;
            }
            else
            {
                //generate_count++;
                continue;
            }
        }

        //contract_adder.Instance.insert_chararcter(1);
        contract_adder.Instance.result_on(1);


        //�ؽ�Ʈ ������Ʈ ������Ʈ
        game_manager.Instance.update_src();

    }
}
