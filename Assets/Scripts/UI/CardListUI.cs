using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CardListUI : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Card> cardList;

    private void Start()
    {
        DisableCardList();
        
    }

    public void ShowCardList()
    {
        GetComponent<RectTransform>().DOAnchorPosY(-215,1);
        EnableCardList();
    }

    public void DisableCardList()
    {
        foreach (Card card in cardList) 
        { 
            card.DisableCard(); 
        }
    }
    void EnableCardList()
    {
        foreach (Card card in cardList)
        {
            card.EnableCard();
        }
    }
}
