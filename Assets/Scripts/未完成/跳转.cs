using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 跳转 : MonoBehaviour
{
    // Start is called before the first frame update
    public void YiZicaiDanButtonClick()
    {
        Aduiomanager.Instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-2);
    }
    public void MiNicaiDanButtonClick()
    {
        Aduiomanager.Instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 3);
    }
    public void MaoXiancaiDanButtonClick()
    {
        Aduiomanager.Instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
