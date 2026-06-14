using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Data
{
    [CreateAssetMenu(fileName ="NPCConfig",menuName ="ConfigNPC/NPCConfig")]
    [Serializable]
    public class NPCConfig :ScriptableObject{
        public string Name;
        public string ID;
        public int Level;
        public Feature Feature;
        public int MaxCoin;
        public int CoinDropRate;
        public int MaxSoul;
        public int SoulDropRate;
        public int CleanlinessValue;
        public Sprite LevelIcon;
        //只有头像
        public Sprite Avater;
        public NPCDropConfigTable DropTable;
    }
}

public enum Feature
{
    Normal,  //无特殊特征
    Rich,    //更多金币
    Neat,    //减少消耗的整洁度
}