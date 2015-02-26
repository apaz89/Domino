﻿Feature: SpecStatistics
	In order to avoid silly mistakes
	As a domino idiot
	I want to be told the winner or loser in a domino match

@mytag
Scenario: Player Win
	Given I have the score of the players
	   | Player | Score |
	   | Player1 | 1     |
	   | Player2 | 2     |
	Then Write Player Statictics 'Player Winner' on the screen

Scenario: Player Lose
	Given I have the score of the players
	   | Player | Score |
	   | Player1 | 1     |
	   | Player2 | 2     |
	Then Write Player Statictics 'Player Loser' on the screen

Scenario: Player Draw
    Given I have the score of the players
	   | Player | Score |
	   | Player1 | 1     |
	   | Player2 | 1     |
	Then Write Player Statictics 'Players Draw' on the screen