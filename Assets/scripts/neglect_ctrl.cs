using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class neglect_ctrl : MonoBehaviour
{
    public void Calculate_PastTime()
    {
        string closedTime = game_manager.play_data.closeDate;
        string opendTime = DateTime.UtcNow.ToString();
        DateTime currentDateTime = DateTime.Parse(opendTime);
        DateTime closedDateTime = DateTime.Parse(closedTime);
        TimeSpan timeSpan = currentDateTime - closedDateTime;
        int savedData = (int)timeSpan.TotalSeconds;

        Debug.Log("������ �� : " + savedData + " �� | ȹ���� ��� : " + game_manager.play_stat.planet_force * savedData);

        // ������ ����
        game_manager.play_data.basic_chaos_fragments += game_manager.play_stat.planet_force * savedData;
        game_manager.Instance.SetMainUI();
        game_manager.Instance.save();
    }

    public void Start_Neglect()
    {
        StartCoroutine("Neglect");
    }

    public void Stop_Neglect()
    {
        StopCoroutine("Neglect");
    }

    /// <summary>
    /// ���ʸ��� ��ġ�� ����� ����ϴ� �ڷ�ƾ �Լ�
    /// </summary>
    IEnumerator Neglect()
    {
        while (true)
        {
            game_manager.play_data.basic_chaos_fragments += game_manager.play_stat.planet_force;
            game_manager.Instance.SetMainUI();
            yield return new WaitForSeconds(1f);
        }
    }
}
