using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum CardState
{
    Disable,Cooling,WaitingSun,Ready
}

public enum PlantType
{
    Sunflower,Peashooter,Wallnut
}
public class Card : MonoBehaviour
{
    // Start is called before the first frame update
    private CardState cardState = CardState.Disable;
    public PlantType plantType = PlantType.Sunflower;

    public GameObject cardLight;
    public GameObject cardGray;
    public Image cardMask;

    [SerializeField]
    private float cdTime = 2;
    private float cdTimer = 0;

    [SerializeField]
    private int needSunPoint=50;



    private void Update()
    {
        switch (cardState)
        {
            case CardState.Cooling:
                CoolingUpdate();
                break;
            case CardState.WaitingSun:
                WaitingSunUpdate();
                break;
            case CardState.Ready:
                ReadyUpdate();
                break;
        }
    }
        void CoolingUpdate()
        {
            cdTimer += Time.deltaTime;

            cardMask.fillAmount = (cdTime-cdTimer)/cdTime;

            if (cdTimer >= cdTime)
            {
                TransitionToWaitingSun();
            }

        }

        void WaitingSunUpdate()
        {
            if (needSunPoint <= Sunmanager.Instance.SunPoint) 
            {
                TransitionToReady();
            }
            
            
        }

        void ReadyUpdate()
        {
            if (needSunPoint > Sunmanager.Instance.SunPoint) 
            {
                TransitionToWaitingSun();
            }
        }

        void TransitionToWaitingSun()
        {
            cardState = CardState.WaitingSun;

            cardLight.SetActive(false);
            cardGray.SetActive(true);
            cardMask.gameObject.SetActive(false);
        }

        void TransitionToReady()
        {
            cardState = CardState.Ready;

            cardLight.SetActive(true);
            cardGray.SetActive(false);
            cardMask.gameObject.SetActive(false);
        }
        void TransitionToCooling()
        {
        cardState = CardState.Cooling;
        cdTimer = 0;

        cardLight.SetActive(false);
        cardGray.SetActive(true);
        cardMask.gameObject.SetActive(true);
        }
    public void OnClick()
    {   
        Aduiomanager.Instance.PlayClip(Config.btn_click);   
        if(cardState==CardState.Disable)return;
        if(needSunPoint > Sunmanager.Instance.SunPoint)return;

        bool isSuccess= Handmanager.Instance.AddPlant(plantType);
        if (isSuccess)
        {
            Sunmanager.Instance.SubSun(needSunPoint);

            TransitionToCooling();
        }
    }

    public void DisableCard()
    {
        cardState=CardState.Disable;
    }
    public void EnableCard()
    {
        TransitionToCooling();
    }
    
}
