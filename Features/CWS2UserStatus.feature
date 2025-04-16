Feature: Activity Status
  As a user
  I want to be able to access the application only if I have Active status

  @TesterTalk
  Scenario Outline: Active user can access application
    Given the user is <active>
    When user enters valid credentials <username> and <password>
    And the user clicks login button
    Then the user is in <PageName>

    Examples: 
      | username                             | password        | active    | PageName  |
      | ABB.SoftwareTestAccount@wales.nhs.uk | moleunicorn3    | true     | Home Page |

  @TesterTalk
  Scenario Outline: Inactive user cannot access application
    Given the user is <active> 
    When user enters valid credentials <username> and <password>
    And the user clicks login button
    Then the error message should be <ErrorMessage>

    Examples: 
      | username                             | password        | active    | ErrorMessage                                          |
      | ABB.SoftwareTestAccount@wales.nhs.uk | moleunicorn3    | false     | Unsuccessful login attempt, this account is inactive. |