using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class conquer_ctrl : MonoBehaviour
{
    private static conquer_ctrl Instance;
    public static conquer_ctrl instance
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

    [SerializeField] private GameObject content_1st, content_2nd;
    [SerializeField] private Transform content_panel;
    [SerializeField] private Animator animator;
    [SerializeField] private uibox_data selected_planet_uibox;
    private uibox_data[] planet_uis;

    /// <summary> ���� ������(�߾ӿ� ��ġ��) �༺�� Code </summary>
    public int planet_code;

    /// <summary> ������ ������ �����ΰ�? </summary>
    private bool isCanCtrl;

    /// <summary> ���� Slide ���� (-1 = ����, 0 = ������, 1 = ����) </summary>
    public int slide_type;

    /// <summary> ���� Content ���� (-2 = 2�� �г� ����, -1 = 1�� ä�� ����, 1 = 1�� �г� �̵� ��, 2 = 2�� �г� �̵� ��) </summary>
    public int content_type;

    // Temp ����
    uibox_data uibox_Data;
    Sprite sprite;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        planet_uis = content_panel.GetComponentsInChildren<uibox_data>();

        Init();
    }

    private void Update()
    {
        if (!isCanCtrl)
            return;

        if (Input.GetKeyDown(KeyCode.LeftArrow) && planet_code > 0)
            SlidePlanetUI(2);
        else if (Input.GetKeyDown(KeyCode.RightArrow) && planet_code < data_pool.planetNum - 1)
            SlidePlanetUI(1);
    }

    /// <summary>
    /// ���� ���� ������ �� UI�� Default�� �ʱ�ȭ�ϴ� �Լ�
    /// </summary>
    public void Init()
    {
        planet_code = 0;
        slide_type = -1;
        content_type = -1;
        isCanCtrl = true;
        content_1st.SetActive(true);
        content_2nd.SetActive(false);
        animator.SetInteger("slideType", slide_type);
        animator.SetInteger("contentType", content_type);

        SetPlanetUI();
    }

    /// <summary>
    /// �������� �̵��ϴ� ��ư �̺�Ʈ �Լ�
    /// </summary>
    public void OnGotoMain()
    {
        if (!isCanCtrl)
            return;
    }

    /// <summary>
    /// ���� ���õ� �༺ UI ����
    /// </summary>
    private void SetPlanetUI()
    {
        // �༺ ���� UI ����
        int[] planet_codes = { planet_code - 2, planet_code - 1, planet_code, planet_code + 1, planet_code + 2 };

        for (int i = 0; i < planet_uis.Length; i++)
        {
            if (planet_codes[i] >= 0)
            {
                sprite = data_pool.planet_Datas[planet_codes[i]].sprite;

                planet_uis[i].rectTransform.sizeDelta = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y) * sprite.pixelsPerUnit;
                planet_uis[i].images[0].sprite = sprite;
                planet_uis[i].images[0].color = Color.white;
                planet_uis[i].texts[0].text = data_pool.planet_Datas[planet_codes[i]].name;
            }
            else
            {
                planet_uis[i].images[0].sprite = null;
                planet_uis[i].images[0].color = new Color(1f, 1f, 1f, 0f);
                planet_uis[i].texts[0].text = "";
            }
        }
    }

    /// <summary>
    /// Slide Type�� ���� �༺ UI�� Slide �ϴ� �Լ�
    /// </summary>
    /// <param name="_slide_type">1 = ������, 2 = ����</param>
    public void SlidePlanetUI(int _slide_type)
    {
        slide_type = _slide_type;
        animator.SetInteger("slideType", slide_type);
        isCanCtrl = false;
    }

    /// <summary>
    /// Slide �ִϸ��̼��� ���� �� ����Ǵ� �Լ�
    /// </summary>
    public void EndSlide()
    {
        if (slide_type == 1)
            planet_code++;
        else if (slide_type == 2)
            planet_code--;

        slide_type = -1;
        animator.SetInteger("slideType", slide_type);
        isCanCtrl = true;
    }

    public void OnGotoContent_1st()
    {
        if (!isCanCtrl)
            return;

        content_type = 1;
        animator.SetInteger("contentType", content_type);
    }

    /// <summary>
    /// �༺ Ŭ�� �̺�Ʈ �Լ�
    /// </summary>
    public void OnGotoContent_2nd()
    {
        if (!isCanCtrl)
            return;

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            Debug.LogError("OnPlanetSlot is failed : ���õ� ������Ʈ�� ����");
            return;
        }

        uibox_Data = EventSystem.current.currentSelectedGameObject.GetComponent<uibox_data>();
        if (uibox_Data == null)
        {
            Debug.LogError("OnPlanetSlot is failed : ���õ� ������Ʈ�� <uibox_data> ������Ʈ�� ����");
            return;
        }

        content_type = 2;
        animator.SetInteger("contentType", content_type);
    }

    /// <summary>
    /// �г� ���� �ִϸ��̼� �߰��� ȣ��Ǵ� �Լ�
    /// </summary>
    public void SetSwitchContent()
    {
        if (content_type == 2)
        {
            content_1st.SetActive(false);
            content_2nd.SetActive(true);

            sprite = data_pool.planet_Datas[planet_code].sprite;

            selected_planet_uibox.images[0].sprite = sprite;
            selected_planet_uibox.rectTransform.sizeDelta = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y) * sprite.pixelsPerUnit;
            selected_planet_uibox.texts[0].text = data_pool.planet_Datas[planet_code].name;
            selected_planet_uibox.texts[1].text = data_pool.planet_Datas[planet_code].info;
        }
        else if (content_type == 1)
        {
            content_1st.SetActive(true);
            content_2nd.SetActive(false);
        }
    }

    /// <summary>
    /// �г� ���� �ִϸ��̼� �������� ȣ��Ǵ� �Լ�
    /// </summary>
    public void EndSwitchContent()
    {
        if (content_type == 2)
            content_type = -2;
        else if (content_type == 1)
            content_type = -1;
        animator.SetInteger("contentType", content_type);
    }

    public void OnConquerStart()
    {

    }
}
