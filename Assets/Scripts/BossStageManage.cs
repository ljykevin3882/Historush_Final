using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossStageManage : MonoBehaviour
{
    // TODO
    // 1. 화면의 하단에 캐릭터가 위치하게끔 조정
    // 2. 스테이지 3 클리어시 보스 스테이지로 넘어가게
    // 3. 보스 스테이지 클리어시 스테이지 선택 화면으로 넘어가게
    float timer; 
    int sec;
    public GameObject player;
    public GameObject _boss;
    public GameObject answerOne, answerOneBackground, answerTwo, answerTwoBackground;
    public GameObject mainCamera;
    public GameObject question, questionBackground, questionTimer;
    public GameObject finishFlag;
    public Transform finishFlagSpawnPos;
    private GameObject boss;

    static public bool answer;
    private bool isChecked = false;
    static public string mode = "Boss";
    static private bool isBossGen = false;

    void Start()
    {
        mainCamera.GetComponent<Camera>().orthographicSize = 12.0f; // 원래 값 6.12
    }

    void Update()
    {
        if (mode == "Quiz") timer -= Time.deltaTime;
        else timer = 10.0f; // 문제 5초 보여주고 5초 동안 답 고르기
        Process();
        AnswerSpotlight();
    }

    private void Process() {
        switch(mode){
            case "Boss":
                ProcessBoss();
                break;
            case "Quiz":
                ProcessQuiz();
                break;
            case "Clear":
                ProcessClear();
                break;
        }
    }
    private void ProcessBoss() {
        if (isBossGen == false) {
            boss = Instantiate(_boss, transform.position, transform.rotation);
        }
        isBossGen = true;
        answerOne.SetActive(false);
        answerTwo.SetActive(false);
        answerOneBackground.SetActive(false);
        answerTwoBackground.SetActive(false);
        question.SetActive(false);
        questionTimer.SetActive(false);
        questionBackground.SetActive(false);
    }

    private void ProcessQuiz() {
        answerOne.SetActive(true);
        answerTwo.SetActive(true);
        answerOneBackground.SetActive(true);
        answerTwoBackground.SetActive(true);
        question.SetActive(true);
        questionTimer.SetActive(true);
        questionBackground.SetActive(true);
        isBossGen = false;
        Destroy(boss);

        // 문제 설정
        if (timer > 0 && timer < 10) {
            switch(Boss.patternIndex) {
                case 0:
                    question.GetComponent<TMP_Text>().text = "Q1. 몽고의 침입을 막기 위한 염원으로 만든 이것은 무엇인가?";
                    answerOne.GetComponent<TMP_Text>().text = "팔만대장경";
                    answerTwo.GetComponent<TMP_Text>().text = "동의보감";
                    break;
                case 1:
                    question.GetComponent<TMP_Text>().text = "Q2. 대한민국의 수도는?";
                    answerOne.GetComponent<TMP_Text>().text = "서울";
                    answerTwo.GetComponent<TMP_Text>().text = "화전";
                    break;
                case 2:
                    question.GetComponent<TMP_Text>().text = "Q3. 치킨 VS 피자?";
                    answerOne.GetComponent<TMP_Text>().text = "치킨";
                    answerTwo.GetComponent<TMP_Text>().text = "피자";
                    break;
                case 3:
                    question.GetComponent<TMP_Text>().text = "Q4. 1+1 = 2?";
                    answerOne.GetComponent<TMP_Text>().text = "O";
                    answerTwo.GetComponent<TMP_Text>().text = "X";
                    break;
            }
        }
        // 타이머 설정
        if (timer < 0) questionTimer.GetComponent<TMP_Text>().text = 0.ToString();
        else if (timer < 5) questionTimer.GetComponent<TMP_Text>().text = ((int)timer).ToString();
        else questionTimer.SetActive(false);

        // 정답 체크
        if (timer < 0 && isChecked == false) {
            CheckAnswer();
            isChecked = true;
        }

        // 보스로 전환
        if (timer < -5.0f)  {
            mode = "Boss";
            isChecked = false;
        }
    }
    private void ProcessClear() {
        Instantiate(finishFlag, finishFlagSpawnPos.position, finishFlagSpawnPos.rotation);
    }
    private void CheckAnswer() {
        switch(Boss.patternIndex) {
            case 0:
                if (answer == true) question.GetComponent<TMP_Text>().text = "정답입니다 !!";
                else {
                    question.GetComponent<TMP_Text>().text = "오답입니다...";
                    Boss.isWrong = true;
                }
                break;
            case 1:
                if (answer == true) question.GetComponent<TMP_Text>().text = "정답입니다 !!";
                else {
                    question.GetComponent<TMP_Text>().text = "오답입니다...";
                    Boss.isWrong = true;
                }
                break;
            case 2:
                if (answer == true) question.GetComponent<TMP_Text>().text = "정답입니다 !!";
                else {
                    question.GetComponent<TMP_Text>().text = "오답입니다...";
                    Boss.isWrong = true;
                }
                break;
            case 3:
                if (answer == true)  {
                    question.GetComponent<TMP_Text>().text = "정답입니다 !!";
                    mode = "Clear";
                }
                else {
                    question.GetComponent<TMP_Text>().text = "오답입니다...";
                    Boss.isWrong = true;
                }
                break;
        }
    }
    private void AnswerSpotlight() {
        if (answer == true) {
            answerOne.GetComponent<TMP_Text>().outlineColor = Color.black;
            answerOne.GetComponent<TMP_Text>().outlineWidth = 0.2f;
            answerTwo.GetComponent<TMP_Text>().outlineWidth = 0;

        }
        else if (answer == false) {
            answerTwo.GetComponent<TMP_Text>().outlineColor = Color.black;
            answerTwo.GetComponent<TMP_Text>().outlineWidth = 0.2f;
            answerOne.GetComponent<TMP_Text>().outlineWidth = 0;
        }
    }
}
