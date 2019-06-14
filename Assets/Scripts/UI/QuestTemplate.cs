using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu (fileName = "New Quest", menuName = "Quest" )]
public class QuestTemplate : ScriptableObject 
{
    public new string name;
    public string description;
    public string reward;
    public Image questPopUp;
}
