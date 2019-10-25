using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu (fileName = "New Quest", menuName = "Quest" )]
public class QuestTemplate : ScriptableObject 
{
    public string questName;
    public string description;
    public Item grantedItem;
    public Item reward;
    public Image questPopUp;
}
