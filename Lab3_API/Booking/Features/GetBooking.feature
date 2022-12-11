Feature: GetBooking

Scenario: Getting the booking
	Given id of booking
	When creating get booking with id and send request
	Then booking has found