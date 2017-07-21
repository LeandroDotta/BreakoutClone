using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
    private InputField fieldName;

	public Text[] LeaderBoardNames;
	public Text[] LeaderBoardScores;
    
	void Start () {
        fieldName = transform.Find("FieldName").GetComponent<InputField>();
        fieldName.text = GetComponent<UIEvents>().PlayersName;

		GameManager.Instance.LoadLeaderBoard();

		for(int i = 0; i < 10; i++)
		{
			if(GameManager.Instance.LeaderBoard.Count > i)
			{
				LeaderBoardNames[i].text = string.Format("{0}. {1}", i+1, GameManager.Instance.LeaderBoard[i].Name);
				LeaderBoardScores[i].text = GameManager.Instance.LeaderBoard[i].Score.ToString();
			}
			else
			{
				LeaderBoardNames[i].text = "";
				LeaderBoardScores[i].text = "";
			}
		}
	}
}
