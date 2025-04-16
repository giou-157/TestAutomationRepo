Feature: Login to Dashboard
  As a user
  I want to log into the application to access dashboard

  @TesterTalk
  Scenario: Successful login to the dashboard
    Given the user is on the login page
    When the user enters valid credentials
    And the user clicks on the login button
    Then the user should be redirected to the dashboard

  @TesterTalk
  Scenario Outline: Invalid login to the dashboard
    Given the user is on the login page
    When I enter <username> and <password>
    And the user clicks on the login button
    Then the error message should be <ErrorMessage>

    Examples: 
      | username                             | password        | ErrorMessage                |
      | ABB.SoftwareTestAccount@wales.nhs.uk | invalidpassword | Unsuccessful login attempt. |
      | invalid@username                     | moleunicorn3    | Unsuccessful login attempt. |
      |                                      |                 | Unsuccessful login attempt. |