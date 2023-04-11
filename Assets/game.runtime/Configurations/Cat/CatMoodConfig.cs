using UnityEngine;

namespace Game.Configurations
{
    [CreateAssetMenu(fileName = nameof(CatMoodConfig), menuName = "Game/Configurations/" + nameof(CatMoodConfig))]
    public class CatMoodConfig : BaseConfig
    {
        public string Caption;
    }
}