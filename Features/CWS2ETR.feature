Feature: ETR integration
  As a user with the relevant roles
  I can navigate to Electronic Test Request screen and access ETR.

  @TesterTalk
  Scenario Outline: User can access ETR from Electronic Test Request screen
    Given the user is on the Electronic Test Request screen
    When user clicks 'Request Test' button
    Then 'Request Test' button is hidden, 'Exit WCP' button appears with ETR hidden div


  @TesterTalk
  Scenario Outline: User can exit ETR from Electronic Test Request screen
    Given the user is on the Electronic Test Request screen with active ETR
    When user clicks 'Exit WCP' button
    Then 'Request Test' button appears, 'Exit WCP' button and ETR div is hidden 
