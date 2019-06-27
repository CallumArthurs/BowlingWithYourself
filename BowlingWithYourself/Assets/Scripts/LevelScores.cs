using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScores : MonoBehaviour
{
    public Image img_L1;
    public Image img_L2;
    public Image img_L3;

    public Sprite Star0;
    public Sprite Star1;
    public Sprite Star2;
    public Sprite Star3;

    public int L1Score;
    public int L2Score;
    public int L3Score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Level1();
        Level2();
        Level3();
    }

    public void Level1()
    {
        if (L1Score == 0)
        {
            img_L1.sprite = Star0;
        }
        if (L1Score <= 5)
        {
            img_L1.sprite = Star1;
        }

        if (L1Score >= 9)
        {
            img_L1.sprite = Star2;
        }

        if (L1Score == 10)
        {
            img_L1.sprite = Star3;
        }

    }
    public void Level2()
    {

    }
    public void Level3()
    {

    }
}
