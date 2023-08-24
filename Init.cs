using System;
using System.Media;
using space1;

namespace space2 {
  class Init {
    private Player p1;
    private Player p2;
    private static int p1CurrAP;
    private static int p2CurrAP;
    private static int p1Partial;
    private static int p2Partial;
    private static double finalTurnSec;

    public Init(Player one, Player two) {
      p1 = new Player(one.getSpeed(), one.getAP(), one.getReflex(), one.getConditioning(), one.getPerception());
      p1.calcPlayerTurnTime();
      p2 = new Player(two.getSpeed(), two.getAP(), two.getReflex(), two.getConditioning(), two.getPerception());
      p2.calcPlayerTurnTime();
      p1.setBloodVol();
      p2.setBloodVol();
      playTrack("HEAD SPLITTER - Hyperpunk.wav");
      playCombatEncounter(p1, p2);
      //playTrack("HEAD SPLITTER - Hyperpunk.wav");
      }

    private static void playCombatEncounter(Player p1, Player p2) 
    {
    calcTurnSpeed(p1, p2);
    Console.WriteLine("In-Game Turn Time: " + finalTurnSec + "Sec");
    calcFinalAp(p1, p2);
    Console.WriteLine("Player 1 AP: " + p1.getFinalAP());
    Console.WriteLine("Player 1 Speed: " + p1.getSpeed());
    Console.WriteLine("Player 1 Conditioning: " + p1.getConditioning());
    Console.WriteLine("Player 1 Blood Volume: " + p1.getBloodVol());
    Console.WriteLine("Player 2 AP: " + p2.getFinalAP());
    Console.WriteLine("Player 2 Speed: " + p2.getSpeed());
    Console.WriteLine("Player 2 Conditioning: " + p2.getConditioning());
    Console.WriteLine("Player 2 Blood Volume: " + p2.getBloodVol());
    int firstTurn = turnOrder(p1, p2);
    while(true) {
      Console.WriteLine();
      p1CurrAP = p1.getFinalAP();
      p2CurrAP = p2.getFinalAP(); 
      if (firstTurn == 1) {
        Console.WriteLine("Player 1 Turn");
        //Console.WriteLine("How many action are you taking?");
        //int numActions = p1.getFinalAP()/50;
        bool react;
        while (p1CurrAP > 0) {
          react = testReaction(p2);
          attackAction(p1, p2, 1, p1Partial);
          if (react) {
            Console.WriteLine("Player 2 Reaction AP: " + reactionAp(p2));
            }
          Console.WriteLine();
          }
        Console.WriteLine();
        //Other Player Turn
        Console.WriteLine("Player 2 Turn");
        //Console.WriteLine("How many action are you taking?");
        //numActions = p2.getFinalAP() / 50;
        while (p2CurrAP > 0) {
          react = testReaction(p1);
          attackAction(p2, p1, 2, p2Partial);
          if (react) {
            Console.WriteLine("Player 1 Reaction AP: " + reactionAp(p1));
            }
          Console.WriteLine();
          }
           Console.WriteLine();
         }
      else {
        Console.WriteLine("Player 2 Turn");
        //Console.WriteLine("How many action are you taking?");
        //int numActions = p2.getFinalAP() / 50;
        bool react;
        while (p2CurrAP > 0) {
          react = testReaction(p1);
          attackAction(p2, p1, 2, p2Partial);
          if (react) {
            Console.WriteLine("Player 1 Reaction AP: " + reactionAp(p1));
            }
          Console.WriteLine();
          }
        Console.WriteLine();
        //Other Player Turn
        Console.WriteLine("Player 1 Turn");
        //Console.WriteLine("How many action are you taking?");
        //numActions = p1.getFinalAP() / 50;
        while (p1CurrAP > 0) {
          react = testReaction(p2);
          attackAction(p1, p2, 1, p1Partial);
          if (react) {
            Console.WriteLine("Player 2 Reaction AP: " + reactionAp(p2));
            }
          Console.WriteLine();
          }
        }
      Console.WriteLine();
                Console.WriteLine("Next Round?");
                String answer = Console.ReadLine();
                while (answer != "y") {
                    answer = Console.ReadLine();
                }
      }
    }

    private static void calcTurnSpeed(Player p1, Player p2) {
      if (p1.getPlayerTurnTime() > p2.getPlayerTurnTime()) {
        finalTurnSec = p2.getPlayerTurnTime();
      }
      else {
        finalTurnSec = p1.getPlayerTurnTime();
      }
    }

    private static void calcFinalAp(Player p1, Player p2) {
      p1.calcFinalAP(finalTurnSec);
      p2.calcFinalAP(finalTurnSec);
    }

    private static bool testReaction(Player p) {
      int reactChance = (int)((p.getReflex()/10.0) * 75);  
      Random ran = new Random();
      int per = ran.Next(1, 101);
      Console.WriteLine("Reaction Chance: " + reactChance + " Reaction Roll: " + per);
      if (per < reactChance) {
        return true;
      }
      else {
        return false;
      }
      }

