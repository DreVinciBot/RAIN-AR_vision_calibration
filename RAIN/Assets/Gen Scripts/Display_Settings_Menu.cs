using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Display_Settings_Menu : MonoBehaviour
{
    public RectTransform sideMenu;
    private bool isClicked = false;
    public int display_value = -131;
    public int target_value = -131;
    public int left_position = 0;

    public void ButtonToggle()
    {
        if (isClicked)
        {
            isClicked = false;
            Side_menu_btn();
            //swap texture to OFF
        }
        else
        {
            isClicked = true;
            Close_Side_menu_btn();
            //swap texture to ON
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //sideMenu.DOAnchorPos(Vector2.zero, 0.25f);
    }

    public void Side_menu_btn()
    {
        sideMenu.DOAnchorPos(new Vector2(left_position, display_value + target_value), 0.25f);
    }

    public void Close_Side_menu_btn()
    {
        sideMenu.DOAnchorPos(new Vector2(left_position, display_value), 0.25f);
    }

}
