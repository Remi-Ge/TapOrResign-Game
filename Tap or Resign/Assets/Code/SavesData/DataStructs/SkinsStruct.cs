using System;
using System.Collections.Generic;

namespace Code.SavesData.DataStructs
{
    [Serializable]
    public struct SkinsStruct
    {
        public List<SkinStruct> ownedSkins;
        public int ownedExplosionType;

        [Serializable]
        public struct SkinStruct
        {
            public int bodyType;
            public int bodyColor;
            public int eyesType;
            public int eyesColor;
            public int animationType;
        }
    }
}