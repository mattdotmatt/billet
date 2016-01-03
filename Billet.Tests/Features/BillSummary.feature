Feature: Bill Summary
	In order to quickly see the state of my bill
	As a sky customer
	I want to see a summary of bill

Scenario: My account exists
	Given I have an account '123'
	When I request my summary
	Then the summary should contain	
	| Field         | Value   |
	| total         | £136.03 |
	| packageTotal  | £71.40  |
	| skystoreTotal | £24.97  |
	| callsTotal    | £59.64  |

Scenario: My account doesnt exist
	Given I have an account 'BAD'
	When I request my summary
	Then I should see an error 'Darn, we can't find that account. Can you check and try again?'