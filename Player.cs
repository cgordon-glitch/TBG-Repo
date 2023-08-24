using System;

namespace space1 {
  class Player {
    private double Speed = 0;
    private int aP = 150;
    private int Reflex = 5;
    private int Agility = 5;
    private int Conditioning = 5;
    private int Perception = 5;
    private double playerTurnSec;
    private int finalAP;
    private int attackAPSaved = 0;
    private int bloodVol = 0;

    public Player(double SpeedN, int apN, int Ref, int ConN, int Per) {
      Speed = SpeedN;
      aP = apN;
      Reflex = Ref;
      Conditioning = ConN;
      Perception = Per;
    }

    public Player() {
      //Default Constructor
    }

   public void setSpeed (double speedNum) {
     Speed = speedNum;
    }

    public void setSpeedForm() {
      Speed = (0.1 * Reflex) + (0.1 * Agility);
     }
   
    public double getSpeed() {
     return Speed;
    }

    public void setAP (int apNum) {
     aP = apNum;
    }
   
    public int getAP() {
     return aP;
    }

    public void setReflex (int reflexNum) {
     Reflex = reflexNum;
    }
   
    public int getReflex() {
     return Reflex;
    }

    public double getPlayerTurnTime() {
      return playerTurnSec;
    }

    public void calcPlayerTurnTime() {
      playerTurnSec = 5/Speed;
    }

    public void calcFinalAP(double finalTurnTime) {
      finalAP = (int)((finalTurnTime/playerTurnSec) * aP);
    }

    public int getFinalAP() {
      return finalAP;
    }

    public int getAgility() {
      return Agility;
     }

    public void setAgility(int agilityNum) { 
      Agility = agilityNum; 
     }

    public int getAttackAPSaved() { return attackAPSaved;}

    public void setAttackAPSaved(int attackAP) { attackAPSaved = attackAP; }

    public void setConditioning(int conditioningNum) { Conditioning = conditioningNum; }

    public int getConditioning() {  return Conditioning;}

    public void setBloodVol()
        {
            bloodVol = 4380 + (120 * Conditioning);
        }

    public int getBloodVol() {  return bloodVol; }

    public int getPerception()
        {
            return Perception;
        }

    public void setPerception(int perceptionNum) {  Perception = perceptionNum; }
    
  }
}