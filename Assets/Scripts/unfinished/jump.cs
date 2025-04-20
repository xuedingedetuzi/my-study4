using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jump : MenuSceneContorller
{
    // Start is called before the first frame update
    
   
    public void MenuButtonClick()//三个模式跳转菜单
    {
        Aduiomanager.Instance.PlayClip(Config.btn_click);
        base.jump("MENU");
    }
   
}
