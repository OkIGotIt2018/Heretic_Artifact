using BepInEx;
using BepInEx.Configuration;
using Mono.Cecil.Cil;
using MonoMod.Cil;
using RoR2;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security;
using System.Security.Permissions;
using UnityEngine;

[module: UnverifiableCode]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]

namespace Heretic_Artifact
{
    [BepInPlugin("com.OkIGotIt.Heretic_Artifact", "Heretic_Artifact", "1.0.0")]
    public class Heretic_Artifact : BaseUnityPlugin
    {
        /*private static readonly HashSet<NetworkUser> votedForMetamorphosis = new HashSet<NetworkUser>();
        public static bool YesNo;*/
        public void Awake()
        {

            /*On.RoR2.PreGameController.StartRun += PreGameControllerStartRun;
            IL.RoR2.CharacterMaster.Respawn += CharacterMasterRespawn;*/
            On.RoR2.CharacterMaster.OnBodyStart += CharacterMaster_OnBodyStart;
        }

        private void CharacterMaster_OnBodyStart(On.RoR2.CharacterMaster.orig_OnBodyStart orig, CharacterMaster self, CharacterBody body)
        {
            orig(self, body);
            CharacterBody body2 = PlayerCharacterMasterController.instances[0].master.GetBody();
            if (body == body2)
            {
                if (body.inventory.GetItemCount(ItemCatalog.FindItemIndex("LunarPrimaryReplacement")) == 0)
                {
                    body.inventory.GiveItem(ItemCatalog.FindItemIndex("LunarPrimaryReplacement"));
                }
                if (body.inventory.GetItemCount(ItemCatalog.FindItemIndex("LunarSecondaryReplacement")) == 0)
                {
                    body.inventory.GiveItem(ItemCatalog.FindItemIndex("LunarSecondaryReplacement"));
                }
                if (body.inventory.GetItemCount(ItemCatalog.FindItemIndex("LunarUtilityReplacement")) == 0)
                {
                    body.inventory.GiveItem(ItemCatalog.FindItemIndex("LunarUtilityReplacement"));
                }
                if (body.inventory.GetItemCount(ItemCatalog.FindItemIndex("LunarSpecialReplacement")) == 0)
                {
                    body.inventory.GiveItem(ItemCatalog.FindItemIndex("LunarSpecialReplacement"));
                }
            }
        }

        /*public void Destroy()
        {
            On.RoR2.PreGameController.StartRun -= PreGameControllerStartRun;
            IL.RoR2.CharacterMaster.Respawn -= CharacterMasterRespawn;
        }

        private static void CharacterMasterRespawn(ILContext il)
        {
            var c = new ILCursor(il);

            c.GotoNext(x => x.MatchLdsfld(typeof(RoR2Content.Artifacts), "randomSurvivorOnRespawnArtifactDef"));
            c.Index += 3;
            var endIf = c.Previous.Operand;
            c.Emit(OpCodes.Ldarg_0);
            c.EmitDelegate<Func<CharacterMaster, bool>>(ShouldChangeCharacter);
            c.Emit(OpCodes.Brfalse_S, endIf);
        }

        private static bool ShouldChangeCharacter(CharacterMaster master)
        {
            if (votedForMetamorphosis.Any(el => el.master == master))
                YesNo = true;
            return !(votedForMetamorphosis.Any(el => el.master == master));
        }

        private static void PreGameControllerStartRun(On.RoR2.PreGameController.orig_StartRun orig, PreGameController self)
        {
            votedForMetamorphosis.Clear();
            var choice = RuleCatalog.FindChoiceDef("Artifacts.RandomSurvivorOnRespawn.On");
            foreach (var user in NetworkUser.readOnlyInstancesList)
            {
                var voteController = PreGameRuleVoteController.FindForUser(user);
                var isMetamorphosisVoted = voteController.IsChoiceVoted(choice);

                if (isMetamorphosisVoted)
                {
                    votedForMetamorphosis.Add(user);
                    Chat.AddMessage(user.name);
                }
            }
            orig(self);
        }*/
    }
}
