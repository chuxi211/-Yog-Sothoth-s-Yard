using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "CharacterAsset", menuName = "ScriptableObjects/CharacterAsset", order = 1)]
public class CharacterAsset : ScriptableObject
{
    public string ID;
    public string Name;
    public Sprite Idle;
    public Sprite Smile;
    public Sprite Angry;
    public Sprite Wink;
    public Sprite GetSprite(CharacterStateEnum characterState)
    {
        switch(characterState)
        {
            case CharacterStateEnum.Idle:
                return Idle;
            case CharacterStateEnum.Smile:
                return Smile;
            case CharacterStateEnum.Angry:
                return Angry;
            case CharacterStateEnum.Wink:
                return Wink;
            default:
                return null;
        }
    }
}
