# Automation Task 2 using Selenium WebDriver, NUnit, and Page Object Pattern

## Description
This repository contains a task automation script using Selenium WebDriver, NUnit, and the Page Object Model (POM) concept. The script automates the creation of a new paste on Pastebin (or a similar service) with specified attributes and verifies the correctness of the operation.

## Requirements
- .NET Framework or .NET Core
- NUnit framework
- Selenium WebDriver for .NET
- WebDriver-compatible browser (e.g., Chrome, Firefox, Edge)

## The script performs the following actions:

1. **Open Pastebin Website:**
   - Navigate to [Pastebin](https://pastebin.com/) or a similar service in any browser.

2. **Create a New Paste with the Following Attributes:**
   - **Code:**
     ```bash
     git config --global user.name "New Sheriff in Town"
     git reset $(git commit-tree HEAD^{tree} -m "Legacy code")
     git push origin master --force
     ```
   - **Syntax Highlighting:** Bash
   - **Paste Expiration:** 10 Minutes
   - **Paste Name / Title:** how to gain dominance among developers

3. **Save the Paste and Verify:**
   - Check that the browser page title matches the Paste Name / Title.
   - Verify that the syntax highlighting is set to Bash.
   - Ensure that the pasted code matches the provided code.