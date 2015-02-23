Feature: Player
	

@mytag
Scenario: Player one gets a tile from stock
	Given a Domino game
	And a stock
	And Player 1 doesn't have a matching piece
	Then add 1 tile to Player 1 list of tiles
	And remove 1 tile from stock

Scenario: The winner is the player with less quantity of pieces left
	Given a Domino game
	And an empty stock
	And Player 1 doesn't have a matching piece
	Then validate the players pieces amount
	And return player number with less pieces left