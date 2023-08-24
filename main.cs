using System;
using System.Media;
using space1;
using space2;

class Program {
  public static void Main (string[] args) {
    Player p1 = new Player();
    Player p2 = new Player();
    Console.WriteLine("Create Player 1:");
    //Set Speed for Player 1 (now redundant)
    Console.WriteLine("Player 1 Speed: (redundant now)");
    double speedNum = Convert.ToDouble(Console.ReadLine());
    p1.setSpeed(speedNum);
    //Set default AP for Player 1
    Console.WriteLine("Player 1 AP:");
    int apNum = Convert.ToInt32(Console.ReadLine());
    p1.setAP(apNum);
    //set Reflesx for Player 1
    Console.WriteLine("Player 1 Reflex:");
    int reflexNum = Convert.ToInt32(Console.ReadLine());
    p1.setReflex(reflexNum);
    //set Agility for Player 1
    Console.WriteLine("Player 1 Agility:");
    int agilityNum = Convert.ToInt32(Console.ReadLine());
    p1.setAgility(agilityNum);
    //set Conditioning for Player 1
    Console.WriteLine("Player 1 Conditioning:");
    int conditioningNum = Convert.ToInt32(Console.ReadLine());
    p1.setConditioning(conditioningNum);
    //set Perception for Player 1
    Console.WriteLine("Player 1 Perception:");
    int perceptionNum = Convert.ToInt32(Console.ReadLine());
    p1.setPerception(perceptionNum);
    //Calculate Speed
    p1.setSpeedForm();
    

    //do the same for Player 2
    //Set Speed for Player 2 (now redundant)
    Console.WriteLine("Player 2 Speed: (redundant now)");
    speedNum = Convert.ToDouble(Console.ReadLine());
    p2.setSpeed(speedNum);
    //Set default AP for Player 2
    Console.WriteLine("Player 2 AP:");
    apNum = Convert.ToInt32(Console.ReadLine());
    p2.setAP(apNum);
    //set Reflesx for Player 2
    Console.WriteLine("Player 2 Reflex:");
    reflexNum = Convert.ToInt32(Console.ReadLine());
    p2.setReflex(reflexNum);
    //set Agility for Player 2
    Console.WriteLine("Player 2 Agility:");
    agilityNum = Convert.ToInt32(Console.ReadLine());
    p2.setAgility(agilityNum);
    //set Conditioning for Player 2
    Console.WriteLine("Player 2 Conditioning:");
    conditioningNum = Convert.ToInt32(Console.ReadLine());
    p2.setConditioning(conditioningNum);
    //set Perception for Player 2
    Console.WriteLine("Player 2 Perception:");
    perceptionNum = Convert.ToInt32(Console.ReadLine());
    p1.setPerception(perceptionNum);
    //Calculate Speed for player 2
    p2.setSpeedForm();
    

    Init combatDemo = new Init(p1, p2);
  }
}