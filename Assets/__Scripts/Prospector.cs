using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class Prospector : MonoBehaviour {

	static public Prospector 	S;

	[Header("Set in Inspector")]
	public TextAsset			deckXML;
	public TextAsset layoutXML;


	[Header("Set Dynamically")]
	public Deck					deck;
	public Layout layout;
	public List<CardProspector> drawPile;

	void Awake(){
		S = this;
	}

	void Start() {
		deck = GetComponent<Deck> ();
		deck.InitDeck (deckXML.text);
		

		layout = GetComponent<Layout>();
		layout.ReadLayout(layoutXML.text);
		drawPile = ConvertListCardsToListCardProspectors(deck.cards);
	}

	List<CardProspector> ConvertListCardsToListCardProspectors(List<Card> ICD) {

		List < CardProspector > ICP = new List<CardProspector>();
		CardProspector tCP;
		foreach (Card tCD in ICD){
			tCP = tCD as CardProspector;
			ICP.Add(tCP);
		}
		return (ICP );
	}
	
}
