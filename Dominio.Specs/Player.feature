Feature: Player
	

@mytag
Scenario: Player one gets a tile from stock
	Given a Domino game
	And a stock
	| Head | Tail |
	| 2    | 6    |
	| 6    | 6    |
	| 2    | 3    |
	| 3    | 4    |
	| 4    | 4    |
	| 4    | 5    |
	| 2    | 2    |
	And Player 1 doesn't have a matching piece
	Then add 1 tile to Player 1 list of tiles
	And remove 1 tile from stock

Scenario: The winner is the player with less quantity of pieces left
	Given a Domino game
	And an empty stock
	And Player 1 doesn't have a matching piece
	Then validate the players pieces amount
	And return player number with less pieces left



Scenario: When player 1 puts a piece on the board is the player's turn 2, where is the 2 is the turn of one.
	Given a Domino game 
	And  a Domino StartBord
	When the player one has the following sets of tiles
	| Head | Tail |
	| 0    | 6    |
	| 0    | 5    |
	| 0    | 2    |
	| 1    | 2    |
	| 5    | 2    |
	| 0    | 6    |
	| 1    | 3    |
	And the player two has the following set of tiles
	| Head | Tail |
	| 0    | 2    |
	| 1    | 3    |
	| 1    | 2    |
	| 1    | 5    |
	| 2    | 6    |
	| 2    | 2    |
	| 2    | 3    |
	And Player one puts his piece on the board
	Then is the turn of the player 2 




Scenario: When The player puts a Tile on the Board
	Given is the turn of player one
	When the board has the next set of tiles
	| Head | Tail |
	| 0    | 1    |
	| 0    | 6    |
	| 0    | 5    |
	| 1    | 3    |
	| 5    | 6    |
	| 0    | 2    |
	| 1    | 2    |
	And the player place a tile on the board
	Then the tiles on board must increase by 1
	And the tiles on the hand of the player must decrease by 1
