using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType { Normal, Boss }

[System.Serializable]
public class Enemy
{
	public string name;
	public string dialogue;

    public Enemy(string name, string dialogue)
    {
        this.name = name;
        this.dialogue = dialogue;
    }

    public void Method()
	{
		Debug.Log("Method called on " + name);
	}

}

