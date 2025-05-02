Feature: ETR integration
  As a user with the relevant roles
  I can navigate to Electronic Test Request screen and access ETR.

  @TesterTalk
  Scenario Outline: User with rol_ETR_RequestTests role can access ETR screen
    Given an user with rol_ETR_RequestTests role can log in with valid credentials
    When the user navigates to ETR screen
    Then the user can access the screen successfully

  @TesterTalk
  Scenario Outline: User with NO rol_ETR_RequestTests role can NOT access ETR screen
    Given an user without rol_ETR_RequestTests role can log in with valid credentials
    When the user navigates to ETR screen
    Then the user is displayed Denied Access screen

  @TesterTalk
  Scenario Outline: User can navigate to ETR screen via Patient Search
    Given an user with relevant roles can log in with valid credentials 
    When the user clicks 'Patient Search' on the side bar
    And the user inputs a valid crn and clicks 'ETR'
    Then the user is redireted to the ETR screen

  @TesterTalk
  Scenario Outline: User can access ETR from Electronic Test Request screen
    Given the user is on the Electronic Test Request screen
    When user clicks 'Request Test' button
    Then 'Request Test' button is hidden, 'Back to CWS' button appears with ETR hidden div


  @TesterTalk
  Scenario Outline: User can exit ETR from Electronic Test Request screen
    Given the user is on the Electronic Test Request screen with active ETR
    When user clicks 'Back to CWS' button
    Then user is redirected to CWS pathology 
