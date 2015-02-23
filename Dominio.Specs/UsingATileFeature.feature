Feature: UsingATileFeature
	In order to use one of my pieces
	As a domino player
	I want to take a tile from my hand and place it on the board

@mytag
Scenario: Place tile on board and remove it from the player hand
	Given A list of tiles that are placed on the board
	And Player one and two have seven tiles each
	And Player one starts playing
	When The board has these tiles placed
	| Head | Tail |
	| 0    | 3    |
	| 0    | 5    |
	| 5    | 6    |
	| 0    | 1    |
	| 4    | 5    |
	| 4    | 6    |
	| 2    | 3    |

	And Player one places one of his tiles on the board
	Then the tile must be removed from his hand
	And the tile must be added to the board
