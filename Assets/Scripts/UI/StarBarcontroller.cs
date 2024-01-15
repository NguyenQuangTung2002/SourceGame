using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using UnityEngine;

public class StarBarcontroller : MonoBehaviour
{
    [Header("Player 1 Star")]
    public GameObject m_Player1Star1;
    public GameObject m_Player1Star2;
    public GameObject m_Player1Star3;

    public GameObject m_Player1Star1_TrueStar;
    public GameObject m_Player1Star2_TrueStar;
    public GameObject m_Player1Star3_TrueStar;
    
    
    [Header("Player 2 Star")]
    public GameObject m_Player2Star1;
    public GameObject m_Player2Star2;
    public GameObject m_Player2Star3;
    
    public GameObject m_Player2Star1_TrueStar;
    public GameObject m_Player2Star2_TrueStar;
    public GameObject m_Player2Star3_TrueStar;
    
    [Header("Controller")] 
    public GameManager m_GameManager;
    
    
    public GameObject[] m_listStarPlayer1;
    public GameObject[] m_listStarPlayer2;
    // Start is called before the first frame update
    void Start()
    {
        CreateStar();
    }

    void CreateStar()
    {
        m_listStarPlayer1 = new GameObject[m_GameManager.m_NumRoundsToWin];
        m_listStarPlayer2 = new GameObject[m_GameManager.m_NumRoundsToWin];
        
        switch(m_GameManager.m_NumRoundsToWin)
        {
            case 1:
                m_Player1Star2.SetActive(false);
                m_Player1Star3.SetActive(false);
                m_Player2Star2.SetActive(false);
                m_Player2Star3.SetActive(false);
                m_listStarPlayer1[0] = m_Player1Star1_TrueStar;
                m_listStarPlayer2[0] = m_Player2Star1_TrueStar;
                break;
            case 2:
                m_Player1Star3.SetActive(false);
                m_Player2Star3.SetActive(false);
                m_listStarPlayer1[0] = m_Player1Star1_TrueStar;
                m_listStarPlayer1[1] = m_Player1Star2_TrueStar;
                m_listStarPlayer2[0] = m_Player2Star1_TrueStar;
                m_listStarPlayer2[1] = m_Player2Star2_TrueStar;
                break;
            default:
                m_listStarPlayer1[0] = m_Player1Star1_TrueStar;
                m_listStarPlayer1[1] = m_Player1Star2_TrueStar;
                m_listStarPlayer1[2] = m_Player1Star3_TrueStar;
                m_listStarPlayer2[0] = m_Player2Star1_TrueStar;
                m_listStarPlayer2[1] = m_Player2Star2_TrueStar;
                m_listStarPlayer2[2] = m_Player2Star3_TrueStar;
                break;
        }

        foreach (var star in m_listStarPlayer1)
        {
            star.SetActive(false);
        }
        foreach (var star in m_listStarPlayer2)
        {
            star.SetActive(false);
        }
    }

    public void UpdateStar()
    {
        foreach (var star in m_listStarPlayer1)
        {
            star.SetActive(false);
        }
        foreach (var star in m_listStarPlayer2)
        {
            star.SetActive(false);
        }
        
        foreach (var tank in m_GameManager.m_Tanks)
        {
            if (tank.m_PlayerNumber == 1)
            {
                for (int i = 0; i < tank.m_Wins; i++)
                {
                    m_listStarPlayer1[i].SetActive(true);
                }
            }
            else
            {
                for (int i = 0; i < tank.m_Wins; i++)
                {
                    m_listStarPlayer2[i].SetActive(true);
                }
            }
        }
    }

}
