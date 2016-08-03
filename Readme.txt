Notes:

1. Code was written in VS 2015 and tables were created in SQL server 2014

2. The project is using IIS Express.


Setup:

1. In order to make the project work properly, please run CreationScript.sql under Scripts\SQL in the project folder to create tables and testing data first.

2. Set the PeopleSearchMvc project as the startup project.

3. Start the project in chrome from Visural Studio directly


Requirements:

The People Search Application

Business Requirements

    The application accepts search input in a text box and then displays in a pleasing style a list of people where any part of their first or last name matches what was typed in the search box (displaying at least name, address, age, interests, and a picture). 
    Solution should either seed data or provide a way to enter new users or both
    Simulate search being slow and have the UI gracefully handle the delay 

Technical Requirements

    An ASP.NET MVC OR a WPF Application that uses the MVVM Design Pattern
    If you use ASP.NET MVC then use Ajax to respond to search request (no full page refresh) using JSON for both the request and the response
    Use Entity Framework Code First to talk to the database
    Unit Tests for appropriate parts of the application 
