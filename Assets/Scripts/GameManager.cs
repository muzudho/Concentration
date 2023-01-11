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
        // �J�[�h�̖��O
        for(int i=1; i<14; i++)
        {
            playingCardNames.Add($"Hearts {i}");
            playingCardNames.Add($"Diamonds {i}");
            playingCardNames.Add($"Clubs {i}");
            playingCardNames.Add($"Spades {i}");
        }
        playingCardNames.Add($"Joker Black");
        playingCardNames.Add($"Joker Red");

        // ���Z�b�g
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Reset()
    {
        // �J�[�h���Q���I�сA�ʒu����������
        Debug.Log("���Z�b�g");

        CloseAllCards();
        ShuffleCards();
    }

    /// <summary>
    /// �V���b�t��
    /// </summary>
    private void ShuffleCards()
    {
        for (int i = 0; i < 10000; i++)
        {
            string name1 = playingCardNames[Random.Range(0, playingCardNames.Count)];
            string name2 = playingCardNames[Random.Range(0, playingCardNames.Count)];

            // ���� Find �����͏d��������P�̗]�n����
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
            // ���� Find �����͏d��������P�̗]�n����
            GameObject go = GameObject.Find(name);

            go.transform.rotation = Quaternion.Euler(0, 0, 180); // z=180 �i�x���@�j�ŁA���Ԃ����
        }
    }
}
