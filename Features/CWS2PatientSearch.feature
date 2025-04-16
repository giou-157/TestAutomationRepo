Feature: Search Patient Based on CRN,Name and DOB
  As a user
  I want to search a patient Based on CRN/NHS Number,Name and Date of Birth
  Background:
    Given the user is on the login page
    When the user enters valid credentials
    And the user clicks on the login button
    And the user clicks on patient search

  @TesterTalk
  Scenario Outline: Search by CRN/NHS number
    When the user enters the <Key> and clicks on <MiniApp>
    Then the Associated <Key> can now viewed in <MiniApp> Homepage along with first report

    Examples: 
      | Key    | MiniApp              |
      | 999326 | Blood Bank           |
      | 999326 | ATD                  |
      | 999326 | Patient Demographics |
      | 999326 | Documents            |
      | 999326 | Patient Registration |
     

  @TesterTalk
  Scenario Outline: Search by Name 
    And the user click in Name 
    And the user enters <Forename> followed by <Surname> and selects <Gender> radio button
    And the user clicks on <MiniApp> App
    Then the Associated <Forename> and <Surname> is visible in <MiniApp> Homepage

        Examples: 
      | Forename    | Surname       | Gender | MiniApp    |
      | SOFTWARE 26 | TEST CAREFLOW | Male   | Blood Bank |
      | SOFTWARE 26 | TEST CAREFLOW | Male   | ATD |
      | SOFTWARE 26 | TEST CAREFLOW | Male   | Patient Demographics |
      | SOFTWARE 26 | TEST CAREFLOW | Male   | Documents |
      | SOFTWARE 26 | TEST CAREFLOW | Male   | Patient Registration |

  @TesterTalk
  Scenario Outline: Search by DOB
    And the user click in DOB 
    And the user enters <DOB> and selects <Gender> radio button
    And the user clicks on <MiniApp> App
    Then the Associated <Forename> and <Surname> is visible in <MiniApp> Homepage

    Examples: 
      | DOB             | Gender     | MiniApp |
      | 26/04/1966      | Male       | Blood Bank |
      | 26/04/1966      | Male       |  ATD |
      | 26/04/1966      | Male       | Patient Demographics |
      | 26/04/1966      | Male       | Documents |
      | 26/04/1966      | Male       | patient Registration |
