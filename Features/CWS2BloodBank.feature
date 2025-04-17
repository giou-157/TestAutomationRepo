Feature: Search Patient Based on CRN,Name and DOB in bloodbank
  As a user
  I want to search a patient Based on CRN/NHS Number,Name and Date of Birth
  Background:
    Given the user is on the Authorisation Server login page
    When the user enters some valid credentials
    And the user proceeds to click login button
    And the user clicks on patient search button

  @TesterTalk
  Scenario Outline: Search by CRN/NHS number
    When the user enters the <Key> and clicks on <MiniApp>
    Then the Associated <Key> can now viewed in <MiniApp> Homepage along with first report

    Examples: 
      | Key          | MiniApp    |
      | 999305       | Blood Bank |
      | 938 291 0301 | Blood Bank |


  @TesterTalk
  Scenario Outline: Search by Name 
    When the user click in Name and then enters <Forename> and <Surname>
    And the user choose <Gender> radio button and clicks on <MiniApp>
    Then the Associated <Forename> and <Surname> is visible in <MiniApp> Homepage

        Examples: 
      | Forename    | Surname       | Gender | MiniApp    |
      | SOFTWARE 5 | TEST CWS | Male   | Blood Bank |


  @TesterTalk
  Scenario Outline: Search by DOB 
    When the user click in DOB and enters <Forename> and <Surname>
    And the user clicks on <MiniApp>
    Then the Associated patients are visible in <MiniApp> Homepage

        Examples: 
      | Forename    | Surname       | Gender | MiniApp    |
      | SOFTWARE 5 | TEST CWS | Male   | Blood Bank |
