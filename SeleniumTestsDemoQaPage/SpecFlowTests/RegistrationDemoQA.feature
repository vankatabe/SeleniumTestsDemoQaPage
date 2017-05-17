Feature: RegistrationDemoQA
	In order to avoid silly mistakes
	As a web idiot
	I want to be told when I don't fill-in the form correctly
	So I can fill it in correctly

	or

	As a User
	I want to be able to fill-in the registration form
	So I can get a registered account

@mytag1
Scenario: RegistrationWithoutFirstName
	Given I am on the Registration page
	When I fill-in the registration form without first name is "FirstNameField_Empty_ErrorMessage"
	Then Error message for names should be displayed is "* This field is required"

@mytag2
Scenario: RegistrationWithoutLastName
	Given I am on the Registration page
	When I fill-in the registration form without first name is "LastNameField_Empty_ErrorMessage"
	Then Error message for names should be displayed is "* This field is required"
