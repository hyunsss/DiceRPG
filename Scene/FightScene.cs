using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class FightScene : Scene
    {
        enum RandomMonster { Flowey, GreatDog, Wimson, Jery }
        Running running;
        InventoryScene inventoryScene;
        Monster FightMonster;

        public FightScene(Running running) : base(running)
        {
        }

        private void Init()
        {
            inventoryScene = running.inventoryScene;
        }

        public override void Render()
        {
            Thread.Sleep(800);
            Console.Clear();
            Console.WriteLine("\n\n");
            FightMonster.Sprite.SpriteRender();
            Console.WriteLine();
            Console.WriteLine(UI.GetInstance.Status(FightMonster)); 
        }

        public override void Update()
        {
            Init();
            FightMonster = Data.MonsterInPos(Player.GetInstance.pos);
            UI.GetInstance.num = Dice.GetInstance.ReloadDice();
            Render();
            Fight(FightMonster, Player.GetInstance);
        }

        private void Fight(Monster monster, Player player)
        {
            bool PlayerAttackTrue = true;
            bool HasDie = false;
            while (!HasDie)
            {
                
                //플레이어 공격 턴
                if (PlayerAttackTrue)
                {
                    string answer = Console.ReadLine();

                    switch (answer)
                    {
                        case "1":
                            //공격하기
                            player.Attack(monster);
                            Render();
                            break;
                        case "2":
                            //아이템 사용
                            inventoryScene.Update();
                            Render();
                            break;
                        case "3":
                            //스킬 사용
                            Dice.GetInstance.GetSkill[UI.GetInstance.num].Use();
                            UI.GetInstance.num = Dice.GetInstance.ReloadDice();
                            Render();
                            break;
                        case "4":
                            //도망가기
                            player.GetIsFight = false;
                            return;
                        default:
                            continue;
                    }
                    PlayerAttackTrue = false;
                }
                //몬스터 공격 턴
                else
                {
                    monster.Attack(player);
                    Render();
                    PlayerAttackTrue = true;
                }

                    
                

                if (monster.GetHp <= 0)
                {
                    Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.KILLMONSTER));
                    player.GetIsFight = false;
                    HasDie = true;
                    Data.monsters.Remove(monster);
                }
                else if (player.GetPlayerHp <= 0)
                {
                    Console.WriteLine(UI.GetInstance.LogMessage(UI.GetInstance.DEATHPLAYER));
                    player.GetIsFight = false;
                    HasDie = true;
                    //Todo 게임 종료 함수
                }
            }

        }

        public void GetRunning(Running running)
        { 
            this.running = running;
        }
    }
}
