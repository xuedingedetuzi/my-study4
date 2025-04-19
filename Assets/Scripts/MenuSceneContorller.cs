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

    private void Start()
    {
        UpdateNameUI();
    }
    public void OnChangeNameButtonClick()
    {
        string name = PlayerPrefs.GetString("Name", "");
        nameInputField.text = name;
        inputPanelGo.SetActive(true);
        Aduiomanager.Instance.PlayClip(Config.btn_click);
    }
    public void OnSubmitButtonClick()
    {
        PlayerPrefs.SetString("Name",nameInputField.text);
        inputPanelGo.SetActive(false);
        UpdateNameUI();
        Aduiomanager.Instance.PlayClip(Config.btn_click);
    }
    void UpdateNameUI()
    {
        string name =PlayerPrefs.GetString("Name","-");
        nameText.text = name;
    }
    public void OnAdventureButtonClick()
    {
        Aduiomanager.Instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }
    public void YiZhiButtonClick()
    {
        Aduiomanager.Instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
    public void MiNiButtonClick()
    {
        Aduiomanager.Instance.PlayClip(Config.btn_click);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }
    
}
