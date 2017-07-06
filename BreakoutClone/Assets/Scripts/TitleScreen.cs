using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleScreen : MonoBehaviour {
    private InputField fieldName;
    
	// Use this for initialization
	void Start () {
        fieldName = transform.Find("FieldName").GetComponent<InputField>();

        fieldName.text = GameManager.Instance.PlayersName;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