    private static int reactionAp(Player p) {
      return (int)(((1.0/5.0) * p.getFinalAP()) * (p.getReflex()/5.0));
    }

    private static int turnOrder(Player p1, Player p2) {
      Random ran = new Random();
      int p1Init = (ran.Next(1, 11)) + p1.getReflex();
      int p2Init = (ran.Next(1, 11)) + p2.getReflex();
      if (p1Init > p2Init) {
        return 1;
      }
      else {
        return 2;
      }
    }

        private static void playTrack(string file) {
          SoundPlayer musicPlayer = new SoundPlayer(file);
          musicPlayer.Play();
        }

        private static void attackAction(Player at, Player df, int attackerNum, int playerPartial) {
          int attackCost = 50 - playerPartial;
          if (attackerNum == 1)
            {
                if (p1CurrAP < attackCost) {
                    Console.WriteLine("Player 1 Partial Action");
                    p1Partial = p1CurrAP + playerPartial;
                    p1CurrAP = 0;
                    return;
                }
                p1CurrAP = p1CurrAP - attackCost;
            }
            else
            {
                if (p2CurrAP < attackCost)
                {
                    Console.WriteLine("Player 2 Partial Action");
                    p2Partial = p1CurrAP + playerPartial;
                    p2CurrAP = 0;
                    return;
                }
                p2CurrAP = p2CurrAP - attackCost;
            }
            // control statment to account for partial actions (implemeted later)
            if (attackerNum == 1)
            {
                p1Partial = 0;
            }
            else
            {
                p2Partial = 0;
            }
            Console.WriteLine("Choose attack action");
            string choice = Console.ReadLine();
            if (choice == "m")
            {
                meleeAttack(at, df);
            }
            else if (choice == "sr")
            {
                rangedSlowAttack(at, df);
            }
            else if (choice == "fr")
            {
                if (df.getSpeed() > 2)
                {
                    rangedSlowAttack(at, df);
                }
                else
                {
                    rangedFastAttack(at, df);
                }
            }
    }

    private static void meleeAttack(Player attacker, Player defender) {
            Random ran = new Random();
            double aCP = (attacker.getSpeed() * (attacker.getReflex() + attacker.getAgility() + attacker.getConditioning()));
            double dCP = (defender.getSpeed() * (defender.getReflex() + defender.getAgility() + defender.getConditioning()));
            double hitPro = ((aCP / (aCP + dCP)) * 100);
            int hitProb = Convert.ToInt32(hitPro);
            int damDealt = attacker.getConditioning();
            int dodgeProb = (int)((dCP / (dCP + aCP)) * 100);
            int hitPer = ran.Next(1, 101);
            Console.WriteLine("Hit Probability: " + hitProb);
            Console.WriteLine("Hit Roll: " + hitPer);
            if (hitPer <= hitProb) {
                Console.WriteLine("Attack Hit");
                Console.WriteLine("Damage Dealt: " + attacker.getConditioning());
            }
            else {
                Console.WriteLine("Attack Missed");
            }
        }

    private static void rangedSlowAttack(Player attacker, Player defender) {
            Random ran = new Random();
            double aCP = (attacker.getSpeed() * (attacker.getReflex() + attacker.getAgility() + attacker.getPerception()));
            double dCP = (defender.getSpeed() * (defender.getReflex() + defender.getAgility() + defender.getPerception()));
            double hitPro = ((aCP / (aCP + dCP)) * 100);
            int hitProb = Convert.ToInt32(hitPro);
            int damDealt = attacker.getPerception();
            int dodgeProb = (int)((dCP / (dCP + aCP)) * 100);
            int hitPer = ran.Next(1, 101);
            Console.WriteLine("Hit Probability: " + hitProb);
            Console.WriteLine("Hit Roll: " + hitPer);
            if (hitPer <= hitProb)
            {
                Console.WriteLine("Attack Hit");
                Console.WriteLine("Damage Dealt: " + damDealt);
            }
            else
            {
                Console.WriteLine("Attack Missed");
            }
        }

    private static void rangedFastAttack(Player attacker, Player defender) {
            Random ran = new Random();
            int cover = ran.Next(0, 15);
            int distance = ran.Next(0, 15);
            double aCP = (attacker.getSpeed() * (attacker.getReflex() + attacker.getAgility() + attacker.getPerception()));
            double dCP = (cover * distance);
            double hitPro = ((aCP / (aCP + dCP)) * 100);
            int hitProb = Convert.ToInt32(hitPro);
            int damDealt = attacker.getPerception();
            int dodgeProb = (int)((dCP / (dCP + aCP)) * 100);
            int hitPer = ran.Next(1, 101);
            Console.WriteLine("Hit Probability: " + hitProb);
            Console.WriteLine("Hit Roll: " + hitPer);
            if (hitPer <= hitProb)
            {
                Console.WriteLine("Attack Hit");
                Console.WriteLine("Damage Dealt: " + damDealt);
            }
            else
            {
                Console.WriteLine("Attack Missed");
            }
        }
    
  }
}