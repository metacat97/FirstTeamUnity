using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject gameoverText; // ���� ������ Ȱ��ȭ�� �ؽ�Ʈ ���� ������Ʈ
    public Text timeText; // ���� �ð��� ǥ���� �ؽ�Ʈ ������Ʈ
    public Text recordText; // ���� ��� ǥ��
    public Text killText; // ����� ���� �� ǥ��
    

    private float ScoreCount;
    private float surviveTime; // ���� �ð� = >  ���� Ƚ�� 
    private bool isGameover; //���� ���� ���� 


    // Start is called before the first frame update
    void Start()
    {
        surviveTime = 0;
        isGameover = false;
        ScoreCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isGameover) 
        {
            //���� �ð� ����
            surviveTime += Time.deltaTime;
            // ������ ���� �ð��� timeText �ؽ�Ʈ ������Ʈ�� �̿��� ǥ��
            timeText.text = string.Format("Time: {0}", (int)surviveTime);
            killText.text = string.Format("Score: {0}", (int)surviveTime+(int)ScoreCount);
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("PlayScene");
            }
        }
    }
    //���� ������ ���� ���� ���·� �����ϴ� �޼���
    public void EndGame()
    {
        isGameover = true;
        gameoverText.SetActive(true);

        float bestTime = PlayerPrefs.GetFloat("BestScore");

        if (surviveTime+ScoreCount > bestTime) 
        {
            bestTime = surviveTime + ScoreCount;
            PlayerPrefs.SetFloat("BestScore", bestTime);

        }
        recordText.text = string.Format("Best Score: {0}", (int)bestTime);
    }


    public void SetScore(int killscore)
    {
        ScoreCount += killscore;
    }

    public int GetScore()
    {
        return (int)ScoreCount;
    }


}
