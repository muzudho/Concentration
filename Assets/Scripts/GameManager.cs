using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private List<string> playingCardNames = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        // カードの名前
        for(int i=1; i<14; i++)
        {
            playingCardNames.Add($"Hearts {i}");
            playingCardNames.Add($"Diamonds {i}");
            playingCardNames.Add($"Clubs {i}");
            playingCardNames.Add($"Spades {i}");
        }
        playingCardNames.Add($"Joker Black");
        playingCardNames.Add($"Joker Red");

        // リセット
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        // カードを２枚選び、位置を交換する
        Debug.Log("リセット");

        CloseAllCards();
        ShuffleCards();
    }

    /// <summary>
    /// シャッフル
    /// </summary>
    private void ShuffleCards()
    {
        for (int i = 0; i < 10000; i++)
        {
            string name1 = playingCardNames[Random.Range(0, playingCardNames.Count)];
            string name2 = playingCardNames[Random.Range(0, playingCardNames.Count)];

            // この Find 処理は重いから改善の余地あり
            GameObject go1 = GameObject.Find(name1);
            GameObject go2 = GameObject.Find(name2);

            Vector3 pos1 = go1.transform.position;
            Vector3 pos2 = go2.transform.position;

            go1.transform.position = pos2;
            go2.transform.position = pos1;
        }
    }

    private void CloseAllCards()
    {
        foreach (string name in playingCardNames)
        {
            // この Find 処理は重いから改善の余地あり
            GameObject go = GameObject.Find(name);

            go.transform.rotation = Quaternion.Euler(0, 0, 180); // z=180 （度数法）で、裏返し状態
        }
    }
}
