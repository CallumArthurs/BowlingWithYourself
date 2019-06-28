using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScores : MonoBehaviour
{
    public Image[] levelImages;

    public Image img_L1;
    public Image img_L2;
    public Image img_L3;

    public Sprite Star0;
    public Sprite Star1;
    public Sprite Star2;
    public Sprite Star3;


    public static int[] Scores = {0,0,0};
    public static int L1Score;
    public static int L2Score;
    public static int L3Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        levelUpdate();
        //Level1();
        //Level2();
        //Level3();
    }

    private void levelUpdate()
    {
        for (int i = 0; i < 3; i++)
        {
            if (Scores[i] == 0)
            {
                levelImages[i].sprite = Star0;
            }
            if (Scores[i] >= 1)
            {
                levelImages[i].sprite = Star1;
            }

            if (Scores[i] >= 6)
            {
                levelImages[i].sprite = Star2;
            }

            if (Scores[i] >= 10)
            {
                levelImages[i].sprite = Star3;
            }
        }
    }

    public void Level1()
    {
        if (L1Score == 0)
        {
            img_L1.sprite = Star0;
        }
        if (L1Score >= 1)
        {
            img_L1.sprite = Star1;
        }

        if (L1Score >= 6)
        {
            img_L1.sprite = Star2;
        }

        if (L1Score >= 10)
        {
            img_L1.sprite = Star3;
        }

    }
    public void Level2()
    {
        if (L2Score == 0)
        {
            img_L2.sprite = Star0;
        }
        if (L2Score >= 1)
        {
            img_L2.sprite = Star1;
        }

        if (L2Score >= 6)
        {
            img_L2.sprite = Star2;
        }

        if (L2Score >= 10)
        {
            img_L2.sprite = Star3;
        }
    }
    public void Level3()
    {
        if (L3Score == 0)
        {
            img_L3.sprite = Star0;
        }
        if (L3Score >= 1)
        {
            img_L3.sprite = Star1;
        }

        if (L3Score >= 6)
        {
            img_L3.sprite = Star2;
        }

        if (L3Score >= 10)
        {
            img_L3.sprite = Star3;
        }
    }
}
