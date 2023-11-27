public class Running
{

  Player player = new Player();
  Map map = new Map();





  private void Init()
  {
    map.GetPlayer(player);
  }

  public void Run()
  {
    map.Update();
    player.Update();
  }



}