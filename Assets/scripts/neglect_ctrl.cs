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

        Debug.Log("지나간 초 : " + savedData + " 초");

        // 데이터 설정


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
    /// 매초마다 방치형 기능을 담당하는 코루틴 함수
    /// </summary>
    IEnumerator Neglect()
    {
        while (true)
        {


            yield return new WaitForSeconds(1f);
        }
    }
}
