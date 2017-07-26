using UnityEngine;
using UnityEngine.UI;

public class VictoryScreen : MonoBehaviour {
	public Button btnRestart;
	public Button btnChooseStage;

	void OnEnable()
	{
		switch(GameManager.Instance.CurrentGame.Mode)
		{
			case GameMode.Campaign:
				if(GameManager.Instance.CurrentGame.LifeCount <= 1)
					btnRestart.interactable = false;

				btnChooseStage.gameObject.SetActive(false);
				break;

			case GameMode.Hardcore:
				btnRestart.gameObject.SetActive(false);
				btnChooseStage.gameObject.SetActive(false);
				break;

			case GameMode.Free:
				btnRestart.gameObject.SetActive(true);
				btnRestart.interactable = true;

				btnChooseStage.gameObject.SetActive(true);
				break;
		}
	}
}
