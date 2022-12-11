Feature: CreateBooking

Scenario: Creating the booking
	Given connect to client for creating booking
	When send request for create booking
	Then booking is created