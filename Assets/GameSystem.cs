using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using TMPro;
public class GameSystem : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject scoreText;
    GameObject[] objects = new GameObject[4];
    [SerializeField] float lives = 2; // currently unimplemented
    int score = 0;



    


    void Start()
    {
        scoreText = GameObject.Find("Score");
        for(int i = 0; i < 4; i++)
        {
            objects[i] = GameObject.Find("Option_" + (i + 1));
            Button b = objects[i].GetComponent<Button>();
            b.tag = "Wrong"; // all default wrong
            b.onClick.AddListener(()=>TaskOnClick(b));
        }
        selectRandomObject(objects);
    }
    void TaskOnClick(Button b)
    {
        if(b.tag.Equals("Correct"))
        {
            Debug.Log("Correct");
            selectRandomObject(objects);
            score += 1;
        }
        else
        {
            lives--;
            Destroy(GameObject.Find("Extra Life"));
        }
    }


    void selectRandomObject(GameObject[] objects)
    {
        int r = Random.Range(0, 4);
        
        for(int i = 0; i < 4; i++)
        {
            TMP_Text s = objects[i].GetComponentInChildren<TMP_Text>();
            if (i == r)
            {
                objects[i].GetComponent<Button>().tag = "Correct";
                s.text = "Randomly selected correct answer";
                s.color = new Color32(0, 255, 0, 255);
                objects[i].tag = "Correct";
            }
            else
            {
                s.text = "Randomly selected wrong answer";
                s.color = new Color32(255, 0, 0, 255);
                objects[i].tag = "Wrong";
            }
            s.fontSize = 12;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(lives <= 0)
        {
            Debug.Log("Done");
            Application.Quit();
        }
        scoreText.GetComponent<TMP_Text>().text = "Score: " + score;


    }
}
