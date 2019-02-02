using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjeKontrol : MonoBehaviour
{
    public GameObject astereoid;
    public Vector3 randomobje;
    public float baslangicsuresi;
    public float uretimaraligi;
    public float dongubekleme;
    public Text text;
    public Text gameovertext;
    public Text replaytext;
    int score;
    bool gameovercontrol = false;
    bool replaycontrol = false;

    void Start()
    {
        score = 0;
        text.text = "SCORE:" + score;
        StartCoroutine(olustur());
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) && replaycontrol)
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicsuresi);
        while (true) //sonsuza kadar
        {
            for (int i = 0; i < 10; i++)
            {

                if (gameovercontrol)
                {
                    replaytext.text = "(Press 'R' to Play Again)";
                    replaycontrol = true;
                    break;
                }
                Vector3 vec = new Vector3(Random.Range(-randomobje.x, randomobje.x), 0.5f, randomobje.z);
                Instantiate(astereoid, vec, Quaternion.identity);
                yield return new WaitForSeconds(uretimaraligi);
            }
            yield return new WaitForSeconds(dongubekleme);
        }

    }
    public void scorearttir(int gelenscore)
    {
        score += gelenscore;  
        text.text = "SCORE:" + score;
    }

    public void gameover()
    {
        gameovertext.text = "GAME OVER";
        gameovercontrol = true;
    }

}
