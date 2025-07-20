# SportsDataApp

## Overview
SportsDataApp is a modular, extensible API for retrieving data about various sports leagues. The architecture is designed to support multiple leagues, with the NBA as the first implementation. The API provides endpoints to retrieve upcoming games, games by date, and team statistics by name and year.

## Purpose
The goal of this repository is to provide a way to retrieve sports data in a simple way by aggregating data from various sources, performing backend calculations, and surfacing the data in clear and concise entities.

## Core Domain Concepts

### Aggregates
- **Team**: Represents a sports team. Aggregate root for team-related data.
- **Game**: Represents a sports game. Aggregate root for game-related data.

> _Note: Currently, Team and Game are data holders. Most business logic is implemented in the Application layer, as it is specific to the application's use cases._

### NBA-Specific Entities
- **Statistics**: Encapsulates NBA team statistics for a season. Fields include:
  - PointsFor, PointsAgainst, FastBreakPoints, PointsInPaint, BiggestLead, SecondChancePoints, PointsOffTurnovers, LongestRun, FGM, FGA, FGP, FTM, FTA, FTP, TPM, TPA, TPP, OffReb, DefReb, TotReb, Assists, PFouls, Steals, Turnovers, Blocks, PlusMinus, Min

## Architecture
- **Layered Structure**: Core (domain), Application (business logic), Infrastructure (data access), API (presentation)
- **SOLID Principles**: Interface-driven, dependency injection, separation of concerns
- **Domain-Driven Design**: Aggregates, entities, and DTOs are clearly separated
- **Extensibility**: Adding new leagues/controllers is straightforward

## Running the Application
- **Local Development**: `dotnet run` from the API project directory
- **Production Deployment**: Deployed as an Azure WebApp with CI/CD via Azure DevOps (see `azure-pipelines.yml`)

## API Endpoints (NBA)

### Get Upcoming Games
- **Endpoint:** `GET /api/nba/games`
- **Sample Request:**
  ```http
  GET https://<your-base-url>/api/nba/games
  ```
- **Sample Response:**
  ```json
  [
    {
      "seasonYear": "2023",
      "league": "NBA",
      "gameId": "12345",
      "startTimeUTC": "2023-12-01T00:00:00Z",
      "arena": "Chase Center",
      "city": "San Francisco",
      "country": "USA",
      "homeTeam": {
        "teamId": "GSW",
        "shortName": "GSW",
        "fullName": "Golden State Warriors",
        "nickName": "Warriors",
        "logo": "https://...",
        "record": "10-5",
        "ats": "8-7-0",
        "overUnder": "7-8-0",
        "gameSpread": "-5.5",
        "gameOverUnder": "220.5",
        "overOdds": 100,
        "underOdds": -110,
        "spreadOdds": -110,
        "score": { "points": "110" }
      },
      "visitingTeam": {
        "teamId": "LAL",
        "shortName": "LAL",
        "fullName": "Los Angeles Lakers",
        "nickName": "Lakers",
        "logo": "https://...",
        "record": "8-7",
        "ats": "7-8-0",
        "overUnder": "6-9-0",
        "gameSpread": "+5.5",
        "gameOverUnder": "220.5",
        "overOdds": 100,
        "underOdds": -110,
        "spreadOdds": -110,
        "score": { "points": "105" }
      }
    }
  ]
  ```

### Get Games by Date
- **Endpoint:** `GET /api/nba/games/{date}`
- **Sample Request:**
  ```http
  GET https://<your-base-url>/api/nba/games/2023-12-01
  ```
- **Sample Response:** _Same as above, filtered by date._

### Get Stats by Team Name and Year
- **Endpoint:** `POST /api/nba/stats`
- **Sample Request:**
  ```http
  POST https://<your-base-url>/api/nba/stats
  Content-Type: application/json

  {
    "seasonYear": "2023",
    "teamName": "Golden State Warriors"
  }
  ```
- **Sample Response:**
  ```json
  {
    "seasonYear": "2023",
    "shortName": "GSW",
    "fullName": "Golden State Warriors",
    "nickname": "Warriors",
    "logoUrl": "https://...",
    "gamesPlayed": 15,
    "stats": {
      "pointsFor": 1100,
      "pointsAgainst": 1050,
      "fastBreakPoints": 150,
      "pointsInPaint": 400,
      "biggestLead": 20,
      "secondChancePoints": 80,
      "pointsOffTurnovers": 90,
      "longestRun": 12,
      "fGM": 400,
      "fGA": 900,
      "fGP": 44.4,
      "fTM": 200,
      "fTA": 250,
      "fTP": 80.0,
      "tPM": 100,
      "tPA": 300,
      "tPP": 33.3,
      "offReb": 120,
      "defReb": 300,
      "totReb": 420,
      "assists": 350,
      "pFouls": 200,
      "steals": 80,
      "turnovers": 120,
      "blocks": 50,
      "plusMinus": 50,
      "min": "720"
    }
  }
  ```

## Extending the API
- To add a new league, implement new aggregates/entities in the Core layer, add services in the Application layer, repositories in Infrastructure, and controllers in the API layer.
- The architecture is designed for easy extension and maintenance.

## Security
- The API is currently public and does not require authentication.

## Future Plans
- Add support for additional leagues (e.g., NFL, MLB, NHL)
- Implement authentication and rate limiting
- Add automated tests
