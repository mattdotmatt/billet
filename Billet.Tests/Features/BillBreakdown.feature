Feature: Bill Breakdown
	In order to see the full state of my bill
	As a sky customer
	I want to see a breakdown of the components of my bill

Scenario: Package breakdown
	Given I have an account '123'
	When I request my package breakdown
	Then the package breakdown should contain	
	| Name                   | Cost   | Type      |
	| Variety with Movies HD | £50.00 | TV        |
	| Sky Talk Anytime       | £5.00  | Talk      |
	| Fibre Unlimited        | £16.40 | Broadband |

	
Scenario: Store breakdown
	Given I have an account '123'
	When I request my store breakdown
	Then the store breakdown should contain	
	| Title                | Cost  |
	| That's what she said | £9.99 |
	| Broke back mountain  | £9.99 |
	| 50 Shades of Grey    | £4.99 |

Scenario: Calls breakdown
	Given I have an account '123'
	When I request my calls breakdown
	Then the calls breakdown should contain	
	| Called      | Cost  | Duration |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 07716393769 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |
	| 02074351359 | £2.13 | 00:23:03 |