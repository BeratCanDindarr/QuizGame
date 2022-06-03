using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Level", menuName = "CreateLevel/NewLevel", order = 1)]
public class SpawnManagerScriptableObject : ScriptableObject
{
    public List<QuestionAndAnswer> qnA;
}

