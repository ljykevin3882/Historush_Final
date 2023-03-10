using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageMenu : MonoBehaviour
{
    public Color black;
    public Color white;
    public Image[] ButtonImages;
    public GameObject[] LockImages;
    
    public GameObject Stage_Menu, Player,Main_Menu;
    public GameObject Stage1, Stage2, Stage3;
    public GameManager gameManager;
    
    public void Start()
    {
        
        
        

    }

    public void Update()
    {
        
    }
    public void StartStageMenu()
    {
        

        //시작할때 DB없어서 듀토리얼만 가능
        
        for (int i = 1; i < 8; i++)
        {
            ButtonImages[i].color = black;
            LockImages[i].SetActive(true);
        }
        gameManager.LoadPlayerDataFromJson(); //DB 불러오기 
        int MaxStageindex = gameManager.playerData.MaxStageLevel;
        if (MaxStageindex > 0)
        { //한번 플레이해서 DB가 만들어졌으면
            for (int i = 1; i < Mathf.CeilToInt((MaxStageindex - 1) / 4) + 2; i++)
            {
                ButtonImages[i].color = white;

                LockImages[i].SetActive(false);
            }
            for (int i = Mathf.CeilToInt((MaxStageindex - 1) / 4) + 2; i < 8; i++)
            {
                ButtonImages[i].color = black;
                LockImages[i].SetActive(true);
            }
        }
    }

    // 단군신화 버튼
    public void ClickDangun()
    {
        print("단군신화 버튼 누름");
        Stage_Menu.SetActive(false);
        Stage1.SetActive(true);
        Player.SetActive(true);
        gameManager.LoadPlayerDataFromJson();
        gameManager.ItemSet();
        gameManager.stageIndex = 0;
        gameManager.StageName(gameManager.stageIndex);
    }

    // 고조선 버튼
    public void ClickGojoseon()
    {
        print("고조선 버튼 누름");
        Stage_Menu.SetActive(false);
        Stage2.SetActive(true);
        Player.SetActive(true);
        gameManager.LoadPlayerDataFromJson();
        gameManager.ItemSet();
        gameManager.stageIndex = 1;
        gameManager.StageName(gameManager.stageIndex);
    }

    // 삼국시대 버튼
    public void ClickThreeState()
    {
        print("삼국시대 버튼 누름");
        Stage_Menu.SetActive(false);
        Stage3.SetActive(true);
        Player.SetActive(true);
        gameManager.LoadPlayerDataFromJson();
        gameManager.ItemSet();
        gameManager.stageIndex = 5;
        gameManager.StageName(gameManager.stageIndex);
    }

    // 통일신라 버튼
    public void ClickUnifiedSilla()
    {
        print("통일신라 버튼 누름");
    }

    // 고려 버튼
    public void ClickKoryo()
    {
        print("고려 버튼 누름");
    }

    // 조선 버튼
    public void ClickJoseon()
    {
        print("조선 버튼 누름");
    }

    // 일제강점기 버튼
    public void ClickJapanOccupation()
    {
        print("일제강점기 버튼 누름");
    }

    // 현대사 버튼
    public void ClickMordernHistory()
    {
        print("고조선 버튼 누름");
    }
    //뒤로가기 버튼
    public void GoBack()
    {
        Stage_Menu.SetActive(false);
        Main_Menu.SetActive(true);
        print("뒤로가기 누름");
    }
}
