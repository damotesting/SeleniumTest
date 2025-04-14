# 🧪 Selenium DuckDuckGo Search Test (NUnit + ChromeDriver)

This project automates a basic search on [DuckDuckGo](https://duckduckgo.com) using **Selenium WebDriver** and **NUnit** in C#.

---

## 🧾 Gherkin Scenario

```gherkin
Feature: DuckDuckGo Search

  Scenario: User searches for 'Selenium'
    Given the user opens DuckDuckGo homepage
    When the user types "Selenium" into the search bar
    And presses Enter
    Then the results page should load
    And the page title should contain "selenium"
