using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jump : MenuSceneContorller
{
    // Start is called before the first frame update
    
   
    public void MenuButtonClick()//����ģʽ��ת�˵�
    {
        Aduiomanager.Instance.PlayClip(Config.btn_click);
        base.jump("MENU");
    }
   
}
