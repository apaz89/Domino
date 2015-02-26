Feature: StartingPlayerFeature
	In order to determine the starting player
	As a domino player
	I want to decide who meets the conditions

Scenario: Player one has the highest sum of a tile and neither have double tiles
	Given A new game
		
	When Player one has seven tiles
		| Head | Tail |
		| 0    | 3    |
		| 0    | 5    |
		| 5    | 6    |
		| 0    | 1    |
		| 4    | 5    |
		| 4    | 6    |
		| 2    | 3    |

	When Player two has seven tiles
		| Head | Tail |
		| 3    | 4    |
		| 2    | 4    |
		| 2    | 5    |
		| 0    | 2    |
		| 2    | 6    |
		| 1    | 5    |
		| 1    | 4    |

		#| Player| Tile Sum | Head | Tail |
		#| 1		| 3        | 0    | 3    |
		#| 1		| 5        | 0    | 5    |
		#| 1		| 11       | 5    | 6    |
		#| 1		| 1        | 0    | 1    |
		#| 1		| 9        | 4    | 5    |
		#| 1		| 10       | 4    | 6    |
		#| 1		| 5        | 2    | 3    |
		#| 2		| 7        | 3    | 4    |
		#| 2		| 6        | 2    | 4    |
		#| 2		| 7        | 2    | 5    |
		#| 2		| 2        | 0    | 2    |
		#| 2		| 8        | 2    | 6    |
		#| 2		| 6        | 1    | 5    |
		#| 2		| 5        | 1    | 4    |

	Then Player 1 should be the starting player
