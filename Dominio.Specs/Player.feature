Feature: Player
	

@mytag
Scenario: Player one gets a tile from stock
	#Given a board
	Given a stock
	| Tile | head | tail |
	| 1    | 3    | 4    |
	| 2    | 1    | 0    |
	| 3    | 6    | 6    |
	| 4    | 2    | 3    |
	And Player 1 doesn't have a matching piece
	| Tile | head | tail |
	| 1    | 1    | 4    |
	| 2    | 5    | 6    |
	| 3    | 0    | 5    |
	| 4    | 0    | 3    |
	Then add 1 tile to Player 1 list of tiles
	And remove 1 tile from stock