using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace DiceRPG
{
    public abstract class Monster
    {
        public enum MonsterBurf { IsFaint, IsWeek, IsGetMoneyX2 }
        MapScene map;
        public Position pos;
        public AsciiSprite Sprite = new AsciiSprite();
        protected StringBuilder sb;

        protected int Gold;
        protected string name;
        protected int Hp;
        protected int FullHp;
        protected int Damage;
        //몬스터 버프 디버프 통합
        private bool[] Burf = { false, false, false };
        private int moveTurn = 0;


        protected void TryMove(Direction moveDir)
        {
            Position prevPos = pos;
            // 이동
            switch (moveDir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }

            if (Data.map[pos.y, pos.x] == (char)MapScene.MapDir.Block)
            {
                pos = prevPos;
            }
            else if (Data.MonsterInPos(pos) != this)

            {
                pos = prevPos;
            }
            if (Player.GetInstance.pos.x == pos.x && Player.GetInstance.pos.y == pos.y)
            {
                Player.GetInstance.GetIsFight = true;
            }
        }
        public void MoveAction()
        {
            if (moveTurn++ < 3)
            {
                return;
            }
            moveTurn = 0;

            List<Position> path;
            if (!PathFinding(in Data.map, pos, Player.GetInstance.pos, out path))
                return;

            if (path.Count > 1)
            {
                if (path[1].x == pos.x)
                {
                    if (path[1].y == pos.y - 1)
                        TryMove(Direction.Up);
                    else
                        TryMove(Direction.Down);
                }
                else
                {
                    if (path[1].x == pos.x - 1)
                        TryMove(Direction.Left);
                    else
                        TryMove(Direction.Right);
                }
            }



        }

        /******************************************************
		 * A* 알고리즘
		 * 
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		 ******************************************************/

        const int CostStraight = 10;
        const int CostDiagonal = 14;

        static (int x, int y)[] direction =
        {
            (  0, +1 ),			// 상
			(  0, -1 ),			// 하
			( -1,  0 ),			// 좌
			( +1,  0 ),			// 우
			// ( -1, +1 ),		// 좌상
			// ( -1, -1 ),		// 좌하
			// ( +1, +1 ),		// 우상
			// ( +1, -1 )		// 우하
		};

        public bool PathFinding(in char[,] tileMap, in Position start, in Position end, out List<Position> path)
        {
            int ySize = tileMap.GetLength(0);
            int xSize = tileMap.GetLength(1);

            ASNode[,] nodes = new ASNode[ySize, xSize];
            bool[,] visited = new bool[ySize, xSize];
            PriorityQueue<ASNode, int> nextPointPQ = new PriorityQueue<ASNode, int>();

            // 0. 시작 정점을 생성하여 추가
            ASNode startNode = new ASNode(start, null, 0, Heuristic(start, end));
            nodes[startNode.point.y, startNode.point.x] = startNode;
            nextPointPQ.Enqueue(startNode, startNode.f);

            while (nextPointPQ.Count > 0)
            {
                // 1. 다음으로 탐색할 정점 꺼내기
                ASNode nextNode = nextPointPQ.Dequeue();

                // 2. 방문한 정점은 방문표시
                visited[nextNode.point.y, nextNode.point.x] = true;

                // 3. 다음으로 탐색할 정점이 도착지인 경우
                // 도착했다고 판단해서 경로 반환
                if (nextNode.point.x == end.x &&
                    nextNode.point.y == end.y)
                {
                    Position? pathPoint = end;
                    path = new List<Position>();

                    while (pathPoint != null)
                    {
                        Position point = pathPoint.GetValueOrDefault();
                        path.Add(point);
                        pathPoint = nodes[point.y, point.x].parent;
                    }

                    path.Reverse();
                    return true;
                }

                // 4. AStar 탐색을 진행
                // 방향 탐색
                for (int i = 0; i < direction.Length; i++)
                {
                    int x = nextNode.point.x + direction[i].x;
                    int y = nextNode.point.y + direction[i].y;

                    // 4-1. 탐색하면 안되는 경우
                    // 맵을 벗어났을 경우
                    if (x < 0 || x >= xSize || y < 0 || y >= ySize)
                        continue;
                    // 탐색할 수 없는 정점일 경우
                    else if (tileMap[y, x] == '#')
                        continue;
                    // 이미 방문한 정점일 경우
                    else if (visited[y, x])
                        continue;

                    // 4-2. 탐색한 정점 만들기
                    int g = nextNode.g + ((nextNode.point.x == x || nextNode.point.y == y) ? CostStraight : CostDiagonal);
                    int h = Heuristic(new Position(x, y), end);
                    ASNode newNode = new ASNode(new Position(x, y), nextNode.point, g, h);

                    // 4-3. 정점의 갱신이 필요한 경우 새로운 정점으로 할당
                    if (nodes[y, x] == null ||      // 탐색하지 않은 정점이거나
                        nodes[y, x].f > newNode.f)  // 가중치가 높은 정점인 경우
                    {
                        nodes[y, x] = newNode;
                        nextPointPQ.Enqueue(newNode, newNode.f);
                    }
                }
            }

            path = null;
            return false;
        }

        // 휴리스틱 (Heuristic) : 최상의 경로를 추정하는 순위값, 휴리스틱에 의해 경로탐색 효율이 결정됨
        private static int Heuristic(Position start, Position end)
        {
            int xSize = Math.Abs(start.x - end.x);  // 가로로 가야하는 횟수
            int ySize = Math.Abs(start.y - end.y);  // 세로로 가야하는 횟수

            // 맨해튼 거리 : 가로 세로를 통해 이동하는 거리
            // return CostStraight * (xSize + ySize);

            // 유클리드 거리 : 대각선을 통해 이동하는 거리
            return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
        }

        private class ASNode
        {
            public Position point;    // 현재 정점
            public Position? parent;  // 이 정점을 탐색한 정점

            public int g;           // 현재까지의 값, 즉 지금까지 경로 가중치
            public int h;           // 앞으로 예상되는 값, 목표까지 추정 경로 가중치
            public int f;           // f(x) = g(x) + h(x);

            public ASNode(Position point, Position? parent, int g, int h)
            {
                this.point = point;
                this.parent = parent;
                this.g = g;
                this.h = h;
                this.f = g + h;
            }
        }

        public void DropGold(Player player)
        {
            player.GetMoney += Gold;
        }

        public abstract void Attack(Player player);

        public string GetName { get { return name; } }
        public int GetHp { get { return Hp; } set { Hp = value; } }
        public int GetFullHp { get { return FullHp; } set { FullHp = value; } }
        public int GetDamage { get { return Damage; } set { Damage = value; } }
        public bool[] GetBurf { get { return Burf; } set { Burf = value; } }
    }

    public class Toriel : Monster
    {
        public Toriel()
        {
            Sprite = new S_Toriel();
            Hp = 10;
            FullHp = 10;
            Damage = 1;
            Gold = 100;
        }

        public void PrintSprite()
        {

        }

        public override void Attack(Player player)
        {
            Console.WriteLine(UI.GetInstance.LogMessage("날 공격하다니..."));

        }
    }
    public class Jery : Monster
    {
        public Jery()
        {
            Sprite = new S_Jery();
            Hp = 45;
            FullHp = 45;
            Damage = 8;
            Gold = 300;
        }
        public override void Attack(Player player)
        {
            Console.WriteLine(UI.GetInstance.LogMessage("누구,,,?"));
            player.GetPlayerHp -= this.Damage;
        }
    }
    public class Wimson : Monster
    {
        public Wimson()
        {
            Sprite = new S_Wimson();
            Hp = 30;
            FullHp = 30;
            Damage = 5;
            Gold = 300;

        }
        public override void Attack(Player player)
        {
            Console.WriteLine(UI.GetInstance.LogMessage(" . . . . . . !! "));
            player.GetPlayerHp -= this.Damage;
        }
    }
    public class GreatDog : Monster
    {
        public GreatDog()
        {
            Sprite = new S_GreatDog();
            Hp = 80;
            FullHp = 80;
            Damage = 5;
            Gold = 400;
        }
        public override void Attack(Player player)
        {
            Console.WriteLine(UI.GetInstance.LogMessage("왈! 왈! 와ㅏㅏㅏㅏㅏ라랄ㄹㄹㄹ!"));
            player.GetPlayerHp -= this.Damage;
        }
    }
    public class Flowey : Monster
    {

        public Flowey()
        {
            Sprite = new S_Flowey();
            Hp = 15;
            FullHp = 15;
            Damage = 30;
            Gold = 300;
        }
        public override void Attack(Player player)
        {
            Console.WriteLine(UI.GetInstance.LogMessage("난 착한 친구란다?"));
            player.GetPlayerHp -= this.Damage;
        }
    }

    public class PapyRus : Monster
    {
        public PapyRus()
        {
            Sprite = new S_PapyRus();
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            Gold = 3000;
        }
        public override void Attack(Player player)
        {
            throw new NotImplementedException();
        }
    }
    public class Sanz : Monster
    {
        public Sanz()
        {
            Sprite = new S_Sanz();
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            Gold = 3000;

        }
        public override void Attack(Player player)
        {
            throw new NotImplementedException();
        }
    }
    public class Undyne : Monster
    {
        public Undyne()
        {
            Sprite = new S_Undyne();
            Hp = 500;
            FullHp = 500;
            Damage = 30;
            Gold = 3000;
        }
        public override void Attack(Player player)
        {
            Console.WriteLine(UI.GetInstance.LogMessage("나, 언다인이, 널 쓰러뜨릴 것이다!"));
            player.GetPlayerHp -= this.Damage;
        }
    }
}
