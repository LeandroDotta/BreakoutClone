using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionScreen : MonoBehaviour 
{
	public RectTransform[] sections;
	public RectTransform sectionRect;
	public Button buttonNext;
	public Button buttonPrevious;
	private int currentSectionIndex = 0;
	private bool isMoving;

	void Start()
	{
		UpdateButtons(true);
	}

	public void MoveNext()
	{
		if(!isMoving)
			StartCoroutine("MoveCoroutine", currentSectionIndex + 1);
	}

	public void MovePrevious()
	{
		if(!isMoving)
			StartCoroutine("MoveCoroutine", currentSectionIndex - 1);
	}

	public IEnumerator MoveCoroutine(int sectionIndex)
	{
		if(IsIndexInRange(sectionIndex))
		{
			isMoving = true;
			UpdateButtons(false);

			RectTransform currentSection = sections[currentSectionIndex];
			RectTransform incomingSection = sections[sectionIndex];

			float space = currentSection.anchoredPosition.x - incomingSection.anchoredPosition.x;

			Vector2 startPosition = sectionRect.anchoredPosition;
			Vector2 endPosition = new Vector2(sectionRect.anchoredPosition.x + space, sectionRect.anchoredPosition.y);

			float duration = 0.5f;
			float counter = 0;

			do
			{
				yield return new WaitForEndOfFrame();

				counter = counter + (Time.deltaTime / duration);

				sectionRect.anchoredPosition = Vector2.Lerp(startPosition, endPosition, counter);
			}while(counter <= 1);
			
			currentSectionIndex = sectionIndex;

			UpdateButtons(true);
			isMoving = false;
		}
	}

	private void UpdateButtons(bool enable)
	{
		buttonNext.interactable = enable;
		buttonPrevious.interactable = enable;

		buttonNext.gameObject.SetActive(IsIndexInRange(currentSectionIndex + 1));
		buttonPrevious.gameObject.SetActive(IsIndexInRange(currentSectionIndex - 1));
	}

	private bool IsIndexInRange(int index)
	{
		return index >= 0 && index < sections.Length;	
	}
}