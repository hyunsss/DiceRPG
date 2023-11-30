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
        enum RandomMonster { Flowey, GreatDog, Wimson, Jery }
        Monster monster = null;

        public FightManager(Running running) : base(running)
        {
        }

        public override void Render()
        {
            Console.Clear();
            Console.WriteLine("\n\n");
            monster.Sprite.SpriteRender();
            Console.WriteLine();
            Console.WriteLine(UI.GetInstance.Status(monster)); 
        }

        public override void Update()
        {
            CreateRandomMonster(out monster);
            Render();
            Fight(monster, Player.GetInstance);
        }

        private static void CreateRandomMonster(out Monster monster)
        {
            Random rand = new Random();
            int respawn = rand.Next(0, 3);

            switch (respawn)
            {
                case (int)RandomMonster.Flowey:
                    monster = new Flowey();
                    break;
                case (int)RandomMonster.GreatDog:
                    monster = new GreatDog();
                    break;
                case (int)RandomMonster.Wimson:
                    monster = new Wimson();
                    break;
                case (int)RandomMonster.Jery:
                    monster = new Jery();
                    break;
                default:
                    Console.WriteLine("CreateRandomMonster(). Default Exception");
                    monster = null;
                    break;
            }
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
                            Thread.Sleep(400);
                            Render();
                            break;
                        case "2":
                            //아이템 사용
                            inventoryScene.Update();
                            Render();
                            break;
                        case "3":
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
                    Thread.Sleep(400);
                    Render();
                    PlayerAttackTrue = true;
                }

                if (monster.GetHp <= 0)
                {
                    System.Console.WriteLine("몬스터를 쓰러트렸습니다!! ");
                    player.GetIsFight = false;
                    HasDie = true;
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
