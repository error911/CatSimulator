using UnityEngine;

namespace Game.Configurations
{
    [CreateAssetMenu(fileName = nameof(CatActionConfig), menuName = "Game/Configurations/"+nameof(CatActionConfig))]
    public class CatActionConfig : BaseConfig
    {
        public string Caption;
    }
}