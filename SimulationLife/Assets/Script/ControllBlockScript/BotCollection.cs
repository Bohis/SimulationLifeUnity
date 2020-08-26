using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCollection : MonoBehaviour {
	public List<GameObject> Bots;
	public Tree.Tree<NeiralNet.NeuralNetwork> WebTree;
	public int BorderLevel = 3;									 

	public NeiralNet.NeuralNetwork _bestWeb;
	public NeiralNet.NeuralNetwork _worstWeb;

	// Use this for initialization
	void Start () {
		Bots = new List<GameObject>();
		WebTree = new Tree.Tree<NeiralNet.NeuralNetwork>( null,BorderLevel );
		WebTree.MaxLevelReach += WebTree_MaxLevelReach;
		_bestWeb = null;
		_worstWeb = null;
	}

	private void WebTree_MaxLevelReach() {
		_bestWeb = WebTree.MaxRightValue();
		_worstWeb = WebTree.MaxLeftValue();
		WebTree = new Tree.Tree<NeiralNet.NeuralNetwork>( NeiralNet.NeuralNetwork.Mixing( WebTree.MaxLeftValue(), WebTree.MaxRightValue() ), BorderLevel );
	}	  
}