# Library Management System (C# Console Application)

## Overview
This is a simple C# console application for managing a small library collection. Users can add, remove, search, borrow, and return books. The system enforces a maximum library size and a borrowing limit per user.

## Features
- **Add Book:** Add a new book to the library (up to 5 books).
- **Remove Book:** Remove a book by title.
- **Search Book:** Search for a book by title and see if it is available or checked out.
- **Borrow Book:** Borrow a book if it is available (up to 3 books per user).
- **Return Book:** Return a borrowed book.
- **Checked Out Flag:** Books are flagged as checked out when borrowed and available when returned.

## Usage
1. Run the application.
2. Choose an action by entering the corresponding number:
   - 1: Add a book
   - 2: Remove a book
   - 3: Search for a book
   - 4: Borrow a book
   - 5: Return a book
   - 6: Exit
3. Follow the prompts to manage the library.

## Requirements
- .NET 6.0 or later

## How to Run
1. Open a terminal in the `Module5Section1` directory.
2. Run the following command:
   ```
   dotnet run
   ```

## File Structure
- `Program.cs`: Main application logic and all features.
- `Module5Section1.csproj`: Project file.

## Notes
- The library can hold up to 5 books at a time.
- Each user can borrow up to 3 books at a time.
- Book titles are case-insensitive for all operations.
