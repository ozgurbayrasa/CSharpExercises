﻿using DiceRollGame_IS.Game;

var random  = new Random();
var dice = new Dice(random);
var guessingGame = new GuessingGame(dice);

GameResult gameResult = guessingGame.Play();
GuessingGame.PrintResult(gameResult);
Console.ReadKey();
