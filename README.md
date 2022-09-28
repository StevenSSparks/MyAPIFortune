# MyApiFortune
A humor based project that provides API endpoints to return "fortunes" based on time, random number or ID. 

## Purpose
* This is a demo project used for testing Azure build and deployment actions with GitHub. 
* Feel free to use thie code for your own purpose  

## Development Details
* Developer: Steve Sparks

### Tools 
* Developed using Visual Studio 2022
* Based off of the .NET 6 WebAPI Template

### Code
* Simple WebAPI written in .NET 6
* JSON output when you call the API

## Custom Changes
* API pattern modified to support Welcome Page 
* Added basic CORS setup
* Turned on Developer features 

### Endpoints
* / returns a welcome page 
* /api/MyFortune returns JSON object with a single fortune based on the second of the call.
* /api/MyFortune/Random returns JSON object with a single fortune from 0 to # of fortunes in the project. 
* /api/MyFortune/# returns JSON object with a single fortune based on the ID provided

### API Documentation
* /swagger will provide the OpenAPI document
* /swagger will provide a UI to test the API

