Feature: Ordering Tiles
	In order to avoid unordered  tiles
	As a bad person
	I want to be able to mix the stock of two tiles

Scenario: Mix stock of tiles
	Given I have a collection
	| Head | Tail |
	| 0    | 0    |
	| 0    | 1    |
	| 0    | 2    |
	| 0    | 3    |
	| 0    | 4    |
	| 0    | 5    |
	| 0    | 6    |
	| 1    | 1    |
	| 1    | 2    |
	| 1    | 3    |
	| 1    | 4    |
	| 1    | 5    |
	| 1    | 6    |
	When The game start
	Then It should not match
	| Head | Tail |
	| 0    | 0    |
	| 0    | 1    |
	| 0    | 2    |
	| 0    | 3    |
	| 0    | 4    |
	| 0    | 5    |
	| 0    | 6    |
	| 1    | 1    |
	| 1    | 2    |
	| 1    | 3    |
	| 1    | 4    |
	| 1    | 5    |
	| 1    | 6    |

