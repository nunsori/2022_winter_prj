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

    /// <summary> 현재 선택한(중앙에 위치한) 행성의 Code </summary>
    public int planet_code;

    /// <summary> 조작이 가능한 상태인가? </summary>
    private bool isCanCtrl;

    /// <summary> 현재 Slide 상태 (-1 = 종료, 0 = 오른쪽, 1 = 왼쪽) </summary>
    public int slide_type;

    /// <summary> 현재 Content 상태 (-2 = 2번 패널 종료, -1 = 1번 채널 종료, 1 = 1번 패널 이동 중, 2 = 2번 패널 이동 중) </summary>
    public int content_type;

    // Temp 변수
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
    /// 정복 관련 데이터 및 UI를 Default로 초기화하는 함수
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
    /// 메인으로 이동하는 버튼 이벤트 함수
    /// </summary>
    public void OnGotoMain()
    {
        if (!isCanCtrl)
            return;
    }

    /// <summary>
    /// 현재 선택된 행성 UI 설정
    /// </summary>
    private void SetPlanetUI()
    {
        // 행성 슬롯 UI 설정
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
    /// Slide Type에 따라 행성 UI를 Slide 하는 함수
    /// </summary>
    /// <param name="_slide_type">1 = 오른쪽, 2 = 왼쪽</param>
    public void SlidePlanetUI(int _slide_type)
    {
        slide_type = _slide_type;
        animator.SetInteger("slideType", slide_type);
        isCanCtrl = false;
    }

    /// <summary>
    /// Slide 애니메이션이 끝날 때 수행되는 함수
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
    /// 행성 클릭 이벤트 함수
    /// </summary>
    public void OnGotoContent_2nd()
    {
        if (!isCanCtrl)
            return;

        if (EventSystem.current.currentSelectedGameObject == null)
        {
            Debug.LogError("OnPlanetSlot is failed : 선택된 오브젝트가 없음");
            return;
        }

        uibox_Data = EventSystem.current.currentSelectedGameObject.GetComponent<uibox_data>();
        if (uibox_Data == null)
        {
            Debug.LogError("OnPlanetSlot is failed : 선택된 오브젝트에 <uibox_data> 컴포넌트가 없음");
            return;
        }

        content_type = 2;
        animator.SetInteger("contentType", content_type);
    }

    /// <summary>
    /// 패널 변경 애니메이션 중간에 호출되는 함수
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
    /// 패널 변경 애니메이션 마지막에 호출되는 함수
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
