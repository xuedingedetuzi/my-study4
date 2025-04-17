using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Sunmanager : MonoBehaviour
{
    // Start is called before the first frame update
    public static Sunmanager Instance {  get; private set; }
    

    [SerializeField]
    private int sunPoint;
    public int SunPoint
    {
        get { return sunPoint; }
    }

    public TextMeshProUGUI sunPointText;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        UpdateSunPointText();
    }
    public void UpdateSunPointText()
    {
        sunPointText.text = sunPoint.ToString();
    }

    public void SubSun(int point)
    {
        sunPoint-=point;
        UpdateSunPointText();
    }
}
