using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet_data
{
    public static Sprite[] sprites;
    public static string[] names = { "�׶�", "����", "�����", "����Ʈ", "�����Ǵ�", "��ٳ�", "���", "Ŭ��ġ", "����", "Ÿ��ź", "ũ�ζ�Ͼ�", "���Ҷ�", "�����ÿ�" };
    public static int[] powers = { 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000, 1100, 1200, 1300 };

    public Sprite sprite;
    public string name;
    public int power;
    public int code;

    public planet_data(int _code)
    {
        if (sprites == null)
            sprites = Resources.LoadAll<Sprite>("Image/Sprite/Planet");

        code = _code;
        sprite = sprites[code];
        name = names[code];
        power = powers[code];
    }
}
