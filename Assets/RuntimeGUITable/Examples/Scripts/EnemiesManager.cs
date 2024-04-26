using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityUITable;

public class EnemiesManager : MonoBehaviour 
{

	public List<Enemy> enemies;

	public void AddEnemy(string name, string dialogue){
		Debug.LogError("ADDING ENEMY!!!!");
		enemies.Add(new Enemy(name, dialogue));
	}

}
