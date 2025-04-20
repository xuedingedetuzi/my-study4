using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager Instance {  get; private set; }

    public PrePareUI prepareUI;
    public CardListUI cardListUI;
    public FallUI fallUI;
    public winUI winui;

    private Aduiomanager audio;

    private bool isGameEnd=false;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        GameStart();
        audio=Aduiomanager.Instance;
    }

    void GameStart()
    {   
        Vector3 currentPosition=Camera.main.transform.position;
        Camera.main.transform.DOPath(
            new Vector3[] {currentPosition,new Vector3(3.5f,0,-10),currentPosition},
            3,PathType.Linear).OnComplete(ShowReadyUI);
    }
    public void GameEndFall()
    {
        if (isGameEnd == true) return;
        isGameEnd=true;
        fallUI.Show();
        ZombieManager.Instance.Pause();
        cardListUI.DisableCardList();
        Sunmanager.Instance.StopProduce();
        audio.PlayClip(Config.lose_music);
    }

    public void GameEndSuccess()
    {
        if (isGameEnd == true) return;
        isGameEnd = true;
        winui.Show();
        cardListUI.DisableCardList();
        Sunmanager.Instance.StopProduce();
        audio.PlayClip(Config.win_music);
    }
    void ShowReadyUI()
    {
        prepareUI.Show(OnPrepreUIComplete);
    }
    void OnPrepreUIComplete()
    {
        Sunmanager.Instance.StartProduce();
        ZombieManager.Instance.StartSpawn();
        cardListUI.ShowCardList();
        audio.PlayBgm(Config.bgm1);
    }
}
