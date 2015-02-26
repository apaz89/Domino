Feature: PlayerTwoStartBecauseMaxDoublePiece
	In order to start the game
	As player
	I want that the player Two Start the game because he has the Max double piece

Scenario: Player two start for max double piece
	Given Player one has a collection
	| Head | Tail |
	| 0    | 0    |
	| 1    | 1    |
	| 0    | 2    |
	| 2    | 3    |
	| 4    | 4    |
	| 0    | 5    |
	| 6    | 5    |
	And Player two has a collection
	| Head | Tail |
	| 6    | 6    |
	| 1    | 3    |
	| 3    | 2    |
	| 5    | 3    |
	| 0    | 4    |
	| 6    | 5    |
	| 2    | 6    |	
	When Player two has the max double piece
	Then The player two start the game
