using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace PartyLowFood
{
    // This mod warns the player when their party is low on food.
    public class PartyLowFoodSubModule : MBSubModuleBase
    {
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if (game.GameType is Campaign)
            {
                ((CampaignGameStarter)gameStarterObject).AddBehavior(new PartyLowFoodCampaignBehavior());
            }
        }
    }
}
