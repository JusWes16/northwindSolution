Feature: Increment the counter by custom number
    This feature lets a user increment (by a custom number) the counter by clicking on the button.

Scenario: Basic increment n scenario
    Given I am on the counter-n page
    When I click on the increment button 10 times
    Then The counter should show "70"
