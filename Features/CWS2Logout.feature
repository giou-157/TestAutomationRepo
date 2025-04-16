Feature: Logout From hub, Dashboard and all mini apps
  As a user
  I want to log into the application to access dashboard

  @TesterTalk
  Scenario: Successful logout from hub
    Given the user is on the login page
    When the user enters valid credentials
    And the user clicks on the login button
    And the user logs out from the application
    Then the user is on the login page

  @TesterTalk
  Scenario Outline: Successful logout from Dashboard Options
    Given the user is on the login page
    When the user enters valid credentials
    And the user clicks on the login button
    And the user selects <Dashboard Options>
    And the user logs out from the application
    Then the user is on the login page

    Examples: 
      | Dashboard Options |
      | Patient Search    |
      | Settings          |
      | WardList          |
      | D2RA              |

  @TesterTalk
  Scenario Outline: Successful logout from Miniapps
    Given the user is on the login page
    When the user enters valid credentials
    And the user clicks on the login button
    And the user clicks on patient search
    And the user enters the <Key> and clicks on <MiniApp>
    And the user logs out from the application
    Then the user is on the login page

        Examples: 
      | Key    | MiniApp              |
      | 999306 | Blood Bank           |
      | 999306 | ATD                  |
      | 999306 | Patient Demographics |
      | 999306 | Documents            |
      | 999306 | Patient Registration |
