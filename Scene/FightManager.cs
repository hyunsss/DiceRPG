using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public class FightManager : Scene
    {
        InventoryScene inventoryScene;
        Monster FightMonster;
        enum RandomMonster { Flowey, GreatDog, Wimson, Jery }

        public FightManager(Running running) : base(running)
        {
        }

        public override void Render()
        {
            Thread.Sleep(600);
            Console.Clear();
            Console.WriteLine("\n\n");
            FightMonster.Sprite.SpriteRender();
            Console.WriteLine();
            Console.WriteLine(UI.GetInstance.Status(FightMonster)); 
        }

        public override void Update()
        {
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
                    System.Console.WriteLine("몬스터를 쓰러트렸습니다!! ");
                    player.GetIsFight = false;
                    HasDie = true;
                    Data.monsters.Remove(monster);
                }
                else if (player.GetPlayerHp <= 0)
                {
                    System.Console.WriteLine("플레이어가 쓰러졌습니다....");
                    player.GetIsFight = false;
                    HasDie = true;
                    //Todo 게임 종료 함수
                }
            }

        }

        public void GetInventoryScene(InventoryScene invenScene)
        {
            this.inventoryScene = invenScene;
        }
    }
}
