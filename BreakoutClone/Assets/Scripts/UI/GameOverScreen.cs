using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour 
{
	public Button btnChooseStage;

	void OnEnable()
	{
		btnChooseStage.gameObject.SetActive(GameManager.Instance.CurrentGame.Mode == GameMode.Free);
	}
}
