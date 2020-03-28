using System;
using SSJ.DTO;
using UnityEngine;

namespace SSJ
{
    public interface IGameConfig
    {
        
    }

    [Serializable]
    public class GameConfig : IGameConfig
    {
        
    }

    [AddComponentMenu("DTO/GameConfigDTO")]
    public class GameConfigDTO : DTOConfig<GameConfig>, IGameConfig
    {
        
        public override GameConfig ToDTO()
        {
            var result = new GameConfig();

            return result;
        }

        [ContextMenu("Setup")]
        public override void Setup()
        {
        }
    }
}