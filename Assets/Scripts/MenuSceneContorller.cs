using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneContorller : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject inputPanelGo;
    public TMP_InputField nameInputField;
    public TextMeshProUGUI nameText;
    private Aduiomanager audio;

    public void jump(string name)
    {
        SceneManager.LoadScene(name);
    }

    private void Start()
    {
        UpdateNameUI();
        audio =Aduiomanager.Instance;
    }
    public void OnChangeNameButtonClick()
    {
        string name = PlayerPrefs.GetString("Name", "");
        nameInputField.text = name;
        inputPanelGo.SetActive(true);
        audio.PlayClip(Config.btn_click);
    }
    public void OnSubmitButtonClick()
    {
        PlayerPrefs.SetString("Name",nameInputField.text);
        inputPanelGo.SetActive(false);
        UpdateNameUI();
        audio.PlayClip(Config.btn_click);
    }
    void UpdateNameUI()
    {
        string name =PlayerPrefs.GetString("Name","-");
        if (nameText != null)
        {
            nameText.text = name;
        }
    }
    public void OnAdventureButtonClick()
    {
        audio.PlayClip(Config.btn_click);
        jump("Adventure Mode");
    }
    public void YiZhiButtonClick()
    {
        audio.PlayClip(Config.btn_click);
        jump("Yizi Mode");
    }
    public void MiNiButtonClick()
    {
        audio.PlayClip(Config.btn_click);
        jump("MiNi Mode");
    }
    
}
