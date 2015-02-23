Feature: UsingATileFeature
	In order to use one of my pieces
	As a domino player
	I want to take a tile from my hand and place it on the board

@mytag
Scenario: Place tile on board and remove it from the player hand
	Given A new game with a clean board
	And Player one has seven tiles in the hand
	| Head | Tail |
	| 0    | 3    |
	| 0    | 5    |
	| 5    | 6    |
	| 0    | 1    |
	| 4    | 5    |
	| 4    | 6    |
	| 2    | 3    |
	And Player two has seven tiles in the hand
	| Head | Tail |
	| 3    | 4    |
	| 2    | 4    |
	| 2    | 5    |
	| 0    | 2    |
	| 2    | 6    |
	| 1    | 5    |
	| 1    | 4    |
	And Player one starts playing
	When The board has tiles placed
	| Head | Tail |
	| 1    | 1    |
	| 0    | 4    |
	| 1    | 3    |
	| 0    | 6    |
	| 3    | 3    |

	#| 4    | 6    |
	#| 2    | 3    |

	And Player one places one of his tiles on the board
	Then the tile must be removed from his hand
	And the tile must be added to the board
