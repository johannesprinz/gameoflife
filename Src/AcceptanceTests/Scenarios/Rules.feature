Feature: Rules
    In order to display the current state of the universe 
    As a Game of Life grid
    I want to obtain the next generation of cells

Scenario: Death by under-population
    Given a live cell has fewer than 2 live neighbours
    When I ask for the next generation of cells
    Then I should get back a new generation
    And it should have the same number of cells
    And the cell should be dead

Scenario: Survival by minimal-population
    Given a live cell with 2 live neighbours
    When I ask for the next generation of cells
    Then I should get back a new generation
    And it should have the same number of cells
    And the cell should be alive

Scenario: Survival by maximum-population
    Given a live cell with 3 live neighbours
    When I ask for the next generation of cells
    Then I should get back a new generation
    And it should have the same number of cells
    And the cell should be alive
	
Scenario: Death by over-population
    Given a live cell has more than 3 live neighbours
    When I ask for the next generation of cells
    Then I should get back a new generation
    And it should have the same number of cells
    And the cell should be dead

Scenario: Revived by reproduction
    Given a dead cell has exactly 3 live neighbours
    When I ask for the next generation of cells
    Then I should get back a new generation
    And it should have the same number of cells
    And the cell should be alive
