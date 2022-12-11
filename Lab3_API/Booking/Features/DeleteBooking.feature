Feature: DeleteBooking

@tag1
Scenario: Deleting the booking
	Given token and id for delete the booking
	When send request for delete the booking
	Then booking is deleted