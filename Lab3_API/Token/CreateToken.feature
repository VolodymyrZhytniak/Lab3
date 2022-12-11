Feature: CreateToken

Scenario: Creating token request
	Given token request
	When send token request
	Then response is success