Feature: Persona(s) To Role(s) Conversions
  As a user
  I can only access functionalities associeted to my role(s).

  @TesterTalk
  Scenario Outline: User cannot access functionalities not associated to it
    Given the user has no role or personas associated to it
    When user enters the valid credentials <username> and <password>
    And the user clicks the login button
    Then the user is displayed <DeniedAccessMessage> for any functionality

    Examples: 
      | username                             | password        | DeniedAccessMessage                               |
      | ABB.SoftwareTestAccount@wales.nhs.uk | moleunicorn3    | You do not have the required access for this page |


  @TesterTalk
  Scenario Outline: User can access functionalities associated to its role(s) and persona(s)
    Given the user has at least one role or persona associated to it
    When user enters the valid credentials <username> and <password>
    And the user clicks the login button
    Then the user can access the relevant functionalities and pages <PageNames>

    Examples: 
      | username                             | password        | PageNames  |
      | ABB.SoftwareTestAccount@wales.nhs.uk | moleunicorn3    | ["Home Page", "Find a Patient", "Ward List"] |
      
